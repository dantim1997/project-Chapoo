﻿using System;
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
        public Product_Service ProdSer = new Product_Service();
        public List<OrderProduct> orderProducts = new List<OrderProduct>(); //List voor de producten in de bestelling
        List<Button> buttons = new List<Button>(); //List voor alle aangemaakte buttons
        List<Product> producten = new List<Product>(); //List voor het maken van de buttons
        public int ID;

        Order_Service orderService = new Order_Service();
        OrderProduct_Service orderProService = new OrderProduct_Service();

        Employee employee;

        //TODO: Bij orderreset supply ook resetten



        public Order(Employee employee)
        {
            InitializeComponent();
            producten = ProdSer.GetProducts();
            this.employee = employee;
            InitButtons();

            //FormBorderStyle = FormBorderStyle.None;
            //WindowState = FormWindowState.Maximized;

        }



        public ChapooModels.Order GetOrder(ChapooModels.Order order)
        {
            return order;
        }

        public void SendOrder()
        {
            orderService.UpdateOrder(ID, "In Progress...");
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
            InitButtons();
            FillButtons();
        }

        private void ResetButtons()
        {
            foreach(Button button in buttons)
            {
                button.Text = string.Empty;
                button.Enabled = false; 
                button.Click -= new EventHandler(GeneratedButton_Click);
            }
        }

        private void InitButtons()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Button newButton = new Button();
                    newButton.Height = 75;
                    newButton.Width = 75;
                    newButton.Location = new Point((80 * j) + 266, (80 * i) + 132); //266 en 132 zijn de begin coordinaten
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
                    orderproduct.OrderId = ID;
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
                MessageBox.Show("Bestelling succesvol doorgegeven", "Order bevestigen");

                SendOrder();

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
            string input = Microsoft.VisualBasic.Interaction.InputBox("Prompt", "Title", "Default", 0, 0);
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

       
    }
}