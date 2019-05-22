using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapooModels
{
    public class OrderProduct
    {
        public int OrderProductId { get; set; }
        public int OrderId { get; set; }
        public Statustype Status { get; set; } 
        public int Amount { get; set; }

        public Product Product { get; set; }


    }
    public enum Statustype { Bereid, Open};
}
