using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChapooDAL;
using ChapooModels;

namespace ChapooLogic
{
    public class Employee_Service
    {
        DAO_Employee dAO_Employee = new DAO_Employee();

        /// <summary>
        /// This method communicates with the DAO_Employee and asks for a employee where employee.username and employee.password are equal to the given parameters username and password.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Employee GetWorkerLogin(string username, string password)
        {
            return dAO_Employee.GetWorkerLogin(username, password);
        }
        /// <summary>
        /// This method communicates with the DAO_Employee and asks for a list of all employees.
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetAllEmployees()
        {
            return dAO_Employee.GetWorker();
        }
        /// <summary>
        /// This method communicates with the DAO_Employee and asks for a employee where employee.employeeId is equal to the given parameter Id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Employee GetEmployeeById(int Id)
        {
            return dAO_Employee.GetWorkerById(Id);
        }
    }
}
