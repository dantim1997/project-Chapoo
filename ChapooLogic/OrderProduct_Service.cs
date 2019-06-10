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

        /// <summary>
        /// get all orderporducts by orderid
        /// </summary>
        /// <param name="OrderId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        
        public List<OrderProduct> GetAllByOrder(int OrderId, string type)
        {
            return DAO_OrderProduct.GetAllByOrder(OrderId, type);
        }

        /// <summary>
        /// update all status for all orderproduct in the list
        /// </summary>
        /// <param name="orderProduct"></param>
        /// <param name="status"></param>
        
        public void UpdateAllStatus(List<OrderProduct> orderProduct, Statustype status)
        {
            DAO_OrderProduct.UpdateAllOrderProduct(orderProduct, status);
        }
        
        /// <summary>
        /// create orderproducts
        /// </summary>
        /// <param name="orderProducts"></param>
        
        public void CreateOrderProduct(List<OrderProduct> orderProducts)
        {
            DAO_OrderProduct.CreateOrderPruduct(orderProducts);
        }

        /// <summary>
        /// get active orderproducts
        /// </summary>
        /// <returns></returns>
        
        public List<OrderProduct> GetActiveOrderProductList()
        {
            return DAO_OrderProduct.GetAllByActiveOrder();
        }

        /// <summary>
        /// update orderproducts by tablenumber
        /// </summary>
        /// <param name="TableNumber"></param>
        /// <param name="Status"></param>
        /// <param name="type"></param>
       
        public void UpdateOrderProductStatus(int TableNumber, Statustype Status, string type)
        {
            DAO_OrderProduct.UpdateOrderProductStatusByTablenumber(TableNumber, Status, type);
        }
        /// <summary>
        /// update orderproducts by orderID
        /// </summary>
        /// <param name="OrderId"></param>
        /// <param name="Status"></param>
        public void UpdateOrderProductStatusByOrderId(int OrderId, Statustype Status)
        {
            DAO_OrderProduct.UpdateOrderProductStatusByOrderId(OrderId, Status);
        }
    }
}
