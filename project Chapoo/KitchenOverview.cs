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
        Order_Service Order_Service = new Order_Service();
        OrderProduct_Service OrderProduct_Service = new OrderProduct_Service();
        List<ChapooModels.Order> Orders = new List<ChapooModels.Order>();
        ChapooModels.Order order1, order2, order3, order4;
        List<Label> LabelsName, LabelsTable;

        /// <summary>
        /// when the program is opened
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KitchenOverview_Load(object sender, EventArgs e)
        {
        }

        public KitchenOverview(string TypeOfView)
        {
            int i = 0;
            InitializeComponent();
            Orders = Order_Service.GetOrders(TypeOfView);
            foreach (ChapooModels.Order order in Orders)
            {
                switch (i)
                {
                    case 0: order1 = order; break;
                    case 1: order2 = order; break;
                    case 2: order3 = order; break;
                    case 3: order4 = order; break;
                }
                i++;
            }
            Orders.Remove(order1);
            Orders.Remove(order2);
            Orders.Remove(order3);
            Orders.Remove(order4);
            Order1(order1);
            Order2(order2);
            Order3(order3);
            Order4(order4);
        }

        private void btn_Order1_Click(object sender, EventArgs e)
        {
            Order_Service.UpdateStatus("Done", order1.OrderId);
            OrderProduct_Service.UpdateAllStatus(order1.OrderProduct, Statustype.Bereid);
            lv_Order1.Items.Clear();
            lb_NameOrder1.Text = string.Empty;
            lb_TableOrder1.Text = string.Empty;
            NewOrder(1);
        }

        private void btn_Order2_Click(object sender, EventArgs e)
        {
            Order_Service.UpdateStatus("Done", order2.OrderId);
            OrderProduct_Service.UpdateAllStatus(order1.OrderProduct, Statustype.Bereid);
            lv_Order2.Items.Clear();
            lb_NameOrder2.Text = string.Empty;
            lb_TableOrder2.Text = string.Empty;
            NewOrder(2);
        }

        private void btn_Order3_Click(object sender, EventArgs e)
        {
            Order_Service.UpdateStatus("Done", order3.OrderId);
            OrderProduct_Service.UpdateAllStatus(order1.OrderProduct, Statustype.Bereid);
            lv_Order3.Items.Clear();
            lb_NameOrder3.Text = string.Empty;
            lb_TableOrder3.Text = string.Empty;
            NewOrder(3);
        }

        private void btn_Order4_Click(object sender, EventArgs e)
        {
            Order_Service.UpdateStatus("Done", order4.OrderId);
            OrderProduct_Service.UpdateAllStatus(order1.OrderProduct, Statustype.Bereid);
            lv_Order4.Items.Clear();
            lb_NameOrder4.Text = string.Empty;
            lb_TableOrder4.Text = string.Empty;
            NewOrder(4);
        }

        private void Order1(ChapooModels.Order order)
        {
            if (order != null)
            {
                lb_NameOrder1.Text = order.EmployeeId.ToString();
                lb_TableOrder1.Text = order.TableNumber.ToString();
                lv_Order1.Items.Clear();
                foreach (OrderProduct orderProduct in order.OrderProduct)
                {
                    ListViewItem item = new ListViewItem(orderProduct.OrderProductId.ToString());
                    item.SubItems.Add(orderProduct.Product.ProductName);
                    item.SubItems.Add(orderProduct.Amount.ToString());
                    item.SubItems.Add((orderProduct.Status).ToString());
                    lv_Order1.Items.Add(item);
                }
            }
        }

        private void Order2(ChapooModels.Order order)
        {
            if (order != null)
            {
                lb_NameOrder2.Text = order.EmployeeId.ToString();
                lb_TableOrder2.Text = order.TableNumber.ToString();
                lv_Order2.Items.Clear();
                foreach (OrderProduct orderProduct in order.OrderProduct)
                {
                    ListViewItem item = new ListViewItem(orderProduct.OrderProductId.ToString());
                    item.SubItems.Add(orderProduct.Product.ProductName);
                    item.SubItems.Add(orderProduct.Amount.ToString());
                    item.SubItems.Add((orderProduct.Status).ToString());
                    lv_Order2.Items.Add(item);
                }
            }
        }

        private void Order3(ChapooModels.Order order)
        {
            if (order != null)
            {
                lb_NameOrder3.Text = order.EmployeeId.ToString();
                lb_TableOrder3.Text = order.TableNumber.ToString();
                lv_Order3.Items.Clear();
                foreach (OrderProduct orderProduct in order.OrderProduct)
                {
                    ListViewItem item = new ListViewItem(orderProduct.OrderProductId.ToString());
                    item.SubItems.Add(orderProduct.Product.ProductName);
                    item.SubItems.Add(orderProduct.Amount.ToString());
                    item.SubItems.Add((orderProduct.Status).ToString());
                    lv_Order3.Items.Add(item);
                }
            }
        }

        private void Order4(ChapooModels.Order order)
        {
            if (order != null)
            {
                lb_NameOrder4.Text = order.EmployeeId.ToString();
                lb_TableOrder4.Text = order.TableNumber.ToString();
                lv_Order4.Items.Clear();
                foreach (OrderProduct orderProduct in order.OrderProduct)
                {
                    ListViewItem item = new ListViewItem(orderProduct.OrderProductId.ToString());
                    item.SubItems.Add(orderProduct.Product.ProductName);
                    item.SubItems.Add(orderProduct.Amount.ToString());
                    item.SubItems.Add((orderProduct.Status).ToString());
                    lv_Order4.Items.Add(item);
                }
            }
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
            this.Close();
        }

        private void NewOrder(int orderNumber)
        {
            if (Orders.Count != 0)
            {
                if (orderNumber == 1)
                {
                    ChapooModels.Order order = Orders.FirstOrDefault();
                    Order1(order);
                    Orders.Remove(order);
                }
                if (orderNumber == 2)
                {
                    ChapooModels.Order order = Orders.FirstOrDefault();
                    Order2(order);
                    Orders.Remove(order);
                }
                if (orderNumber == 3)
                {
                    ChapooModels.Order order = Orders.FirstOrDefault();
                    Order3(order);
                    Orders.Remove(order);
                }
                if (orderNumber == 4)
                {
                    ChapooModels.Order order = Orders.FirstOrDefault();
                    Order4(order);
                    Orders.Remove(order);
                }
            }
        }
    }
}
