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

        public void CreateOrder(int employeeId, int tableNumber)
        {
            DAO_Order.CreateNewOrder(employeeId, tableNumber);
        }

        public List<Order> GetOrders(string type)
        {
            return DAO_Order.GetAllOrders(type);
        }

        public List<Order> GetAllOrders()
        {
            return DAO_Order.GetAllOrdersAnyStatus();
        }

        public List<Order> GetActiveOrderList()
        {
            return DAO_Order.GetActiveOrderList();
        }

        public List<Order> GetOrdersAboveID(string type, int Id)
        {
            return DAO_Order.GetOrdersAboveID(type, Id);
        }

        public void UpdateStatus(string status, int orderId)
        {
            DAO_Order.UpdateStatus(status, orderId);
        }
    }
}
