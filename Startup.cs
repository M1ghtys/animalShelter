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
using System.IO;

namespace iis
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            services.AddTransient<DbInitializer>();

            var configurationOptions = new ConfigurationOptions();
            Configuration.GetSection(ConfigurationOptions.Configuration).Bind(configurationOptions);
            if (configurationOptions.Database.DatabaseProvider == DatabaseProvider.PostgreSQL)
            {
                services.AddTransient<iisContext, PostgreSqlDbContext>(_ => new PostgreSqlDbContext(configurationOptions.Database.PostgresConnectionString));
            }
            else
            {
                services.AddTransient<iisContext, SqliteIISDbContext>(_ =>
                {
                    var pathRootDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "iis-server");
                    if (!Directory.Exists(pathRootDirectory))
                    {
                        Directory.CreateDirectory(pathRootDirectory);
                    }

                    var dbPath = Path.Combine(pathRootDirectory, "iis.db");
                    return new SqliteIISDbContext($"Data Source={dbPath}");
                });
            }

            /*services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.Name = "UserIdentification";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Error";
                options.SlidingExpiration = true;
            });

            services.AddHttpClient();*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DbInitializer dbInitializer)
        {
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });

            dbInitializer.Migrate();
            dbInitializer.SeedAnimals();
            dbInitializer.SeedVolunteers();
            dbInitializer.SeedWalks();
        }
    }
}
