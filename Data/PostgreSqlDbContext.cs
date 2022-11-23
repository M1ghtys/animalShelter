using Microsoft.EntityFrameworkCore;

namespace iis.Data
{
    public class PostgreSqlDbContext : DbContext
    {
        private readonly string _connectionString = "iisContext";

        public PostgreSqlDbContext()
        {
        }

        public PostgreSqlDbContext(string connectionString)
        {
                _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(_connectionString);
        }
    }
}
