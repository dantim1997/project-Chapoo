using ChapooModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapooDAL
{
    public class DAO_Worker: Base
    {
        private SqlConnection dbConnection;

        public DAO_Worker()
        {
            string connstring = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            dbConnection = new SqlConnection(connstring);
        }

        public Worker GetWorker()
        {
            string query = "SELECT WorkerId, Name, Surname, TypeWorker FROM Worker";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTable(ExecuteSelectQuery(query, sqlParameters));
        }

        public Worker GetWorkerById(int WorkerId)
        {
            string query = "SELECT WorkerId, Name, Surname, TypeWorker FROM Worker where WorkerId ="+WorkerId;
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTable(ExecuteSelectQuery(query, sqlParameters));
        }

        private Worker ReadTable(DataTable dataTable)
        {
            Worker login = new Worker();
            //each row from the database is converted into the login class
            foreach (DataRow dr in dataTable.Rows)
            {
                login.WorkerId = (int)dr["WorkerId"];
                login.Name = (string)dr["Name"];
                login.Surname = (string)dr["Surname"];
                login.TypeWorker = (string)dr["TypeWorker"];
            };
            return login;
        }
    }
}
