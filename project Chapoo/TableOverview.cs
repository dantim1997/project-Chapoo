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
        TableOverview_Service service;
        List<Table> tableList;
        List<Order> orders;
        Employee employee;

        public TableOverview()
        {
            InitializeComponent();
            service = new TableOverview_Service();
            orders = new List<Order>();
            tableList = service.GetTableList();
            UpdateServiceStatus();
        }

        public void InfoEmployee(Employee e)
        {
            employee = e;
            lblServerInfo.Text = employee.Name + " " + employee.Surname;
            lblServerIdInfo.Text = employee.EmployeeId.ToString();
        }

        private void UpdateServiceStatus()
        {
            foreach (Table table in tableList)
            {
                if (table.Status == "occupied")
                {
                    switch (table.TableNumber)
                    {
                        case 1:
                            btnTable1.Image = Image.FromFile(@"../../Rescources\table-05.png");
                            break;
                        case 2:
                            btnTable2.Image = Image.FromFile(@"../../Rescources\table-05.png");
                            break;
                        case 3:
                            btnTable3.Image = Image.FromFile(@"../../Rescources\table-05.png");
                            break;
                        case 4:
                            btnTable4.Image = Image.FromFile(@"../../Rescources\table-05.png");
                            break;
                        case 5:
                            btnTable5.Image = Image.FromFile(@"../../Rescources\table-05.png");
                            break;
                        case 6:
                            btnTable6.Image = Image.FromFile(@"../../Rescources\table-05.png");
                            break;
                        case 7:
                            btnTable7.Image = Image.FromFile(@"../../Rescources\table-05.png");
                            break;
                        case 8:
                            btnTable8.Image = Image.FromFile(@"../../Rescources\table-05.png");
                            break;
                        case 9:
                            btnTable9.Image = Image.FromFile(@"../../Rescources\table-05.png");
                            break;
                        case 10:
                            btnTable10.Image = Image.FromFile(@"../../Rescources\table-05.png");
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
            this.Close();
        }

        private void btnTable1_Click(object sender, EventArgs e)
        {
            if (tableList[0].Status == "free")
            {
                string message = "Do you want to set this table occupied.";
                string title = "Assign table";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    btnTable1.Image = Image.FromFile(@"../../Rescources\table-05.png");
                    service.UpdateTableStatusOccupied("1", "occupied");
                    tableList = service.GetTableList();
                }
            }
            else
            {
                Order order = new Order(tableList[1].TableNumber, employee);
                this.Hide();
                order.ShowDialog();
                this.Close();
            }
        }

        private void btnBar1_Click(object sender, EventArgs e)
        {

        }

        private void btnKitchen1_Click(object sender, EventArgs e)
        {

        }

        private void btnTable2_Click(object sender, EventArgs e)
        {
            if (tableList[1].Status == "free")
            {
                string message = "Do you want to set this table occupied.";
                string title = "Assign table";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    btnTable2.Image = Image.FromFile(@"../../Rescources\table-05.png");
                    service.UpdateTableStatusOccupied("1", "occupied");
                    tableList = service.GetTableList();
                }
            }
            else
            {
                Order order = new Order(tableList[2].TableNumber, employee);
                this.Hide();
                order.ShowDialog();
                this.Close();
            }
        }
    }
}
