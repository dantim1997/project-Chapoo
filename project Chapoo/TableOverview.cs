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
        Button[] btnList;

        public TableOverview(Employee employee) // employee
        {
            InitializeComponent();
            this.employee = employee;
            service = new TableOverview_Service();
            btnList = new Button[10] { btnTable1, btnTable2, btnTable3, btnTable4, btnTable5, btnTable6, btnTable7, btnTable8, btnTable9, btnTable10 };
            orders = service.GetOrderList();
            tableList = service.GetTableList();
            UpdateTableStatus();
            //UpdateServiceStatus();
            //all buttons.
            timer = new Timer();
            InitializeTimer();

            // ...
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
            //UpdateServiceStatus();
        }

        public void InfoEmployee()
        {
            lblServerInfo.Text = employee.Name + " " + employee.Surname;
            lblServerIdInfo.Text = employee.EmployeeId.ToString();
        }

        //private void UpdateTableStatus()
        //{
        //    foreach (Table table in tableList)
        //    {
        //        if (table.Status == "occupied")
        //        {
        //            switch (table.TableNumber)
        //            {
        //                case 1:
        //                    btnTable1.Image = Image.FromFile(@"../../Rescources\table-05.png");
        //                    break;
        //                case 2:
        //                    btnTable2.Image = Image.FromFile(@"../../Rescources\table-05.png");
        //                    break;
        //                case 3:
        //                    btnTable3.Image = Image.FromFile(@"../../Rescources\table-05.png");
        //                    break;
        //                case 4:
        //                    btnTable4.Image = Image.FromFile(@"../../Rescources\table-05.png");
        //                    break;
        //                case 5:
        //                    btnTable5.Image = Image.FromFile(@"../../Rescources\table-05.png");
        //                    break;
        //                case 6:
        //                    btnTable6.Image = Image.FromFile(@"../../Rescources\table-05.png");
        //                    break;
        //                case 7:
        //                    btnTable7.Image = Image.FromFile(@"../../Rescources\table-05.png");
        //                    break;
        //                case 8:
        //                    btnTable8.Image = Image.FromFile(@"../../Rescources\table-05.png");
        //                    break;
        //                case 9:
        //                    btnTable9.Image = Image.FromFile(@"../../Rescources\table-05.png");
        //                    break;
        //                case 10:
        //                    btnTable10.Image = Image.FromFile(@"../../Rescources\table-05.png");
        //                    break;
        //            }
        //        }
        //    }
        //}

        private void UpdateTableStatus()
        {
            List<ChapooModels.Order> activeOrderlist = service.GetActiveOrderList();

            foreach (ChapooModels.Order order in activeOrderlist)
            {
                if (DateTime.Now.AddMinutes(-20) > order.Date)
                {
                    btnList[order.TableNumber - 1].Image = Image.FromFile(@"../../Rescources\table-03.png");
                }
                else if (DateTime.Now.AddMinutes(-10) > order.Date)
                {
                    btnList[order.TableNumber - 1].Image = Image.FromFile(@"../../Rescources\table-04.png");
                }
                else
                {
                    btnList[order.TableNumber - 1].Image = Image.FromFile(@"../../Rescources\table-05.png");
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
            Button btn = (Button)sender;
            int tafelIndex = int.Parse(btn.Text) - 1;
            tableList = service.GetTableList();

            ChapooModels.Order order;
            if (tableList[tafelIndex].Status == "free")
            {
                string message = "Do you want to set this table occupied.";
                string title = "Assign table";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    order = new ChapooModels.Order();
                    service.CreateOrder(employee.EmployeeId, "new", tableList[tafelIndex].TableNumber);
                    tableList[tafelIndex].OrderId = service.GetOrderId();
                    btn.Image = Image.FromFile(@"../../Rescources\table-05.png");
                    service.UpdateTableStatusOccupied((tafelIndex + 1).ToString(), "occupied");
                }
            }
            else
            {
                Order orderForm = new Order(employee);
                this.Hide();
                orderForm.ShowDialog();
                this.Close();
            }
        }

        private void btnBar1_Click(object sender, EventArgs e)
        {
            if (true)
            {
                string message = "Set drinks delivered?";
                string title = "Update servings";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {

                }
            }
        }
        private void btnKitchen1_Click(object sender, EventArgs e)
        {

        }

    }
}
