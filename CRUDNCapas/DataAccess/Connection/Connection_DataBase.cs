using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Connection
{
    public class Connection_DataBase
    {
        private SqlConnection c = new SqlConnection("Data Source=10.10.72.161\\SQL2016_1;Initial Catalog=CRUD_N_CAPAS;Integrated Security=True");
        public SqlConnection OpenConnection()
        {
            if (c.State == ConnectionState.Closed) c.Open();
            return c;
        }
        public SqlConnection ClosedConnection()
        {
            if (c.State == ConnectionState.Open) c.Close();
            return c;
        }
    }
}