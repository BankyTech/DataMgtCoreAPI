using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DataManagement.Repository
{
    public class BaseRepository: IDisposable
    {
       protected IDbConnection con;
        public BaseRepository()
        {
            // TODO: This should be injected via dependency injection from configuration
            // Connection string should match the one in appsettings.json
            string connectionString = "Data Source=BANKEPC;Initial Catalog=DataManagement;Integrated Security=True";
            con = new SqlConnection(connectionString);
        }

        public void Dispose()
        {
            con?.Dispose();
        }
    }
}
