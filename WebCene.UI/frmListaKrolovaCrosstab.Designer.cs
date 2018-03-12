namespace WebCene.UI
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.lblNazivKrola = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblKrolGlavaPoruka = new System.Windows.Forms.Label();
            this.lstViewKrolGlava = new System.Windows.Forms.ListView();
            this.colDatum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNaziv = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIzvrsilac = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.KrolGlavaContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripObrisiKrol = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.picFilter = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.btnNoviKrol = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grpBoxCenaMaloPM = new System.Windows.Forms.GroupBox();
            this.chkBPAL = new System.Windows.Forms.CheckBox();
            this.chkKULA = new System.Windows.Forms.CheckBox();
            this.chkODZ = new System.Windows.Forms.CheckBox();
            this.chkAPA = new System.Windows.Forms.CheckBox();
            this.chkSO = new System.Windows.Forms.CheckBox();
            this.chkCenaM = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewKrolDetalj)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.KrolGlavaContextMenu.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.grpBoxCenaMaloPM.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboKategorije
            // 
            this.comboKategorije.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboKategorije.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboKategorije.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboKategorije.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboKategorije.FormattingEnabled = true;
            this.comboKategorije.Location = new System.Drawing.Point(13, 52);
            this.comboKategorije.Name = "comboKategorije";
            this.comboKategorije.Size = new System.Drawing.Size(235, 25);
            this.comboKategorije.TabIndex = 0;
            // 
            // comboBrendovi
            // 
            this.comboBrendovi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBrendovi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBrendovi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBrendovi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBrendovi.FormattingEnabled = true;
            this.comboBrendovi.Location = new System.Drawing.Point(275, 52);
            this.comboBrendovi.Name = "comboBrendovi";
            this.comboBrendovi.Size = new System.Drawing.Size(235, 25);
            this.comboBrendovi.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.BlueViolet;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(364, 50);
            this.label1.TabIndex = 2;
            this.label1.Text = "Crosstab LISTA KROLOVA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Kategorija";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(272, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Brend";
            // 
            // dgViewKrolDetalj
            // 
            this.dgViewKrolDetalj.AllowUserToAddRows = false;
            this.dgViewKrolDetalj.AllowUserToDeleteRows = false;
            this.dgViewKrolDetalj.AllowUserToOrderColumns = true;
            this.dgViewKrolDetalj.AllowUserToResizeRows = false;
            this.dgViewKrolDetalj.BackgroundColor = System.Drawing.Color.White;
            this.dgViewKrolDetalj.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgViewKrolDetalj.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgViewKrolDetalj.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgViewKrolDetalj.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgViewKrolDetalj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgViewKrolDetalj.Location = new System.Drawing.Point(3, 21);
            this.dgViewKrolDetalj.Margin = new System.Windows.Forms.Padding(10);
            this.dgViewKrolDetalj.Name = "dgViewKrolDetalj";
            this.dgViewKrolDetalj.ReadOnly = true;
            this.dgViewKrolDetalj.RowHeadersVisible = false;
            this.dgViewKrolDetalj.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgViewKrolDetalj.ShowEditingIcon = false;
            this.dgViewKrolDetalj.Size = new System.Drawing.Size(1142, 481);
            this.dgViewKrolDetalj.TabIndex = 5;
            // 
            // btnFilter
            // 
            this.btnFilter.Enabled = false;
            this.btnFilter.Location = new System.Drawing.Point(516, 52);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(83, 25);
            this.btnFilter.TabIndex = 6;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // groupBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblDetaljPoruka);
            this.groupBox1.Controls.Add(this.dgViewKrolDetalj);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(373, 153);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1148, 505);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalji";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Sienna;
            this.label5.Location = new System.Drawing.Point(9, -3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 21);
            this.label5.TabIndex = 22;
            this.label5.Text = "Detalji";
            // 
            // lblDetaljPoruka
            // 
            this.lblDetaljPoruka.AutoSize = true;
            this.lblDetaljPoruka.BackColor = System.Drawing.Color.White;
            this.lblDetaljPoruka.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetaljPoruka.ForeColor = System.Drawing.Color.Red;
            this.lblDetaljPoruka.Location = new System.Drawing.Point(389, 222);
            this.lblDetaljPoruka.Name = "lblDetaljPoruka";
            this.lblDetaljPoruka.Padding = new System.Windows.Forms.Padding(3);
            this.lblDetaljPoruka.Size = new System.Drawing.Size(170, 31);
            this.lblDetaljPoruka.TabIndex = 20;
            this.lblDetaljPoruka.Text = "Nema podataka !";
            this.lblDetaljPoruka.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblNazivKrola);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblKrolGlavaPoruka);
            this.groupBox2.Controls.Add(this.lstViewKrolGlava);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 153);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(364, 505);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Krol";
            // 
            // lblNazivKrola
            // 
            this.lblNazivKrola.AutoSize = true;
            this.lblNazivKrola.BackColor = System.Drawing.Color.Gray;
            this.lblNazivKrola.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNazivKrola.ForeColor = System.Drawing.Color.White;
            this.lblNazivKrola.Location = new System.Drawing.Point(92, 0);
            this.lblNazivKrola.Name = "lblNazivKrola";
            this.lblNazivKrola.Padding = new System.Windows.Forms.Padding(2);
            this.lblNazivKrola.Size = new System.Drawing.Size(47, 21);
            this.lblNazivKrola.TabIndex = 22;
            this.lblNazivKrola.Text = "label7";
            this.lblNazivKrola.Visible = false;
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
            this.lblKrolGlavaPoruka.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKrolGlavaPoruka.ForeColor = System.Drawing.Color.Red;
            this.lblKrolGlavaPoruka.Location = new System.Drawing.Point(96, 228);
            this.lblKrolGlavaPoruka.Name = "lblKrolGlavaPoruka";
            this.lblKrolGlavaPoruka.Size = new System.Drawing.Size(164, 25);
            this.lblKrolGlavaPoruka.TabIndex = 21;
            this.lblKrolGlavaPoruka.Text = "Nema podataka !";
            this.lblKrolGlavaPoruka.Visible = false;
            // 
            // lstViewKrolGlava
            // 
            this.lstViewKrolGlava.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstViewKrolGlava.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDatum,
            this.colNaziv,
            this.colIzvrsilac});
            this.lstViewKrolGlava.ContextMenuStrip = this.KrolGlavaContextMenu;
            this.lstViewKrolGlava.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstViewKrolGlava.FullRowSelect = true;
            this.lstViewKrolGlava.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstViewKrolGlava.Location = new System.Drawing.Point(3, 21);
            this.lstViewKrolGlava.Margin = new System.Windows.Forms.Padding(10);
            this.lstViewKrolGlava.MultiSelect = false;
            this.lstViewKrolGlava.Name = "lstViewKrolGlava";
            this.lstViewKrolGlava.Size = new System.Drawing.Size(358, 481);
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
            this.colNaziv.Width = 120;
            // 
            // colIzvrsilac
            // 
            this.colIzvrsilac.Text = "Izvršilac";
            this.colIzvrsilac.Width = 120;
            // 
            // KrolGlavaContextMenu
            // 
            this.KrolGlavaContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripObrisiKrol});
            this.KrolGlavaContextMenu.Name = "KrolGlavaContextMenu";
            this.KrolGlavaContextMenu.Size = new System.Drawing.Size(129, 26);
            // 
            // toolStripObrisiKrol
            // 
            this.toolStripObrisiKrol.ForeColor = System.Drawing.Color.Red;
            this.toolStripObrisiKrol.Image = global::WebCene.UI.Properties.Resources.delete_26;
            this.toolStripObrisiKrol.Name = "toolStripObrisiKrol";
            this.toolStripObrisiKrol.Size = new System.Drawing.Size(128, 22);
            this.toolStripObrisiKrol.Text = "Obriši krol";
            this.toolStripObrisiKrol.Click += new System.EventHandler(this.toolStripObrisiKrol_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.picFilter);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.comboKategorije);
            this.groupBox3.Controls.Add(this.comboBrendovi);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.btnFilter);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Location = new System.Drawing.Point(373, 53);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(684, 94);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filter detalja";
            // 
            // picFilter
            // 
            this.picFilter.BackColor = System.Drawing.Color.LemonChiffon;
            this.picFilter.Cursor = System.Windows.Forms.Cursors.No;
            this.picFilter.Image = global::WebCene.UI.Properties.Resources.filled_filter_32;
            this.picFilter.Location = new System.Drawing.Point(605, 32);
            this.picFilter.Name = "picFilter";
            this.picFilter.Size = new System.Drawing.Size(61, 50);
            this.picFilter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picFilter.TabIndex = 22;
            this.picFilter.TabStop = false;
            this.picFilter.Visible = false;
            this.picFilter.Click += new System.EventHandler(this.picFilter_Click);
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
            this.btnOdustani.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOdustani.Location = new System.Drawing.Point(1378, 686);
            this.btnOdustani.Margin = new System.Windows.Forms.Padding(25);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(121, 30);
            this.btnOdustani.TabIndex = 19;
            this.btnOdustani.Text = "Zatvori";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // btnNoviKrol
            // 
            this.btnNoviKrol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNoviKrol.Location = new System.Drawing.Point(25, 686);
            this.btnNoviKrol.Margin = new System.Windows.Forms.Padding(25);
            this.btnNoviKrol.Name = "btnNoviKrol";
            this.btnNoviKrol.Size = new System.Drawing.Size(121, 30);
            this.btnNoviKrol.TabIndex = 20;
            this.btnNoviKrol.Text = "Novi krol";
            this.btnNoviKrol.UseVisualStyleBackColor = true;
            this.btnNoviKrol.Click += new System.EventHandler(this.btnNoviKrol_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::WebCene.UI.Properties.Resources.logoEponuda;
            this.pictureBox1.Location = new System.Drawing.Point(3, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(364, 94);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 370F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 690F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnNoviKrol, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnOdustani, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.grpBoxCenaMaloPM, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1524, 741);
            this.tableLayoutPanel1.TabIndex = 22;
            // 
            // grpBoxCenaMaloPM
            // 
            this.grpBoxCenaMaloPM.Controls.Add(this.chkCenaM);
            this.grpBoxCenaMaloPM.Controls.Add(this.chkBPAL);
            this.grpBoxCenaMaloPM.Controls.Add(this.chkKULA);
            this.grpBoxCenaMaloPM.Controls.Add(this.chkODZ);
            this.grpBoxCenaMaloPM.Controls.Add(this.chkAPA);
            this.grpBoxCenaMaloPM.Controls.Add(this.chkSO);
            this.grpBoxCenaMaloPM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxCenaMaloPM.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.grpBoxCenaMaloPM.ForeColor = System.Drawing.Color.Firebrick;
            this.grpBoxCenaMaloPM.Location = new System.Drawing.Point(1070, 60);
            this.grpBoxCenaMaloPM.Margin = new System.Windows.Forms.Padding(10);
            this.grpBoxCenaMaloPM.Name = "grpBoxCenaMaloPM";
            this.grpBoxCenaMaloPM.Size = new System.Drawing.Size(444, 80);
            this.grpBoxCenaMaloPM.TabIndex = 22;
            this.grpBoxCenaMaloPM.TabStop = false;
            this.grpBoxCenaMaloPM.Text = "CENAMALO (ARTPROD) * 0.9";
            // 
            // chkBPAL
            // 
            this.chkBPAL.AutoSize = true;
            this.chkBPAL.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chkBPAL.Location = new System.Drawing.Point(221, 24);
            this.chkBPAL.Name = "chkBPAL";
            this.chkBPAL.Size = new System.Drawing.Size(81, 21);
            this.chkBPAL.TabIndex = 4;
            this.chkBPAL.Tag = "B.PALANKA";
            this.chkBPAL.Text = "B.Palanka";
            this.chkBPAL.UseVisualStyleBackColor = true;
            this.chkBPAL.CheckedChanged += new System.EventHandler(this.chkBPAL_CheckedChanged);
            // 
            // chkKULA
            // 
            this.chkKULA.AutoSize = true;
            this.chkKULA.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chkKULA.Location = new System.Drawing.Point(117, 51);
            this.chkKULA.Name = "chkKULA";
            this.chkKULA.Size = new System.Drawing.Size(52, 21);
            this.chkKULA.TabIndex = 3;
            this.chkKULA.Tag = "KULA";
            this.chkKULA.Text = "Kula";
            this.chkKULA.UseVisualStyleBackColor = true;
            this.chkKULA.CheckedChanged += new System.EventHandler(this.chkKULA_CheckedChanged);
            // 
            // chkODZ
            // 
            this.chkODZ.AutoSize = true;
            this.chkODZ.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chkODZ.Location = new System.Drawing.Point(117, 24);
            this.chkODZ.Name = "chkODZ";
            this.chkODZ.Size = new System.Drawing.Size(67, 21);
            this.chkODZ.TabIndex = 2;
            this.chkODZ.Tag = "ODŽACI";
            this.chkODZ.Text = "Odžaci";
            this.chkODZ.UseVisualStyleBackColor = true;
            this.chkODZ.CheckedChanged += new System.EventHandler(this.chkODZ_CheckedChanged);
            // 
            // chkAPA
            // 
            this.chkAPA.AutoSize = true;
            this.chkAPA.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chkAPA.Location = new System.Drawing.Point(6, 51);
            this.chkAPA.Name = "chkAPA";
            this.chkAPA.Size = new System.Drawing.Size(64, 21);
            this.chkAPA.TabIndex = 1;
            this.chkAPA.Tag = "APATIN";
            this.chkAPA.Text = "Apatin";
            this.chkAPA.UseVisualStyleBackColor = true;
            this.chkAPA.CheckedChanged += new System.EventHandler(this.chkAPA_CheckedChanged);
            // 
            // chkSO
            // 
            this.chkSO.AutoSize = true;
            this.chkSO.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chkSO.Location = new System.Drawing.Point(6, 24);
            this.chkSO.Name = "chkSO";
            this.chkSO.Size = new System.Drawing.Size(74, 21);
            this.chkSO.TabIndex = 0;
            this.chkSO.Tag = "SOMBOR";
            this.chkSO.Text = "Sombor";
            this.chkSO.UseVisualStyleBackColor = true;
            this.chkSO.CheckedChanged += new System.EventHandler(this.chkSO_CheckedChanged);
            // 
            // chkCenaM
            // 
            this.chkCenaM.AutoSize = true;
            this.chkCenaM.Checked = true;
            this.chkCenaM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCenaM.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chkCenaM.Location = new System.Drawing.Point(221, 51);
            this.chkCenaM.Name = "chkCenaM";
            this.chkCenaM.Size = new System.Drawing.Size(141, 21);
            this.chkCenaM.TabIndex = 5;
            this.chkCenaM.Tag = "CENAM";
            this.chkCenaM.Text = "CENAM (NABCENE)";
            this.chkCenaM.UseVisualStyleBackColor = true;
            this.chkCenaM.CheckedChanged += new System.EventHandler(this.chkCenaM_CheckedChanged);
            // 
            // frmListaKrolovaCrosstab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1524, 741);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmListaKrolovaCrosstab";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crosstab lista krolova";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_NextControl);
            ((System.ComponentModel.ISupportInitialize)(this.dgViewKrolDetalj)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.KrolGlavaContextMenu.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.grpBoxCenaMaloPM.ResumeLayout(false);
            this.grpBoxCenaMaloPM.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Label lblDetaljPoruka;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnOdustani;
        private System.Windows.Forms.Button btnNoviKrol;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox picFilter;
        private System.Windows.Forms.ContextMenuStrip KrolGlavaContextMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripObrisiKrol;
        private System.Windows.Forms.Label lblNazivKrola;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox grpBoxCenaMaloPM;
        private System.Windows.Forms.CheckBox chkBPAL;
        private System.Windows.Forms.CheckBox chkKULA;
        private System.Windows.Forms.CheckBox chkODZ;
        private System.Windows.Forms.CheckBox chkAPA;
        private System.Windows.Forms.CheckBox chkSO;
        private System.Windows.Forms.CheckBox chkCenaM;
    }
}