namespace WebCene.UI
{
    partial class frmKrolovi
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNoviKrol = new System.Windows.Forms.Button();
            this.dgvListaKrolova = new System.Windows.Forms.DataGridView();
            this.dgvDetaljiKrola = new System.Windows.Forms.DataGridView();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaKrolova)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetaljiKrola)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvDetaljiKrola);
            this.groupBox2.Location = new System.Drawing.Point(16, 325);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(948, 242);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detalji krola";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvListaKrolova);
            this.groupBox1.Location = new System.Drawing.Point(15, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(948, 254);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista krolova";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Dosadašnji krolovi";
            // 
            // btnNoviKrol
            // 
            this.btnNoviKrol.Location = new System.Drawing.Point(19, 584);
            this.btnNoviKrol.Name = "btnNoviKrol";
            this.btnNoviKrol.Size = new System.Drawing.Size(121, 37);
            this.btnNoviKrol.TabIndex = 17;
            this.btnNoviKrol.Text = "Novi krol";
            this.btnNoviKrol.UseVisualStyleBackColor = true;
            // 
            // dgvListaKrolova
            // 
            this.dgvListaKrolova.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaKrolova.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListaKrolova.Location = new System.Drawing.Point(3, 21);
            this.dgvListaKrolova.Name = "dgvListaKrolova";
            this.dgvListaKrolova.Size = new System.Drawing.Size(942, 230);
            this.dgvListaKrolova.TabIndex = 0;
            // 
            // dgvDetaljiKrola
            // 
            this.dgvDetaljiKrola.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetaljiKrola.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetaljiKrola.Location = new System.Drawing.Point(3, 21);
            this.dgvDetaljiKrola.Name = "dgvDetaljiKrola";
            this.dgvDetaljiKrola.Size = new System.Drawing.Size(942, 218);
            this.dgvDetaljiKrola.TabIndex = 0;
            // 
            // Krolovi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 642);
            this.Controls.Add(this.btnNoviKrol);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Krolovi";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Krolovi";
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaKrolova)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetaljiKrola)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNoviKrol;
        private System.Windows.Forms.DataGridView dgvDetaljiKrola;
        private System.Windows.Forms.DataGridView dgvListaKrolova;
    }
}