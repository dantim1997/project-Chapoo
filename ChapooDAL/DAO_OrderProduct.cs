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

        /// <summary>
        /// constructor
        /// </summary>
        public DAO_OrderProduct()
        {
            string connstring = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            dbConnection = new SqlConnection(connstring);
        }

        /// <summary>
        /// gets all orders
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<OrderProduct> GetAllByOrder(int orderId, string type)
        {
            string query = "SELECT OrderId, o.ProductId, Amount, Status, Id, Note FROM Order_Product as o join Product as p on o.ProductId = p.ProductId where OrderId = " + orderId + " and p.ProductType = '" + type + "' and o.Status = 1";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTable(ExecuteSelectQuery(query, sqlParameters), type);
        }

        /// <summary>
        /// get all active orders
        /// </summary>
        /// <returns></returns>
        public List<OrderProduct> GetAllByActiveOrder()
        {
            string query = "SELECT P.OrderId, P.ProductId, P.Status FROM [Order_Product] AS P JOIN [Order] AS O ON O.OrderId = P.OrderId WHERE O.Status NOT LIKE 'c%'";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTableActive(ExecuteSelectQuery(query, sqlParameters));
        }

        /// <summary>
        /// update all orderproduct with an status
        /// </summary>
        /// <param name="orderProducts"></param>
        /// <param name="Status"></param>
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

        /// <summary>
        /// update status by orderproduct with the tablenumber
        /// </summary>
        /// <param name="Tablenumber"></param>
        /// <param name="Status"></param>
        /// <param name="type"></param>
        public void UpdateOrderProductStatusByTablenumber(int Tablenumber, Statustype Status, string Type)
        {
            //string query = "UPDATE [Order_Product] SET Order_Product.Status = @Status FROM [Order_Product] AS P JOIN [Order] AS O ON P.OrderId = O.OrderId WHERE O.TableNumber = @Tablenumber AND P.ProductId " + type + " 22";
            string query = "UPDATE [Order_Product] SET Order_Product.Status = @Status FROM[Order] AS O JOIN[Order_Product] AS OP ON O.OrderId = OP.OrderId JOIN[Product] AS P ON OP.ProductId = P.ProductId WHERE O.TableNumber = @Tablenumber AND P.ProductType = @Type";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("Status", Status),
                new SqlParameter("TableNumber", Tablenumber),
                new SqlParameter("Type", Type)

            };
            ExecuteEditQuery(query, sqlParameters);
        }
        /// <summary>
        /// update status by orderproduct with the OrderId
        /// </summary>
        /// <param name="OrderId"></param>
        /// <param name="Status"></param>
        public void UpdateOrderProductStatusByOrderId(int OrderId, Statustype Status)
        {
            string query = "UPDATE [Order_Product] SET Status = @Status WHERE OrderId = @OrderId";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("Status", (int)Status),
                new SqlParameter("OrderId", OrderId)

            };
            ExecuteEditQuery(query, sqlParameters);
        }

        /// <summary>
        /// create an orderproduct
        /// </summary>
        /// <param name="orderProducts"></param>
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

        /// <summary>
        /// reads the datatable
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="type"></param>
        /// <returns></returns>
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
                OrderProduct.Note = (string)dr["Note"];
                OrderProducts.Add(OrderProduct);
            };
            return OrderProducts;
        }

        /// <summary>
        /// read all the active datatable
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        private List<OrderProduct> ReadTableActive(DataTable dataTable)
        {
            List<OrderProduct> OrderProducts = new List<OrderProduct>();
            //each row from the database is converted into the login class
            foreach (DataRow dr in dataTable.Rows)
            {
                OrderProduct OrderProduct = new OrderProduct();
                OrderProduct.OrderId = (int)dr["OrderID"];
                Product product = new Product();
                product.ProductId = (int)dr["ProductID"];
                OrderProduct.Product = product;
                OrderProduct.Status = (Statustype)dr["Status"];
                OrderProducts.Add(OrderProduct);

            };
            return OrderProducts;
        }
    }
}
