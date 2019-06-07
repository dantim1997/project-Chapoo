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
        List<ChapooModels.Order> activeOrderlist;
        Employee employee;
        static Timer timer;
        Button[] btnListTable;
        Button[] btnListBar;
        Button[] btnListKitchen;

        public TableOverview(Employee employee) // employee
        {
            InitializeComponent();
            this.employee = employee;
            service = new TableOverview_Service();
            btnListTable = new Button[10] { btnTable1, btnTable2, btnTable3, btnTable4, btnTable5, btnTable6, btnTable7, btnTable8, btnTable9, btnTable10 };
            btnListBar = new Button[10] { btnBar1, btnBar2, btnBar3, btnBar4, btnBar5, btnBar6, btnBar7, btnBar8, btnBar9, btnBar10 };
            btnListKitchen = new Button[10] { btnKitchen1, btnKitchen2, btnKitchen3, btnKitchen4, btnKitchen5, btnKitchen6, btnKitchen7, btnKitchen8, btnKitchen9, btnKitchen10 };
            orders = service.GetOrderList();
            tableList = service.GetTableList();
            UpdateTableStatus();
            ServiceBtnUpdate("Drink");
            ServiceBtnUpdate("Food");
            InfoEmployee();
            timer = new Timer();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            timer.Interval = 30000;
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Enabled = true;
        }

        private void Timer_Tick(object Sender, EventArgs e)
        {
            orders = service.GetOrderList();
            UpdateTableStatus();
            ServiceBtnUpdate("Drink");
            ServiceBtnUpdate("Food");
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
            activeOrderlist = service.GetActiveOrderList();

            foreach (ChapooModels.Order order in activeOrderlist)
            {
                if (DateTime.Now.AddMinutes(-20) > order.Date)
                {
                    btnListTable[order.TableNumber - 1].Image = Image.FromFile(@"../../Rescources\table-03.png");
                }
                else if (DateTime.Now.AddMinutes(-10) > order.Date)
                {
                    btnListTable[order.TableNumber - 1].Image = Image.FromFile(@"../../Rescources\table-04.png");
                }
                else
                {
                    btnListTable[order.TableNumber - 1].Image = Image.FromFile(@"../../Rescources\table-05.png");
                }
            }
        }

        private void ServiceBtnUpdate(string type)
        {
            List<OrderProduct> activeOrderProductList = service.GetActiveOrderProductList(type);

            foreach (ChapooModels.Order order in activeOrderlist)
            {
                foreach (OrderProduct orderProduct in activeOrderProductList)
                {
                    if (order.OrderId == orderProduct.OrderId)
                    {
                        if (type == "Drink")
                        {
                            switch (orderProduct.Status)
                            {
                                case Statustype.Bereid:
                                    btnListBar[order.TableNumber - 1].Image = Image.FromFile(@"../../Rescources\btnBestelling_btnBestellingGroen.png");
                                    break;
                                case Statustype.Open:
                                    btnListBar[order.TableNumber - 1].Image = Image.FromFile(@"../../Rescources\btnBestelling_btnBestellingGeel.png");
                                    break;
                                case Statustype.Afgehandeld:
                                    btnListBar[order.TableNumber - 1].Image = Image.FromFile(@"../../Rescources\btnBestelling_btnBestellingGrijs.png");
                                    break;
                            }
                        }
                        else
                        {
                            switch (orderProduct.Status)
                            {
                                case Statustype.Bereid:
                                    btnListKitchen[order.TableNumber - 1].Image = Image.FromFile(@"../../Rescources\btnBestelling_btnBestellingGroen.png");
                                    break;
                                case Statustype.Open:
                                    btnListKitchen[order.TableNumber - 1].Image = Image.FromFile(@"../../Rescources\btnBestelling_btnBestellingGeel.png");
                                    break;
                                case Statustype.Afgehandeld:
                                    btnListKitchen[order.TableNumber - 1].Image = Image.FromFile(@"../../Rescources\btnBestelling_btnBestellingGrijs.png");
                                    break;
                            }
                        }

                    }
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
            Button btn = (Button)sender;
            int tafelIndex = int.Parse(btn.Tag.ToString());


            string message = "Set drinks delivered?";
            string title = "Update servings";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                service.UpdateOrderProductStatus(tafelIndex, Statustype.Bereid, ">=");
                btnListBar[tafelIndex - 1].Image = Image.FromFile(@"../../Rescources\btnBestelling_btnBestellingGrijs.png");
            }

        }
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
                service.UpdateOrderProductStatus(tafelIndex, Statustype.Bereid, "<=");
                btnListKitchen[tafelIndex - 1].Image = Image.FromFile(@"../../Rescources\btnBestelling_btnBestellingGrijs.png");
            }

        }

    }
}
