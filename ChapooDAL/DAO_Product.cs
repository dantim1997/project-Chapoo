using ChapooModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapooDAL
{
    public class DAO_Product: Base
    {
        private SqlConnection dbConnection;

        public DAO_Product()
        {
            string connstring = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            dbConnection = new SqlConnection(connstring);
        }

        public List<Product> GetProducts()
        {
            string query = "SELECT ProductId, ProductName, ProductPrice, ProductType, BTW FROM Product";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTable(ExecuteSelectQuery(query, sqlParameters));
        }

        public List<Product> GetAllFood()
        {
            string query = "SELECT ProductId, ProductName, ProductPrice, ProductType, BTW FROM Product where ProductType = 'Food'";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTable(ExecuteSelectQuery(query, sqlParameters));
        }

        public List<Product> GetAllLunch()
        {
            string query = "SELECT ProductId, ProductName, ProductPrice, ProductType, BTW, supply, MenuType FROM Product where ProductID BETWEEN 3 AND 12";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTable(ExecuteSelectQuery(query, sqlParameters));
        }

        public List<Product> GetAllDiner()
        {
            string query = "SELECT ProductId, ProductName, ProductPrice, ProductType, BTW, supply, MenuType FROM Product where ProductID BETWEEN 13 AND 23";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTable(ExecuteSelectQuery(query, sqlParameters));
        }

        public List<Product> GetAllDrinks()
        {
            string query = "SELECT ProductId, ProductName, ProductPrice, ProductType, BTW, supply, MenuType FROM Product where ProductType = 'Drink'";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTable(ExecuteSelectQuery(query, sqlParameters));
        }

        public Product GetAllByBill(int productId, string type)
        {
            string query = "SELECT ProductId, ProductName, ProductPrice, ProductType, BTW, supply FROM Product where ProductType = '" + type+"' and ProductId = "+productId;
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadProduct(ExecuteSelectQuery(query, sqlParameters));
        }

        public Product GetByProductId(int productId, string type)
        {
            string query = "SELECT ProductId, ProductName, ProductPrice, ProductType, BTW, supply FROM Product where ProductType = '" + type+"' and ProductId = " + productId;
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadProduct(ExecuteSelectQuery(query, sqlParameters));
        }

        private Product ReadProduct(DataTable dataTable)
        {
            Product product = new Product();
            //each row from the database is converted into the login class
            foreach (DataRow dr in dataTable.Rows)
            {
                product.ProductId = (int)dr["ProductId"];
                product.ProductName = (string)dr["ProductName"];
                product.ProductPrice = (double)dr["ProductPrice"];
                product.ProductType = (string)dr["ProductType"];
                product.BTW = (int)dr["BTW"];
                product.Supply = (int)dr["supply"];
                product.MenuType = (string)dr["MenuType"];
            };
            return product;
        }

        private List<Product> ReadTable(DataTable dataTable)
        {
            List<Product> products = new List<Product>();
            //each row from the database is converted into the login class
            foreach (DataRow dr in dataTable.Rows)
            {
                Product product = new Product();
                product.ProductId = (int)dr["ProductId"];
                product.ProductName = (string)dr["ProductName"];
                product.ProductPrice = (double)dr["ProductPrice"];
                product.ProductType = (string)dr["ProductType"];
                product.BTW = (int)dr["BTW"];
                product.Supply = (int)dr["supply"];
                product.MenuType = (string)dr["MenuType"];
                products.Add(product);
            };
            return products;
        }

        public void UpdateProductStock(int Stock, int productId)
        {
            dbConnection.Open();
            SqlCommand command = new SqlCommand("UPDATE Product SET Supply = Supply - @Stock WHERE ProductId = @ProductId", dbConnection);
            command.Parameters.AddWithValue("@Stock", (int)Stock);
            command.Parameters.AddWithValue("@ProductId", productId);
            SqlDataReader reader = command.ExecuteReader();
            dbConnection.Close();
        }
    }
}
