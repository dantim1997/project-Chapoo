using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChapooModels;
using ChapooDAL;

namespace ChapooLogic
{
    public class Order_Service
    {
        DAO_Order DAO_Order = new DAO_Order();

        public List<Order> GetOrders()
        {
            return DAO_Order.GetAllOrders();
        }
    }
}
