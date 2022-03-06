using monolithic_service.Database.Interfaces;
using System.Data.SqlClient;

namespace monolithic_service.Database
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;
        private readonly Lazy<string> _connectionString;

        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = new Lazy<string>(() => _configuration.GetValue<string>("mssql"));
        }

        public SqlConnection CreateDBConnection()
        {
            return new SqlConnection(_connectionString.Value);
        }
    }
}
