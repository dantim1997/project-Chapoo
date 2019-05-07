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
    public class DAO_Served : Base
    {
        private SqlConnection dbConnection;

        public DAO_Served()
        {
            string connstring = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            dbConnection = new SqlConnection(connstring);
        }

        public Served GetBill(int billId)
        {
            string query = "SELECT BillId, TableNumber, WorkerId, StartDate, EndeDate, Done FROM Served where BillId = " + billId;
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTable(ExecuteSelectQuery(query, sqlParameters));
        }

        public List<Served> GetAllBills()
        {
            string query = "SELECT BillId, TableNumber, WorkerId, StartDate, EndeDate, Done FROM Served";
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

        private Served ReadTable(DataTable dataTable)
        {
            List<Product> products = new List<Product>();
            //each row from the database is converted into the login class
            DAO_Bill dao_Bill = new DAO_Bill();
            Served served = new Served();
            foreach (DataRow dr in dataTable.Rows)
            {
                served.BillId = (int)dr["BillId"];
                served.TableNumber = (int)dr["TableNumber"];
                served.WorkerId = (int)dr["WorkerId"];
                served.StartDate = (DateTime)dr["StartDate"];
                served.EndDate = (DateTime)dr["EndeDate"];
                served.Done = (bool)dr["Done"];
                served.Products = dao_Bill.GetBillfromId(served.BillId);
            };

            return served;
        }

        private List<Served> ReadAllTables(DataTable dataTable)
        {
            List<Product> products = new List<Product>();
            //each row from the database is converted into the login class
            DAO_Bill dao_Bill = new DAO_Bill();
            List<Served> allServed = new List<Served>();
            foreach (DataRow dr in dataTable.Rows)
            {
                Served served = new Served();
                served.BillId = (int)dr["BillId"];
                served.TableNumber = (int)dr["TableNumber"];
                served.WorkerId = (int)dr["WorkerId"];
                served.StartDate = (DateTime)dr["StartDate"];
                served.EndDate = (DateTime)dr["EndeDate"];
                served.Done = (bool)dr["Done"];
                served.Products = dao_Bill.GetBillfromId(served.BillId);
                allServed.Add(served);
            };

            return allServed;
        }
    }
}
