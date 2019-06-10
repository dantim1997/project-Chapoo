using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChapooLogic;
using ChapooModels;
using Microsoft.VisualBasic;

namespace project_Chapoo
{
    public partial class Order : Form
    {
        public Product_Service ProdSer = new Product_Service();
        public List<OrderProduct> orderProducts = new List<OrderProduct>(); //List voor de producten in de bestelling
        List<Button> buttons = new List<Button>(); //List voor alle aangemaakte buttons
        List<Product> producten = new List<Product>(); //List voor het maken van de buttons
        public Table Table = new Table();

        Order_Service orderService = new Order_Service();
        OrderProduct_Service orderProService = new OrderProduct_Service();
        TableOverview_Service tableService = new TableOverview_Service();

        Employee employee;

        /// <summary>
        /// constructor, retrieves employee and table from tableoverview, initializes buttons and updates labels to display current user and table
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="table"></param>
        public Order(Employee employee, Table table)
        {
            InitializeComponent();
            Table = table;
            producten = ProdSer.GetProducts();
            this.employee = employee;
            lbl_OrderTableInfo.Text = Table.TableNumber.ToString();
            lbl_currentUser.Text = employee.Fullname;
            InitButtons();

            List<Product> Drinks = new List<Product>();
            Drinks = ProdSer.GetDrinks();
            producten = Drinks;
            FillButtons();

            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

        }

        /// <summary>
        /// Updates table states and creates order with list of orderproducts
        /// </summary>
        public void SendOrder()
        {
            orderService.UpdateOrder(Table.OrderId, "In Progress...");
            orderProService.CreateOrderProduct(orderProducts);
        }


        /// <summary>
        /// gets lunch items 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Lunch_Click(object sender, EventArgs e)
        {
            producten.Clear();
            List<Product> LunchItem = new List<Product>();
            LunchItem = ProdSer.GetLunch();
            producten = LunchItem;
            FillButtons();
        }

        /// <summary>
        /// gets diner items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Diner_Click(object sender, EventArgs e)
        {
            producten.Clear();
            List<Product> DinerItem = new List<Product>();
            DinerItem = ProdSer.GetDiner();
            producten = DinerItem;
            FillButtons();
        }

        /// <summary>
        /// gets drink items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Drinks_Click(object sender, EventArgs e)
        {
            producten.Clear();
            List<Product> Drinks = new List<Product>();
            Drinks = ProdSer.GetDrinks();
            producten = Drinks;
            FillButtons();
        }

        /// <summary>
        /// clears button info
        /// </summary>
        private void ResetButtons()
        {
            foreach(Button button in buttons)
            {
                button.Text = string.Empty;
                button.Enabled = false; 
                button.Click -= new EventHandler(GeneratedButton_Click);
                button.BackColor = Color.DarkGray;
            }
        }

