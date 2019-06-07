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
