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
        private DAO_Table TableDAO;
        private Order_Service OrderService;
        private OrderProduct_Service OrderProductService;
        private Product_Service ProductService;

        public TableOverview_Service()
        {
            TableDAO = new DAO_Table();
            OrderService = new Order_Service();
            OrderProductService = new OrderProduct_Service();
            ProductService = new Product_Service();
        }
        /// <summary>
        /// This method communicates with the DAO_Table and retrieves a list of all tables.
        /// </summary>
        /// <returns></returns>
        public List<Table> GetTableList()
        {
            return TableDAO.GetTableList();
        }
        /// <summary>
        /// This method communicates with the DAO_Table and retrieves a Table whith the given parameter TableId.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Table GetTableById(int id)
        {
            Table table = new Table();
            table = TableDAO.GetTableByID(id);

            return table;
        }
        /// <summary>
        /// This method communicates with the Order_Service and asks for a Orderid where Order.TableNumber is equal to the given parameter tableNumber
        /// </summary>
        /// <param name="tableNumber"></param>
        /// <returns></returns>
        public int GetOrderId(int tableNumber)
        {
            return OrderService.GetOrderByTableNumber(tableNumber);
        }
        /// <summary>
        /// Deze methode communiceerd met de Order_Service en vraagt om een order aan te maken met de meegegeven parameters.
        /// </summary>
        public void CreateOrder(int employeeId, string status, int tableNumber)
        {
            OrderService.CreateOrder(employeeId, status, tableNumber);
        }

        /// <summary>
        /// This method communicates with the Order_Service and asks for a list of all active orders.
        /// </summary>
        /// <returns></returns>
        public List<Order> GetActiveOrderList()
        {
            return OrderService.GetActiveOrderList();
        }
        /// <summary>
        /// This method communicates with the OrderProduct_Service and asks for a list of all OrderProducts where the order is active.
        /// </summary>
        /// <returns></returns>
        public List<OrderProduct> GetActiveOrderProductList()
        {
            return OrderProductService.GetActiveOrderProductList();
        }
        /// <summary>
        /// This method communicates with the DAO_Table and asks to update the Table.Status with the given parameter status where Table.TableId is the given parameter id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        public void UpdateTableStatus(int id, string status)
        {
            TableDAO.SetTableStatus(id, status);
        }
        /// <summary>
        /// This method communicates with the OrderProduct_Service and asks to update the OrderProduct.Status Where Order.TableNumber is equal to the given parameter 'TableNumber' and Where Product.Id is greater or smaller than type.
        /// </summary>
        /// <param name="TableNumber"></param>
        /// <param name="Status"></param>
        /// <param name="type"></param>
        public void UpdateOrderProductStatus(int TableNumber, Statustype Status, string type)
        {
            OrderProductService.UpdateOrderProductStatus(TableNumber, Status, type);
        }
        /// <summary>
        /// This method communicates with the Order_service and asks to update the Order.Date to DateTime.Now where Order.TableNumber is given the parameter Tablenumber.
        /// </summary>
        /// <param name="TableNumber"></param>
        public void UpdateOrderTime(int TableNumber)
        {
            OrderService.UpdateOrderTime(TableNumber);
        }

        public List<Product> GetProductList()
        {
            return ProductService.GetProducts();
        }
    }


}
