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

        public DAO_Order()
        {
            string connstring = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            dbConnection = new SqlConnection(connstring);
        }

        public void CreateNewOrder(int employeeId, int tableNumber)
        {
            string query = "INSERT INTO [Order] (EmployeeID, TableNumber, Date) VALUES (@EmployeeId, @TableNumber, @Date)";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("EmployeeId", employeeId),
                new SqlParameter("Tablenumber", tableNumber),
                new SqlParameter("Date", DateTime.Now)
            };
            ExecuteEditQuery(query, sqlParameters);
        }

        public List<Order> GetAllOrders(string type)
        {
            string test = DateTime.Now.ToString("dd/MM/yyyy");
            string query = "SELECT OrderId, TableNumber, EmployeeId, Date, Status FROM [Order]";
            //string query = "SELECT OrderId, TableNumber, EmployeeId, Date, Status FROM [Order] where date = '"+DateTime.Now.ToString("MM/dd/yyyy") + "'";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadAllTables(ExecuteSelectQuery(query, sqlParameters), type);
        }

        public List<Order> GetAllOrdersAnyStatus()
        {
            string query = "SELECT OrderId FROM [Order]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadAllTablesAnyStatus(ExecuteSelectQuery(query, sqlParameters));
        }

        public List<Order> GetActiveOrderList()
        {
            string query = "SELECT TableNumber, Date, Status FROM [Order] WHERE Status NOT LIKE 'c%'";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadAllTablesActive(ExecuteSelectQuery(query, sqlParameters));
        }

        public List<Order> GetOrdersAboveID(string type, int Id)
        {
            string query = "SELECT OrderId, TableNumber, EmployeeId, Date, Status FROM [Order] where Status = 'Open'";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadAllTables(ExecuteSelectQuery(query, sqlParameters), type);
        }

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

        private List<Order> ReadAllTablesAnyStatus(DataTable dataTable)
        {
            List<Order> orders = new List<Order>();
            foreach (DataRow dr in dataTable.Rows)
            {
                Order served = new Order();
                served.OrderId = (int)dr["OrderId"];
            };
            return orders;
        }

        private List<Order> ReadAllTablesActive(DataTable dataTable)
        {
            List<Order> orders = new List<Order>();
            foreach (DataRow dr in dataTable.Rows)
            {
                Order order = new Order();
                order.TableNumber = (int)dr["TableNumber"];
                order.Date = (DateTime)dr["Date"];
                order.Status = (string)dr["Status"];
                orders.Add(order);
            };
            return orders;
        }
        

        public void UpdateStatus(string done, int orderId)
        {
            dbConnection.Open();
            SqlCommand command = new SqlCommand("UPDATE [Order] SET Status = @Status WHERE OrderId = @OrderId", dbConnection);
            command.Parameters.AddWithValue("@Status", done);
            command.Parameters.AddWithValue("@OrderId", orderId);
            SqlDataReader reader = command.ExecuteReader();
            dbConnection.Close();
        }
    }
}
