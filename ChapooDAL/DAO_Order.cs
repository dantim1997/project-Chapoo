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

        public List<Order> GetAllOrders(string type)
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
