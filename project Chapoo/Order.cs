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
        Employee employee;

        public Order(int tableNumber, Employee employee)
        {
            InitializeComponent();
            this.employee = employee;
        }

        private void vulListView(string type)
        {
            listView_Products.Clear();
            ChapooLogic.Product_Service prodService = new ChapooLogic.Product_Service();
            List<Product> prodList = prodService.GetProducts();
            foreach (ChapooModels.Product p in prodList)
            {
                if (p.ProductType == type)
                {
                    ListViewItem li = new ListViewItem(p.ProductName);
                    listView_Products.Items.Add(li);
                }
            }
        }

        private void btn_Afronden_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Wil je de order doorgeven naar de keuken?", "Order bevestigen", MessageBoxButtons.YesNo);
            if(dr == DialogResult.Yes)
            {
                MessageBox.Show("Bestelling succesvol doorgegeven", "Order bevestigen");
                //Daadwerkelijk order doorgeven lol
                //Open tafeloverzicht
            }
        }
        

        private void btn_Dranken_Click(object sender, EventArgs e)
        {
            vulListView("Drink");
        }

        private void btn_Eten_Click(object sender, EventArgs e)
        {
            vulListView("Food");
        }

        private void listView_Products_SelectedIndexChanged(object sender, EventArgs e)
        {
            var firstSelectedItem = listView_Products.SelectedItems[0];
            //listView_Order.Items.Add(firstSelectedItem);

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

