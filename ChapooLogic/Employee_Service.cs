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
        /// Deze methode communiceerd met de DAO_Employee en haald een employee op met het megegeven username en password.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Employee GetWorkerLogin(string username, string password)
        {
            return dAO_Employee.GetWorkerLogin(username, password);
        }

        public List<Employee> GetAllEmployees()
        {
            return dAO_Employee.GetWorker();
        }

        public Employee GetEmployeeById(int Id)
        {
            return dAO_Employee.GetWorkerById(Id);
        }
    }
}
