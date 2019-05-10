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
    public class DAO_Employee: Base
    {
        private SqlConnection dbConnection;

        public DAO_Employee()
        {
            string connstring = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            dbConnection = new SqlConnection(connstring);
        }

        public Employee GetWorker()
        {
            string query = "SELECT EmployeeId, Name, Surname, TypeWorker FROM Employee";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTable(ExecuteSelectQuery(query, sqlParameters));
        }

        public Employee GetWorkerLogin(string username)
        {
            string query = "SELECT EmployeeId, Name, Surname, TypeWorker, Username, Password FROM Employee WHERE Username =" + username;
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTable(ExecuteSelectQuery(query, sqlParameters));
        }

        public Employee GetWorkerById(int EmployeeId)
        {
            string query = "SELECT EmployeeId, Name, Surname, TypeWorker FROM Worker where EmployeeId =" + EmployeeId;
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTable(ExecuteSelectQuery(query, sqlParameters));
        }

        private Employee ReadTable(DataTable dataTable)
        {
            Employee login = new Employee();
            //each row from the database is converted into the login class
            foreach (DataRow dr in dataTable.Rows)
            {
                login.EmployeeId = (int)dr["WorkerId"];
                login.Name = (string)dr["Name"];
                login.Surname = (string)dr["Surname"];
                login.TypeWorker = (string)dr["TypeWorker"];
                login.Username = (string)dr["Username"];
                login.Password = (string)dr["Password"];
            };
            return login;
        }
    }
}
