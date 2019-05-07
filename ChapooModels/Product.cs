using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapooModels
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public string ProductType { get; set; }
        public int BTW { get; set; }

        public bool Done { get; set; }
        public int Amount { get; set; }
    }
}
