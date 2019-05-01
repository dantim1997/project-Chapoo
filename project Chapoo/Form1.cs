using project_Chapoo.DAO;
using project_Chapoo.Models;
using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            KitchenOverview kitchenOverview = new KitchenOverview();
            kitchenOverview.Show();

            DAO_Product product = new DAO_Product();
            List<Product> products = product.GetAllFood();

            DAO_Served dAO_Bill = new DAO_Served();
            Served served = new Served();
            served = dAO_Bill.GetBill(1);

            List<Served> serveds = dAO_Bill.GetAllBills();
        }
    }
}
