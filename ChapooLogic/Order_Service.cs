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


        public void CreateOrder(int employeeId, string status, int tableNumber)
        {
            DAO_Order.CreateNewOrder(employeeId, status, tableNumber);
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

        public void UpdateStatus(string status, int orderId)
        {
            DAO_Order.UpdateStatus(status, orderId);
        }

        public void UpdateOrder(int OrderID, string status)
        {
            DAO_Order.UpdateOrder(OrderID, status);

        }

        public void UpdateOrderTime(int TableNumber)
        {
            DAO_Order.UpdateOrderTime(TableNumber);
        }

        public void UpdateStock()
        {
        }
    }
}