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
        List<ChapooModels.Order> Orders = new List<ChapooModels.Order>();
        private int SelectedOrderId, SelectedProductId, SelectedOrderProductId;

        public KitchenOverview()
        {
            InitializeComponent();

            Orders = Order_Service.GetOrders("Food");
            foreach (ChapooModels.Order order in Orders)
            {
                ListViewItem item = new ListViewItem(order.OrderId.ToString());
                item.SubItems.Add(order.TableNumber.ToString());
                item.SubItems.Add(order.Status);
                listView1.Items.Add(item);
            }
        }


        /// <summary>
        /// when the program is opened
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KitchenOverview_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// btn click of done
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Done_Click(object sender, EventArgs e)
        {
            UpdateOrderProduct(Statustype.Bereid);

        }
        /// <summary>
        /// Update the checkbox in de database table Bill
        /// </summary>
        /// <param name="done"></param>
        private void UpdateOrderProduct(Statustype done)
        {
            OrderProduct_Service.UpdateStatus(SelectedOrderProductId, done, SelectedOrderId);
            ReloadOrderProductList();
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            SelectedOrderId = Convert.ToInt32(e.Item.Text);
            ChapooModels.Order id = Orders.Where(p => p.OrderId == SelectedOrderId).FirstOrDefault();
            listView2.Items.Clear();
            foreach (OrderProduct orderProduct in Orders.Where(p => p.OrderId == SelectedOrderId).FirstOrDefault().OrderProduct)
            {
                ListViewItem item = new ListViewItem(orderProduct.OrderProductId.ToString());
                item.SubItems.Add(orderProduct.Product.ProductName);
                item.SubItems.Add(orderProduct.Amount.ToString());
                item.SubItems.Add((orderProduct.Status).ToString());
                listView2.Items.Add(item);
            }
        }

        private void listView2_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            OrderProduct orderProduct = Orders.Where(p => p.OrderId == SelectedOrderId).FirstOrDefault().OrderProduct.Where(a => a.OrderProductId == Convert.ToInt32( e.Item.Text)).FirstOrDefault();
            LB_Amount.Text = orderProduct.Amount.ToString();
            LB_ProductName.Text = orderProduct.Product.ProductName;
            SelectedOrderProductId = orderProduct.OrderProductId;
            //LB_Table.Text = 
        }


        /// <summary>
        /// Reload the productlist
        /// </summary>
        private void ReloadOrderProductList()
        {
            List<OrderProduct> Orders = OrderProduct_Service.GetAllByOrder(SelectedOrderId, "Food");

            List<OrderProductViewModel> orderProductViewModel = OrderProduct_Service.OrderProductsToViewModels(Orders);
            //dataGridView2.DataSource = orderProductViewModel;
        }
    }
}
