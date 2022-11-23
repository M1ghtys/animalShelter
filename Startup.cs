using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using iis.Data;
using iis.Controllers;
using System.IO;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;


namespace iis
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private bool NewDBCreated = false;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddIdentity<iis.Models.User, IdentityRole>()
                .AddEntityFrameworkStores<Data.DbContext>()
                .AddDefaultTokenProviders();
 
            services.AddTransient<DbInitializer>();

            var configurationOptions = new ConfigurationOptions();
            Configuration.GetSection(ConfigurationOptions.Configuration).Bind(configurationOptions);
            if (configurationOptions.Database.DatabaseProvider == DatabaseProvider.PostgreSQL)
            {
                services.AddTransient<Data.DbContext, PostgreSqlDbContext>(_ => new PostgreSqlDbContext(configurationOptions.Database.PostgresConnectionString));
            }
            else
            {
                services.AddTransient<Data.DbContext, SqliteIISDbContext>(_ =>
                {
                    var pathRootDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "iis-server");
                    if (!Directory.Exists(pathRootDirectory))
                    {
                        Directory.CreateDirectory(pathRootDirectory);
                    }

                    var dbName = "iis.db";
                    var dbPath = Path.Combine(pathRootDirectory, dbName);
                    
                    if (!File.Exists(dbPath)) NewDBCreated = true;
                    
                    return new SqliteIISDbContext($"Data Source={dbPath}");
                });
            }

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

                // User settings
                options.User.RequireUniqueEmail = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.Name = "UserIdentification";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Error";
                options.SlidingExpiration = true;
            });

            services.AddHttpClient();

            services.AddRazorPages()
                .AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DbInitializer dbInitializer)
        {
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto,
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });

            var configurationOptions = new ConfigurationOptions();
            Configuration.GetSection(ConfigurationOptions.Configuration).Bind(configurationOptions);
            
            dbInitializer.Migrate();

            if (NewDBCreated)
            {
                dbInitializer.SeedRoles();
                //TODO change password to secret
                dbInitializer.SeedAdminUser("password");
                dbInitializer.SeedAnimals();
                dbInitializer.SeedEmployees();
                dbInitializer.SeedHealthConditions();
                dbInitializer.SeedOccupations();
                dbInitializer.SeedPhotos();
                dbInitializer.SeedVeterinaryRecords();
                dbInitializer.SeedVolunteers();
                dbInitializer.SeedWalks();
            }
            
        }
    }
}
