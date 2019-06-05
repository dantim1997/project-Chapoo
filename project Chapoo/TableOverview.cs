using System;
using ChapooModels;
using ChapooLogic;
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
    public partial class TableOverview : Form
    {
        TableOverview_Service service;
        List<Table> tableList;
        List<ChapooModels.Order> orders;
        Employee employee;
        static Timer timer;


        public TableOverview()
        {
            InitializeComponent();
            service = new TableOverview_Service();
            orders = service.GetOrderList();
            tableList = service.GetTableList();
            UpdateTableStatus();
            UpdateServiceStatus();
            timer = new Timer();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            timer.Interval = 15000;
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Enabled = true;
        }

        private void Timer_Tick(object Sender, EventArgs e)
        {
            orders = service.GetOrderList();
            UpdateTableStatus();
            UpdateServiceStatus();
        }

        public void InfoEmployee(Employee e)
        {
            employee = e;
            lblServerInfo.Text = employee.Name + " " + employee.Surname;
            lblServerIdInfo.Text = employee.EmployeeId.ToString();
        }

        private void UpdateTableStatus()
        {
            foreach (Table table in tableList)
            {
                if (table.Status == "occupied")
                {
                    switch (table.TableNumber)
                    {
                        case 1:
                            btnTable1.Image = Image.FromFile(@"../../Rescources\table-05.png");
                            break;
                        case 2:
                            btnTable2.Image = Image.FromFile(@"../../Rescources\table-05.png");
                            break;
                        case 3:
                            btnTable3.Image = Image.FromFile(@"../../Rescources\table-05.png");
                            break;
                        case 4:
                            btnTable4.Image = Image.FromFile(@"../../Rescources\table-05.png");
                            break;
                        case 5:
                            btnTable5.Image = Image.FromFile(@"../../Rescources\table-05.png");
                            break;
                        case 6:
                            btnTable6.Image = Image.FromFile(@"../../Rescources\table-05.png");
                            break;
                        case 7:
                            btnTable7.Image = Image.FromFile(@"../../Rescources\table-05.png");
                            break;
                        case 8:
                            btnTable8.Image = Image.FromFile(@"../../Rescources\table-05.png");
                            break;
                        case 9:
                            btnTable9.Image = Image.FromFile(@"../../Rescources\table-05.png");
                            break;
                        case 10:
                            btnTable10.Image = Image.FromFile(@"../../Rescources\table-05.png");
                            break;
                    }
                }
            }
        }

        private void UpdateServiceStatus()
        {
            List<ChapooModels.Order> activeOrderlist = service.GetActiveOrderList();

            foreach (ChapooModels.Order order in activeOrderlist)
            {
                switch (order.TableNumber)
                {
                    case 1:
                        if (DateTime.Now.AddMinutes(-20) > order.Date)
                        {
                            btnTable1.Image = Image.FromFile(@"../../Rescources\table-03.png");
                        }
                        else if (DateTime.Now.AddMinutes(-10) > order.Date)
                        {
                            btnTable1.Image = Image.FromFile(@"../../Rescources\table-04.png");
                        }
                        else
                        {
                            btnTable1.Image = Image.FromFile(@"../../Rescources\table-05.png");
                        }
                        break;
                    case 2:
                        if (DateTime.Now.AddMinutes(-20) > order.Date)
                        {
                            btnTable2.Image = Image.FromFile(@"../../Rescources\table-03.png");
                        }
                        else if (DateTime.Now.AddMinutes(-10) > order.Date)
                        {
                            btnTable2.Image = Image.FromFile(@"../../Rescources\table-04.png");
                        }
                        else
                        {
                            btnTable2.Image = Image.FromFile(@"../../Rescources\table-05.png");
                        }
                        break;
                    case 3:
                        if (DateTime.Now.AddMinutes(-20) > order.Date)
                        {
                            btnTable3.Image = Image.FromFile(@"../../Rescources\table-03.png");
                        }
                        else if (DateTime.Now.AddMinutes(-10) > order.Date)
                        {
                            btnTable3.Image = Image.FromFile(@"../../Rescources\table-04.png");
                        }
                        else
                        {
                            btnTable3.Image = Image.FromFile(@"../../Rescources\table-05.png");
                        }
                        break;
                    case 4:
                        if (DateTime.Now.AddMinutes(-20) > order.Date)
                        {
                            btnTable4.Image = Image.FromFile(@"../../Rescources\table-03.png");
                        }
                        else if (DateTime.Now.AddMinutes(-10) > order.Date)
                        {
                            btnTable4.Image = Image.FromFile(@"../../Rescources\table-04.png");
                        }
                        else
                        {
                            btnTable4.Image = Image.FromFile(@"../../Rescources\table-05.png");
                        }
                        break;
                    case 5:
                        if (DateTime.Now.AddMinutes(-20) > order.Date)
                        {
                            btnTable5.Image = Image.FromFile(@"../../Rescources\table-03.png");
                        }
                        else if (DateTime.Now.AddMinutes(-10) > order.Date)
                        {
                            btnTable5.Image = Image.FromFile(@"../../Rescources\table-04.png");
                        }
                        else
                        {
                            btnTable5.Image = Image.FromFile(@"../../Rescources\table-05.png");
                        }
                        break;
                    case 6:
                        if (DateTime.Now.AddMinutes(-20) > order.Date)
                        {
                            btnTable6.Image = Image.FromFile(@"../../Rescources\table-03.png");
                        }
                        else if (DateTime.Now.AddMinutes(-10) > order.Date)
                        {
                            btnTable6.Image = Image.FromFile(@"../../Rescources\table-04.png");
                        }
                        else
                        {
                            btnTable6.Image = Image.FromFile(@"../../Rescources\table-05.png");
                        }
                        break;
                    case 7:
                        if (DateTime.Now.AddMinutes(-20) > order.Date)
                        {
                            btnTable7.Image = Image.FromFile(@"../../Rescources\table-03.png");
                        }
                        else if (DateTime.Now.AddMinutes(-10) > order.Date)
                        {
                            btnTable7.Image = Image.FromFile(@"../../Rescources\table-04.png");
                        }
                        else
                        {
                            btnTable7.Image = Image.FromFile(@"../../Rescources\table-05.png");
                        }
                        break;
                    case 8:
                        if (DateTime.Now.AddMinutes(-20) > order.Date)
                        {
                            btnTable8.Image = Image.FromFile(@"../../Rescources\table-03.png");
                        }
                        else if (DateTime.Now.AddMinutes(-10) > order.Date)
                        {
                            btnTable8.Image = Image.FromFile(@"../../Rescources\table-04.png");
                        }
                        else
                        {
                            btnTable8.Image = Image.FromFile(@"../../Rescources\table-05.png");
                        }
                        break;
                    case 9:
                        if (DateTime.Now.AddMinutes(-20) > order.Date)
                        {
                            btnTable9.Image = Image.FromFile(@"../../Rescources\table-03.png");
                        }
                        else if (DateTime.Now.AddMinutes(-10) > order.Date)
                        {
                            btnTable9.Image = Image.FromFile(@"../../Rescources\table-04.png");
                        }
                        else
                        {
                            btnTable9.Image = Image.FromFile(@"../../Rescources\table-05.png");
                        }
                        break;
                    case 10:
                        if (DateTime.Now.AddMinutes(-20) > order.Date)
                        {
                            btnTable10.Image = Image.FromFile(@"../../Rescources\table-03.png");
                        }
                        else if (DateTime.Now.AddMinutes(-10) > order.Date)
                        {
                            btnTable10.Image = Image.FromFile(@"../../Rescources\table-04.png");
                        }
                        else
                        {
                            btnTable10.Image = Image.FromFile(@"../../Rescources\table-05.png");
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
            this.Close();
        }

        private void btnTable1_Click(object sender, EventArgs e)
        {
            ChapooModels.Order order;
            if (tableList[0].Status == "free")
            {
                string message = "Do you want to set this table occupied.";
                string title = "Assign table";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    tableList = service.GetTableList();
                    order = new ChapooModels.Order();
                    service.CreateOrder(employee.EmployeeId, tableList[0].TableNumber);
                    tableList[0].OrderId = service.GetOrderId();
                    btnTable1.Image = Image.FromFile(@"../../Rescources\table-05.png");
                    service.UpdateTableStatusOccupied("1", "occupied");
                }
            }
            else
            {
                Order orderForm = new Order(20);
                this.Hide();
                orderForm.ShowDialog();
                this.Close();
            }
        }

        private void btnBar1_Click(object sender, EventArgs e)
        {

        }

        private void btnKitchen1_Click(object sender, EventArgs e)
        {

        }

        private void btnTable2_Click(object sender, EventArgs e)
        {
            ChapooModels.Order order;
            if (tableList[1].Status == "free")
            {
                string message = "Do you want to set this table occupied.";
                string title = "Assign table";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    tableList = service.GetTableList();
                    order = new ChapooModels.Order();
                    service.CreateOrder(employee.EmployeeId, tableList[1].TableNumber);
                    tableList[1].OrderId = service.GetOrderId();
                    btnTable2.Image = Image.FromFile(@"../../Rescources\table-05.png");
                    service.UpdateTableStatusOccupied("2", "occupied");
                }
            }
            else
            {
                Order orderForm = new Order(20);
                this.Hide();
                orderForm.ShowDialog();
                this.Close();
            }
        }

    }
}
