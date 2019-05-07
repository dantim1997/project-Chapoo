using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_Chapoo.Models
{
    public class Served
    {
        public int BillId { get; set; }
        public int WorkerId { get; set; }
        public int TableNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Bill> Products { get; set; }
        public bool Done { get; set; }
    }
}
