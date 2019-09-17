using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace TrainingEcoleDotNet.DAL
{
    class BaseDAL
    {
        public SqlConnection Connection { get; set; }
        public SqlCommand Sql { get; set; }
        public BaseDAL(string query)
        {
            Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TrainingEcole"].ConnectionString);
            Connection.Open();
            Sql = Connection.CreateCommand();
            Sql.CommandText = query;
            Sql.CommandType = System.Data.CommandType.Text;
        }
        ~BaseDAL()
        {
            Connection.Close();
        }
    }
}

