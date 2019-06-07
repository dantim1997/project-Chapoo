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
    public class DAO_Employee : Base
    {
        private SqlConnection dbConnection;

        public DAO_Employee()
        {
            string connstring = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            dbConnection = new SqlConnection(connstring);
        }

        public List<Employee> GetWorker()
        {
            string query = "SELECT EmployeeId, Name, Surname, TypeWorker FROM Employee";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadAllTables(ExecuteSelectQuery(query, sqlParameters));
        }

        public Employee GetWorkerLogin(string username, string password)
        {
            string query = "SELECT EmployeeId, Name, Surname, TypeWorker, Username, Password FROM Employee WHERE Username = @username AND Password = @password";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("Username", username),
                new SqlParameter("Password", password)
            };
            return ReadTable(ExecuteSelectQuery(query, sqlParameters));
        }

        public Employee GetWorkerById(int EmployeeId)
        {
            string query = "SELECT EmployeeId, Name, Surname, TypeWorker, Username, Password FROM Employee where EmployeeId = @EmployeeId";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("EmployeeId", EmployeeId)
            };
            return ReadTable(ExecuteSelectQuery(query, sqlParameters));
        }

        private Employee ReadTable(DataTable dataTable)
        {
            Employee login = new Employee();
            try
            {
                foreach (DataRow dr in dataTable.Rows)
                {
                    login.EmployeeId = (int)dr["EmployeeId"];
                    login.Name = (string)dr["Name"];
                    login.Surname = (string)dr["Surname"];
                    login.TypeWorker = (string)dr["TypeWorker"];
                    login.Username = (string)dr["Username"];
                    login.Password = (string)dr["Password"];
                };
                return login;
            }
            catch (Exception)
            {
                return login;
            }

        }
        private List<Employee> ReadAllTables(DataTable dataTable)
        {
            List<Employee> Employees = new List<Employee>();
            foreach (DataRow dr in dataTable.Rows)
            {
                Employee employee = new Employee();
                employee.EmployeeId = (int)dr["EmployeeId"];
                employee.Name = (string)dr["Name"];
                employee.Surname = (string)dr["Surname"];
                employee.TypeWorker = (string)dr["TypeWorker"];
                Employees.Add(employee);
            };
            return Employees;
        }
    }
}
