﻿using System;
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
        OrderProduct_Service orderProductService;

        public TableOverview_Service()
        {
            tableDAO = new DAO_Table();
            orderService = new Order_Service();
            orderProductService = new OrderProduct_Service();
        }

        public List<Table> GetTableList()
        {
            return tableDAO.GetTableList();
        }

        public Table GetTableById(int id)
        {
            Table table = new Table();
            table = tableDAO.GetTableByID(id);

            return table;
        }

        public int GetOrderId(int tableNumber)
        {
            return orderService.GetOrderByTableNumber(tableNumber);
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

        public List<OrderProduct> GetActiveOrderProductList()
        {
            return orderProductService.GetActiveOrderProductList();
        }

        public bool CheckTableStatus(int id)
        {
            if (GetTableById(id).Status == "free")
            {
                tableOccupied = true;
            }

            return tableOccupied;
        }// check int

        public void UpdateTableStatus(int id, string status)
        {
            tableDAO.SetTableStatus(id, status);
        }// check int

        public void UpdateOrderProductStatus(int TableNumber, Statustype Status, string type)
        {
            orderProductService.UpdateOrderProductStatus(TableNumber, Status, type);
        }
        public void UpdateOrderTime(int TableNumber)
        {
            orderService.UpdateOrderTime(TableNumber);
        }
    }


}
