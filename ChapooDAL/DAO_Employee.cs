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
        /// <summary>
        /// This method returns a list of all Employees.
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetWorker()
        {
            string query = "SELECT EmployeeId, Name, Surname, TypeWorker FROM Employee";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadAllTables(ExecuteSelectQuery(query, sqlParameters));
        }

        /// <summary>
        /// Haald een employee uit de database waar username en password hetzelfde zijn als die megegeven. 
        /// This method returns an employee where employee.username and employee.password are equal to the given parameters username and password.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Employee GetWorkerLogin(string username, string password)
        {
            string query = "SELECT EmployeeId, Name, Surname, TypeWorker FROM Employee WHERE Username = @username AND Password = @password";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("Username", username),
                new SqlParameter("Password", password)
            };
            return ReadTable(ExecuteSelectQuery(query, sqlParameters));
        }

        /// <summary>
        /// This method returns an employee where employee.employeeId is equal to the given parameter EmployeeId.
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <returns></returns>
        public Employee GetWorkerById(int EmployeeId)
        {
            string query = "SELECT EmployeeId, Name, Surname, TypeWorker FROM Employee where EmployeeId = @EmployeeId";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("EmployeeId", EmployeeId)
            };
            return ReadTable(ExecuteSelectQuery(query, sqlParameters));
        }
        /// <summary>
        /// This method fills an Employee object and returns it.
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
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
                };
                return login;
            }
            catch (Exception)
            {
                return login;
            }

        }
        /// <summary>
        /// This method fills Employee objects and adds it to a list. Then it returns the list. 
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
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
