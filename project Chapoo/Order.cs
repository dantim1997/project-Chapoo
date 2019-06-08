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

        public ChapooModels.Order GetOrder(ChapooModels.Order order)
        {
            return order;
        }

        public void SendOrder()
        {
            orderService.UpdateOrder(Table.OrderId, "In Progress...");
            orderProService.CreateOrderProduct(orderProducts);
        }


        private void btn_Lunch_Click(object sender, EventArgs e)
        {
            producten.Clear();
            List<Product> LunchItem = new List<Product>();
            LunchItem = ProdSer.GetLunch();
            producten = LunchItem;
            FillButtons();
        }

        private void btn_Diner_Click(object sender, EventArgs e)
        {
            producten.Clear();
            List<Product> DinerItem = new List<Product>();
            DinerItem = ProdSer.GetDiner();
            producten = DinerItem;
            FillButtons();
        }

        private void btn_Drinks_Click(object sender, EventArgs e)
        {
            producten.Clear();
            List<Product> Drinks = new List<Product>();
            Drinks = ProdSer.GetDrinks();
            producten = Drinks;
            FillButtons();
        }

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

        private void FillButtons()
        {
            ResetButtons();
            int index = -1;
            foreach(Product p in producten)
            {
                index++;
                buttons[index].Text = p.ProductName;
                buttons[index].Enabled = true;
                buttons[index].Click += new EventHandler(GeneratedButton_Click);
                buttons[index].BackColor = Color.LightGray;

                if (p.ProductType == "Drink")
                {
                    if (p.MenuType == "Bier")
                        buttons[index].BackColor = Color.Yellow;
                    else if (p.MenuType == "Wijn" || p.MenuType == "Gedistelleerd")
                        buttons[index].BackColor = Color.Red;
                }
            }
        }

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

        private void listView_Order_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_Remove.Enabled = true;
            btn_Note.Enabled = true;
        }

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

        private void btn_Back_Click(object sender, EventArgs e)
        {
            TableOverview tableOverview = new TableOverview(employee);
            this.Hide();
            tableOverview.ShowDialog();
            this.Close();
        }

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