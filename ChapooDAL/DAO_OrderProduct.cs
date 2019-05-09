using System;
using ChapooModels;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ChapooDAL
{
    public class DAO_OrderProduct : Base
    {
        private SqlConnection dbConnection;
        DAO_Product DAO_Product = new DAO_Product();

        public DAO_OrderProduct()
        {
            string connstring = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            dbConnection = new SqlConnection(connstring);
        }

        public List<OrderProduct> GetAllByOrder(int orderId)
        {
            string query = "SELECT OrderId, ProductId, Name, Amount, Status FROM Product where OrderProductId = "+ orderId;
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTable(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<OrderProduct> ReadTable(DataTable dataTable)
        {
            List<OrderProduct> OrderProducts = new List<OrderProduct>();
            //each row from the database is converted into the login class
            foreach (DataRow dr in dataTable.Rows)
            {
                OrderProduct OrderProduct = new OrderProduct();
                OrderProduct.OrderId = (int)dr["OrderID"];
                OrderProduct.ProductId = (int)dr["ProductID"];
                Product product = DAO_Product.GetByProductId(OrderProduct.ProductId);
                OrderProduct.Name = (string)dr["Name"];
                OrderProduct.Amount = (int)dr["Amount"];
                OrderProduct.Status= (string)dr["Status"];
                OrderProducts.Add(OrderProduct);
            };
            return OrderProducts;
        }
    }
}
