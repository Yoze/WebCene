namespace WebCene.UI
{
    partial class StartKrol
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
            this.dateTimeDatumKrola = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIzvrsilacKrola = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStartKrol = new System.Windows.Forms.Button();
            this.listBoxProizvodi = new System.Windows.Forms.ListBox();
            this.listBoxProdavci = new System.Windows.Forms.ListBox();
            this.txtKrolId = new System.Windows.Forms.TextBox();
            this.progressKrol = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Start krol";
            // 
            // dateTimeDatumKrola
            // 
            this.dateTimeDatumKrola.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeDatumKrola.Location = new System.Drawing.Point(105, 54);
            this.dateTimeDatumKrola.Name = "dateTimeDatumKrola";
            this.dateTimeDatumKrola.Size = new System.Drawing.Size(111, 25);
            this.dateTimeDatumKrola.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Datum";
            // 
            // txtIzvrsilacKrola
            // 
            this.txtIzvrsilacKrola.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIzvrsilacKrola.Location = new System.Drawing.Point(105, 85);
            this.txtIzvrsilacKrola.MaxLength = 50;
            this.txtIzvrsilacKrola.Name = "txtIzvrsilacKrola";
            this.txtIzvrsilacKrola.Size = new System.Drawing.Size(280, 25);
            this.txtIzvrsilacKrola.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Izvršilac krola";
            // 
            // btnStartKrol
            // 
            this.btnStartKrol.Location = new System.Drawing.Point(672, 495);
            this.btnStartKrol.Name = "btnStartKrol";
            this.btnStartKrol.Size = new System.Drawing.Size(110, 39);
            this.btnStartKrol.TabIndex = 7;
            this.btnStartKrol.Text = "Start";
            this.btnStartKrol.UseVisualStyleBackColor = true;
            this.btnStartKrol.Click += new System.EventHandler(this.btnStartKrol_Click);
            // 
            // listBoxProizvodi
            // 
            this.listBoxProizvodi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxProizvodi.FormattingEnabled = true;
            this.listBoxProizvodi.ItemHeight = 17;
            this.listBoxProizvodi.Location = new System.Drawing.Point(16, 149);
            this.listBoxProizvodi.Name = "listBoxProizvodi";
            this.listBoxProizvodi.Size = new System.Drawing.Size(369, 308);
            this.listBoxProizvodi.TabIndex = 8;
            // 
            // listBoxProdavci
            // 
            this.listBoxProdavci.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxProdavci.FormattingEnabled = true;
            this.listBoxProdavci.ItemHeight = 17;
            this.listBoxProdavci.Location = new System.Drawing.Point(406, 149);
            this.listBoxProdavci.Name = "listBoxProdavci";
            this.listBoxProdavci.Size = new System.Drawing.Size(369, 308);
            this.listBoxProdavci.TabIndex = 9;
            // 
            // txtKrolId
            // 
            this.txtKrolId.Location = new System.Drawing.Point(406, 12);
            this.txtKrolId.Name = "txtKrolId";
            this.txtKrolId.Size = new System.Drawing.Size(45, 25);
            this.txtKrolId.TabIndex = 10;
            this.txtKrolId.Visible = false;
            // 
            // progressKrol
            // 
            this.progressKrol.Location = new System.Drawing.Point(12, 519);
            this.progressKrol.Name = "progressKrol";
            this.progressKrol.Size = new System.Drawing.Size(369, 15);
            this.progressKrol.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Odaberi proizvode (Ctrl za više)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(403, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Odaberi prodavce (Ctrl za više)";
            // 
            // StartKrol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 546);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.progressKrol);
            this.Controls.Add(this.txtKrolId);
            this.Controls.Add(this.listBoxProdavci);
            this.Controls.Add(this.listBoxProizvodi);
            this.Controls.Add(this.btnStartKrol);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIzvrsilacKrola);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimeDatumKrola);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "StartKrol";
            this.ShowInTaskbar = false;
            this.Text = "StartKrol";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimeDatumKrola;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIzvrsilacKrola;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnStartKrol;
        private System.Windows.Forms.ListBox listBoxProizvodi;
        private System.Windows.Forms.ListBox listBoxProdavci;
        private System.Windows.Forms.TextBox txtKrolId;
        private System.Windows.Forms.ProgressBar progressKrol;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}