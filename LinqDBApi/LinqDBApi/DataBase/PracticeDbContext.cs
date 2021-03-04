using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinqDBApi.DataBase
{
    public class PracticeDbContext
    {
        public MySqlConnection Connection { get; }

        public PracticeDbContext(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
        }
        public void Dispose() => Connection.Dispose();
    }
}
