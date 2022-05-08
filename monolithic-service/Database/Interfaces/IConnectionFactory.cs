using Npgsql;
using System.Data;
using System.Data.SqlClient;

namespace monolithic_service.Database.Interfaces
{
    public interface IConnectionFactory
    {
        Task<NpgsqlConnection> CreateDBConnection();
    }
}
