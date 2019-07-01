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
        private List<Product> ProductList;
        private Employee Employee;
        private static Timer Timer;// kan ook megegeven.
        private Button[] BtnListTable;
        private Button[] BtnListBar;
        private Button[] BtnListKitchen;
        private Dictionary<Images, Image> ButtonImages;

        public TableOverview(Employee employee) // Employee
        {
            InitializeComponent();
            this.Employee = employee;
            Service = new TableOverview_Service();
            BtnListTable = new Button[10] { btnTable1, btnTable2, btnTable3, btnTable4, btnTable5, btnTable6, btnTable7, btnTable8, btnTable9, btnTable10 };
            BtnListBar = new Button[10] { btnBar1, btnBar2, btnBar3, btnBar4, btnBar5, btnBar6, btnBar7, btnBar8, btnBar9, btnBar10 };
            BtnListKitchen = new Button[10] { btnKitchen1, btnKitchen2, btnKitchen3, btnKitchen4, btnKitchen5, btnKitchen6, btnKitchen7, btnKitchen8, btnKitchen9, btnKitchen10 };
            ButtonImages = new Dictionary<Images, Image>();
            LoadImages();
            TableList = Service.GetTableList();
            ActiveOrderlist = Service.GetActiveOrderList();
            ActiveOrderProductList = Service.GetActiveOrderProductList();
            ProductList = Service.GetProductList();
            UpdateTableStatus();
            ServiceBtnUpdate();
            InfoEmployee();
            InitializeTimer();
        }

        private void LoadImages()
        {
            ButtonImages.Add(Images.btnTableGray, Image.FromFile(@"../../Rescources\table-02.png"));
            ButtonImages.Add(Images.btnTableRed, Image.FromFile(@"../../Rescources\table-03.png"));
            ButtonImages.Add(Images.btnTableYellow, Image.FromFile(@"../../Rescources\table-04.png"));
            ButtonImages.Add(Images.btnTableGreen, Image.FromFile(@"../../Rescources\table-05.png"));
            ButtonImages.Add(Images.btnServiceGray, Image.FromFile(@"../../Rescources\btnBestelling_btnBestellingGrijs.png"));
            ButtonImages.Add(Images.btnServiceGreen, Image.FromFile(@"../../Rescources\btnBestelling_btnBestellingGroen.png"));
            ButtonImages.Add(Images.btnServiceYellow, Image.FromFile(@"../../Rescources\btnBestelling_btnBestellingGeel.png"));
        }

        private void InitializeTimer()
        {
            Timer = new Timer();
            Timer.Interval = 10000;
            Timer.Tick += new EventHandler(Timer_Tick);
            Timer.Enabled = true;
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
            ActiveOrderlist = Service.GetActiveOrderList();
            ActiveOrderProductList = Service.GetActiveOrderProductList();
        }
        /// <summary>
        /// This method displays the Employee name and ID.
        /// </summary>
        private void InfoEmployee()
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
                    BtnListTable[order.TableNumber - 1].BackgroundImage = ButtonImages[Images.btnTableRed];
                }
                else if (DateTime.Now.AddMinutes(-15) > order.Date)
                {
                    BtnListTable[order.TableNumber - 1].BackgroundImage = ButtonImages[Images.btnTableYellow];
                }
                else
                {
                    BtnListTable[order.TableNumber - 1].BackgroundImage = ButtonImages[Images.btnTableGreen];
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
                        SetServiceButtonColor(order, orderProduct);
                    }
                }
            }
        }
        /// <summary>
        /// This method changes the color of the service buttons depending on the status of the order.
        /// </summary>
        /// <param name="order"></param>
        /// <param name="orderProduct"></param>
        private void SetServiceButtonColor(ChapooModels.Order order, OrderProduct orderProduct)
        {
            Button[] ButtonList;

            if (ProductList[orderProduct.Product.ProductId].ProductType == "Drink")
            {
                ButtonList = BtnListBar;
            }
            else
            {
                ButtonList = BtnListKitchen;
            }

            switch (orderProduct.Status)
            {
                case Statustype.Bereid:
                    ButtonList[order.TableNumber - 1].BackgroundImage = ButtonImages[Images.btnServiceGreen];
                    break;
                case Statustype.Open:
                    ButtonList[order.TableNumber - 1].BackgroundImage = ButtonImages[Images.btnServiceYellow];
                    break;
                case Statustype.Afgehandeld:
                    ButtonList[order.TableNumber - 1].BackgroundImage = ButtonImages[Images.btnServiceGray];
                    break;
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
                    btn.BackgroundImage = ButtonImages[Images.btnTableGreen];
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
            string buttonType;
            int tafelIndex = Convert.ToInt16(btn.Tag);

            if (btn.Text == "Bar")
            {
                buttonType = "Drink";
            }
            else
            {
                buttonType = "Food";
            }

            string message = "Set item delivered?";
            string title = "Update servings";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                Service.UpdateOrderProductStatus(tafelIndex, Statustype.Afgehandeld, buttonType);
                Service.UpdateOrderTime(tafelIndex);
                ActiveOrderlist = Service.GetActiveOrderList();
                UpdateTableStatus();
                if (buttonType == "Food")
                {
                    BtnListKitchen[tafelIndex - 1].BackgroundImage = ButtonImages[Images.btnServiceGray];
                }
                else
                {
                    BtnListBar[tafelIndex - 1].BackgroundImage = ButtonImages[Images.btnServiceGray];
                }
            }

        }
        /// <summary>
        /// This method is for the buttons btnKitchen. This button will update the OpderProduct.Status to 'afgehandeld' and updates the Order.Date to DateTime.Now. Then it changes the buttons color to gray.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

    }
}
