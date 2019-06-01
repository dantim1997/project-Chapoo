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
        Employee_Service Employee_Service = new Employee_Service();
        List<ChapooModels.Order> Orders = new List<ChapooModels.Order>();
        ChapooModels.Order order1, order2, order3, order4;
        List<Employee> employees = new List<Employee>();
        Employee CurrentEmployee;
        Dictionary<string, Label> labels = new Dictionary<string, Label>();
        Dictionary<string, ListView> listviews = new Dictionary<string, ListView>();
        string TypeOfView;
        int LastOrderId;

        /// <summary>
        /// when the program is opened
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KitchenOverview_Load(object sender, EventArgs e)
        {
            labels.Add("name1", lb_NameOrder1);
            labels.Add("name2", lb_NameOrder2);
            labels.Add("name3", lb_NameOrder3);
            labels.Add("name4", lb_NameOrder4);

            labels.Add("table1", lb_TableOrder1);
            labels.Add("table2", lb_TableOrder2);
            labels.Add("table3", lb_TableOrder3);
            labels.Add("table4", lb_TableOrder4);

            listviews.Add("lv1", lv_Order1);
            listviews.Add("lv2", lv_Order2);
            listviews.Add("lv3", lv_Order3);
            listviews.Add("lv4", lv_Order4);

            Label label = labels["name" + 1];

            employees = Employee_Service.GetAllEmployees();

            int i = 0;
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
            Order(order1, 1);
            Order(order2, 2);
            Order(order3, 3);
            Order(order4, 4);
        }

        public KitchenOverview(string typeOfView, Employee employee)
        {
            InitializeComponent();
            TypeOfView = typeOfView;
            CurrentEmployee = employee;
            lbl_Loginname.Text = employee.Fullname;
            lbl_LoginID.Text = employee.EmployeeId.ToString();

        }

        private void Order(ChapooModels.Order order, int ordernumber)
        {
            if (order != null)
            {
                switch (ordernumber)
                {
                    case 1: order1 = order; break;
                    case 2: order1 = order; break;
                    case 3: order1 = order; break;
                    case 4: order1 = order; break;
                }
                labels["name" + ordernumber].Text = employees.Where(p => p.EmployeeId == order.EmployeeId).FirstOrDefault().Fullname;
                labels["table" + ordernumber].Text = order.TableNumber.ToString();
                listviews["lv" + ordernumber].Items.Clear();
                foreach (OrderProduct orderProduct in order.OrderProduct)
                {
                    ListViewItem item = new ListViewItem(orderProduct.OrderProductId.ToString());
                    item.SubItems.Add(orderProduct.Product.ProductName);
                    item.SubItems.Add(orderProduct.Amount.ToString());
                    item.SubItems.Add((orderProduct.Status).ToString());
                    listviews["lv" + ordernumber].Items.Add(item);
                }
                LastOrderId = order.OrderId;
            }
        }

        private void btn_Order1_Click(object sender, EventArgs e)
        {
            Order_Service.UpdateStatus("Done", order1.OrderId);
            OrderProduct_Service.UpdateAllStatus(order1.OrderProduct, Statustype.Bereid);
            lv_Order1.Items.Clear();
            lb_NameOrder1.Text = string.Empty;
            lb_TableOrder1.Text = string.Empty;
            order1 = null;
            NewOrder(1);
        }

        private void btn_Order2_Click(object sender, EventArgs e)
        {
            Order_Service.UpdateStatus("Done", order2.OrderId);
            OrderProduct_Service.UpdateAllStatus(order1.OrderProduct, Statustype.Bereid);
            lv_Order2.Items.Clear();
            lb_NameOrder2.Text = string.Empty;
            lb_TableOrder2.Text = string.Empty;
            order2 = null;
            NewOrder(2);
        }

        private void btn_Order3_Click(object sender, EventArgs e)
        {
            Order_Service.UpdateStatus("Done", order3.OrderId);
            OrderProduct_Service.UpdateAllStatus(order1.OrderProduct, Statustype.Bereid);
            lv_Order3.Items.Clear();
            lb_NameOrder3.Text = string.Empty;
            lb_TableOrder3.Text = string.Empty;
            order3 = null;
            NewOrder(3);
        }

        private void btn_Order4_Click(object sender, EventArgs e)
        {
            Order_Service.UpdateStatus("Done", order4.OrderId);
            OrderProduct_Service.UpdateAllStatus(order1.OrderProduct, Statustype.Bereid);
            lv_Order4.Items.Clear();
            lb_NameOrder4.Text = string.Empty;
            lb_TableOrder4.Text = string.Empty;
            order4 = null;
            NewOrder(4);
        }

        private void btn_reload_Click(object sender, EventArgs e)
        {
            List<ChapooModels.Order> newOrders = Order_Service.GetOrdersAboveID(TypeOfView, Orders.Count-1);
            foreach (ChapooModels.Order order in newOrders)
            {
                Orders.Add(order);
            }
            if(order1 == null)
            {
                NewOrder(1);
            }
            if (order2 == null)
            {
                NewOrder(2);
            }
            if (order3 == null)
            {
                NewOrder(3);
            }
            if (order4 == null)
            {
                NewOrder(4);
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
                ChapooModels.Order order = Orders.FirstOrDefault();
                Order(order, orderNumber);
                Orders.Remove(order);
            }
        }
    }
}
