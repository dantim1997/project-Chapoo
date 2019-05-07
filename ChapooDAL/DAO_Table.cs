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
    public class DAO_Table: Base
    {
        private SqlConnection dbConnection;

        public DAO_Table()
        {
            string connstring = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            dbConnection = new SqlConnection(connstring);
        }
        public Table GetTable()
        {
            string query = "SELECT TableNumber, Status FROM Table";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTable(ExecuteSelectQuery(query, sqlParameters));
        }

        private Table ReadTable(DataTable dataTable)
        {
            Table login = new Table();
            //each row from the database is converted into the login class
            foreach (DataRow dr in dataTable.Rows)
            {
                login.TableNumber = (int)dr["TableNumber"];
                login.Status = (string)dr["Status"];
            };
            return login;
        }
    }
}
