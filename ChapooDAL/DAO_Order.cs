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

        public DAO_Order()
        {
            string connstring = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            dbConnection = new SqlConnection(connstring);
        }

        public List<Order> GetBill(int orderId)
        {
            string query = "SELECT OrderId, TableNumber, EmployeeId, Date, Done FROM Order where OrderId = " + orderId;
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTable(ExecuteSelectQuery(query, sqlParameters));
        }

        public List<Order> GetAllOrders()
        {
            string query = "SELECT OrderId, TableNumber, EmployeeId, Date, Status FROM Order";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadAllTables(ExecuteSelectQuery(query, sqlParameters));
        }

        public void UpdateServedByIds(int billId)
        {
            dbConnection.Open();
            SqlCommand command = new SqlCommand("UPDATE Served SET Done = @Done WHERE BillId = @BillId", dbConnection);
            command.Parameters.AddWithValue("@BillId", billId);
            command.Parameters.AddWithValue("@Done", true);
            SqlDataReader reader = command.ExecuteReader();
            dbConnection.Close();
        }

        private List<Order> ReadTable(DataTable dataTable)
        {
            List<Order> orders = new List<Order>();
            //each row from the database is converted into the login class
            foreach (DataRow dr in dataTable.Rows)
            {
                Order served = new Order();
                served.OrderId = (int)dr["OrderId"];
                served.TableNumber = (int)dr["TableNumber"];
                served.EmployeeId = (int)dr["EmployeeId"];
                served.Date = (DateTime)dr["Date"];
                served.Status = (string)dr["Status"];
            };

            return orders;
        }

        private List<Order> ReadAllTables(DataTable dataTable)
        {
            List<Product> products = new List<Product>();
            //each row from the database is converted into the login class
            DAO_Bill dao_Bill = new DAO_Bill();
            List<Order> allServed = new List<Order>();
            foreach (DataRow dr in dataTable.Rows)
            {
                Order served = new Order();
                served.OrderId = (int)dr["OrderId"];
                served.EmployeeId = (int)dr["EmployeeId"];
                served.TableNumber = (int)dr["TableNumber"];
                served.Date = (DateTime)dr["Date"];
                served.Status= (string)dr["Status"];
                allServed.Add(served);
            };

            return allServed;
        }
    }
}
