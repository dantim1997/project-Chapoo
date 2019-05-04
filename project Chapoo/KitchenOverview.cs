using project_Chapoo.DAO;
using project_Chapoo.Models;
using project_Chapoo.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_Chapoo
{
    public partial class KitchenOverview : Form
    {
        Product_Service ProductService = new Product_Service();
        Bill_Service Bill_Service = new Bill_Service();
        Served_Service Served_Service = new Served_Service();
        int selectedBillId, selectedProductId;

        public KitchenOverview()
        {
            InitializeComponent();
        }


        /// <summary>
        /// when the program is opened
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KitchenOverview_Load(object sender, EventArgs e)
        {
            List<Served> serveds = Served_Service.GetAllBills();
            dataGridView1.DataSource = serveds;
        }

        /// <summary>
        /// update the productlist by the connected bill
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                int value1 = int.Parse(row.Cells[0].Value.ToString());
                int value2 = int.Parse(row.Cells[1].Value.ToString());
                int value3 = int.Parse(row.Cells[2].Value.ToString());

                selectedBillId = value1;
                DAO_Worker worker = new DAO_Worker();
                LB_WorkerName.Text = worker.GetWorkerById(value2).Name;
                LB_Table.Text = value3.ToString();
                ReloadBillList();
            }
        }

        /// <summary>
        /// if an other product row is selected the data is displayed in the info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                int productId = int.Parse(row.Cells[0].Value.ToString());
                string productname = row.Cells[1].Value.ToString();
                string amount = row.Cells[2].Value.ToString();
                bool made = Convert.ToBoolean(row.Cells[3].Value);

                selectedProductId = productId;
                LB_ProductName.Text = productname;
                LB_Amount.Text = amount;
                if (made != false)
                {
                    btn_Done.Hide();
                    btn_NotDone.Show();
                }
                else
                {
                    btn_NotDone.Hide();
                    btn_Done.Show();
                }
            }
        }

        /// <summary>
        /// btn click of done
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Done_Click(object sender, EventArgs e)
        {
            UpdateBill(true);
        }

        /// <summary>
        /// btn click of not done
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_NotDone_Click(object sender, EventArgs e)
        {
            UpdateBill(false);
        }

        /// <summary>
        /// Update the checkbox in de database table Bill
        /// </summary>
        /// <param name="done"></param>
        private void UpdateBill(bool done)
        {
            Bill_Service.UpdateBillByIds(selectedBillId, selectedProductId, done);
            if(dataGridView2.Rows.Count == Bill_Service.GetAllDoneByBill(1))
            {
                //if all records are made where wil be an question to remove the bill from the view
                DialogResult dialogResult = MessageBox.Show("the whole order is made, remove from list?","warnig", MessageBoxButtons.YesNo);
                if(dialogResult == DialogResult.Yes)
                {
                    Served_Service.UpdateStatus(selectedBillId);
                }
                else if(dialogResult == DialogResult.No)
                {

                }
            }
            dataGridView2.DataSource = null;
            ReloadBillList();
        }


        /// <summary>
        /// Reload the productlist
        /// </summary>
        private void ReloadBillList()
        {
            List<Bill> bills = Bill_Service.GetBillfromId(selectedBillId);

            List<Bill_ViewModel> bill_Views = ProductService.FromProductToBill_ViewModel(ProductService.FromBillToProducts(bills));
            dataGridView2.DataSource = bill_Views;
        }
    }
}
