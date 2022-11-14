using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace iis.Data
{
    public class SqliteIISDbContext : iisContext
    {
        private readonly string _connectionString = "connectionString";
        private readonly SqliteConnection _inMemory = null;

        public SqliteIISDbContext()
        {
            _inMemory = new SqliteConnection("Data Source=:memory:");
        }

        public SqliteIISDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqliteIISDbContext(SqliteConnection inMemory)
        {
            _inMemory = inMemory;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (_inMemory != null)
            {
                options.UseSqlite(_inMemory);
            }
            else
            {
                options.UseSqlite(_connectionString);
            }
        }
    }
}
