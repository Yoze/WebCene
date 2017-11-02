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
            this.components = new System.ComponentModel.Container();
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
            this.lstViewRezultat = new System.Windows.Forms.ListView();
            this.colProizvoda = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProdavac = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCena = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label6 = new System.Windows.Forms.Label();
            this.btnSnimi = new System.Windows.Forms.Button();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.txtNAzivKrola = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSacekajte = new System.Windows.Forms.Label();
            this.errProviderNoviKrol = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderNoviKrol)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimeDatumKrola
            // 
            this.dateTimeDatumKrola.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeDatumKrola.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeDatumKrola.Location = new System.Drawing.Point(92, 98);
            this.dateTimeDatumKrola.Name = "dateTimeDatumKrola";
            this.dateTimeDatumKrola.Size = new System.Drawing.Size(111, 25);
            this.dateTimeDatumKrola.TabIndex = 2;
            this.dateTimeDatumKrola.Validating += new System.ComponentModel.CancelEventHandler(this.dateTimeDatumKrola_Validating);
            this.dateTimeDatumKrola.Validated += new System.EventHandler(this.dateTimeDatumKrola_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(11, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Datum";
            // 
            // txtIzvrsilacKrola
            // 
            this.txtIzvrsilacKrola.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIzvrsilacKrola.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIzvrsilacKrola.Location = new System.Drawing.Point(92, 67);
            this.txtIzvrsilacKrola.MaxLength = 50;
            this.txtIzvrsilacKrola.Name = "txtIzvrsilacKrola";
            this.txtIzvrsilacKrola.Size = new System.Drawing.Size(347, 25);
            this.txtIzvrsilacKrola.TabIndex = 1;
            this.txtIzvrsilacKrola.Validating += new System.ComponentModel.CancelEventHandler(this.txtIzvrsilacKrola_Validating);
            this.txtIzvrsilacKrola.Validated += new System.EventHandler(this.txtIzvrsilacKrola_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(11, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Izvršilac";
            // 
            // btnStartKrol
            // 
            this.btnStartKrol.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartKrol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnStartKrol.Location = new System.Drawing.Point(876, 114);
            this.btnStartKrol.Name = "btnStartKrol";
            this.btnStartKrol.Size = new System.Drawing.Size(229, 37);
            this.btnStartKrol.TabIndex = 5;
            this.btnStartKrol.Text = "POKRENI KROL";
            this.btnStartKrol.UseVisualStyleBackColor = true;
            this.btnStartKrol.Click += new System.EventHandler(this.btnStartKrol_Click);
            // 
            // listBoxProizvodi
            // 
            this.listBoxProizvodi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxProizvodi.FormattingEnabled = true;
            this.listBoxProizvodi.ItemHeight = 17;
            this.listBoxProizvodi.Location = new System.Drawing.Point(31, 207);
            this.listBoxProizvodi.Name = "listBoxProizvodi";
            this.listBoxProizvodi.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxProizvodi.Size = new System.Drawing.Size(285, 325);
            this.listBoxProizvodi.TabIndex = 2;
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
            this.listBoxProdavci.TabIndex = 4;
            // 
            // txtKrolId
            // 
            this.txtKrolId.Location = new System.Drawing.Point(481, 549);
            this.txtKrolId.Name = "txtKrolId";
            this.txtKrolId.Size = new System.Drawing.Size(45, 25);
            this.txtKrolId.TabIndex = 9;
            this.txtKrolId.Visible = false;
            // 
            // progressKrol
            // 
            this.progressKrol.Location = new System.Drawing.Point(31, 598);
            this.progressKrol.Name = "progressKrol";
            this.progressKrol.Size = new System.Drawing.Size(582, 7);
            this.progressKrol.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(27, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Odaberi artikle";
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
            this.label5.TabIndex = 3;
            this.label5.Text = "Odaberi prodavce";
            // 
            // btnStopKrol
            // 
            this.btnStopKrol.Location = new System.Drawing.Point(532, 542);
            this.btnStopKrol.Name = "btnStopKrol";
            this.btnStopKrol.Size = new System.Drawing.Size(121, 37);
            this.btnStopKrol.TabIndex = 10;
            this.btnStopKrol.Text = "Stop";
            this.btnStopKrol.UseVisualStyleBackColor = true;
            this.btnStopKrol.Visible = false;
            this.btnStopKrol.Click += new System.EventHandler(this.btnStopKrol_Click);
            // 
            // lblKompletirano
            // 
            this.lblKompletirano.AutoSize = true;
            this.lblKompletirano.Location = new System.Drawing.Point(28, 578);
            this.lblKompletirano.Name = "lblKompletirano";
            this.lblKompletirano.Size = new System.Drawing.Size(87, 17);
            this.lblKompletirano.TabIndex = 7;
            this.lblKompletirano.Text = "Kompletirano";
            // 
            // checkSviProizvodi
            // 
            this.checkSviProizvodi.AutoSize = true;
            this.checkSviProizvodi.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkSviProizvodi.Location = new System.Drawing.Point(236, 186);
            this.checkSviProizvodi.Name = "checkSviProizvodi";
            this.checkSviProizvodi.Size = new System.Drawing.Size(80, 17);
            this.checkSviProizvodi.TabIndex = 11;
            this.checkSviProizvodi.Text = "Označi sve";
            this.checkSviProizvodi.UseVisualStyleBackColor = true;
            this.checkSviProizvodi.CheckedChanged += new System.EventHandler(this.checkSviProizvodi_CheckedChanged);
            // 
            // checkSviProdavci
            // 
            this.checkSviProdavci.AutoSize = true;
            this.checkSviProdavci.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkSviProdavci.Location = new System.Drawing.Point(533, 186);
            this.checkSviProdavci.Name = "checkSviProdavci";
            this.checkSviProdavci.Size = new System.Drawing.Size(80, 17);
            this.checkSviProdavci.TabIndex = 12;
            this.checkSviProdavci.Text = "Označi sve";
            this.checkSviProdavci.UseVisualStyleBackColor = true;
            this.checkSviProdavci.CheckedChanged += new System.EventHandler(this.checkSviProdavci_CheckedChanged);
            // 
            // lstViewRezultat
            // 
            this.lstViewRezultat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstViewRezultat.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colProizvoda,
            this.colProdavac,
            this.colCena});
            this.lstViewRezultat.FullRowSelect = true;
            this.lstViewRezultat.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstViewRezultat.Location = new System.Drawing.Point(625, 207);
            this.lstViewRezultat.Margin = new System.Windows.Forms.Padding(5);
            this.lstViewRezultat.MultiSelect = false;
            this.lstViewRezultat.Name = "lstViewRezultat";
            this.lstViewRezultat.Size = new System.Drawing.Size(480, 325);
            this.lstViewRezultat.TabIndex = 15;
            this.lstViewRezultat.UseCompatibleStateImageBehavior = false;
            this.lstViewRezultat.View = System.Windows.Forms.View.Details;
            // 
            // colProizvoda
            // 
            this.colProizvoda.Text = "Artikal";
            this.colProizvoda.Width = 190;
            // 
            // colProdavac
            // 
            this.colProdavac.Text = "Prodavac";
            this.colProdavac.Width = 190;
            // 
            // colCena
            // 
            this.colCena.Text = "";
            this.colCena.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colCena.Width = 90;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkRed;
            this.label6.Location = new System.Drawing.Point(621, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Rezultat krola";
            // 
            // btnSnimi
            // 
            this.btnSnimi.Enabled = false;
            this.btnSnimi.Location = new System.Drawing.Point(1006, 585);
            this.btnSnimi.Name = "btnSnimi";
            this.btnSnimi.Size = new System.Drawing.Size(121, 37);
            this.btnSnimi.TabIndex = 6;
            this.btnSnimi.Text = "Snimi";
            this.btnSnimi.UseVisualStyleBackColor = true;
            this.btnSnimi.Click += new System.EventHandler(this.btnSnimi_Click);
            // 
            // btnOdustani
            // 
            this.btnOdustani.Location = new System.Drawing.Point(879, 585);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(121, 37);
            this.btnOdustani.TabIndex = 16;
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // txtNAzivKrola
            // 
            this.txtNAzivKrola.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNAzivKrola.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNAzivKrola.Location = new System.Drawing.Point(92, 36);
            this.txtNAzivKrola.MaxLength = 50;
            this.txtNAzivKrola.Name = "txtNAzivKrola";
            this.txtNAzivKrola.Size = new System.Drawing.Size(347, 25);
            this.txtNAzivKrola.TabIndex = 0;
            this.txtNAzivKrola.Validating += new System.ComponentModel.CancelEventHandler(this.txtNAzivKrola_Validating);
            this.txtNAzivKrola.Validated += new System.EventHandler(this.txtNAzivKrola_Validated);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(11, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "Naziv";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtIzvrsilacKrola);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtNAzivKrola);
            this.groupBox1.Controls.Add(this.dateTimeDatumKrola);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox1.Location = new System.Drawing.Point(17, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(596, 139);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "NOVI KROL";
            // 
            // lblSacekajte
            // 
            this.lblSacekajte.AutoSize = true;
            this.lblSacekajte.BackColor = System.Drawing.Color.OrangeRed;
            this.lblSacekajte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSacekajte.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSacekajte.ForeColor = System.Drawing.Color.White;
            this.lblSacekajte.Location = new System.Drawing.Point(437, 343);
            this.lblSacekajte.Name = "lblSacekajte";
            this.lblSacekajte.Padding = new System.Windows.Forms.Padding(7);
            this.lblSacekajte.Size = new System.Drawing.Size(316, 41);
            this.lblSacekajte.TabIndex = 13;
            this.lblSacekajte.Text = "Krol je u toku. Molim sačekajte...";
            // 
            // errProviderNoviKrol
            // 
            this.errProviderNoviKrol.ContainerControl = this;
            // 
            // frmStartKrol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 634);
            this.Controls.Add(this.lblSacekajte);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOdustani);
            this.Controls.Add(this.btnSnimi);
            this.Controls.Add(this.label6);
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
            this.Controls.Add(this.listBoxProizvodi);
            this.Controls.Add(this.listBoxProdavci);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmStartKrol";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Krol";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_NextControl);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderNoviKrol)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSnimi;
        private System.Windows.Forms.ColumnHeader colProizvoda;
        private System.Windows.Forms.ColumnHeader colProdavac;
        private System.Windows.Forms.ColumnHeader colCena;
        private System.Windows.Forms.ListView lstViewRezultat;
        private System.Windows.Forms.Button btnOdustani;
        private System.Windows.Forms.TextBox txtNAzivKrola;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblSacekajte;
        private System.Windows.Forms.ErrorProvider errProviderNoviKrol;
    }
}