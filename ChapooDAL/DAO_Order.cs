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

        public List<Order> GetAllOrders()
        {
            string query = "SELECT OrderId, TableNumber, EmployeeId, Date, Status FROM [Order]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadAllTables(ExecuteSelectQuery(query, sqlParameters));
        }
        
        private List<Order> ReadAllTables(DataTable dataTable)
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
                served.Status= (string)dr["Status"];
                allServed.Add(served);
            };

            return allServed;
        }
    }
}
