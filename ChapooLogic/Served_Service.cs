using ChapooModels;
using ChapooDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapooLogic
{
    public class Served_Service
    {
        DAO_Served dAO_Served = new DAO_Served();
        public List<Served> GetAllBills()
        {
            return dAO_Served.GetAllBills();
        }

        public void UpdateStatus(int billId)
        {
            dAO_Served.UpdateServedByIds(billId);
        }
        
            
    }
}
