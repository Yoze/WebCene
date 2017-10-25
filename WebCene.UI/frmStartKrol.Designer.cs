namespace WebCene.UI
{
    partial class frmStartKrol
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
            this.btnStopKrol = new System.Windows.Forms.Button();
            this.lblKompletirano = new System.Windows.Forms.Label();
            this.checkSviProizvodi = new System.Windows.Forms.CheckBox();
            this.checkSviProdavci = new System.Windows.Forms.CheckBox();
            this.lblSacekajte = new System.Windows.Forms.Label();
            this.lstViewRezultat = new System.Windows.Forms.ListView();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSnimi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Novi krol";
            // 
            // dateTimeDatumKrola
            // 
            this.dateTimeDatumKrola.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeDatumKrola.Location = new System.Drawing.Point(84, 77);
            this.dateTimeDatumKrola.Name = "dateTimeDatumKrola";
            this.dateTimeDatumKrola.Size = new System.Drawing.Size(111, 25);
            this.dateTimeDatumKrola.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Datum";
            // 
            // txtIzvrsilacKrola
            // 
            this.txtIzvrsilacKrola.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIzvrsilacKrola.Location = new System.Drawing.Point(84, 107);
            this.txtIzvrsilacKrola.MaxLength = 50;
            this.txtIzvrsilacKrola.Name = "txtIzvrsilacKrola";
            this.txtIzvrsilacKrola.Size = new System.Drawing.Size(217, 25);
            this.txtIzvrsilacKrola.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Izvršilac";
            // 
            // btnStartKrol
            // 
            this.btnStartKrol.Location = new System.Drawing.Point(1025, 585);
            this.btnStartKrol.Name = "btnStartKrol";
            this.btnStartKrol.Size = new System.Drawing.Size(121, 37);
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
            this.listBoxProizvodi.Location = new System.Drawing.Point(16, 207);
            this.listBoxProizvodi.Name = "listBoxProizvodi";
            this.listBoxProizvodi.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxProizvodi.Size = new System.Drawing.Size(285, 325);
            this.listBoxProizvodi.TabIndex = 8;
            // 
            // listBoxProdavci
            // 
            this.listBoxProdavci.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxProdavci.FormattingEnabled = true;
            this.listBoxProdavci.ItemHeight = 17;
            this.listBoxProdavci.Location = new System.Drawing.Point(328, 207);
            this.listBoxProdavci.Name = "listBoxProdavci";
            this.listBoxProdavci.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxProdavci.Size = new System.Drawing.Size(285, 325);
            this.listBoxProdavci.TabIndex = 9;
            // 
            // txtKrolId
            // 
            this.txtKrolId.Location = new System.Drawing.Point(481, 578);
            this.txtKrolId.Name = "txtKrolId";
            this.txtKrolId.Size = new System.Drawing.Size(45, 25);
            this.txtKrolId.TabIndex = 10;
            this.txtKrolId.Visible = false;
            // 
            // progressKrol
            // 
            this.progressKrol.Location = new System.Drawing.Point(17, 599);
            this.progressKrol.Name = "progressKrol";
            this.progressKrol.Size = new System.Drawing.Size(369, 9);
            this.progressKrol.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(12, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Odaberi proizvode ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkRed;
            this.label5.Location = new System.Drawing.Point(324, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Odaberi prodavce";
            // 
            // btnStopKrol
            // 
            this.btnStopKrol.Location = new System.Drawing.Point(532, 571);
            this.btnStopKrol.Name = "btnStopKrol";
            this.btnStopKrol.Size = new System.Drawing.Size(121, 37);
            this.btnStopKrol.TabIndex = 15;
            this.btnStopKrol.Text = "Stop";
            this.btnStopKrol.UseVisualStyleBackColor = true;
            this.btnStopKrol.Visible = false;
            this.btnStopKrol.Click += new System.EventHandler(this.btnStopKrol_Click);
            // 
            // lblKompletirano
            // 
            this.lblKompletirano.AutoSize = true;
            this.lblKompletirano.Location = new System.Drawing.Point(14, 579);
            this.lblKompletirano.Name = "lblKompletirano";
            this.lblKompletirano.Size = new System.Drawing.Size(87, 17);
            this.lblKompletirano.TabIndex = 16;
            this.lblKompletirano.Text = "Kompletirano";
            // 
            // checkSviProizvodi
            // 
            this.checkSviProizvodi.AutoSize = true;
            this.checkSviProizvodi.Location = new System.Drawing.Point(212, 182);
            this.checkSviProizvodi.Name = "checkSviProizvodi";
            this.checkSviProizvodi.Size = new System.Drawing.Size(89, 21);
            this.checkSviProizvodi.TabIndex = 17;
            this.checkSviProizvodi.Text = "Označi sve";
            this.checkSviProizvodi.UseVisualStyleBackColor = true;
            this.checkSviProizvodi.CheckedChanged += new System.EventHandler(this.checkSviProizvodi_CheckedChanged);
            // 
            // checkSviProdavci
            // 
            this.checkSviProdavci.AutoSize = true;
            this.checkSviProdavci.Location = new System.Drawing.Point(524, 183);
            this.checkSviProdavci.Name = "checkSviProdavci";
            this.checkSviProdavci.Size = new System.Drawing.Size(89, 21);
            this.checkSviProdavci.TabIndex = 18;
            this.checkSviProdavci.Text = "Označi sve";
            this.checkSviProdavci.UseVisualStyleBackColor = true;
            this.checkSviProdavci.CheckedChanged += new System.EventHandler(this.checkSviProdavci_CheckedChanged);
            // 
            // lblSacekajte
            // 
            this.lblSacekajte.AutoSize = true;
            this.lblSacekajte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSacekajte.CausesValidation = false;
            this.lblSacekajte.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSacekajte.ForeColor = System.Drawing.Color.White;
            this.lblSacekajte.Location = new System.Drawing.Point(423, 61);
            this.lblSacekajte.Name = "lblSacekajte";
            this.lblSacekajte.Padding = new System.Windows.Forms.Padding(5);
            this.lblSacekajte.Size = new System.Drawing.Size(285, 35);
            this.lblSacekajte.TabIndex = 19;
            this.lblSacekajte.Text = "Obrada je u toku. Sačekajte ...";
            this.lblSacekajte.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSacekajte.Visible = false;
            // 
            // lstViewRezultat
            // 
            this.lstViewRezultat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstViewRezultat.FullRowSelect = true;
            this.lstViewRezultat.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstViewRezultat.Location = new System.Drawing.Point(640, 207);
            this.lstViewRezultat.MultiSelect = false;
            this.lstViewRezultat.Name = "lstViewRezultat";
            this.lstViewRezultat.Size = new System.Drawing.Size(500, 325);
            this.lstViewRezultat.TabIndex = 20;
            this.lstViewRezultat.UseCompatibleStateImageBehavior = false;
            this.lstViewRezultat.View = System.Windows.Forms.View.Details;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkRed;
            this.label6.Location = new System.Drawing.Point(636, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 20);
            this.label6.TabIndex = 21;
            this.label6.Text = "Rezultat krola";
            // 
            // btnSnimi
            // 
            this.btnSnimi.Location = new System.Drawing.Point(898, 585);
            this.btnSnimi.Name = "btnSnimi";
            this.btnSnimi.Size = new System.Drawing.Size(121, 37);
            this.btnSnimi.TabIndex = 22;
            this.btnSnimi.Text = "Snimi";
            this.btnSnimi.UseVisualStyleBackColor = true;
            // 
            // frmStartKrol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 634);
            this.Controls.Add(this.btnSnimi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblSacekajte);
            this.Controls.Add(this.lstViewRezultat);
            this.Controls.Add(this.checkSviProdavci);
            this.Controls.Add(this.checkSviProizvodi);
            this.Controls.Add(this.lblKompletirano);
            this.Controls.Add(this.btnStopKrol);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.progressKrol);
            this.Controls.Add(this.txtKrolId);
            this.Controls.Add(this.btnStartKrol);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIzvrsilacKrola);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimeDatumKrola);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxProizvodi);
            this.Controls.Add(this.listBoxProdavci);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmStartKrol";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Krolovanje";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_NextControl);
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
        private System.Windows.Forms.Button btnStopKrol;
        private System.Windows.Forms.Label lblKompletirano;
        private System.Windows.Forms.CheckBox checkSviProizvodi;
        private System.Windows.Forms.CheckBox checkSviProdavci;
        private System.Windows.Forms.Label lblSacekajte;
        private System.Windows.Forms.ListView lstViewRezultat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSnimi;
    }
}