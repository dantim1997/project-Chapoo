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
    public partial class InputDialog : Form
    {
        public string inputNote;

        /// <summary>
        /// return note for use in order
        /// </summary>
        /// <returns></returns>
        public string getNote()
        {
            return inputNote;
        }

        /// <summary>
        /// constructor
        /// </summary>
        public InputDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// saves input, closes window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Submit_Click(object sender, EventArgs e)
        {
            string input = txtBox_Note.Text;
            inputNote = input;
            this.Close();
        }

        /// <summary>
        /// closes window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
