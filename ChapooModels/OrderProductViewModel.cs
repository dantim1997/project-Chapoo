using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapooModels
{
    public class OrderProductViewModel
    {
        public int OrderProductId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int Supply { get; set; }
        public bool Status { get; set; }
    }
}
