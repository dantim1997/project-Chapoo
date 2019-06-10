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

namespace project_Chapoo
{
    public partial class Order : Form
    {
        private Employee Employee;
        private Table Table;
        private Product_Service ProdSer = new Product_Service();
        private Order_Service orderService = new Order_Service();
        private OrderProduct_Service orderProductService = new OrderProduct_Service();
        private TableOverview_Service tableService = new TableOverview_Service();
        private List<OrderProduct> orderProducts = new List<OrderProduct>(); //List voor de producten in de bestelling
        private List<Button> buttons = new List<Button>(); //List voor alle aangemaakte buttons
        private List<Product> producten = new List<Product>(); //List voor het maken van de buttons
     
        /// <summary>
        /// constructor, retrieves employee and table from tableoverview, initializes buttons and updates labels to display current user and table
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="table"></param>
        public Order(Employee employee, Table table)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            Table = table;
            Employee = employee;
            producten = ProdSer.GetProducts();
            lbl_OrderTableInfo.Text = Table.TableNumber.ToString();
            lbl_currentUser.Text = employee.Fullname;
            InitButtons();

            GetProducts("Drinks"); //Default startup option
        }

        /// <summary>
        /// Updates table states and creates order with list of orderproducts
        /// </summary>
        public void SendOrder()
        {
            orderService.UpdateOrder(Table.OrderId, "In Progress...");
            orderProductService.CreateOrderProduct(orderProducts);
        }

        /// <summary>
        /// Adds type of product to list
        /// </summary>
        /// <param name="type"></param>
        private void GetProducts(string type)
        {
            producten.Clear();
            switch (type)
            {
                case "Drinks":
                    producten = ProdSer.GetDrinks();
                    break;
                case "Diner":
                    producten = ProdSer.GetDiner();
                    break;
                case "Lunch":
                    producten = ProdSer.GetLunch();
                    break;
            }
            FillButtons();
        }
            
        /// <summary>
        /// gets lunch items 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Lunch_Click(object sender, EventArgs e)
        {
            GetProducts("Lunch");
        }

        /// <summary>
        /// gets diner items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Diner_Click(object sender, EventArgs e)
        {
            GetProducts("Diner");
        }

        /// <summary>
        /// gets drink items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Drinks_Click(object sender, EventArgs e)
        {
            GetProducts("Drinks");
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
                    newButton.Height = 150; 
                    newButton.Width = 150;
                    newButton.Font = new Font(newButton.Font.FontFamily, 10);
                    newButton.Location = new Point((156 * j) + 534, (156 * i) + 246); 
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
                            buttons[index].BackColor = Color.LimeGreen;
                        else if (p.MenuType == "Tussengerecht")
                            buttons[index].BackColor = Color.LightPink;
                        else
                            buttons[index].BackColor = Color.SteelBlue;
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
        /// clears listview and list of products in order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Reset_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Weet je zeker dat je de order wilt resetten?", "Reset Order", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                foreach (OrderProduct orderProduct in orderProducts)
                {
                    orderProduct.Product.Supply += orderProducts.Where(t => t.Product.ProductId == orderProduct.Product.ProductId).FirstOrDefault().Amount;
                }
                listView_Order.Items.Clear();
                orderProducts.Clear();
                orderProductService.UpdateOrderProductStatusByOrderId(Table.OrderId, Statustype.Afgehandeld);
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
                TableOverview tableOverview = new TableOverview(Employee);
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
            EnableControlButtons(false);
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
            EnableControlButtons(false);
        }

        /// <summary>
        /// returns to tableoverview without saving
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Back_Click(object sender, EventArgs e)
        {
            TableOverview tableOverview = new TableOverview(Employee);
            this.Hide();
            tableOverview.ShowDialog();
            this.Close();
        }

        /// <summary>
        /// enables buttons on item click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_Order_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableControlButtons(true);
        }

        /// <summary>
        /// method for enabling/disabling remove and note buttons
        /// </summary>
        /// <param name="state"></param>
        private void EnableControlButtons(bool state)
        {
            btn_Remove.Enabled = state;
            btn_Note.Enabled = state;
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
                TableOverview tableOverview = new TableOverview(Employee);
                this.Hide();
                tableOverview.ShowDialog();
                this.Close();
            }
        }
    }
}