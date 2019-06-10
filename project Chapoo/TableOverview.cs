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
        private TableOverview_Service Service;
        private List<Table> TableList;
        private List<ChapooModels.Order> ActiveOrderlist;
        private List<OrderProduct> ActiveOrderProductList;
        private Employee Employee;
        private static Timer Timer;
        private static Timer UpdateTimer;
        private Button[] BtnListTable;
        private Button[] BtnListBar;
        private Button[] BtnListKitchen;

        public TableOverview(Employee employee) // Employee
        {
            InitializeComponent();
            this.Employee = employee;
            Service = new TableOverview_Service();
            BtnListTable = new Button[10] { btnTable1, btnTable2, btnTable3, btnTable4, btnTable5, btnTable6, btnTable7, btnTable8, btnTable9, btnTable10 };
            BtnListBar = new Button[10] { btnBar1, btnBar2, btnBar3, btnBar4, btnBar5, btnBar6, btnBar7, btnBar8, btnBar9, btnBar10 };
            BtnListKitchen = new Button[10] { btnKitchen1, btnKitchen2, btnKitchen3, btnKitchen4, btnKitchen5, btnKitchen6, btnKitchen7, btnKitchen8, btnKitchen9, btnKitchen10 };
            TableList = Service.GetTableList();
            ActiveOrderlist = Service.GetActiveOrderList();
            ActiveOrderProductList = Service.GetActiveOrderProductList();
            UpdateTableStatus();
            ServiceBtnUpdate();
            InfoEmployee();
            Timer = new Timer();
            UpdateTimer = new Timer();
            InitializeTimer();
            InitializeUpdateTimer();
        }

        private void InitializeUpdateTimer()
        {
            UpdateTimer.Interval = 10000;
            UpdateTimer.Tick += new EventHandler(UpdateTimer_Tick);
            UpdateTimer.Enabled = true;
        }

        private void InitializeTimer()
        {
            Timer.Interval = 10000;
            Timer.Tick += new EventHandler(Timer_Tick);
            Timer.Enabled = true;
        }
        /// <summary>
        /// This method refreshes the ActiveOrderList and the ActiveOrderProductList every 10 seconds.
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        private void UpdateTimer_Tick(object Sender, EventArgs e)
        {
            ActiveOrderlist = Service.GetActiveOrderList();
            ActiveOrderProductList = Service.GetActiveOrderProductList();
        }
        /// <summary>
        /// This method calls the methodes ServiceBtnUpdate and UpdateTableStatus every 10 seconds.
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object Sender, EventArgs e)
        {
            UpdateTableStatus();
            ServiceBtnUpdate();
        }
        /// <summary>
        /// This method displays the Employee name and ID.
        /// </summary>
        public void InfoEmployee()
        {
            lblServerInfo.Text = Employee.Name + " " + Employee.Surname;
            lblServerIdInfo.Text = Employee.EmployeeId.ToString();
        }
        /// <summary>
        ///  This method Updates the tablecolor for every order if order.Date with that tablenumber is +15 or +30 minutes.
        /// </summary>
        private void UpdateTableStatus()
        {
            foreach (ChapooModels.Order order in ActiveOrderlist)
            {
                if (DateTime.Now.AddMinutes(-30) > order.Date)
                {
                    BtnListTable[order.TableNumber - 1].BackgroundImage = Image.FromFile(@"../../Rescources\table-03.png");
                }
                else if (DateTime.Now.AddMinutes(-15) > order.Date)
                {
                    BtnListTable[order.TableNumber - 1].BackgroundImage = Image.FromFile(@"../../Rescources\table-04.png");
                }
                else
                {
                    BtnListTable[order.TableNumber - 1].BackgroundImage = Image.FromFile(@"../../Rescources\table-05.png");
                }
            }
        }
        /// <summary>
        /// This method updates the buttoncolor of btnKitchen and btnBar is the OrderProduct.Status has changed.
        /// </summary>
        private void ServiceBtnUpdate()
        {
            foreach (ChapooModels.Order order in ActiveOrderlist)
            {
                foreach (OrderProduct orderProduct in ActiveOrderProductList)
                {
                    if (order.OrderId == orderProduct.OrderId)
                    {
                        if (orderProduct.Product.ProductId >= 22)
                        {
                            switch (orderProduct.Status)
                            {
                                case Statustype.Bereid:
                                    BtnListBar[order.TableNumber - 1].BackgroundImage = Image.FromFile(@"../../Rescources\btnBestelling_btnBestellingGroen.png");
                                    break;
                                case Statustype.Open:
                                    BtnListBar[order.TableNumber - 1].BackgroundImage = Image.FromFile(@"../../Rescources\btnBestelling_btnBestellingGeel.png");
                                    break;
                                case Statustype.Afgehandeld:
                                    BtnListBar[order.TableNumber - 1].BackgroundImage = Image.FromFile(@"../../Rescources\btnBestelling_btnBestellingGrijs.png");
                                    break;
                            }
                        }
                        else
                        {
                            switch (orderProduct.Status)
                            {
                                case Statustype.Bereid:
                                    BtnListKitchen[order.TableNumber - 1].BackgroundImage = Image.FromFile(@"../../Rescources\btnBestelling_btnBestellingGroen.png");
                                    break;
                                case Statustype.Open:
                                    BtnListKitchen[order.TableNumber - 1].BackgroundImage = Image.FromFile(@"../../Rescources\btnBestelling_btnBestellingGeel.png");
                                    break;
                                case Statustype.Afgehandeld:
                                    BtnListKitchen[order.TableNumber - 1].BackgroundImage = Image.FromFile(@"../../Rescources\btnBestelling_btnBestellingGrijs.png");
                                    break;
                            }
                        }

                    }
                }
            }
        }
        /// <summary>
        /// This method is for the btnLogOut. It closed the TableOverview and opens the Login form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
            this.Close();
        }
        /// <summary>
        /// This method is for the buttons btnTable. This button opens the Order form with the right tablenumber. If the table.Status is 'free' it will set the table.status to 'occupied' and creates a new Order Object.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTable1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int tableIndex = int.Parse(btn.Text) - 1;
            TableList = Service.GetTableList();

            ChapooModels.Order order;
            if (TableList[tableIndex].Status == "free")
            {
                string message = "Do you want to set this table occupied.";
                string title = "Assign table";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    order = new ChapooModels.Order();
                    Service.CreateOrder(Employee.EmployeeId, "new", TableList[tableIndex].TableNumber);
                    TableList[tableIndex].OrderId = Service.GetOrderId(tableIndex + 1);
                    btn.BackgroundImage = Image.FromFile(@"../../Rescources\table-05.png");
                    Service.UpdateTableStatus((tableIndex + 1), "occupied");
                }
            }
            else
            {
                TableList[tableIndex].OrderId = Service.GetOrderId(tableIndex + 1);
                Order orderForm = new Order(Employee, TableList[tableIndex]);
                this.Hide();
                orderForm.ShowDialog();
                this.Close();
            }
        }
        /// <summary>
        /// This method is for the buttons btnBar. This button will update the OpderProduct.Status to 'afgehandeld' and updates the Order.Date to DateTime.Now. Then it changes the buttons color to gray.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBar1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int tableIndex = int.Parse(btn.Tag.ToString());


            string message = "Set drinks delivered?";
            string title = "Update servings";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                Service.UpdateOrderProductStatus(tableIndex, Statustype.Afgehandeld, ">=");
                Service.UpdateOrderTime(tableIndex);
                ActiveOrderlist = Service.GetActiveOrderList();
                UpdateTableStatus();
                BtnListBar[tableIndex - 1].BackgroundImage = Image.FromFile(@"../../Rescources\btnBestelling_btnBestellingGrijs.png");
            }

        }
        /// <summary>
        /// This method is for the buttons btnKitchen. This button will update the OpderProduct.Status to 'afgehandeld' and updates the Order.Date to DateTime.Now. Then it changes the buttons color to gray.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnKitchen1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int tafelIndex = int.Parse(btn.Tag.ToString());


            string message = "Set food delivered?";
            string title = "Update servings";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                Service.UpdateOrderProductStatus(tafelIndex, Statustype.Afgehandeld, "<=");
                Service.UpdateOrderTime(tafelIndex);
                ActiveOrderlist = Service.GetActiveOrderList();
                UpdateTableStatus();
                BtnListKitchen[tafelIndex - 1].BackgroundImage = Image.FromFile(@"../../Rescources\btnBestelling_btnBestellingGrijs.png");
            }

        }

    }
}
