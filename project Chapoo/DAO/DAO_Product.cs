using project_Chapoo.DAL;
using project_Chapoo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_Chapoo.DAO
{
    class DAO_Product: Base
    {
        private SqlConnection dbConnection;

        public DAO_Product()
        {
            string connstring = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            dbConnection = new SqlConnection(connstring);
        }

        public Product GetProducts()
        {
            string query = "SELECT ProductId, ProductName, ProductPrice, ProductType, BTW FROM Product";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTable(ExecuteSelectQuery(query, sqlParameters));
        }

        private Product ReadProduct(SqlDataReader reader)
        {
            Product product = new Product()
            {
                ProductId = (int)reader["ProductId"],
                ProductName = (string)reader["ProductName"],
                ProductPrice = (decimal)reader["ProductPrice"],
                ProductType = (string)reader["ProductType"],
                BTW = (int)reader["BTW"]
            };
            return product;
        }

        private Product ReadTable(DataTable dataTable)
        {
            Product product = new Product();
            //each row from the database is converted into the login class
            foreach (DataRow dr in dataTable.Rows)
            {
                product.ProductId = (int)dr["ProductId"];
                product.ProductName = (string)dr["ProductName"];
                product.ProductPrice = (decimal)dr["ProductPrice"];
                product.ProductType = (string)dr["ProductType"];
                product.BTW = (int)dr["BTW"];
            };
            return product;
        }
    }
}
