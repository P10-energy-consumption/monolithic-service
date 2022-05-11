using monolithic_service.Database.Interfaces;
using Npgsql;

namespace monolithic_service.Database
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;
        private readonly Lazy<string> _connectionString;

        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = new Lazy<string>(() => _configuration.GetValue<string>("postgres"));
        }

        public NpgsqlConnection CreateDBConnection()
        {
            return new NpgsqlConnection(_connectionString.Value);
        }
    }
}
