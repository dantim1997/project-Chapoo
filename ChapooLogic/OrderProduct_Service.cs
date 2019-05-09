using System;
using ChapooModels;
using ChapooDAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapooLogic
{
    public class OrderProduct_Service
    {
        DAO_OrderProduct DAO_OrderProduct = new DAO_OrderProduct();
        public List<OrderProduct> GetAllByOrder(int OrderId)
        {
            return DAO_OrderProduct.GetAllByOrder(OrderId);
        }
    }
}
