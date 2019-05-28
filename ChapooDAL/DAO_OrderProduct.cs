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

        public List<OrderProduct> GetAllByOrder(int orderId, string type)
        {
            string query = "SELECT OrderId, o.ProductId, Amount, Status, Id FROM Order_Product as o join Product as p on o.ProductId = p.ProductId where OrderId = " + orderId + " and p.ProductType = '" + type + "' and o.Status = 1";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTable(ExecuteSelectQuery(query, sqlParameters), type);
        }

        public void UpdateAllOrderProduct(List<OrderProduct> orderProducts, Statustype Status)
        {
            foreach (OrderProduct orderProduct in orderProducts)
            {
                dbConnection.Open();
                SqlCommand command = new SqlCommand("UPDATE Order_Product SET Status = @Status WHERE Id = @OrderProductId", dbConnection);
                command.Parameters.AddWithValue("@Status", (int)Status);
                command.Parameters.AddWithValue("@OrderProductId", orderProduct.OrderProductId);
                SqlDataReader reader = command.ExecuteReader();
                dbConnection.Close();
            }
        }

        public void UpdateOrderProductByIds(int OrderProductId, Statustype Status, int orderId)
        {
            dbConnection.Open();
            SqlCommand command = new SqlCommand("UPDATE Order_Product SET Status = @Status WHERE Id = @OrderProductId", dbConnection);
            command.Parameters.AddWithValue("@Status", (int)Status);
            command.Parameters.AddWithValue("@OrderProductId", OrderProductId);
            SqlDataReader reader = command.ExecuteReader();
            dbConnection.Close();
        }

        private List<OrderProduct> ReadTable(DataTable dataTable, string type)
        {
            List<OrderProduct> OrderProducts = new List<OrderProduct>();
            //each row from the database is converted into the login class
            foreach (DataRow dr in dataTable.Rows)
            {
                OrderProduct OrderProduct = new OrderProduct();
                OrderProduct.OrderId = (int)dr["OrderID"];
                int ProductId = (int)dr["ProductID"];
                Product product = DAO_Product.GetByProductId(ProductId, type);
                OrderProduct.Product = product;
                OrderProduct.Amount = (int)dr["Amount"];
                OrderProduct.Status = (Statustype)dr["Status"];
                OrderProduct.OrderProductId = (int)dr["Id"];
                OrderProducts.Add(OrderProduct);
            };
            return OrderProducts;
        }
    }
}
