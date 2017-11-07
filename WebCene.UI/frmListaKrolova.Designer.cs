namespace WebCene.UI
{
    partial class frmListaKrolova
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblDetaljPoruka = new System.Windows.Forms.Label();
            this.lstViewKrolDetalj = new System.Windows.Forms.ListView();
            this.Proizvod = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Prodavac = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cena = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblKrolGlavaPoruka = new System.Windows.Forms.Label();
            this.lstViewKrolGlava = new System.Windows.Forms.ListView();
            this.Datum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Naziv = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Izvrsilac = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextKrolGlava = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.obrišiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNoviKrol = new System.Windows.Forms.Button();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextKrolGlava.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblDetaljPoruka);
            this.groupBox2.Controls.Add(this.lstViewKrolDetalj);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(526, 108);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(501, 457);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detalji";
            // 
            // lblDetaljPoruka
            // 
            this.lblDetaljPoruka.AutoSize = true;
            this.lblDetaljPoruka.BackColor = System.Drawing.Color.White;
            this.lblDetaljPoruka.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetaljPoruka.ForeColor = System.Drawing.Color.Red;
            this.lblDetaljPoruka.Location = new System.Drawing.Point(158, 224);
            this.lblDetaljPoruka.Name = "lblDetaljPoruka";
            this.lblDetaljPoruka.Size = new System.Drawing.Size(164, 25);
            this.lblDetaljPoruka.TabIndex = 19;
            this.lblDetaljPoruka.Text = "Nema podataka !";
            this.lblDetaljPoruka.Visible = false;
            // 
            // lstViewKrolDetalj
            // 
            this.lstViewKrolDetalj.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstViewKrolDetalj.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Proizvod,
            this.Prodavac,
            this.Cena});
            this.lstViewKrolDetalj.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstViewKrolDetalj.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstViewKrolDetalj.Location = new System.Drawing.Point(15, 33);
            this.lstViewKrolDetalj.Margin = new System.Windows.Forms.Padding(10);
            this.lstViewKrolDetalj.MultiSelect = false;
            this.lstViewKrolDetalj.Name = "lstViewKrolDetalj";
            this.lstViewKrolDetalj.Size = new System.Drawing.Size(471, 409);
            this.lstViewKrolDetalj.TabIndex = 0;
            this.lstViewKrolDetalj.UseCompatibleStateImageBehavior = false;
            this.lstViewKrolDetalj.View = System.Windows.Forms.View.Details;
            // 
            // Proizvod
            // 
            this.Proizvod.Text = "Artikal";
            this.Proizvod.Width = 195;
            // 
            // Prodavac
            // 
            this.Prodavac.Text = "Prodavac";
            this.Prodavac.Width = 160;
            // 
            // Cena
            // 
            this.Cena.Text = "";
            this.Cena.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Cena.Width = 100;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblKrolGlavaPoruka);
            this.groupBox1.Controls.Add(this.lstViewKrolGlava);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(501, 457);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Krol";
            // 
            // lblKrolGlavaPoruka
            // 
            this.lblKrolGlavaPoruka.AutoSize = true;
            this.lblKrolGlavaPoruka.BackColor = System.Drawing.Color.White;
            this.lblKrolGlavaPoruka.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKrolGlavaPoruka.ForeColor = System.Drawing.Color.Red;
            this.lblKrolGlavaPoruka.Location = new System.Drawing.Point(171, 224);
            this.lblKrolGlavaPoruka.Name = "lblKrolGlavaPoruka";
            this.lblKrolGlavaPoruka.Size = new System.Drawing.Size(164, 25);
            this.lblKrolGlavaPoruka.TabIndex = 20;
            this.lblKrolGlavaPoruka.Text = "Nema podataka !";
            this.lblKrolGlavaPoruka.Visible = false;
            // 
            // lstViewKrolGlava
            // 
            this.lstViewKrolGlava.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstViewKrolGlava.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Datum,
            this.Naziv,
            this.Izvrsilac});
            this.lstViewKrolGlava.ContextMenuStrip = this.contextKrolGlava;
            this.lstViewKrolGlava.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lstViewKrolGlava.FullRowSelect = true;
            this.lstViewKrolGlava.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstViewKrolGlava.Location = new System.Drawing.Point(15, 33);
            this.lstViewKrolGlava.Margin = new System.Windows.Forms.Padding(10);
            this.lstViewKrolGlava.MultiSelect = false;
            this.lstViewKrolGlava.Name = "lstViewKrolGlava";
            this.lstViewKrolGlava.Size = new System.Drawing.Size(471, 409);
            this.lstViewKrolGlava.TabIndex = 0;
            this.lstViewKrolGlava.UseCompatibleStateImageBehavior = false;
            this.lstViewKrolGlava.View = System.Windows.Forms.View.Details;
            this.lstViewKrolGlava.SelectedIndexChanged += new System.EventHandler(this.lstViewKrolGlava_SelectedIndexChanged);
            // 
            // Datum
            // 
            this.Datum.Text = "Datum";
            this.Datum.Width = 90;
            // 
            // Naziv
            // 
            this.Naziv.Text = "Naziv";
            this.Naziv.Width = 185;
            // 
            // Izvrsilac
            // 
            this.Izvrsilac.Text = "Izvršilac";
            this.Izvrsilac.Width = 185;
            // 
            // contextKrolGlava
            // 
            this.contextKrolGlava.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.obrišiToolStripMenuItem});
            this.contextKrolGlava.Name = "contextKrolGlava";
            this.contextKrolGlava.Size = new System.Drawing.Size(143, 26);
            // 
            // obrišiToolStripMenuItem
            // 
            this.obrišiToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.obrišiToolStripMenuItem.Name = "obrišiToolStripMenuItem";
            this.obrišiToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.obrišiToolStripMenuItem.Text = "Obriši stavku";
            this.obrišiToolStripMenuItem.Click += new System.EventHandler(this.obrišiToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(28, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Grupisana LISTA KROLOVA";
            // 
            // btnNoviKrol
            // 
            this.btnNoviKrol.Location = new System.Drawing.Point(12, 596);
            this.btnNoviKrol.Name = "btnNoviKrol";
            this.btnNoviKrol.Size = new System.Drawing.Size(121, 37);
            this.btnNoviKrol.TabIndex = 17;
            this.btnNoviKrol.Text = "Novi krol";
            this.btnNoviKrol.UseVisualStyleBackColor = true;
            this.btnNoviKrol.Click += new System.EventHandler(this.btnNoviKrol_Click);
            // 
            // btnOdustani
            // 
            this.btnOdustani.Location = new System.Drawing.Point(908, 596);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(121, 37);
            this.btnOdustani.TabIndex = 18;
            this.btnOdustani.Text = "Zatvori";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WebCene.UI.Properties.Resources.logoEponuda;
            this.pictureBox1.Location = new System.Drawing.Point(812, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(168, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // frmListaKrolova
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 645);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnOdustani);
            this.Controls.Add(this.btnNoviKrol);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmListaKrolova";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grupisana lista krolova";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_NextControl);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextKrolGlava.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNoviKrol;
        private System.Windows.Forms.Button btnOdustani;
        private System.Windows.Forms.ListView lstViewKrolDetalj;
        private System.Windows.Forms.ColumnHeader Proizvod;
        private System.Windows.Forms.ColumnHeader Prodavac;
        private System.Windows.Forms.ColumnHeader Cena;
        private System.Windows.Forms.ListView lstViewKrolGlava;
        private System.Windows.Forms.ColumnHeader Datum;
        private System.Windows.Forms.ColumnHeader Naziv;
        private System.Windows.Forms.ColumnHeader Izvrsilac;
        private System.Windows.Forms.ContextMenuStrip contextKrolGlava;
        private System.Windows.Forms.Label lblDetaljPoruka;
        private System.Windows.Forms.ToolStripMenuItem obrišiToolStripMenuItem;
        private System.Windows.Forms.Label lblKrolGlavaPoruka;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}