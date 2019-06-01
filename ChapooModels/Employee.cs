using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapooModels
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TypeWorker { get; set; }
        public string Username{ get; set; }
        public string Password { get; set; }

        public string Fullname { get { return Name + " " + Surname; } }
    }
}
