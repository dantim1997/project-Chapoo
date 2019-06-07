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

        public List<OrderProduct> GetAllByActiveOrder(string type)
        {
            string query = "SELECT P.OrderId, P.ProductId, P.Status FROM [Order_Product] AS P JOIN [Order] AS O ON O.OrderId = P.OrderId WHERE O.Status NOT LIKE 'c%'";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTableActive(ExecuteSelectQuery(query, sqlParameters), type);
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

        public void UpdateOrderProductStatusByTablenumber(int Tablenumber, Statustype Status, string type)
        {
            string query = "UPDATE [OrderProduct] SET OrderProduct.Status = @Status FROM [OrderProduct] AS P JOIN [Order] AS O ON P.OrderId = O.OrderId WHERE O.TableNumber = @TableNumber AND P.ProductId @type 22";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("Status", Status),
                new SqlParameter("TableNumber", Tablenumber),
                new SqlParameter("Type", type)

            };
            ExecuteEditQuery(query, sqlParameters);
        }

        public void CreateOrderPruduct(List<OrderProduct> orderProducts)
        {
            foreach (OrderProduct orderProduct in orderProducts)
            {
                string query = "INSERT INTO [Order_Product] (OrderId, ProductId, Amount, Status, Note) VALUES (@OrderId, @ProductId, @Amount, @Status, @Note)";
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                new SqlParameter("OrderId", orderProduct.OrderId),
                new SqlParameter("ProductId", orderProduct.Product.ProductId),
                new SqlParameter("Amount", orderProduct.Amount),
                new SqlParameter("Status", orderProduct.Status),
                new SqlParameter("Note", orderProduct.Note)
                };
                ExecuteEditQuery(query, sqlParameters);
                DAO_Product.UpdateProductStock(orderProduct.Amount, orderProduct.Product.ProductId);
            }
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

        private List<OrderProduct> ReadTableActive(DataTable dataTable, string type)
        {
            List<OrderProduct> OrderProducts = new List<OrderProduct>();
            //each row from the database is converted into the login class
            foreach (DataRow dr in dataTable.Rows)
            {
                OrderProduct OrderProduct = new OrderProduct();
                OrderProduct.OrderId = (int)dr["OrderID"];
                int ProductId = (int)dr["ProductID"];
                OrderProduct.Status = (Statustype)dr["Status"];
                if (type == "Drink")
                {
                    if (ProductId >= 22)
                    {
                        OrderProducts.Add(OrderProduct);
                    }
                }
                else
                {
                    OrderProducts.Add(OrderProduct);
                }
            };
            return OrderProducts;
        }
    }
}
