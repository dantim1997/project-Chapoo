namespace project_Chapoo
{
    partial class Order
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView_Order = new System.Windows.Forms.ListView();
            this.lbl_OrderTable = new System.Windows.Forms.Label();
            this.btn_Back = new System.Windows.Forms.Button();
            this.btn_Diner = new System.Windows.Forms.Button();
            this.btn_Lunch = new System.Windows.Forms.Button();
            this.btn_Drinks = new System.Windows.Forms.Button();
            this.btn_Note = new System.Windows.Forms.Button();
            this.btn_Submit = new System.Windows.Forms.Button();
            this.btn_Pay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView_Order
            // 
            this.listView_Order.Location = new System.Drawing.Point(12, 52);
            this.listView_Order.Name = "listView_Order";
            this.listView_Order.Size = new System.Drawing.Size(237, 482);
            this.listView_Order.TabIndex = 6;
            this.listView_Order.UseCompatibleStateImageBehavior = false;
            // 
            // lbl_OrderTable
            // 
            this.lbl_OrderTable.AutoSize = true;
            this.lbl_OrderTable.Font = new System.Drawing.Font("Arial", 11F);
            this.lbl_OrderTable.Location = new System.Drawing.Point(8, 18);
            this.lbl_OrderTable.Name = "lbl_OrderTable";
            this.lbl_OrderTable.Size = new System.Drawing.Size(102, 19);
            this.lbl_OrderTable.TabIndex = 7;
            this.lbl_OrderTable.Text = "Order table x";
            // 
            // btn_Back
            // 
            this.btn_Back.BackColor = System.Drawing.Color.White;
            this.btn_Back.Location = new System.Drawing.Point(266, 52);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(75, 74);
            this.btn_Back.TabIndex = 8;
            this.btn_Back.Text = "Back";
            this.btn_Back.UseVisualStyleBackColor = false;
            // 
            // btn_Diner
            // 
            this.btn_Diner.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_Diner.Location = new System.Drawing.Point(509, 52);
            this.btn_Diner.Name = "btn_Diner";
            this.btn_Diner.Size = new System.Drawing.Size(75, 74);
            this.btn_Diner.TabIndex = 9;
            this.btn_Diner.Text = "Diner";
            this.btn_Diner.UseVisualStyleBackColor = false;
            this.btn_Diner.Click += new System.EventHandler(this.btn_Diner_Click);
            // 
            // btn_Lunch
            // 
            this.btn_Lunch.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_Lunch.Location = new System.Drawing.Point(428, 52);
            this.btn_Lunch.Name = "btn_Lunch";
            this.btn_Lunch.Size = new System.Drawing.Size(75, 74);
            this.btn_Lunch.TabIndex = 10;
            this.btn_Lunch.Text = "Lunch";
            this.btn_Lunch.UseVisualStyleBackColor = false;
            this.btn_Lunch.Click += new System.EventHandler(this.btn_Lunch_Click);
            // 
            // btn_Drinks
            // 
            this.btn_Drinks.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_Drinks.Location = new System.Drawing.Point(347, 52);
            this.btn_Drinks.Name = "btn_Drinks";
            this.btn_Drinks.Size = new System.Drawing.Size(75, 74);
            this.btn_Drinks.TabIndex = 11;
            this.btn_Drinks.Text = "Drinks";
            this.btn_Drinks.UseVisualStyleBackColor = false;
            this.btn_Drinks.Click += new System.EventHandler(this.btn_Drinks_Click);
            // 
            // btn_Note
            // 
            this.btn_Note.BackColor = System.Drawing.Color.LemonChiffon;
            this.btn_Note.Location = new System.Drawing.Point(671, 52);
            this.btn_Note.Name = "btn_Note";
            this.btn_Note.Size = new System.Drawing.Size(75, 74);
            this.btn_Note.TabIndex = 13;
            this.btn_Note.Text = "Note";
            this.btn_Note.UseVisualStyleBackColor = false;
            this.btn_Note.Click += new System.EventHandler(this.btn_Note_Click);
            // 
            // btn_Submit
            // 
            this.btn_Submit.BackColor = System.Drawing.Color.White;
            this.btn_Submit.Location = new System.Drawing.Point(590, 460);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(156, 74);
            this.btn_Submit.TabIndex = 14;
            this.btn_Submit.Text = "Submit";
            this.btn_Submit.UseVisualStyleBackColor = false;
            this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
            // 
            // btn_Pay
            // 
            this.btn_Pay.BackColor = System.Drawing.Color.White;
            this.btn_Pay.Location = new System.Drawing.Point(255, 460);
            this.btn_Pay.Name = "btn_Pay";
            this.btn_Pay.Size = new System.Drawing.Size(156, 74);
            this.btn_Pay.TabIndex = 15;
            this.btn_Pay.Text = "Pay";
            this.btn_Pay.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(713, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 546);
            this.Controls.Add(this.btn_Pay);
            this.Controls.Add(this.btn_Submit);
            this.Controls.Add(this.btn_Note);
            this.Controls.Add(this.btn_Drinks);
            this.Controls.Add(this.btn_Lunch);
            this.Controls.Add(this.btn_Diner);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.lbl_OrderTable);
            this.Controls.Add(this.listView_Order);
            this.Name = "Order";
            this.Text = "Order";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView listView_Order;
        private System.Windows.Forms.Label lbl_OrderTable;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.Button btn_Diner;
        private System.Windows.Forms.Button btn_Lunch;
        private System.Windows.Forms.Button btn_Drinks;
        private System.Windows.Forms.Button btn_Note;
        private System.Windows.Forms.Button btn_Submit;
        private System.Windows.Forms.Button btn_Pay;
    }
}