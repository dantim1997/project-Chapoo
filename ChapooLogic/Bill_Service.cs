using ChapooModels;
using ChapooDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapooLogic
{
    public class Bill_Service
    {

        DAO_Bill dAO_Bill = new DAO_Bill();
        public void UpdateBillByIds(int billId, int productId, bool done)
        {
            dAO_Bill.UpdateBillByIds(billId, productId, done);
        }
        

        public int GetAllDoneByBill(int BillId)
        {
            return dAO_Bill.GetAllDoneByBill(BillId);
        }
    }
}
