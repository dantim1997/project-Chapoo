using System;
using ChapooModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapooLogic
{
    public class Login_Service
    {
        public bool CheckLogin(string user, string pass)
        {
            bool loginCorrect = false;
            Employee employee = new Employee();
            Employee_Service employeeService = new Employee_Service();
            employee = employeeService.GetWorkerLogin(user);

            if (employee.Password == pass)
            {
                loginCorrect = true;
            }

            return loginCorrect;
        }
    }
}
