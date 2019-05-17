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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(344, 426);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(362, 131);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(515, 307);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.SelectionChanged += new System.EventHandler(this.dataGridView2_SelectionChanged);
            // 
            // LB_Table
            // 
            this.LB_Table.AutoSize = true;
            this.LB_Table.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Table.Location = new System.Drawing.Point(503, 68);
            this.LB_Table.Name = "LB_Table";
            this.LB_Table.Size = new System.Drawing.Size(97, 25);
            this.LB_Table.TabIndex = 12;
            this.LB_Table.Text = ".................";
            // 
            // LB_WorkerName
            // 
            this.LB_WorkerName.AutoSize = true;
            this.LB_WorkerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_WorkerName.Location = new System.Drawing.Point(503, 25);
            this.LB_WorkerName.Name = "LB_WorkerName";
            this.LB_WorkerName.Size = new System.Drawing.Size(97, 25);
            this.LB_WorkerName.TabIndex = 11;
            this.LB_WorkerName.Text = ".................";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(369, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Tablenumber";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(367, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Server name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
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
            this.panel1.Location = new System.Drawing.Point(606, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(276, 100);
            this.panel1.TabIndex = 13;
            // 
            // btn_NotDone
            // 
            this.btn_NotDone.Location = new System.Drawing.Point(195, 72);
            this.btn_NotDone.Name = "btn_NotDone";
            this.btn_NotDone.Size = new System.Drawing.Size(75, 23);
            this.btn_NotDone.TabIndex = 11;
            this.btn_NotDone.Text = "Undo";
            this.btn_NotDone.UseVisualStyleBackColor = true;
            this.btn_NotDone.Click += new System.EventHandler(this.btn_NotDone_Click);
            // 
            // btn_Done
            // 
            this.btn_Done.Location = new System.Drawing.Point(196, 72);
            this.btn_Done.Name = "btn_Done";
            this.btn_Done.Size = new System.Drawing.Size(75, 23);
            this.btn_Done.TabIndex = 10;
            this.btn_Done.Text = "Done";
            this.btn_Done.UseVisualStyleBackColor = true;
            this.btn_Done.Click += new System.EventHandler(this.btn_Done_Click);
            // 
            // LB_Amount
            // 
            this.LB_Amount.AutoSize = true;
            this.LB_Amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Amount.Location = new System.Drawing.Point(65, 42);
            this.LB_Amount.Name = "LB_Amount";
            this.LB_Amount.Size = new System.Drawing.Size(0, 17);
            this.LB_Amount.TabIndex = 9;
            // 
            // LB_ProductName
            // 
            this.LB_ProductName.AutoSize = true;
            this.LB_ProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_ProductName.Location = new System.Drawing.Point(3, 0);
            this.LB_ProductName.Name = "LB_ProductName";
            this.LB_ProductName.Size = new System.Drawing.Size(0, 17);
            this.LB_ProductName.TabIndex = 9;
            // 
            // BarOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 450);
            this.Controls.Add(this.LB_Table);
            this.Controls.Add(this.LB_WorkerName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "BarOverview";
            this.Text = "BarOverview";
            this.Load += new System.EventHandler(this.BarOverview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
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
    }
}