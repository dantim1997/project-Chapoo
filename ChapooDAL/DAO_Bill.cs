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
    public class DAO_Bill : Base
    {
        private SqlConnection dbConnection;

        public DAO_Bill()
        {
            string connstring = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            dbConnection = new SqlConnection(connstring);
        }

        public List<Bill> GetBill()
        {
            string query = "SELECT ProductId, BillId, Amount, Date, Done FROM Bill";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTable(ExecuteSelectQuery(query, sqlParameters));
        }

        public List<Bill> GetBillfromId(int billId)
        {
            string query = "SELECT ProductId, BillId, Amount, Date, Done FROM Bill where BillId = " + billId;
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTable(ExecuteSelectQuery(query, sqlParameters));
        }

        public void UpdateBillByIds(int billId, int productId, bool Done)
        {
            dbConnection.Open();
            SqlCommand command = new SqlCommand("UPDATE Bill SET Done = @Done WHERE BillId = @BillId and ProductId = @ProductId", dbConnection);
            command.Parameters.AddWithValue("@Done", Done);
            command.Parameters.AddWithValue("@ProductId", productId);
            command.Parameters.AddWithValue("@BillId", billId);
            SqlDataReader reader = command.ExecuteReader();
            dbConnection.Close();
        }

        private List<Bill> ReadTable(DataTable dataTable)
        {
            List<Bill> products = new List<Bill>();
            //each row from the database is converted into the login class
            DAO_Product dao_product = new DAO_Product();
            foreach (DataRow dr in dataTable.Rows)
            {
                Bill bill = new Bill();
                bill.ProductId = (int)dr["ProductId"];
                bill.BillId = (int)dr["BillId"];
                bill.Date = (DateTime)dr["Date"];
                bill.product = dao_product.GetAllByBill(bill.ProductId);
                bill.product.Supply = (int)dr["Amount"];

                products.Add(bill);
            };

            return products;
        }

        public int GetAllDoneByBill(int billId)
        {
            dbConnection.Open();
            SqlCommand command = new SqlCommand("select Count(*) as [count] from Bill where BillId = @BillId and Done = 'true'", dbConnection);
            command.Parameters.AddWithValue("@BillId", billId);
            int count = 0;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                count = (int)reader["Count"];

            }
            dbConnection.Close();
            return count;
        }
    }
}
