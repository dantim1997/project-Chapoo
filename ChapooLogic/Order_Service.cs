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
        DAO_OrderProduct DAO_OrderProduct = new DAO_OrderProduct();

        /// <summary>
        /// set order to DAO_Order
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="status"></param>
        /// <param name="tableNumber"></param>
        public void CreateOrder(int employeeId, string status, int tableNumber)
        {
            DAO_Order.CreateNewOrder(employeeId, status, tableNumber);
        }

        /// <summary>
        /// gets all orders by type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<Order> GetOrders(string type)
        {
            return DAO_Order.GetAllOrders(type);
        }

        /// <summary>
        /// get all active orders
        /// </summary>
        /// <returns></returns>
        public List<Order> GetActiveOrderList()
        {
            return DAO_Order.GetActiveOrderList();
        }

        /// <summary>
        /// update only the status by orderId
        /// </summary>
        /// <param name="status"></param>
        /// <param name="orderId"></param>
        public void UpdateStatus(string status, int orderId)
        {
            DAO_Order.UpdateStatus(status, orderId);
        }

        /// <summary>
        /// update order with the date
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="status"></param>
        public void UpdateOrder(int OrderID, string status)
        {
            DAO_Order.UpdateOrder(OrderID, status);

        }

        /// <summary>
        /// update the order time by tablenumber
        /// </summary>
        /// <param name="TableNumber"></param>
        public void UpdateOrderTime(int TableNumber)
        {
            DAO_Order.UpdateOrderTime(TableNumber);
        }

        /// <summary>
        /// gets orderId by tablenumber
        /// </summary>
        /// <param name="tableNumber"></param>
        /// <returns></returns>
        public int GetOrderByTableNumber(int tableNumber)
        {
            return DAO_Order.GetOrderByTableNumber(tableNumber);
        }
    }
}