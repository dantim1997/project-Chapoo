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

            labels.Add("time1", lbl_TimeOrder1);
            labels.Add("time2", lbl_TimeOrder2);
            labels.Add("time3", lbl_TimeOrder3);
            labels.Add("time4", lbl_TimeOrder4);

            labels.Add("note1", lb_NoteOrder1);
            labels.Add("note2", lb_NoteOrder2);
            labels.Add("note3", lb_NoteOrder3);
            labels.Add("note4", lb_NoteOrder4);

            listviews.Add("lv1", lv_Order1);
            listviews.Add("lv2", lv_Order2);
            listviews.Add("lv3", lv_Order3);
            listviews.Add("lv4", lv_Order4);

            Label label = labels["name" + 1];

            order1 = new ChapooModels.Order();
            order2 = new ChapooModels.Order();
            order3 = new ChapooModels.Order();
            order4 = new ChapooModels.Order();

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

        /// <summary>
        /// constructor for the from kitchenoverview
        /// </summary>
        /// <param name="employee"></param>
        public KitchenOverview(Employee employee)
        {
            InitializeComponent();
            if (employee.TypeWorker == "cook") { TypeOfView = "Food"; }
            if (employee.TypeWorker == "bar") { TypeOfView = "Drink"; }
            CurrentEmployee = employee;
            lbl_Loginname.Text = employee.Fullname;
            lbl_LoginID.Text = employee.EmployeeId.ToString();

        }

        /// <summary>
        /// shows the order in the right collumn
        /// </summary>
        /// <param name="order"></param>
        /// <param name="ordernumber"></param>
        private void Order(ChapooModels.Order order, int ordernumber)
        {
            if (order.OrderId == 0)
                return;

            switch (ordernumber)
            {
                case 1: order1 = order; break;
                case 2: order2 = order; break;
                case 3: order3 = order; break;
                case 4: order4 = order; break;
            }
            labels["name" + ordernumber].Text = employees.Where(p => p.EmployeeId == order.EmployeeId).FirstOrDefault().Fullname;
            labels["table" + ordernumber].Text = order.TableNumber.ToString();
            labels["time" + ordernumber].Text = order.Date.ToString("HH:mm");
            listviews["lv" + ordernumber].Items.Clear();
            string note = "";
            foreach (OrderProduct orderProduct in order.OrderProduct)
            {
                if (orderProduct.Note != string.Empty)
                {
                    note += orderProduct.Product.ProductName + ": " + orderProduct.Note + Environment.NewLine;
                }
                ListViewItem item = new ListViewItem(orderProduct.OrderProductId.ToString());
                item.SubItems.Add(orderProduct.Product.ProductName);
                item.SubItems.Add(orderProduct.Amount.ToString());
                item.SubItems.Add((orderProduct.Status).ToString());
                listviews["lv" + ordernumber].Items.Add(item);
            }
            labels["note" + ordernumber].Text = note;
        }

        /// <summary>
        /// on button1 click 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Order1_Click(object sender, EventArgs e)
        {
            OrderProduct_Service.UpdateAllStatus(order1.OrderProduct, Statustype.Bereid);
            order1 = new ChapooModels.Order();
            SetOrderInView(1);
        }

        /// <summary>
        /// on button2 click 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Order2_Click(object sender, EventArgs e)
        {
            OrderProduct_Service.UpdateAllStatus(order2.OrderProduct, Statustype.Bereid);
            order2 = new ChapooModels.Order();
            SetOrderInView(2);
        }

        /// <summary>
        /// on button3 click 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Order3_Click(object sender, EventArgs e)
        {
            OrderProduct_Service.UpdateAllStatus(order3.OrderProduct, Statustype.Bereid);
            order3 = new ChapooModels.Order();
            SetOrderInView(3);
        }

        /// <summary>
        /// on button4 click 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Order4_Click(object sender, EventArgs e)
        {
            OrderProduct_Service.UpdateAllStatus(order4.OrderProduct, Statustype.Bereid);
            order4 = new ChapooModels.Order();
            SetOrderInView(4);
        }

        /// <summary>
        /// get all new orders from the database and put them in the orderlist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_reload_Click(object sender, EventArgs e)
        {
            List<ChapooModels.Order> newOrders = Order_Service.GetOrders(TypeOfView);
            foreach (ChapooModels.Order order in newOrders)
            {
                if (Orders.Exists(t => t.OrderId == order.OrderId) == false &&
                    order1.OrderId != order.OrderId &&
                    order2.OrderId != order.OrderId &&
                    order3.OrderId != order.OrderId &&
                    order4.OrderId != order.OrderId)
                {
                    Orders.Add(order);
                }
            }
            if (order1.OrderId == 0)
            {
                SetOrderInView(1);
            }
            if (order2.OrderId == 0)
            {
                SetOrderInView(2);
            }
            if (order3.OrderId == 0)
            {
                SetOrderInView(3);
            }
            if (order4.OrderId == 0)
            {
                SetOrderInView(4);
            }
        }

        /// <summary>
        /// logs the cook out and goes to the login screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
            this.Close();
        }

        /// <summary>
        /// when the order is set on done the SetOrderinView will set the first order in the list in the view
        /// </summary>
        /// <param name="orderNumber"></param>
        private void SetOrderInView(int orderNumber)
        {
            labels["name" + orderNumber].Text = string.Empty;
            labels["table" + orderNumber].Text = string.Empty; ;
            labels["time" + orderNumber].Text = string.Empty;
            listviews["lv" + orderNumber].Items.Clear();
            labels["note" + orderNumber].Text = "No Note";
            if (Orders.Count != 0)
            {
                ChapooModels.Order order = Orders.FirstOrDefault();
                Order(order, orderNumber);
                Orders.Remove(order);
            }
        }
    }
}
