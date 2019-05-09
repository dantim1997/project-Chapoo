using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapooModels
{
    public class OrderProduct
    {
        public int OrderId { get; set; }
        public string Status { get; set; }
        public int ProductId { get; set; }

        public string Name { get; set; }
        public int Amount { get; set; }
    }
}
