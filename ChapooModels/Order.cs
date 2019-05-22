using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapooModels
{
    public class Order
    {
        public int OrderId { get; set; }
        public int EmployeeId { get; set; }
        public int TableNumber { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }

        public List<OrderProduct> OrderProduct { get; set; }
    }
}