        /// <summary>
        /// initializes button location, color, size and clickable state
        /// </summary>
        private void InitButtons()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Button newButton = new Button();
                    newButton.Height = 130; 
                    newButton.Width = 130;
                    newButton.Location = new Point((135 * j) + 574, (135 * i) + 255); //584 en 206 zijn de begin coordinaten 
                    this.Controls.Add(newButton);
                    buttons.Add(newButton);
                    newButton.Enabled = false;
                }
            }
        }

        /// <summary>
        /// uses current products to name, color and enable buttons
        /// </summary>
        private void FillButtons()
        {
            ResetButtons();
            int index = 0;
            foreach(Product p in producten)
            {
          
                buttons[index].Text = p.ProductName;
                buttons[index].Enabled = true;
                buttons[index].Click += new EventHandler(GeneratedButton_Click);
                buttons[index].BackColor = Color.LightGray;
                switch(p.ProductType)
                {
                    case "Drink":
                        if (p.MenuType == "Bier")
                            buttons[index].BackColor = Color.LightGoldenrodYellow;
                        else if (p.MenuType == "Wijn" || p.MenuType == "Gedistelleerd")
                            buttons[index].BackColor = Color.IndianRed;
                        else if (p.MenuType == "Frisdrank")
                            buttons[index].BackColor = Color.LightGreen;
                        else
                            buttons[index].BackColor = Color.SandyBrown;
                        break;
                    case "Food":
                        if (p.MenuType == "Voorgerecht")
                            buttons[index].BackColor = Color.LightSeaGreen;
                        else if (p.MenuType == "Hoofdgerecht")
                            buttons[index].BackColor = Color.LightSalmon;
                        else
                            buttons[index].BackColor = Color.LightSkyBlue;
                        break;
                }
                index++;
            }
        }

        /// <summary>
        /// Adds product to listview, updates supply 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void GeneratedButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int index = buttons.IndexOf(button);
            OrderProduct product = new OrderProduct();
            product.Product = producten[index];

            if (product.Product.Supply != 0)
            {
                if (orderProducts.Where(t => t.Product.ProductId == product.Product.ProductId).FirstOrDefault() != null)
                {
                    orderProducts.Where(t => t.Product.ProductId == product.Product.ProductId).FirstOrDefault().Amount++;
                }
                else
                {
                    OrderProduct orderproduct = product;
                    orderproduct.Product = product.Product;
                    orderproduct.Amount = 1;
                    orderproduct.OrderId = Table.OrderId;
                    orderproduct.Note = string.Empty;
                    orderproduct.Status = Statustype.Open;
                    orderProducts.Add(orderproduct);
                }
                producten[index].Supply--;
                UpdateListView();
            }
            else
            {
                MessageBox.Show("Product niet op voorraad");
            }
        }

        /// <summary>
        /// finishes order, returns to tableoverview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Submit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Wil je de order doorgeven naar de keuken?", "Order bevestigen", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                SendOrder();
                TableOverview tableOverview = new TableOverview(employee);
                this.Hide();
                tableOverview.ShowDialog();
                this.Close();
            }
        }


        /// <summary>
        /// Opens dialogwindow to add a note to selected product 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Note_Click(object sender, EventArgs e)
        {
            var selectedItem = listView_Order.SelectedItems[0];
            InputDialog inputDialog = new InputDialog();
            inputDialog.ShowDialog();
            string input = inputDialog.getNote();
            orderProducts.Where(t => t.Product.ProductName == selectedItem.Text).FirstOrDefault().Note = input;
            UpdateListView();
            btn_Note.Enabled = false;
            btn_Remove.Enabled = false;
        }

        /// <summary>
        /// Substracts amount of a product in order by one
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Remove_Click_1(object sender, EventArgs e)
        {
            var selectedItem = listView_Order.SelectedItems[0];
            OrderProduct orderProduct = orderProducts.Where(t => t.Product.ProductName == selectedItem.Text).FirstOrDefault();
            if (orderProduct.Amount > 1)
            {
                orderProduct.Product.Supply++;
                orderProduct.Amount--;
            }
            else
            {
                orderProducts.Remove(orderProduct);
            }
            UpdateListView();
            btn_Remove.Enabled = false;
            btn_Note.Enabled = false;
        }

        /// <summary>
        /// enables note and remove buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_Order_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_Remove.Enabled = true;
            btn_Note.Enabled = true;
        }

        /// <summary>
        /// clears listview and list of products in order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Reset_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Weet je zeker dat je de order wilt resetten?", "Reset Order", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                foreach(OrderProduct orderProduct in orderProducts)
                {
                    orderProduct.Product.Supply += orderProducts.Where(t => t.Product.ProductId == orderProduct.Product.ProductId).FirstOrDefault().Amount;
                }
                listView_Order.Items.Clear();
                orderProducts.Clear();
            }
        }

        /// <summary>
        /// returns to tableoverview without saving
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Back_Click(object sender, EventArgs e)
        {
            TableOverview tableOverview = new TableOverview(employee);
            this.Hide();
            tableOverview.ShowDialog();
            this.Close();
        }

        /// <summary>
        /// updates the listview
        /// </summary>
        void UpdateListView()
        {
            listView_Order.Items.Clear();
            foreach (OrderProduct product in orderProducts)
            {
                ListViewItem item = new ListViewItem(product.Product.ProductName);
                item.SubItems.Add(product.Amount.ToString());
                item.SubItems.Add(product.Note);
                listView_Order.Items.Add(item);
            }
        }

        /// <summary>
        /// closes order, returns to tableoverview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Pay_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to finish the order?", "Confirm finishing order", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                orderService.UpdateStatus("closed", Table.OrderId);
                tableService.UpdateTableStatus(Table.TableNumber, "free");
                TableOverview tableOverview = new TableOverview(employee);
                this.Hide();
                tableOverview.ShowDialog();
                this.Close();
            }
        }
    }
}