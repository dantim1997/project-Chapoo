using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapooModels
{
    class OrderViewModel
    {
        public int OrderId { get; set; }
        public int EmployeeId { get; set; }
        public int TableNumber { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
    }
}
