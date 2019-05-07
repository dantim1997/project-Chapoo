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
    public class DAO_WorkerLogin: Base
    {
        private SqlConnection dbConnection;

        public DAO_WorkerLogin()
        {
            string connstring = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            dbConnection = new SqlConnection(connstring);
        }
        public WorkerLogin GetLoginByUsername(string User_Name)
        {
            string query = "SELECT Username, Password, WorkerId FROM WorkerLogin where Username like '" + User_Name + "'";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTable(ExecuteSelectQuery(query, sqlParameters));
        }

        private WorkerLogin ReadTable(DataTable dataTable)
        {
            WorkerLogin login = new WorkerLogin();
            //each row from the database is converted into the login class
            foreach (DataRow dr in dataTable.Rows)
            {
                login.Username = (string)dr["Username"];
                login.Password = (string)dr["Password"];
                login.WorkerId = (int)dr["WorkerId"];
            };
            return login;
        }
    }
}
