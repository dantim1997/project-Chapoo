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
        public Product_Service ProdSer = new Product_Service();

        public Order()
        {
            InitializeComponent();
            //FormBorderStyle = FormBorderStyle.None;
            //WindowState = FormWindowState.Maximized;
        }

        public void GetOrder()
        {
            //
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

        List<Button> buttons = new List<Button>();
        List<Product> producten = new List<Product>();

        private void CreateButtons(List<Product>products)
        {
            buttons.Clear();
            producten.Clear();

            int index = 0;

            for(int i = 0; i<6; i++)
            {
                for (int j = 0; j < products.Count/6; j++)
                {
                    Button newButton = new Button();
                    buttons.Add(newButton);
                    newButton.Height = 75;
                    newButton.Width = 74;
                    newButton.Text = products[index].ProductName;
                    newButton.Location = new Point((80 * i) +266, (80 * j) + 132); //266 en 132 zijn de begin coordinaten
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
            foreach(Button button in buttons)
            {
                this.Controls.Remove(button);
            }
        }

        void GeneratedButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int index = buttons.IndexOf(button);
            Product product = producten[index];
            MessageBox.Show(product.ProductName+ " toevoegen?"); //voor test, niet nodig voor final
            listView_Order.Items.Add(product.ProductName);
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Wil je de order doorgeven naar de keuken?", "Order bevestigen", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                MessageBox.Show("Bestelling succesvol doorgegeven", "Order bevestigen");
                //Order doorgeven
                //Terug naar tafeloverzicht
            }
        }

        private void btn_Note_Click(object sender, EventArgs e)
        {
            //Input vragen van gebruiker
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TableOverview tableOverview = new TableOverview();
            tableOverview.InfoEmployee(employee);
            this.Hide();
            tableOverview.ShowDialog();
            this.Close();
        }
    }
}

