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
            this.lbl_Opnemen = new System.Windows.Forms.Label();
            this.btn_Afronden = new System.Windows.Forms.Button();
            this.listView_Products = new System.Windows.Forms.ListView();
            this.btn_Lunch = new System.Windows.Forms.Button();
            this.btn_Diner = new System.Windows.Forms.Button();
            this.btn_Dranken = new System.Windows.Forms.Button();
            this.listView_Order = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lbl_Opnemen
            // 
            this.lbl_Opnemen.AutoSize = true;
            this.lbl_Opnemen.Location = new System.Drawing.Point(13, 13);
            this.lbl_Opnemen.Name = "lbl_Opnemen";
            this.lbl_Opnemen.Size = new System.Drawing.Size(117, 15);
            this.lbl_Opnemen.TabIndex = 0;
            this.lbl_Opnemen.Text = "Bestelling opnemen";
            // 
            // btn_Afronden
            // 
            this.btn_Afronden.Location = new System.Drawing.Point(633, 415);
            this.btn_Afronden.Name = "btn_Afronden";
            this.btn_Afronden.Size = new System.Drawing.Size(155, 23);
            this.btn_Afronden.TabIndex = 1;
            this.btn_Afronden.Text = "Afronden";
            this.btn_Afronden.UseVisualStyleBackColor = true;
            this.btn_Afronden.Click += new System.EventHandler(this.btn_Afronden_Click);
            // 
            // listView_Products
            // 
            this.listView_Products.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView_Products.Location = new System.Drawing.Point(16, 152);
            this.listView_Products.Name = "listView_Products";
            this.listView_Products.Size = new System.Drawing.Size(237, 272);
            this.listView_Products.TabIndex = 2;
            this.listView_Products.UseCompatibleStateImageBehavior = false;
            // 
            // btn_Lunch
            // 
            this.btn_Lunch.Location = new System.Drawing.Point(16, 54);
            this.btn_Lunch.Name = "btn_Lunch";
            this.btn_Lunch.Size = new System.Drawing.Size(75, 79);
            this.btn_Lunch.TabIndex = 3;
            this.btn_Lunch.Text = "Lunch";
            this.btn_Lunch.UseVisualStyleBackColor = true;
            this.btn_Lunch.Click += new System.EventHandler(this.btn_Lunch_Click);
            // 
            // btn_Diner
            // 
            this.btn_Diner.Location = new System.Drawing.Point(97, 54);
            this.btn_Diner.Name = "btn_Diner";
            this.btn_Diner.Size = new System.Drawing.Size(75, 79);
            this.btn_Diner.TabIndex = 4;
            this.btn_Diner.Text = "Diner";
            this.btn_Diner.UseVisualStyleBackColor = true;
            this.btn_Diner.Click += new System.EventHandler(this.btn_Diner_Click);
            // 
            // btn_Dranken
            // 
            this.btn_Dranken.Location = new System.Drawing.Point(178, 54);
            this.btn_Dranken.Name = "btn_Dranken";
            this.btn_Dranken.Size = new System.Drawing.Size(75, 79);
            this.btn_Dranken.TabIndex = 5;
            this.btn_Dranken.Text = "Dranken";
            this.btn_Dranken.UseVisualStyleBackColor = true;
            this.btn_Dranken.Click += new System.EventHandler(this.btn_Dranken_Click);
            // 
            // listView_Order
            // 
            this.listView_Order.Location = new System.Drawing.Point(279, 152);
            this.listView_Order.Name = "listView_Order";
            this.listView_Order.Size = new System.Drawing.Size(237, 272);
            this.listView_Order.TabIndex = 6;
            this.listView_Order.UseCompatibleStateImageBehavior = false;
            // 
            // Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listView_Order);
            this.Controls.Add(this.btn_Dranken);
            this.Controls.Add(this.btn_Diner);
            this.Controls.Add(this.btn_Lunch);
            this.Controls.Add(this.listView_Products);
            this.Controls.Add(this.btn_Afronden);
            this.Controls.Add(this.lbl_Opnemen);
            this.Name = "Order";
            this.Text = "Order";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Opnemen;
        private System.Windows.Forms.Button btn_Afronden;
        private System.Windows.Forms.ListView listView_Products;
        private System.Windows.Forms.Button btn_Lunch;
        private System.Windows.Forms.Button btn_Diner;
        private System.Windows.Forms.Button btn_Dranken;
        private System.Windows.Forms.ListView listView_Order;
    }
}