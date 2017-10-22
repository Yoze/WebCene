namespace WebCene.UI
{
    partial class frmProdavci
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
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtNazivProdavca = new System.Windows.Forms.TextBox();
            this.txtSajt = new System.Windows.Forms.TextBox();
            this.txtSMId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSnimi = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Prodavci";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(407, 12);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(39, 25);
            this.txtId.TabIndex = 2;
            this.txtId.Visible = false;
            // 
            // txtNazivProdavca
            // 
            this.txtNazivProdavca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNazivProdavca.Location = new System.Drawing.Point(120, 36);
            this.txtNazivProdavca.MaxLength = 50;
            this.txtNazivProdavca.Name = "txtNazivProdavca";
            this.txtNazivProdavca.Size = new System.Drawing.Size(270, 25);
            this.txtNazivProdavca.TabIndex = 3;
            // 
            // txtSajt
            // 
            this.txtSajt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSajt.Location = new System.Drawing.Point(120, 67);
            this.txtSajt.MaxLength = 150;
            this.txtSajt.Name = "txtSajt";
            this.txtSajt.Size = new System.Drawing.Size(270, 25);
            this.txtSajt.TabIndex = 4;
            // 
            // txtSMId
            // 
            this.txtSMId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSMId.Location = new System.Drawing.Point(120, 98);
            this.txtSMId.MaxLength = 20;
            this.txtSMId.Name = "txtSMId";
            this.txtSMId.Size = new System.Drawing.Size(270, 25);
            this.txtSMId.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Naziv";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Sajt";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Shopmania alt";
            // 
            // btnSnimi
            // 
            this.btnSnimi.Location = new System.Drawing.Point(392, 253);
            this.btnSnimi.Name = "btnSnimi";
            this.btnSnimi.Size = new System.Drawing.Size(86, 29);
            this.btnSnimi.TabIndex = 9;
            this.btnSnimi.Text = "Snimi";
            this.btnSnimi.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSajt);
            this.groupBox1.Controls.Add(this.txtNazivProdavca);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtSMId);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(16, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(430, 162);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Podaci";
            // 
            // Prodavci
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 294);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSnimi);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Prodavci";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prodavci";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtNazivProdavca;
        private System.Windows.Forms.TextBox txtSajt;
        private System.Windows.Forms.TextBox txtSMId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSnimi;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}