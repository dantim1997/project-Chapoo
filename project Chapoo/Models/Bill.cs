using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_Chapoo.Models
{
    public class Bill
    {
        public int OrderId { get; set; }
        public int BillId { get; set; }
        public int ProductId { get; set; }
        public DateTime Date { get; set; }
        
        public Product product;
    }
}
