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
            this.lbl_Bestelling = new System.Windows.Forms.Label();
            this.btn_Afronden = new System.Windows.Forms.Button();
            this.listView_Products = new System.Windows.Forms.ListView();
            this.btn_Eten = new System.Windows.Forms.Button();
            this.btn_Dranken = new System.Windows.Forms.Button();
            this.listView_Order = new System.Windows.Forms.ListView();
            this.lbl_bestellingvoor = new System.Windows.Forms.Label();
            this.lbl_TafelNummer = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_Bestelling
            // 
            this.lbl_Bestelling.AutoSize = true;
            this.lbl_Bestelling.Font = new System.Drawing.Font("Arial", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Bestelling.Location = new System.Drawing.Point(13, 13);
            this.lbl_Bestelling.Name = "lbl_Bestelling";
            this.lbl_Bestelling.Size = new System.Drawing.Size(149, 16);
            this.lbl_Bestelling.TabIndex = 0;
            this.lbl_Bestelling.Text = "Bestelling opnemen";
            // 
            // btn_Afronden
            // 
            this.btn_Afronden.Location = new System.Drawing.Point(633, 401);
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
            this.listView_Products.Location = new System.Drawing.Point(16, 189);
            this.listView_Products.Name = "listView_Products";
            this.listView_Products.Size = new System.Drawing.Size(237, 235);
            this.listView_Products.TabIndex = 2;
            this.listView_Products.UseCompatibleStateImageBehavior = false;
            this.listView_Products.SelectedIndexChanged += new System.EventHandler(this.listView_Products_SelectedIndexChanged);
            // 
            // btn_Eten
            // 
            this.btn_Eten.Location = new System.Drawing.Point(17, 104);
            this.btn_Eten.Name = "btn_Eten";
            this.btn_Eten.Size = new System.Drawing.Size(75, 79);
            this.btn_Eten.TabIndex = 3;
            this.btn_Eten.Text = "Eten";
            this.btn_Eten.UseVisualStyleBackColor = true;
            this.btn_Eten.Click += new System.EventHandler(this.btn_Eten_Click);
            // 
            // btn_Dranken
            // 
            this.btn_Dranken.Location = new System.Drawing.Point(178, 104);
            this.btn_Dranken.Name = "btn_Dranken";
            this.btn_Dranken.Size = new System.Drawing.Size(75, 79);
            this.btn_Dranken.TabIndex = 5;
            this.btn_Dranken.Text = "Dranken";
            this.btn_Dranken.UseVisualStyleBackColor = true;
            this.btn_Dranken.Click += new System.EventHandler(this.btn_Dranken_Click);
            // 
            // listView_Order
            // 
            this.listView_Order.Location = new System.Drawing.Point(279, 189);
            this.listView_Order.Name = "listView_Order";
            this.listView_Order.Size = new System.Drawing.Size(237, 235);
            this.listView_Order.TabIndex = 6;
            this.listView_Order.UseCompatibleStateImageBehavior = false;
            // 
            // lbl_bestellingvoor
            // 
            this.lbl_bestellingvoor.AutoSize = true;
            this.lbl_bestellingvoor.Font = new System.Drawing.Font("Arial", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_bestellingvoor.Location = new System.Drawing.Point(13, 47);
            this.lbl_bestellingvoor.Name = "lbl_bestellingvoor";
            this.lbl_bestellingvoor.Size = new System.Drawing.Size(155, 16);
            this.lbl_bestellingvoor.TabIndex = 7;
            this.lbl_bestellingvoor.Text = "Bestelling voor tafel:";
            // 
            // lbl_TafelNummer
            // 
            this.lbl_TafelNummer.AutoSize = true;
            this.lbl_TafelNummer.Font = new System.Drawing.Font("Arial", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TafelNummer.Location = new System.Drawing.Point(174, 47);
            this.lbl_TafelNummer.Name = "lbl_TafelNummer";
            this.lbl_TafelNummer.Size = new System.Drawing.Size(16, 16);
            this.lbl_TafelNummer.TabIndex = 8;
            this.lbl_TafelNummer.Text = "x";
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
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbl_TafelNummer);
            this.Controls.Add(this.lbl_bestellingvoor);
            this.Controls.Add(this.listView_Order);
            this.Controls.Add(this.btn_Dranken);
            this.Controls.Add(this.btn_Eten);
            this.Controls.Add(this.listView_Products);
            this.Controls.Add(this.btn_Afronden);
            this.Controls.Add(this.lbl_Bestelling);
            this.Name = "Order";
            this.Text = "Order";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Bestelling;
        private System.Windows.Forms.Button btn_Afronden;
        private System.Windows.Forms.ListView listView_Products;
        private System.Windows.Forms.Button btn_Eten;
        private System.Windows.Forms.Button btn_Dranken;
        private System.Windows.Forms.ListView listView_Order;
        private System.Windows.Forms.Label lbl_bestellingvoor;
        private System.Windows.Forms.Label lbl_TafelNummer;
        private System.Windows.Forms.Button button1;
    }
}