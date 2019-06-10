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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Order));
            this.listView_Order = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbl_OrderTable = new System.Windows.Forms.Label();
            this.btn_Back = new System.Windows.Forms.Button();
            this.btn_Diner = new System.Windows.Forms.Button();
            this.btn_Lunch = new System.Windows.Forms.Button();
            this.btn_Drinks = new System.Windows.Forms.Button();
            this.btn_Note = new System.Windows.Forms.Button();
            this.btn_Submit = new System.Windows.Forms.Button();
            this.btn_Pay = new System.Windows.Forms.Button();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.btn_Remove = new System.Windows.Forms.Button();
            this.lbl_OrderTableInfo = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_textCurrent = new System.Windows.Forms.Label();
            this.lbl_currentUser = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // listView_Order
            // 
            this.listView_Order.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView_Order.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView_Order.Font = new System.Drawing.Font("Arial", 10.86792F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView_Order.HideSelection = false;
            this.listView_Order.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listView_Order.Location = new System.Drawing.Point(71, 90);
            this.listView_Order.Name = "listView_Order";
            this.listView_Order.Size = new System.Drawing.Size(457, 930);
            this.listView_Order.TabIndex = 6;
            this.listView_Order.UseCompatibleStateImageBehavior = false;
            this.listView_Order.View = System.Windows.Forms.View.Details;
            this.listView_Order.SelectedIndexChanged += new System.EventHandler(this.listView_Order_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "                     Name";
            this.columnHeader1.Width = 220;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Amount";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 70;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Note";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 163;
            // 
            // lbl_OrderTable
            // 
            this.lbl_OrderTable.AutoSize = true;
            this.lbl_OrderTable.Font = new System.Drawing.Font("Arial", 14.26415F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_OrderTable.Location = new System.Drawing.Point(67, 63);
            this.lbl_OrderTable.Name = "lbl_OrderTable";
            this.lbl_OrderTable.Size = new System.Drawing.Size(156, 24);
            this.lbl_OrderTable.TabIndex = 7;
            this.lbl_OrderTable.Text = "Order for table";
            // 
            // btn_Back
            // 
            this.btn_Back.BackColor = System.Drawing.Color.White;
            this.btn_Back.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Back.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Back.Location = new System.Drawing.Point(534, 90);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(150, 150);
            this.btn_Back.TabIndex = 8;
            this.btn_Back.Text = "Back";
            this.btn_Back.UseVisualStyleBackColor = false;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // btn_Diner
            // 
            this.btn_Diner.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_Diner.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Diner.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Diner.Location = new System.Drawing.Point(1158, 90);
            this.btn_Diner.Name = "btn_Diner";
            this.btn_Diner.Size = new System.Drawing.Size(150, 150);
            this.btn_Diner.TabIndex = 9;
            this.btn_Diner.Text = "Diner";
            this.btn_Diner.UseVisualStyleBackColor = false;
            this.btn_Diner.Click += new System.EventHandler(this.btn_Diner_Click);
            // 
            // btn_Lunch
            // 
            this.btn_Lunch.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_Lunch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Lunch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Lunch.Location = new System.Drawing.Point(1002, 90);
            this.btn_Lunch.Name = "btn_Lunch";
            this.btn_Lunch.Size = new System.Drawing.Size(150, 150);
            this.btn_Lunch.TabIndex = 10;
            this.btn_Lunch.Text = "Lunch";
            this.btn_Lunch.UseVisualStyleBackColor = false;
            this.btn_Lunch.Click += new System.EventHandler(this.btn_Lunch_Click);
            // 
            // btn_Drinks
            // 
            this.btn_Drinks.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_Drinks.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Drinks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Drinks.Location = new System.Drawing.Point(846, 90);
            this.btn_Drinks.Name = "btn_Drinks";
            this.btn_Drinks.Size = new System.Drawing.Size(150, 150);
            this.btn_Drinks.TabIndex = 11;
            this.btn_Drinks.Text = "Drinks";
            this.btn_Drinks.UseVisualStyleBackColor = false;
            this.btn_Drinks.Click += new System.EventHandler(this.btn_Drinks_Click);
            // 
            // btn_Note
            // 
            this.btn_Note.BackColor = System.Drawing.Color.LemonChiffon;
            this.btn_Note.Enabled = false;
            this.btn_Note.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Note.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Note.Location = new System.Drawing.Point(1458, 90);
            this.btn_Note.Name = "btn_Note";
            this.btn_Note.Size = new System.Drawing.Size(150, 150);
            this.btn_Note.TabIndex = 13;
            this.btn_Note.Text = "Note";
            this.btn_Note.UseVisualStyleBackColor = false;
            this.btn_Note.Click += new System.EventHandler(this.btn_Note_Click);
            // 
            // btn_Submit
            // 
            this.btn_Submit.BackColor = System.Drawing.Color.White;
            this.btn_Submit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Submit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.26415F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Submit.Location = new System.Drawing.Point(1308, 870);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(300, 150);
            this.btn_Submit.TabIndex = 14;
            this.btn_Submit.Text = "Submit";
            this.btn_Submit.UseVisualStyleBackColor = false;
            this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
            // 
            // btn_Pay
            // 
            this.btn_Pay.BackColor = System.Drawing.Color.White;
            this.btn_Pay.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Pay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.26415F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Pay.Location = new System.Drawing.Point(1002, 870);
            this.btn_Pay.Name = "btn_Pay";
            this.btn_Pay.Size = new System.Drawing.Size(300, 150);
            this.btn_Pay.TabIndex = 15;
            this.btn_Pay.Text = "Pay";
            this.btn_Pay.UseVisualStyleBackColor = false;
            this.btn_Pay.Click += new System.EventHandler(this.btn_Pay_Click);
            // 
            // btn_Reset
            // 
            this.btn_Reset.BackColor = System.Drawing.Color.White;
            this.btn_Reset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.26415F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Reset.Location = new System.Drawing.Point(690, 870);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(150, 150);
            this.btn_Reset.TabIndex = 17;
            this.btn_Reset.Text = "Reset";
            this.btn_Reset.UseVisualStyleBackColor = false;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // btn_Remove
            // 
            this.btn_Remove.BackColor = System.Drawing.Color.White;
            this.btn_Remove.Enabled = false;
            this.btn_Remove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Remove.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.26415F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Remove.Location = new System.Drawing.Point(534, 870);
            this.btn_Remove.Name = "btn_Remove";
            this.btn_Remove.Size = new System.Drawing.Size(150, 150);
            this.btn_Remove.TabIndex = 18;
            this.btn_Remove.Text = "Remove";
            this.btn_Remove.UseVisualStyleBackColor = false;
            this.btn_Remove.Click += new System.EventHandler(this.btn_Remove_Click_1);
            // 
            // lbl_OrderTableInfo
            // 
            this.lbl_OrderTableInfo.AutoSize = true;
            this.lbl_OrderTableInfo.Font = new System.Drawing.Font("Arial", 14.26415F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_OrderTableInfo.Location = new System.Drawing.Point(219, 63);
            this.lbl_OrderTableInfo.Name = "lbl_OrderTableInfo";
            this.lbl_OrderTableInfo.Size = new System.Drawing.Size(28, 24);
            this.lbl_OrderTableInfo.TabIndex = 7;
            this.lbl_OrderTableInfo.Text = "...";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::project_Chapoo.Properties.Resources.Laag_2;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(1634, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(258, 152);
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_textCurrent
            // 
            this.lbl_textCurrent.AutoSize = true;
            this.lbl_textCurrent.Font = new System.Drawing.Font("Arial", 12.22642F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_textCurrent.Location = new System.Drawing.Point(1630, 167);
            this.lbl_textCurrent.Name = "lbl_textCurrent";
            this.lbl_textCurrent.Size = new System.Drawing.Size(135, 22);
            this.lbl_textCurrent.TabIndex = 20;
            this.lbl_textCurrent.Text = "Current user:";
            // 
            // lbl_currentUser
            // 
            this.lbl_currentUser.AutoSize = true;
            this.lbl_currentUser.Font = new System.Drawing.Font("Arial", 12.22642F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_currentUser.Location = new System.Drawing.Point(1630, 189);
            this.lbl_currentUser.Name = "lbl_currentUser";
            this.lbl_currentUser.Size = new System.Drawing.Size(25, 22);
            this.lbl_currentUser.TabIndex = 21;
            this.lbl_currentUser.Text = "...";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(1615, 318);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(289, 417);
            this.pictureBox2.TabIndex = 22;
            this.pictureBox2.TabStop = false;
            // 
            // Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1039);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lbl_currentUser);
            this.Controls.Add(this.lbl_textCurrent);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_Remove);
            this.Controls.Add(this.btn_Reset);
            this.Controls.Add(this.btn_Pay);
            this.Controls.Add(this.btn_Submit);
            this.Controls.Add(this.btn_Note);
            this.Controls.Add(this.btn_Drinks);
            this.Controls.Add(this.btn_Lunch);
            this.Controls.Add(this.btn_Diner);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.lbl_OrderTableInfo);
            this.Controls.Add(this.lbl_OrderTable);
            this.Controls.Add(this.listView_Order);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Order";
            this.Text = "Order";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
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
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btn_Remove;
        private System.Windows.Forms.Label lbl_OrderTableInfo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_textCurrent;
        private System.Windows.Forms.Label lbl_currentUser;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}