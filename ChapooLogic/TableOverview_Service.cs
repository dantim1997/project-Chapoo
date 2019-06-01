﻿using System;
using ChapooDAL;
using ChapooModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapooLogic
{
    public class TableOverview_Service
    {
        bool tableOccupied = false;
        DAO_Table tableDAO;

        public TableOverview_Service()
        {
            tableDAO = new DAO_Table();
        }

        public List<Table> GetTableList()
        {
            return tableDAO.GetTableList();
        }

        public bool CheckTableStatus(string id)
        {
            Table table = new Table();

            table = tableDAO.GetTableByID(id);

            if (table.Status == "free")
            {
                tableOccupied = true;
            }

            return tableOccupied;
        }

        public void UpdateTableStatusOccupied(string id, string status)
        {
            tableDAO.SetTableStatus(id, status);
        }


    }
}