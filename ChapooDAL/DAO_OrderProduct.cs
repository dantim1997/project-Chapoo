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
            string query = "SELECT OrderId, o.ProductId, Amount, Status, Id FROM Order_Product as o join Product as p on o.ProductId = p.ProductId where OrderId = "+orderId+" and p.ProductType = '"+type+"' and o.Status = 1";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTable(ExecuteSelectQuery(query, sqlParameters), type);
        }

        public string CheckStatus(int orderId)
        {
            string query = "select (select count(Id) from Order_Product) as Orders, (select count(Id) from Order_Product where Status = 'True') as Done from Order_Product group by OrderId having OrderId =" + orderId;
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadStatus(ExecuteSelectQuery(query, sqlParameters));
        }

        public void UpdateOrderProductByIds(int OrderProductId, Statustype Status, int orderId)
        {
            dbConnection.Open();
            SqlCommand command = new SqlCommand("UPDATE Order_Product SET Status = @Status WHERE Id = @OrderProductId", dbConnection);
            command.Parameters.AddWithValue("@Status", (int)Status);
            command.Parameters.AddWithValue("@OrderProductId", OrderProductId);
            SqlDataReader reader = command.ExecuteReader();
            dbConnection.Close();
            DAO_Order dAO_Order = new DAO_Order();
            //dAO_Order.UpdateStatus(CheckStatus(orderId), orderId);
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
                OrderProduct.Status= (Statustype)dr["Status"];
                OrderProduct.OrderProductId= (int)dr["Id"];
                OrderProducts.Add(OrderProduct);
            };
            return OrderProducts;
        }

        private string ReadStatus(DataTable dataTable)
        {
            List<OrderProduct> OrderProducts = new List<OrderProduct>();
            //each row from the database is converted into the login class
            int Done = 0, Orders = 0;
            foreach (DataRow dr in dataTable.Rows)
            {
                OrderProduct OrderProduct = new OrderProduct();
                Orders = (int)dr["Orders"];
                Done = (int)dr["Done"];
            };

            if (Done == Orders && Orders!= 0)
            {
                return "Bereid";
            }
            return "Open";
        }
    }
}
