namespace WebCene.UI.Forms.Kroler
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
            this.IzborArtikalaContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuDodajZaKrol = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxProdavci = new System.Windows.Forms.ListBox();
            this.txtKrolId = new System.Windows.Forms.TextBox();
            this.progressKrol = new System.Windows.Forms.ProgressBar();
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
            this.groupBoxZaglavlje = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblSacekajte = new System.Windows.Forms.Label();
            this.errProviderNoviKrol = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblKorisnikStopKrolPoruka = new System.Windows.Forms.Label();
            this.comboKategorije = new System.Windows.Forms.ComboBox();
            this.comboBrendovi = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblOdabraniArt = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.listBoxArtikliZaKrol = new System.Windows.Forms.ListBox();
            this.OdabraniArtikliContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextOdabraniArtObrisiStavku = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.contextOdabraniArtObrisiSve = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.picFilter = new System.Windows.Forms.PictureBox();
            this.comboPodesavanjaKrola = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSnimiPodesavanjaKrola = new System.Windows.Forms.Button();
            this.btnObrisiPodesavanjaKrola = new System.Windows.Forms.Button();
            this.IzborArtikalaContextMenu.SuspendLayout();
            this.groupBoxZaglavlje.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderNoviKrol)).BeginInit();
            this.OdabraniArtikliContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFilter)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimeDatumKrola
            // 
            this.dateTimeDatumKrola.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeDatumKrola.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeDatumKrola.Location = new System.Drawing.Point(295, 94);
            this.dateTimeDatumKrola.Name = "dateTimeDatumKrola";
            this.dateTimeDatumKrola.Size = new System.Drawing.Size(141, 25);
            this.dateTimeDatumKrola.TabIndex = 2;
            this.dateTimeDatumKrola.Validating += new System.ComponentModel.CancelEventHandler(this.dateTimeDatumKrola_Validating);
            this.dateTimeDatumKrola.Validated += new System.EventHandler(this.dateTimeDatumKrola_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(238, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Datum";
            // 
            // txtIzvrsilacKrola
            // 
            this.txtIzvrsilacKrola.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIzvrsilacKrola.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIzvrsilacKrola.Location = new System.Drawing.Point(295, 63);
            this.txtIzvrsilacKrola.MaxLength = 50;
            this.txtIzvrsilacKrola.Name = "txtIzvrsilacKrola";
            this.txtIzvrsilacKrola.Size = new System.Drawing.Size(337, 25);
            this.txtIzvrsilacKrola.TabIndex = 1;
            this.txtIzvrsilacKrola.Validating += new System.ComponentModel.CancelEventHandler(this.txtIzvrsilacKrola_Validating);
            this.txtIzvrsilacKrola.Validated += new System.EventHandler(this.txtIzvrsilacKrola_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(238, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Izvršilac";
            // 
            // btnStartKrol
            // 
            this.btnStartKrol.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartKrol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnStartKrol.Location = new System.Drawing.Point(839, 50);
            this.btnStartKrol.Name = "btnStartKrol";
            this.btnStartKrol.Size = new System.Drawing.Size(229, 56);
            this.btnStartKrol.TabIndex = 5;
            this.btnStartKrol.Text = "POKRENI KROL";
            this.btnStartKrol.UseVisualStyleBackColor = true;
            this.btnStartKrol.Click += new System.EventHandler(this.btnStartKrol_Click);
            // 
            // listBoxProizvodi
            // 
            this.listBoxProizvodi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxProizvodi.ContextMenuStrip = this.IzborArtikalaContextMenu;
            this.listBoxProizvodi.FormattingEnabled = true;
            this.listBoxProizvodi.ItemHeight = 17;
            this.listBoxProizvodi.Location = new System.Drawing.Point(31, 208);
            this.listBoxProizvodi.Margin = new System.Windows.Forms.Padding(5);
            this.listBoxProizvodi.Name = "listBoxProizvodi";
            this.listBoxProizvodi.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxProizvodi.Size = new System.Drawing.Size(285, 442);
            this.listBoxProizvodi.TabIndex = 2;
            // 
            // IzborArtikalaContextMenu
            // 
            this.IzborArtikalaContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuDodajZaKrol});
            this.IzborArtikalaContextMenu.Name = "OdabirProizvodaContextMenu";
            this.IzborArtikalaContextMenu.Size = new System.Drawing.Size(204, 26);
            // 
            // contextMenuDodajZaKrol
            // 
            this.contextMenuDodajZaKrol.Name = "contextMenuDodajZaKrol";
            this.contextMenuDodajZaKrol.Size = new System.Drawing.Size(203, 22);
            this.contextMenuDodajZaKrol.Text = "Dodaj u odabrane artikle";
            this.contextMenuDodajZaKrol.Click += new System.EventHandler(this.contextMenuDodajZaKrol_Click);
            // 
            // listBoxProdavci
            // 
            this.listBoxProdavci.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxProdavci.FormattingEnabled = true;
            this.listBoxProdavci.ItemHeight = 17;
            this.listBoxProdavci.Location = new System.Drawing.Point(621, 208);
            this.listBoxProdavci.Margin = new System.Windows.Forms.Padding(5);
            this.listBoxProdavci.Name = "listBoxProdavci";
            this.listBoxProdavci.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxProdavci.Size = new System.Drawing.Size(285, 442);
            this.listBoxProdavci.TabIndex = 4;
            // 
            // txtKrolId
            // 
            this.txtKrolId.Location = new System.Drawing.Point(638, 24);
            this.txtKrolId.Name = "txtKrolId";
            this.txtKrolId.Size = new System.Drawing.Size(13, 33);
            this.txtKrolId.TabIndex = 9;
            this.txtKrolId.Visible = false;
            // 
            // progressKrol
            // 
            this.progressKrol.Location = new System.Drawing.Point(916, 672);
            this.progressKrol.Name = "progressKrol";
            this.progressKrol.Size = new System.Drawing.Size(497, 8);
            this.progressKrol.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkRed;
            this.label5.Location = new System.Drawing.Point(615, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Izbor prodavaca";
            // 
            // btnStopKrol
            // 
            this.btnStopKrol.BackColor = System.Drawing.Color.Tomato;
            this.btnStopKrol.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnStopKrol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopKrol.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopKrol.ForeColor = System.Drawing.Color.White;
            this.btnStopKrol.Location = new System.Drawing.Point(1038, 707);
            this.btnStopKrol.Name = "btnStopKrol";
            this.btnStopKrol.Size = new System.Drawing.Size(121, 37);
            this.btnStopKrol.TabIndex = 10;
            this.btnStopKrol.Text = "ZAUSTAVI";
            this.btnStopKrol.UseVisualStyleBackColor = false;
            this.btnStopKrol.Visible = false;
            this.btnStopKrol.Click += new System.EventHandler(this.btnStopKrol_Click);
            // 
            // lblKompletirano
            // 
            this.lblKompletirano.AutoSize = true;
            this.lblKompletirano.Location = new System.Drawing.Point(914, 653);
            this.lblKompletirano.Name = "lblKompletirano";
            this.lblKompletirano.Size = new System.Drawing.Size(87, 17);
            this.lblKompletirano.TabIndex = 7;
            this.lblKompletirano.Text = "Kompletirano";
            // 
            // checkSviProizvodi
            // 
            this.checkSviProizvodi.AutoSize = true;
            this.checkSviProizvodi.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkSviProizvodi.Location = new System.Drawing.Point(236, 183);
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
            this.checkSviProdavci.Location = new System.Drawing.Point(816, 183);
            this.checkSviProdavci.Name = "checkSviProdavci";
            this.checkSviProdavci.Size = new System.Drawing.Size(80, 17);
            this.checkSviProdavci.TabIndex = 12;
            this.checkSviProdavci.Text = "Označi sve";
            this.checkSviProdavci.UseVisualStyleBackColor = true;
            this.checkSviProdavci.CheckedChanged += new System.EventHandler(this.checkSviProdavci_CheckedChanged);
            // 
            // lstViewRezultat
            // 
            this.lstViewRezultat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstViewRezultat.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colProizvoda,
            this.colProdavac,
            this.colCena});
            this.lstViewRezultat.FullRowSelect = true;
            this.lstViewRezultat.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstViewRezultat.Location = new System.Drawing.Point(916, 208);
            this.lstViewRezultat.Margin = new System.Windows.Forms.Padding(5);
            this.lstViewRezultat.MultiSelect = false;
            this.lstViewRezultat.Name = "lstViewRezultat";
            this.lstViewRezultat.Size = new System.Drawing.Size(497, 440);
            this.lstViewRezultat.TabIndex = 15;
            this.lstViewRezultat.UseCompatibleStateImageBehavior = false;
            this.lstViewRezultat.View = System.Windows.Forms.View.Details;
            // 
            // colProizvoda
            // 
            this.colProizvoda.Text = "Artikal";
            this.colProizvoda.Width = 195;
            // 
            // colProdavac
            // 
            this.colProdavac.Text = "Prodavac";
            this.colProdavac.Width = 175;
            // 
            // colCena
            // 
            this.colCena.Text = "";
            this.colCena.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colCena.Width = 100;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkRed;
            this.label6.Location = new System.Drawing.Point(912, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Rezultat krola";
            // 
            // btnSnimi
            // 
            this.btnSnimi.Enabled = false;
            this.btnSnimi.Location = new System.Drawing.Point(1292, 707);
            this.btnSnimi.Name = "btnSnimi";
            this.btnSnimi.Size = new System.Drawing.Size(121, 37);
            this.btnSnimi.TabIndex = 6;
            this.btnSnimi.Text = "Snimi";
            this.btnSnimi.UseVisualStyleBackColor = true;
            this.btnSnimi.Click += new System.EventHandler(this.btnSnimi_Click);
            // 
            // btnOdustani
            // 
            this.btnOdustani.Location = new System.Drawing.Point(1165, 707);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(121, 37);
            this.btnOdustani.TabIndex = 16;
            this.btnOdustani.Text = "Zatvori";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // txtNAzivKrola
            // 
            this.txtNAzivKrola.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNAzivKrola.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNAzivKrola.Location = new System.Drawing.Point(295, 32);
            this.txtNAzivKrola.MaxLength = 50;
            this.txtNAzivKrola.Name = "txtNAzivKrola";
            this.txtNAzivKrola.Size = new System.Drawing.Size(337, 25);
            this.txtNAzivKrola.TabIndex = 0;
            this.txtNAzivKrola.Validating += new System.ComponentModel.CancelEventHandler(this.txtNAzivKrola_Validating);
            this.txtNAzivKrola.Validated += new System.EventHandler(this.txtNAzivKrola_Validated);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(238, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "Naziv";
            // 
            // groupBoxZaglavlje
            // 
            this.groupBoxZaglavlje.BackColor = System.Drawing.Color.SeaShell;
            this.groupBoxZaglavlje.Controls.Add(this.txtIzvrsilacKrola);
            this.groupBoxZaglavlje.Controls.Add(this.label7);
            this.groupBoxZaglavlje.Controls.Add(this.label3);
            this.groupBoxZaglavlje.Controls.Add(this.txtNAzivKrola);
            this.groupBoxZaglavlje.Controls.Add(this.dateTimeDatumKrola);
            this.groupBoxZaglavlje.Controls.Add(this.label2);
            this.groupBoxZaglavlje.Controls.Add(this.txtKrolId);
            this.groupBoxZaglavlje.Controls.Add(this.btnStartKrol);
            this.groupBoxZaglavlje.Controls.Add(this.pictureBox1);
            this.groupBoxZaglavlje.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBoxZaglavlje.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxZaglavlje.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBoxZaglavlje.Location = new System.Drawing.Point(322, 12);
            this.groupBoxZaglavlje.Name = "groupBoxZaglavlje";
            this.groupBoxZaglavlje.Size = new System.Drawing.Size(1091, 139);
            this.groupBoxZaglavlje.TabIndex = 0;
            this.groupBoxZaglavlje.TabStop = false;
            this.groupBoxZaglavlje.Text = "NOVI KROL ePonuda";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WebCene.UI.Properties.Resources.logoEponuda;
            this.pictureBox1.Location = new System.Drawing.Point(30, 58);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(177, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // lblSacekajte
            // 
            this.lblSacekajte.BackColor = System.Drawing.Color.OrangeRed;
            this.lblSacekajte.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSacekajte.ForeColor = System.Drawing.Color.White;
            this.lblSacekajte.Location = new System.Drawing.Point(567, 323);
            this.lblSacekajte.Name = "lblSacekajte";
            this.lblSacekajte.Padding = new System.Windows.Forms.Padding(7);
            this.lblSacekajte.Size = new System.Drawing.Size(405, 70);
            this.lblSacekajte.TabIndex = 13;
            this.lblSacekajte.Text = "Krol je u toku. Sačekajte...";
            this.lblSacekajte.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // errProviderNoviKrol
            // 
            this.errProviderNoviKrol.ContainerControl = this;
            // 
            // lblKorisnikStopKrolPoruka
            // 
            this.lblKorisnikStopKrolPoruka.AutoSize = true;
            this.lblKorisnikStopKrolPoruka.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKorisnikStopKrolPoruka.ForeColor = System.Drawing.Color.Red;
            this.lblKorisnikStopKrolPoruka.Location = new System.Drawing.Point(1254, 653);
            this.lblKorisnikStopKrolPoruka.Name = "lblKorisnikStopKrolPoruka";
            this.lblKorisnikStopKrolPoruka.Size = new System.Drawing.Size(159, 17);
            this.lblKorisnikStopKrolPoruka.TabIndex = 18;
            this.lblKorisnikStopKrolPoruka.Text = "Korisnik je prekinuo krol!";
            this.lblKorisnikStopKrolPoruka.Visible = false;
            // 
            // comboKategorije
            // 
            this.comboKategorije.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboKategorije.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboKategorije.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboKategorije.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboKategorije.FormattingEnabled = true;
            this.comboKategorije.Location = new System.Drawing.Point(31, 41);
            this.comboKategorije.Margin = new System.Windows.Forms.Padding(5);
            this.comboKategorije.Name = "comboKategorije";
            this.comboKategorije.Size = new System.Drawing.Size(285, 25);
            this.comboKategorije.TabIndex = 19;
            // 
            // comboBrendovi
            // 
            this.comboBrendovi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBrendovi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBrendovi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBrendovi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBrendovi.FormattingEnabled = true;
            this.comboBrendovi.Location = new System.Drawing.Point(31, 93);
            this.comboBrendovi.Margin = new System.Windows.Forms.Padding(5);
            this.comboBrendovi.Name = "comboBrendovi";
            this.comboBrendovi.Size = new System.Drawing.Size(285, 25);
            this.comboBrendovi.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 21;
            this.label1.Text = "Kategorija";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 17);
            this.label8.TabIndex = 22;
            this.label8.Text = "Brend";
            // 
            // lblOdabraniArt
            // 
            this.lblOdabraniArt.AutoSize = true;
            this.lblOdabraniArt.BackColor = System.Drawing.SystemColors.Control;
            this.lblOdabraniArt.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOdabraniArt.ForeColor = System.Drawing.Color.DarkRed;
            this.lblOdabraniArt.Location = new System.Drawing.Point(326, 179);
            this.lblOdabraniArt.Name = "lblOdabraniArt";
            this.lblOdabraniArt.Size = new System.Drawing.Size(117, 20);
            this.lblOdabraniArt.TabIndex = 23;
            this.lblOdabraniArt.Text = "Odabrani artikli";
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(236, 126);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(80, 25);
            this.btnFilter.TabIndex = 24;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // listBoxArtikliZaKrol
            // 
            this.listBoxArtikliZaKrol.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxArtikliZaKrol.ContextMenuStrip = this.OdabraniArtikliContextMenu;
            this.listBoxArtikliZaKrol.FormattingEnabled = true;
            this.listBoxArtikliZaKrol.ItemHeight = 17;
            this.listBoxArtikliZaKrol.Location = new System.Drawing.Point(326, 208);
            this.listBoxArtikliZaKrol.Margin = new System.Windows.Forms.Padding(5);
            this.listBoxArtikliZaKrol.Name = "listBoxArtikliZaKrol";
            this.listBoxArtikliZaKrol.Size = new System.Drawing.Size(285, 442);
            this.listBoxArtikliZaKrol.TabIndex = 25;
            // 
            // OdabraniArtikliContextMenu
            // 
            this.OdabraniArtikliContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextOdabraniArtObrisiStavku,
            this.toolStripSeparator1,
            this.contextOdabraniArtObrisiSve});
            this.OdabraniArtikliContextMenu.Name = "OdabraniArtikliContextMenu";
            this.OdabraniArtikliContextMenu.Size = new System.Drawing.Size(123, 54);
            // 
            // contextOdabraniArtObrisiStavku
            // 
            this.contextOdabraniArtObrisiStavku.ForeColor = System.Drawing.Color.Tomato;
            this.contextOdabraniArtObrisiStavku.Name = "contextOdabraniArtObrisiStavku";
            this.contextOdabraniArtObrisiStavku.Size = new System.Drawing.Size(122, 22);
            this.contextOdabraniArtObrisiStavku.Text = "Briši";
            this.contextOdabraniArtObrisiStavku.Click += new System.EventHandler(this.contextOdabraniArtObrisiStavku_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(119, 6);
            // 
            // contextOdabraniArtObrisiSve
            // 
            this.contextOdabraniArtObrisiSve.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextOdabraniArtObrisiSve.ForeColor = System.Drawing.Color.Tomato;
            this.contextOdabraniArtObrisiSve.Name = "contextOdabraniArtObrisiSve";
            this.contextOdabraniArtObrisiSve.Size = new System.Drawing.Size(122, 22);
            this.contextOdabraniArtObrisiSve.Text = "Briši SVE";
            this.contextOdabraniArtObrisiSve.Click += new System.EventHandler(this.contextOdabraniArtObrisiSve_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(27, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 20);
            this.label4.TabIndex = 27;
            this.label4.Text = "Izbor artikala";
            // 
            // picFilter
            // 
            this.picFilter.BackColor = System.Drawing.Color.LemonChiffon;
            this.picFilter.Cursor = System.Windows.Forms.Cursors.No;
            this.picFilter.Image = global::WebCene.UI.Properties.Resources.filled_filter_32;
            this.picFilter.Location = new System.Drawing.Point(171, 126);
            this.picFilter.Name = "picFilter";
            this.picFilter.Size = new System.Drawing.Size(59, 47);
            this.picFilter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picFilter.TabIndex = 28;
            this.picFilter.TabStop = false;
            this.picFilter.Visible = false;
            this.picFilter.Click += new System.EventHandler(this.picFilter_Click);
            // 
            // comboPodesavanjaKrola
            // 
            this.comboPodesavanjaKrola.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPodesavanjaKrola.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboPodesavanjaKrola.FormattingEnabled = true;
            this.comboPodesavanjaKrola.Location = new System.Drawing.Point(31, 714);
            this.comboPodesavanjaKrola.Name = "comboPodesavanjaKrola";
            this.comboPodesavanjaKrola.Size = new System.Drawing.Size(285, 25);
            this.comboPodesavanjaKrola.TabIndex = 0;
            this.comboPodesavanjaKrola.SelectionChangeCommitted += new System.EventHandler(this.comboPodesavanjaKrola_SelectionChangeCommitted);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DarkRed;
            this.label10.Location = new System.Drawing.Point(27, 672);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(135, 20);
            this.label10.TabIndex = 29;
            this.label10.Text = "Podešavanja krola";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 694);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(193, 17);
            this.label9.TabIndex = 31;
            this.label9.Text = "Odaberi snimljeno podešavanje";
            // 
            // btnSnimiPodesavanjaKrola
            // 
            this.btnSnimiPodesavanjaKrola.Location = new System.Drawing.Point(327, 714);
            this.btnSnimiPodesavanjaKrola.Name = "btnSnimiPodesavanjaKrola";
            this.btnSnimiPodesavanjaKrola.Size = new System.Drawing.Size(80, 25);
            this.btnSnimiPodesavanjaKrola.TabIndex = 30;
            this.btnSnimiPodesavanjaKrola.Text = "Snimi";
            this.btnSnimiPodesavanjaKrola.UseVisualStyleBackColor = true;
            this.btnSnimiPodesavanjaKrola.Click += new System.EventHandler(this.btnSnimiPodesavanjaKrola_Click);
            // 
            // btnObrisiPodesavanjaKrola
            // 
            this.btnObrisiPodesavanjaKrola.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnObrisiPodesavanjaKrola.Location = new System.Drawing.Point(413, 714);
            this.btnObrisiPodesavanjaKrola.Name = "btnObrisiPodesavanjaKrola";
            this.btnObrisiPodesavanjaKrola.Size = new System.Drawing.Size(80, 25);
            this.btnObrisiPodesavanjaKrola.TabIndex = 32;
            this.btnObrisiPodesavanjaKrola.Text = "Obriši";
            this.btnObrisiPodesavanjaKrola.UseVisualStyleBackColor = true;
            this.btnObrisiPodesavanjaKrola.Click += new System.EventHandler(this.btnObrisiPodesavanjaKrola_Click);
            // 
            // frmStartKrol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1439, 763);
            this.Controls.Add(this.btnObrisiPodesavanjaKrola);
            this.Controls.Add(this.picFilter);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBrendovi);
            this.Controls.Add(this.comboKategorije);
            this.Controls.Add(this.btnSnimiPodesavanjaKrola);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboPodesavanjaKrola);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.checkSviProizvodi);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.listBoxProizvodi);
            this.Controls.Add(this.lblSacekajte);
            this.Controls.Add(this.listBoxArtikliZaKrol);
            this.Controls.Add(this.lblOdabraniArt);
            this.Controls.Add(this.lblKorisnikStopKrolPoruka);
            this.Controls.Add(this.groupBoxZaglavlje);
            this.Controls.Add(this.btnOdustani);
            this.Controls.Add(this.btnSnimi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lstViewRezultat);
            this.Controls.Add(this.checkSviProdavci);
            this.Controls.Add(this.lblKompletirano);
            this.Controls.Add(this.btnStopKrol);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.progressKrol);
            this.Controls.Add(this.listBoxProdavci);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmStartKrol";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pokretanje novog krola";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_NextControl);
            this.IzborArtikalaContextMenu.ResumeLayout(false);
            this.groupBoxZaglavlje.ResumeLayout(false);
            this.groupBoxZaglavlje.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderNoviKrol)).EndInit();
            this.OdabraniArtikliContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picFilter)).EndInit();
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
        private System.Windows.Forms.GroupBox groupBoxZaglavlje;
        private System.Windows.Forms.Label lblSacekajte;
        private System.Windows.Forms.ErrorProvider errProviderNoviKrol;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblKorisnikStopKrolPoruka;
        private System.Windows.Forms.ComboBox comboBrendovi;
        private System.Windows.Forms.ComboBox comboKategorije;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblOdabraniArt;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.ListBox listBoxArtikliZaKrol;
        private System.Windows.Forms.ContextMenuStrip IzborArtikalaContextMenu;
        private System.Windows.Forms.ToolStripMenuItem contextMenuDodajZaKrol;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ContextMenuStrip OdabraniArtikliContextMenu;
        private System.Windows.Forms.ToolStripMenuItem contextOdabraniArtObrisiStavku;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem contextOdabraniArtObrisiSve;
        private System.Windows.Forms.PictureBox picFilter;
        private System.Windows.Forms.ComboBox comboPodesavanjaKrola;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnSnimiPodesavanjaKrola;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnObrisiPodesavanjaKrola;
    }
}