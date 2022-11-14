namespace iis
{
    public class ConfigurationOptions
    {
        public const string Configuration = "Configuration";
        public string ServerUrl { get; set; }
        public string DefaultAdminPassword { get; set; }
        public DatabaseConfiguration Database { get; set; } = new DatabaseConfiguration();
    }

    public class DatabaseConfiguration
    {
        public DatabaseProvider DatabaseProvider { get; set; } = DatabaseProvider.SQLite;
        public string PostgresConnectionString { get; set; }
    }

    public enum DatabaseProvider
    {
        SQLite,
        PostgreSQL,
    }
}
