using ChapooLogic;
using ChapooModels;
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
        OrderProduct_Service OrderProduct_Service = new OrderProduct_Service();
        Order_Service Order_Service = new Order_Service();
        Employee_Service employee_Service = new Employee_Service();
        int SelectedOrderId, SelectedProductId, SelectedOrderProductId;

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
            ReloadOrderList();
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
                SelectedOrderId = int.Parse(row.Cells[0].Value.ToString());
                int EmployeeId = int.Parse(row.Cells[1].Value.ToString());
                int TableNumber = int.Parse(row.Cells[2].Value.ToString());

                LB_WorkerName.Text = employee_Service.GetEmployeeById(EmployeeId).Name;
                LB_Table.Text = TableNumber.ToString();
                ReloadOrderProductList();
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
                SelectedOrderProductId= int.Parse(row.Cells[0].Value.ToString());
                int productId = int.Parse(row.Cells[1].Value.ToString());
                string productname = row.Cells[2].Value.ToString();
                string amount = row.Cells[3].Value.ToString();
                bool made = Convert.ToBoolean(row.Cells[5].Value);

                SelectedProductId = productId;
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
            UpdateOrderProduct(true);
            btn_Done.Hide();
            btn_NotDone.Show();
            
        }

        /// <summary>
        /// btn click of not done
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_NotDone_Click(object sender, EventArgs e)
        {
            UpdateOrderProduct(false);
            btn_NotDone.Hide();
            btn_Done.Show();
        }

        /// <summary>
        /// Update the checkbox in de database table Bill
        /// </summary>
        /// <param name="done"></param>
        private void UpdateOrderProduct(bool done)
        {
            OrderProduct_Service.UpdateStatus(SelectedOrderProductId, done, SelectedOrderId);
            ReloadOrderProductList();
            ReloadOrderList();
        }


        /// <summary>
        /// Reload the productlist
        /// </summary>
        private void ReloadOrderProductList()
        {
            List<OrderProduct> Orders = OrderProduct_Service.GetAllByOrder(SelectedOrderId, "Food");

            List<OrderProductViewModel> orderProductViewModel = OrderProduct_Service.OrderProductsToViewModels(Orders);
            dataGridView2.DataSource = orderProductViewModel;
        }

        private void ReloadOrderList()
        {
            dataGridView1.DataSource = Order_Service.GetOrders();
        }
    }
}
