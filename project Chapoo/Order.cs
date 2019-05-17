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
        public Order()
        {
            InitializeComponent();
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

        private void btn_Lunch_Click(object sender, EventArgs e)
        {
            vulListView("Lunch");
        }

        private void btn_Diner_Click(object sender, EventArgs e)
        {
            vulListView("Diner");
        }

        private void btn_Dranken_Click(object sender, EventArgs e)
        {
            vulListView("Dranken");
        }

        private void listView__ItemActivate(object sender, EventArgs e)
        {

        }
    }
}

