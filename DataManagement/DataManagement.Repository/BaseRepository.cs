using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;


namespace DataManagement.Repository
{
   public class BaseRepository: IDisposable
    {
       protected IDbConnection con;
        public BaseRepository()
        {
            string connectionString = "Data Source=BANKEPC;Initial Catalog=DataManagement;Integrated Security=True";
            con = new SqlConnection(connectionString);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
