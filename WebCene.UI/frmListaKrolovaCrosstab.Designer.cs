﻿namespace WebCene.UI
{
    partial class frmListaKrolovaCrosstab
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
            this.comboKategorije = new System.Windows.Forms.ComboBox();
            this.comboBrendovi = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgViewKrolDetalj = new System.Windows.Forms.DataGridView();
            this.btnFilter = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDetaljPoruka = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblKrolGlavaPoruka = new System.Windows.Forms.Label();
            this.lstViewKrolGlava = new System.Windows.Forms.ListView();
            this.colDatum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNaziv = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIzvrsilac = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.linkResetFilter = new System.Windows.Forms.LinkLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.btnNoviKrol = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewKrolDetalj)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboKategorije
            // 
            this.comboKategorije.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboKategorije.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboKategorije.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboKategorije.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboKategorije.FormattingEnabled = true;
            this.comboKategorije.Location = new System.Drawing.Point(19, 51);
            this.comboKategorije.Name = "comboKategorije";
            this.comboKategorije.Size = new System.Drawing.Size(209, 25);
            this.comboKategorije.TabIndex = 0;
            // 
            // comboBrendovi
            // 
            this.comboBrendovi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBrendovi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBrendovi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBrendovi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBrendovi.FormattingEnabled = true;
            this.comboBrendovi.Location = new System.Drawing.Point(249, 51);
            this.comboBrendovi.Name = "comboBrendovi";
            this.comboBrendovi.Size = new System.Drawing.Size(209, 25);
            this.comboBrendovi.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.BlueViolet;
            this.label1.Location = new System.Drawing.Point(25, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Crosstab LISTA KROLOVA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Kategorija";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(246, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Brend";
            // 
            // dgViewKrolDetalj
            // 
            this.dgViewKrolDetalj.AllowUserToAddRows = false;
            this.dgViewKrolDetalj.AllowUserToDeleteRows = false;
            this.dgViewKrolDetalj.AllowUserToResizeRows = false;
            this.dgViewKrolDetalj.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgViewKrolDetalj.Location = new System.Drawing.Point(13, 31);
            this.dgViewKrolDetalj.Margin = new System.Windows.Forms.Padding(10);
            this.dgViewKrolDetalj.MultiSelect = false;
            this.dgViewKrolDetalj.Name = "dgViewKrolDetalj";
            this.dgViewKrolDetalj.ReadOnly = true;
            this.dgViewKrolDetalj.RowHeadersVisible = false;
            this.dgViewKrolDetalj.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgViewKrolDetalj.ShowEditingIcon = false;
            this.dgViewKrolDetalj.Size = new System.Drawing.Size(625, 427);
            this.dgViewKrolDetalj.TabIndex = 5;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(477, 51);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(83, 25);
            this.btnFilter.TabIndex = 6;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblDetaljPoruka);
            this.groupBox1.Controls.Add(this.dgViewKrolDetalj);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(548, 155);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(650, 471);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalji";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Sienna;
            this.label5.Location = new System.Drawing.Point(5, -3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 21);
            this.label5.TabIndex = 22;
            this.label5.Text = "Detalji";
            // 
            // lblDetaljPoruka
            // 
            this.lblDetaljPoruka.AutoSize = true;
            this.lblDetaljPoruka.BackColor = System.Drawing.Color.White;
            this.lblDetaljPoruka.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDetaljPoruka.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetaljPoruka.ForeColor = System.Drawing.Color.Red;
            this.lblDetaljPoruka.Location = new System.Drawing.Point(235, 228);
            this.lblDetaljPoruka.Name = "lblDetaljPoruka";
            this.lblDetaljPoruka.Padding = new System.Windows.Forms.Padding(3);
            this.lblDetaljPoruka.Size = new System.Drawing.Size(201, 25);
            this.lblDetaljPoruka.TabIndex = 20;
            this.lblDetaljPoruka.Text = "Odabrani krol ne sadrži detalje";
            this.lblDetaljPoruka.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblKrolGlavaPoruka);
            this.groupBox2.Controls.Add(this.lstViewKrolGlava);
            this.groupBox2.Location = new System.Drawing.Point(17, 155);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(517, 471);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Krol";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Sienna;
            this.label4.Location = new System.Drawing.Point(9, -3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 21);
            this.label4.TabIndex = 21;
            this.label4.Text = "Krol";
            // 
            // lblKrolGlavaPoruka
            // 
            this.lblKrolGlavaPoruka.AutoSize = true;
            this.lblKrolGlavaPoruka.BackColor = System.Drawing.Color.White;
            this.lblKrolGlavaPoruka.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKrolGlavaPoruka.ForeColor = System.Drawing.Color.Red;
            this.lblKrolGlavaPoruka.Location = new System.Drawing.Point(170, 228);
            this.lblKrolGlavaPoruka.Name = "lblKrolGlavaPoruka";
            this.lblKrolGlavaPoruka.Size = new System.Drawing.Size(157, 17);
            this.lblKrolGlavaPoruka.TabIndex = 21;
            this.lblKrolGlavaPoruka.Text = "Nema sačuvanih krolova";
            this.lblKrolGlavaPoruka.Visible = false;
            // 
            // lstViewKrolGlava
            // 
            this.lstViewKrolGlava.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstViewKrolGlava.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDatum,
            this.colNaziv,
            this.colIzvrsilac});
            this.lstViewKrolGlava.FullRowSelect = true;
            this.lstViewKrolGlava.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstViewKrolGlava.Location = new System.Drawing.Point(13, 31);
            this.lstViewKrolGlava.Margin = new System.Windows.Forms.Padding(10);
            this.lstViewKrolGlava.MultiSelect = false;
            this.lstViewKrolGlava.Name = "lstViewKrolGlava";
            this.lstViewKrolGlava.Size = new System.Drawing.Size(491, 427);
            this.lstViewKrolGlava.TabIndex = 0;
            this.lstViewKrolGlava.UseCompatibleStateImageBehavior = false;
            this.lstViewKrolGlava.View = System.Windows.Forms.View.Details;
            this.lstViewKrolGlava.SelectedIndexChanged += new System.EventHandler(this.lstViewKrolGlava_SelectedIndexChanged);
            // 
            // colDatum
            // 
            this.colDatum.Text = "Datum";
            this.colDatum.Width = 90;
            // 
            // colNaziv
            // 
            this.colNaziv.Text = "Naziv";
            this.colNaziv.Width = 200;
            // 
            // colIzvrsilac
            // 
            this.colIzvrsilac.Text = "Izvršilac";
            this.colIzvrsilac.Width = 200;
            // 
            // linkResetFilter
            // 
            this.linkResetFilter.AutoSize = true;
            this.linkResetFilter.Location = new System.Drawing.Point(576, 54);
            this.linkResetFilter.Name = "linkResetFilter";
            this.linkResetFilter.Size = new System.Drawing.Size(46, 17);
            this.linkResetFilter.TabIndex = 9;
            this.linkResetFilter.TabStop = true;
            this.linkResetFilter.Text = "Poništi";
            this.linkResetFilter.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkResetFilter_LinkClicked);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.comboKategorije);
            this.groupBox3.Controls.Add(this.linkResetFilter);
            this.groupBox3.Controls.Add(this.comboBrendovi);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.btnFilter);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Location = new System.Drawing.Point(548, 37);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(650, 100);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filter detalja";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Goldenrod;
            this.label6.Location = new System.Drawing.Point(6, -3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 21);
            this.label6.TabIndex = 23;
            this.label6.Text = "Filter detalja";
            // 
            // btnOdustani
            // 
            this.btnOdustani.Location = new System.Drawing.Point(1080, 665);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(121, 37);
            this.btnOdustani.TabIndex = 19;
            this.btnOdustani.Text = "Zatvori";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // btnNoviKrol
            // 
            this.btnNoviKrol.Location = new System.Drawing.Point(12, 665);
            this.btnNoviKrol.Name = "btnNoviKrol";
            this.btnNoviKrol.Size = new System.Drawing.Size(121, 37);
            this.btnNoviKrol.TabIndex = 20;
            this.btnNoviKrol.Text = "Novi krol";
            this.btnNoviKrol.UseVisualStyleBackColor = true;
            this.btnNoviKrol.Click += new System.EventHandler(this.btnNoviKrol_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WebCene.UI.Properties.Resources.logoEponuda;
            this.pictureBox1.Location = new System.Drawing.Point(346, 55);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(175, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // frmListaKrolovaCrosstab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 714);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnNoviKrol);
            this.Controls.Add(this.btnOdustani);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmListaKrolovaCrosstab";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista krolova";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_NextControl);
            ((System.ComponentModel.ISupportInitialize)(this.dgViewKrolDetalj)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboKategorije;
        private System.Windows.Forms.ComboBox comboBrendovi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgViewKrolDetalj;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lstViewKrolGlava;
        private System.Windows.Forms.ColumnHeader colDatum;
        private System.Windows.Forms.ColumnHeader colNaziv;
        private System.Windows.Forms.ColumnHeader colIzvrsilac;
        private System.Windows.Forms.Label lblKrolGlavaPoruka;
        private System.Windows.Forms.LinkLabel linkResetFilter;
        private System.Windows.Forms.Label lblDetaljPoruka;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnOdustani;
        private System.Windows.Forms.Button btnNoviKrol;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}