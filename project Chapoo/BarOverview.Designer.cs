namespace project_Chapoo
{
    partial class BarOverview
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
            this.LB_Table = new System.Windows.Forms.Label();
            this.LB_WorkerName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_NotDone = new System.Windows.Forms.Button();
            this.btn_Done = new System.Windows.Forms.Button();
            this.LB_Amount = new System.Windows.Forms.Label();
            this.LB_ProductName = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LB_Table
            // 
            this.LB_Table.AutoSize = true;
            this.LB_Table.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Table.Location = new System.Drawing.Point(671, 84);
            this.LB_Table.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LB_Table.Name = "LB_Table";
            this.LB_Table.Size = new System.Drawing.Size(132, 29);
            this.LB_Table.TabIndex = 12;
            this.LB_Table.Text = ".................";
            // 
            // LB_WorkerName
            // 
            this.LB_WorkerName.AutoSize = true;
            this.LB_WorkerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_WorkerName.Location = new System.Drawing.Point(671, 31);
            this.LB_WorkerName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LB_WorkerName.Name = "LB_WorkerName";
            this.LB_WorkerName.Size = new System.Drawing.Size(132, 29);
            this.LB_WorkerName.TabIndex = 11;
            this.LB_WorkerName.Text = ".................";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(492, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 29);
            this.label2.TabIndex = 10;
            this.label2.Text = "Tablenumber";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(489, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 29);
            this.label1.TabIndex = 9;
            this.label1.Text = "Server name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 52);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Amount:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btn_NotDone);
            this.panel1.Controls.Add(this.btn_Done);
            this.panel1.Controls.Add(this.LB_Amount);
            this.panel1.Controls.Add(this.LB_ProductName);
            this.panel1.Location = new System.Drawing.Point(808, 31);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(367, 123);
            this.panel1.TabIndex = 13;
            // 
            // btn_NotDone
            // 
            this.btn_NotDone.Location = new System.Drawing.Point(260, 89);
            this.btn_NotDone.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_NotDone.Name = "btn_NotDone";
            this.btn_NotDone.Size = new System.Drawing.Size(100, 28);
            this.btn_NotDone.TabIndex = 11;
            this.btn_NotDone.Text = "Undo";
            this.btn_NotDone.UseVisualStyleBackColor = true;
            this.btn_NotDone.Click += new System.EventHandler(this.btn_NotDone_Click);
            // 
            // btn_Done
            // 
            this.btn_Done.Location = new System.Drawing.Point(261, 89);
            this.btn_Done.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Done.Name = "btn_Done";
            this.btn_Done.Size = new System.Drawing.Size(100, 28);
            this.btn_Done.TabIndex = 10;
            this.btn_Done.Text = "Done";
            this.btn_Done.UseVisualStyleBackColor = true;
            this.btn_Done.Click += new System.EventHandler(this.btn_Done_Click);
            // 
            // LB_Amount
            // 
            this.LB_Amount.AutoSize = true;
            this.LB_Amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Amount.Location = new System.Drawing.Point(87, 52);
            this.LB_Amount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LB_Amount.Name = "LB_Amount";
            this.LB_Amount.Size = new System.Drawing.Size(0, 20);
            this.LB_Amount.TabIndex = 9;
            // 
            // LB_ProductName
            // 
            this.LB_ProductName.AutoSize = true;
            this.LB_ProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_ProductName.Location = new System.Drawing.Point(4, 0);
            this.LB_ProductName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LB_ProductName.Name = "LB_ProductName";
            this.LB_ProductName.Size = new System.Drawing.Size(0, 20);
            this.LB_ProductName.TabIndex = 9;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.Location = new System.Drawing.Point(12, 16);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(464, 523);
            this.listView1.TabIndex = 14;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.listView2.Location = new System.Drawing.Point(494, 214);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(675, 325);
            this.listView2.TabIndex = 15;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Id";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tablenumber";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Status";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Name";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Amount";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Status";
            // 
            // BarOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 554);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.LB_Table);
            this.Controls.Add(this.LB_WorkerName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "BarOverview";
            this.Text = "BarOverview";
            this.Load += new System.EventHandler(this.BarOverview_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LB_Table;
        private System.Windows.Forms.Label LB_WorkerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_NotDone;
        private System.Windows.Forms.Button btn_Done;
        private System.Windows.Forms.Label LB_Amount;
        private System.Windows.Forms.Label LB_ProductName;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
    }
}