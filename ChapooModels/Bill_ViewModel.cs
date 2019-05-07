using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_Chapoo.Models
{
    public class Bill_ViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Amount { get; set; }
        public bool Done { get; set; }
    }
}
