namespace WebCene.UI.Forms.B2B
{
    partial class frmMarzeRabatiDobavljaca
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
            this.btnSnimiMarzu = new System.Windows.Forms.Button();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNncDonji = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNncGornji = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMarzaProc = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblNaziv = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRabatProc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBrend = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSnimiMarzu
            // 
            this.btnSnimiMarzu.Location = new System.Drawing.Point(447, 90);
            this.btnSnimiMarzu.Name = "btnSnimiMarzu";
            this.btnSnimiMarzu.Size = new System.Drawing.Size(93, 31);
            this.btnSnimiMarzu.TabIndex = 3;
            this.btnSnimiMarzu.Text = "Snimi";
            this.btnSnimiMarzu.UseVisualStyleBackColor = true;
            this.btnSnimiMarzu.Click += new System.EventHandler(this.btnSnimiMarzu_Click);
            // 
            // btnOdustani
            // 
            this.btnOdustani.Location = new System.Drawing.Point(546, 90);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(93, 31);
            this.btnOdustani.TabIndex = 4;
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 7);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "NNC Donji limit";
            // 
            // txtNncDonji
            // 
            this.txtNncDonji.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNncDonji.Location = new System.Drawing.Point(95, 3);
            this.txtNncDonji.Name = "txtNncDonji";
            this.txtNncDonji.Size = new System.Drawing.Size(108, 23);
            this.txtNncDonji.TabIndex = 0;
            this.txtNncDonji.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateDecimalInput);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(209, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "NNC Gornji limit";
            // 
            // txtNncGornji
            // 
            this.txtNncGornji.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNncGornji.Location = new System.Drawing.Point(305, 3);
            this.txtNncGornji.Name = "txtNncGornji";
            this.txtNncGornji.Size = new System.Drawing.Size(108, 23);
            this.txtNncGornji.TabIndex = 1;
            this.txtNncGornji.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateDecimalInput);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(419, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Marža (%)";
            // 
            // txtMarzaProc
            // 
            this.txtMarzaProc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMarzaProc.Location = new System.Drawing.Point(481, 3);
            this.txtMarzaProc.Name = "txtMarzaProc";
            this.txtMarzaProc.Size = new System.Drawing.Size(108, 23);
            this.txtMarzaProc.TabIndex = 2;
            this.txtMarzaProc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateDecimalInput);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Controls.Add(this.txtNncDonji);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.txtNncGornji);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.txtMarzaProc);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.txtRabatProc);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.comboBrend);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(41, 40);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1011, 31);
            this.flowLayoutPanel1.TabIndex = 13;
            // 
            // lblNaziv
            // 
            this.lblNaziv.AutoSize = true;
            this.lblNaziv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNaziv.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNaziv.ForeColor = System.Drawing.Color.DarkOrchid;
            this.lblNaziv.Location = new System.Drawing.Point(20, 8);
            this.lblNaziv.Margin = new System.Windows.Forms.Padding(5);
            this.lblNaziv.Name = "lblNaziv";
            this.lblNaziv.Size = new System.Drawing.Size(57, 21);
            this.lblNaziv.TabIndex = 14;
            this.lblNaziv.Text = "Marža";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(595, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Rabat (%)";
            // 
            // txtRabatProc
            // 
            this.txtRabatProc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRabatProc.Location = new System.Drawing.Point(656, 3);
            this.txtRabatProc.Name = "txtRabatProc";
            this.txtRabatProc.Size = new System.Drawing.Size(108, 23);
            this.txtRabatProc.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(770, 7);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Brend";
            // 
            // comboBrend
            // 
            this.comboBrend.FormattingEnabled = true;
            this.comboBrend.Location = new System.Drawing.Point(814, 3);
            this.comboBrend.Name = "comboBrend";
            this.comboBrend.Size = new System.Drawing.Size(168, 23);
            this.comboBrend.TabIndex = 15;
            // 
            // frmMarzeRabatiDobavljaca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 133);
            this.ControlBox = false;
            this.Controls.Add(this.lblNaziv);
            this.Controls.Add(this.btnSnimiMarzu);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnOdustani);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1080, 172);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(680, 172);
            this.Name = "frmMarzeRabatiDobavljaca";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Marže i rabati dobavljača";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSnimiMarzu;
        private System.Windows.Forms.Button btnOdustani;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNncDonji;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNncGornji;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMarzaProc;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblNaziv;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRabatProc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBrend;
    }
}