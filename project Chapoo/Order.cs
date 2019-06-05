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
        ChapooModels.Order huidigeOrder = new ChapooModels.Order();
        public Product_Service ProdSer = new Product_Service();
        public List<OrderProduct> orderProducts = new List<OrderProduct>();
        List<Button> buttons = new List<Button>();
        List<Product> producten = new List<Product>();
        Employee employee;

        public int ID = 1;
     
        

        public Order(Employee employee)
        {
            InitializeComponent();
            this.employee = employee;
            //FormBorderStyle = FormBorderStyle.None;
            //WindowState = FormWindowState.Maximized;
        }

        

        public ChapooModels.Order GetOrder(int tableNumber, int EmployeeID)
        {
            ChapooModels.Order order = huidigeOrder;
            order.Date = DateTime.Now;
            order.OrderId = ID;
            order.OrderProduct = orderProducts;
            order.Status = "In progress...";
            //order.TableNumber; 
            //order.EmployeeId;
            //Deze moeten worden verkregen vanuit tableOverview
            return order;
          
        }

        public void SendOrder()
        {
            //
        }

        private void btn_Lunch_Click(object sender, EventArgs e)
        {
            RemoveButtons();
            Product_Service prodSer = new Product_Service();
            List<Product> productsLunch = ProdSer.GetLunch();
            CreateButtons(productsLunch);
        }

        private void btn_Diner_Click(object sender, EventArgs e)
        {
            RemoveButtons();
            Product_Service prodSer = new Product_Service();
            List<Product> productsDiner = ProdSer.GetDiner();
            CreateButtons(productsDiner);
        }

        private void btn_Drinks_Click(object sender, EventArgs e)
        {
            RemoveButtons();
            Product_Service prodSer = new Product_Service();
            List<Product> productsDrinks = ProdSer.GetDrinks();
            CreateButtons(productsDrinks);
        }

        private void CreateButtons(List<Product> products)
        {
            buttons.Clear();
            producten.Clear();

            int index = 0;

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < products.Count / 6; j++)
                {
                    Button newButton = new Button();
                    buttons.Add(newButton);
                    newButton.Height = 75;
                    newButton.Width = 74;
                    newButton.Text = products[index].ProductName;
                    newButton.Location = new Point((80 * i) + 266, (80 * j) + 132); //266 en 132 zijn de begin coordinaten
                    newButton.Name = "btn_" + products[index].ProductName;
                    newButton.Click += new EventHandler(GeneratedButton_Click);
                    this.Controls.Add(newButton);
                    index++;
                }
            }
            producten = products;
        }

        private void RemoveButtons()
        {
            foreach (Button button in buttons)
            {
                this.Controls.Remove(button);
            }
        }

        void AddProduct()
        {
            listView_Order.Items.Clear();
            foreach (OrderProduct product in orderProducts)
            {
                ListViewItem item = new ListViewItem(product.Product.ProductName);
                item.SubItems.Add(product.Amount.ToString());
                listView_Order.Items.Add(item);

            }
        }

        void GeneratedButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int index = buttons.IndexOf(button);
            OrderProduct product = new OrderProduct();
            product.Product = producten[index];

            if (product.Product.Supply != 0) //Voorraad waarde nog niet opgehaald?
            {
                if (orderProducts.Where(t => t.Product.ProductId == product.Product.ProductId).FirstOrDefault() != null)
                {
                    orderProducts.Where(t => t.Product.ProductId == product.Product.ProductId).FirstOrDefault().Amount++;
                    AddProduct();
                }
                else
                {
                    OrderProduct orderproduct = product;
                    orderproduct.Product = product.Product;
                    orderproduct.Amount = 1;
                    orderProducts.Add(orderproduct);
                    AddProduct();
                }
                producten[index].Supply--;
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
                MessageBox.Show("Bestelling succesvol doorgegeven", "Order bevestigen");

                //order doorgeven

                TableOverview tableOverview = new TableOverview(employee);
                //tableOverview.InfoEmployee(employee);
                this.Hide();
                tableOverview.ShowDialog();
                this.Close();
            }
        }

        private void btn_Note_Click(object sender, EventArgs e)
        {
            var selectedItem = listView_Order.SelectedItems[0];
            RemoveButtons();
            TextBox box = new TextBox();
            box.Show();
            box.Location = new Point(266, 132);
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            var selectedItem = listView_Order.SelectedItems[0];
            orderProducts.Where(t => t.Product.ProductName == selectedItem.Text).FirstOrDefault().Product.Supply =+ orderProducts.Where(t => t.Product.ProductName == selectedItem.Text).FirstOrDefault().Amount;
            orderProducts.Remove(orderProducts.Where(t => t.Product.ProductName == selectedItem.Text).FirstOrDefault());
            AddProduct();
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
                listView_Order.Items.Clear();
                orderProducts.Clear();
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            TableOverview tableOverview = new TableOverview(employee);
            //tableOverview.InfoEmployee(employee);
            this.Hide();
            tableOverview.ShowDialog();
            this.Close();
        }
    }
}