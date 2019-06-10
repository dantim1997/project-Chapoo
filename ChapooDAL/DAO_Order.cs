using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChapooModels;

namespace ChapooDAL
{
    public class DAO_Order : Base
    {
        private SqlConnection dbConnection;
        DAO_OrderProduct DAO_OrderProduct = new DAO_OrderProduct();

        /// <summary>
        /// constructor
        /// </summary>
        public DAO_Order()
        {
            string connstring = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            dbConnection = new SqlConnection(connstring);
        }

        /// <summary>
        /// creates an new order
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="status"></param>
        /// <param name="tableNumber"></param>
        public void CreateNewOrder(int employeeId, string status, int tableNumber)
        {
            string query = "INSERT INTO [Order] (EmployeeID, TableNumber, Date, Status) VALUES (@EmployeeId, @TableNumber, @Date, @Status)";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("EmployeeId", employeeId),
                new SqlParameter("Tablenumber", tableNumber),
                new SqlParameter("Date", DateTime.Now),
                new SqlParameter("Status", status)
            };
            ExecuteEditQuery(query, sqlParameters);
        }

        /// <summary>
        /// gets all orders
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<Order> GetAllOrders(string type)
        {
            string test = DateTime.Now.ToString("dd/MM/yyyy");
            string query = "SELECT OrderId, TableNumber, EmployeeId, Date, Status FROM [Order] where date = '"+DateTime.Now.ToString("MM/dd/yyyy") + "'";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadAllTables(ExecuteSelectQuery(query, sqlParameters), type);
        }

        /// <summary>
        /// get all orders by tablenumber
        /// </summary>
        /// <param name="tableNumber"></param>
        /// <returns></returns>
        public int GetOrderByTableNumber(int tableNumber)
        {
            string query = "SELECT OrderId FROM [Order] WHERE TableNumber = @tableNumber";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("TableNumber", tableNumber)
            };
            return ReadTableByTableNumber(ExecuteSelectQuery(query, sqlParameters));
        }

        /// <summary>
        /// get all active orders
        /// </summary>
        /// <returns></returns>
        public List<Order> GetActiveOrderList()
        {
            string query = "SELECT OrderId, TableNumber, Date, Status FROM [Order] WHERE Status NOT LIKE 'c%'";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadAllTablesActive(ExecuteSelectQuery(query, sqlParameters));
        }

        /// <summary>
        /// read all database items
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private List<Order> ReadAllTables(DataTable dataTable, string type)
        {
            List<Product> products = new List<Product>();
            //each row from the database is converted into the login class
            List<Order> allServed = new List<Order>();
            foreach (DataRow dr in dataTable.Rows)
            {
                Order served = new Order();
                served.OrderId = (int)dr["OrderId"];
                served.EmployeeId = (int)dr["EmployeeId"];
                served.TableNumber = (int)dr["TableNumber"];
                served.Date = (DateTime)dr["Date"];
                served.Status = (string)dr["Status"];
                served.OrderProduct = DAO_OrderProduct.GetAllByOrder(served.OrderId, type);
                if (served.OrderProduct.Count != 0)
                {
                    allServed.Add(served);
                }
            };
            return allServed;
        }

        /// <summary>
        /// read all database items only the orderid
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        private int ReadTableByTableNumber(DataTable dataTable)
        {
            int orderId = 0;
            foreach (DataRow dr in dataTable.Rows)
            {
                orderId = (int)dr["OrderId"];
            };
            return orderId;
        }

        /// <summary>
        /// read all active tables
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        private List<Order> ReadAllTablesActive(DataTable dataTable)
        {
            List<Order> orders = new List<Order>();
            foreach (DataRow dr in dataTable.Rows)
            {
                Order order = new Order();
                order.OrderId = (int)dr["OrderId"];
                order.TableNumber = (int)dr["TableNumber"];
                order.Date = (DateTime)dr["Date"];
                order.Status = (string)dr["Status"];
                orders.Add(order);
            };
            return orders;
        }
        
        /// <summary>
        /// update the status of an order
        /// </summary>
        /// <param name="done"></param>
        /// <param name="orderId"></param>
        public void UpdateStatus(string done, int orderId)
        {
            dbConnection.Open();
            SqlCommand command = new SqlCommand("UPDATE [Order] SET Status = @Status WHERE OrderId = @OrderId", dbConnection);
            command.Parameters.AddWithValue("@Status", done);
            command.Parameters.AddWithValue("@OrderId", orderId);
            SqlDataReader reader = command.ExecuteReader();
            dbConnection.Close();
        }

        /// <summary>
        /// updates the status of an order and the date
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="status"></param>
        public void UpdateOrder(int orderID, string status)
        {
            dbConnection.Open();
            SqlCommand command = new SqlCommand("UPDATE [Order] SET Status = @Status , Date = @Date WHERE OrderId = @OrderId", dbConnection);
            DateTime dateNow = DateTime.Now;
            command.Parameters.AddWithValue("@Status", status);
            command.Parameters.AddWithValue("@OrderId", orderID);
            command.Parameters.AddWithValue("@Date", dateNow);
            SqlDataReader reader = command.ExecuteReader();
            dbConnection.Close();
        }

        /// <summary>
        /// update the ordertime of an order
        /// </summary>
        /// <param name="TableNumber"></param>
        public void UpdateOrderTime(int TableNumber)
        {
            string query = "UPDATE [Order] SET Date = @Date WHERE TableNumber = @TableNumber";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("Date", DateTime.Now),
                new SqlParameter("TableNumber", TableNumber)
            };
            ExecuteEditQuery(query, sqlParameters);
        }


    }
}
