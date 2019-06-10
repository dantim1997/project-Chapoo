using ChapooModels;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ChapooDAL
{
    public class DAO_Table : Base
    {
        private SqlConnection dbConnection;

        public DAO_Table()
        {
            string connstring = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            dbConnection = new SqlConnection(connstring);
        }
        /// <summary>
        /// This method returns a List of all tables.
        /// </summary>
        /// <returns></returns>
        public List<Table> GetTableList()
        {
            string query = "SELECT TableNumber, Status FROM [Table]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTableList(ExecuteSelectQuery(query, sqlParameters));
        }
        /// <summary>
        /// This method updates Table.Status with the given parameter status where Table.Tablemumber is equal to the given parameter Tablenumber.
        /// </summary>
        /// <param name="Tablenumber"></param>
        /// <param name="status"></param>
        public void SetTableStatus(int Tablenumber, string status)
        {
            string query = "UPDATE [Table] SET Status = @status WHERE Tablenumber = @Tablenumber";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("Tablenumber", Tablenumber),
                new SqlParameter("Status", status)
            };

            ExecuteEditQuery(query, sqlParameters);
        }
        /// <summary>
        /// This method returns Table where Table.Tablemumber is equal to the given parameter Tablenumber..
        /// </summary>
        /// <param name="TableNumber"></param>
        /// <returns></returns>
        public Table GetTableByID(int TableNumber)
        {
            string query = "SELECT TableNumber, Status FROM [Table] WHERE TableNumber = @TableNumber";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("TableNumber", TableNumber)
            };
            return ReadTable(ExecuteSelectQuery(query, sqlParameters));
        }
        /// <summary>
        /// This method fills a table object and returns it.
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        private Table ReadTable(DataTable dataTable)
        {
            Table table = new Table();

            foreach (DataRow dr in dataTable.Rows)
            {
                table.TableNumber = (int)dr["TableNumber"];
                table.Status = (string)dr["Status"];
            };
            return table;
        }
        /// <summary>
        /// This method fills table objects and adds it to a list. Then it returns the list.
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        private List<Table> ReadTableList(DataTable dataTable)
        {
            List<Table> tableList = new List<Table>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Table table = new Table()
                {
                    TableNumber = (int)dr["TableNumber"],
                    Status = (string)dr["Status"]
                };
                tableList.Add(table);

            };
            return tableList;
        }
    }
}
