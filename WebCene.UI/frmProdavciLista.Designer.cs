namespace WebCene.UI
{
    partial class frmProdavciLista
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnNoviProdavac = new System.Windows.Forms.Button();
            this.dgvListaProdavac = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaProdavac)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lista prodavaca";
            // 
            // btnNoviProdavac
            // 
            this.btnNoviProdavac.Location = new System.Drawing.Point(12, 418);
            this.btnNoviProdavac.Name = "btnNoviProdavac";
            this.btnNoviProdavac.Size = new System.Drawing.Size(121, 37);
            this.btnNoviProdavac.TabIndex = 18;
            this.btnNoviProdavac.Text = "Novi prodavac";
            this.btnNoviProdavac.UseVisualStyleBackColor = true;
            // 
            // dgvListaProdavac
            // 
            this.dgvListaProdavac.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaProdavac.Location = new System.Drawing.Point(12, 54);
            this.dgvListaProdavac.Name = "dgvListaProdavac";
            this.dgvListaProdavac.Size = new System.Drawing.Size(634, 336);
            this.dgvListaProdavac.TabIndex = 19;
            // 
            // ProdavciLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 476);
            this.Controls.Add(this.dgvListaProdavac);
            this.Controls.Add(this.btnNoviProdavac);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ProdavciLista";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prodavci";
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaProdavac)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNoviProdavac;
        private System.Windows.Forms.DataGridView dgvListaProdavac;
    }
}