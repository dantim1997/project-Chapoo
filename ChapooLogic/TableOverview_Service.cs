using System;
using ChapooDAL;
using ChapooModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapooLogic
{
    public class TableOverview_Service
    {
        bool tableOccupied = false;
        int orderId;
        DAO_Table tableDAO;
        Order_Service orderService;

        public TableOverview_Service()
        {
            tableDAO = new DAO_Table();
            orderService = new Order_Service();
        }

        public List<Table> GetTableList()
        {
            return tableDAO.GetTableList();
        }

        public Table GetTableById(string id)
        {
            Table table = new Table();
            table = tableDAO.GetTableByID(id);

            return table;
        }

        public int GetOrderId()
        {
            List<Order> orderList = orderService.GetAllOrders();
            orderId = orderList.Count();
            return orderId;
        }

        public void CreateOrder(int employeeId, string status, int tableNumber)
        {
            orderService.CreateOrder(employeeId, status, tableNumber);
        }

        public List<Order> GetOrderList()
        {
            List<Order> orderList = orderService.GetOrders("open");
            return orderList;
        }

        public List<Order> GetActiveOrderList()
        {
            return orderService.GetActiveOrderList();
        }

        public void CheckTableWaitingStatus()
        {

        }

        public bool CheckTableStatus(string id)
        {
            if (GetTableById(id).Status == "free")
            {
                tableOccupied = true;
            }

            return tableOccupied;
        }

        public void UpdateTableStatusOccupied(string id, string status)
        {
            tableDAO.SetTableStatus(id, status);
        }

    }


}
