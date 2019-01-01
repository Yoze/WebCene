namespace WebCene.UI.Forms.B2B
{
    partial class frmKonfigDobavljaca
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lvMarzeDobavljaca = new System.Windows.Forms.ListView();
            this.colNncDonjiLimit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNncGornjiLimit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMarzaProc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRabatProc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDodajMarzu = new System.Windows.Forms.Button();
            this.btnIzmeniMarzu = new System.Windows.Forms.Button();
            this.btniObrisiMarzu = new System.Windows.Forms.Button();
            this.flowLayoutPanelModelDetails = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.lab = new System.Windows.Forms.Label();
            this.txtCenovnikFilename = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLagerFilename = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtWebProtokol = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.flowLayoutPanelRebateDetails = new System.Windows.Forms.FlowLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKursEvra = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStopaPdvProc = new System.Windows.Forms.TextBox();
            this.checkIsManualno = new System.Windows.Forms.CheckBox();
            this.lblManuelnoDescription = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSnimi = new System.Windows.Forms.Button();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.lvDobavljaci = new System.Windows.Forms.ListView();
            this.colNaziv = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblNaziv = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtRabatProc = new System.Windows.Forms.TextBox();
            this.marzeDobavljacaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanelModelDetails.SuspendLayout();
            this.flowLayoutPanelRebateDetails.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.marzeDobavljacaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanelModelDetails, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanelRebateDetails, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblNaziv, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1194, 670);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel2, 2);
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.Controls.Add(this.lvMarzeDobavljaca);
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel4);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(252, 353);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(910, 244);
            this.flowLayoutPanel2.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Marže/rabati";
            // 
            // lvMarzeDobavljaca
            // 
            this.lvMarzeDobavljaca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvMarzeDobavljaca.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNncDonjiLimit,
            this.colNncGornjiLimit,
            this.colMarzaProc,
            this.colRabatProc,
            this.colId});
            this.lvMarzeDobavljaca.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvMarzeDobavljaca.Location = new System.Drawing.Point(8, 35);
            this.lvMarzeDobavljaca.MultiSelect = false;
            this.lvMarzeDobavljaca.Name = "lvMarzeDobavljaca";
            this.lvMarzeDobavljaca.Size = new System.Drawing.Size(568, 155);
            this.lvMarzeDobavljaca.TabIndex = 4;
            this.lvMarzeDobavljaca.UseCompatibleStateImageBehavior = false;
            this.lvMarzeDobavljaca.ItemActivate += new System.EventHandler(this.lvMarzeDobavljaca_ItemActivate);
            this.lvMarzeDobavljaca.SelectedIndexChanged += new System.EventHandler(this.lvMarzeDobavljaca_SelectedIndexChanged);
            // 
            // colNncDonjiLimit
            // 
            this.colNncDonjiLimit.Text = "NNC Donji Limit";
            this.colNncDonjiLimit.Width = 120;
            // 
            // colNncGornjiLimit
            // 
            this.colNncGornjiLimit.Text = "NNC Gornji Limit";
            this.colNncGornjiLimit.Width = 120;
            // 
            // colMarzaProc
            // 
            this.colMarzaProc.Text = "Marža (%)";
            this.colMarzaProc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colMarzaProc.Width = 90;
            // 
            // colRabatProc
            // 
            this.colRabatProc.DisplayIndex = 4;
            this.colRabatProc.Text = "Rabat (%)";
            this.colRabatProc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colRabatProc.Width = 90;
            // 
            // colId
            // 
            this.colId.DisplayIndex = 3;
            this.colId.Text = "Id";
            this.colId.Width = 0;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.btnDodajMarzu);
            this.flowLayoutPanel4.Controls.Add(this.btnIzmeniMarzu);
            this.flowLayoutPanel4.Controls.Add(this.btniObrisiMarzu);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(8, 196);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(568, 38);
            this.flowLayoutPanel4.TabIndex = 3;
            // 
            // btnDodajMarzu
            // 
            this.btnDodajMarzu.Location = new System.Drawing.Point(3, 3);
            this.btnDodajMarzu.Name = "btnDodajMarzu";
            this.btnDodajMarzu.Size = new System.Drawing.Size(105, 27);
            this.btnDodajMarzu.TabIndex = 3;
            this.btnDodajMarzu.Text = "Dodaj";
            this.btnDodajMarzu.UseVisualStyleBackColor = true;
            this.btnDodajMarzu.Click += new System.EventHandler(this.btnDodajMarzu_Click);
            // 
            // btnIzmeniMarzu
            // 
            this.btnIzmeniMarzu.Location = new System.Drawing.Point(114, 3);
            this.btnIzmeniMarzu.Name = "btnIzmeniMarzu";
            this.btnIzmeniMarzu.Size = new System.Drawing.Size(105, 27);
            this.btnIzmeniMarzu.TabIndex = 4;
            this.btnIzmeniMarzu.Text = "Izmeni";
            this.btnIzmeniMarzu.UseVisualStyleBackColor = true;
            this.btnIzmeniMarzu.Click += new System.EventHandler(this.btnIzmeniMarzu_Click);
            // 
            // btniObrisiMarzu
            // 
            this.btniObrisiMarzu.Location = new System.Drawing.Point(225, 3);
            this.btniObrisiMarzu.Name = "btniObrisiMarzu";
            this.btniObrisiMarzu.Size = new System.Drawing.Size(105, 27);
            this.btniObrisiMarzu.TabIndex = 5;
            this.btniObrisiMarzu.Text = "Obriši";
            this.btniObrisiMarzu.UseVisualStyleBackColor = true;
            this.btniObrisiMarzu.Click += new System.EventHandler(this.btniObrisiMarzu_Click);
            // 
            // flowLayoutPanelModelDetails
            // 
            this.flowLayoutPanelModelDetails.Controls.Add(this.label6);
            this.flowLayoutPanelModelDetails.Controls.Add(this.lab);
            this.flowLayoutPanelModelDetails.Controls.Add(this.txtCenovnikFilename);
            this.flowLayoutPanelModelDetails.Controls.Add(this.label7);
            this.flowLayoutPanelModelDetails.Controls.Add(this.txtLagerFilename);
            this.flowLayoutPanelModelDetails.Controls.Add(this.label3);
            this.flowLayoutPanelModelDetails.Controls.Add(this.txtWebProtokol);
            this.flowLayoutPanelModelDetails.Controls.Add(this.label8);
            this.flowLayoutPanelModelDetails.Controls.Add(this.txtUrl);
            this.flowLayoutPanelModelDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelModelDetails.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelModelDetails.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanelModelDetails.Location = new System.Drawing.Point(252, 63);
            this.flowLayoutPanelModelDetails.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.flowLayoutPanelModelDetails.Name = "flowLayoutPanelModelDetails";
            this.flowLayoutPanelModelDetails.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanelModelDetails.Size = new System.Drawing.Size(452, 277);
            this.flowLayoutPanelModelDetails.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 10);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 5, 5, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 17);
            this.label6.TabIndex = 7;
            this.label6.Text = "Xml/Ftp info";
            // 
            // lab
            // 
            this.lab.AutoSize = true;
            this.lab.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab.Location = new System.Drawing.Point(8, 45);
            this.lab.Margin = new System.Windows.Forms.Padding(3);
            this.lab.Name = "lab";
            this.lab.Size = new System.Drawing.Size(110, 13);
            this.lab.TabIndex = 4;
            this.lab.Text = "Naziv Xml cenovnika";
            // 
            // txtCenovnikFilename
            // 
            this.txtCenovnikFilename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCenovnikFilename.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCenovnikFilename.Location = new System.Drawing.Point(8, 64);
            this.txtCenovnikFilename.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.txtCenovnikFilename.Name = "txtCenovnikFilename";
            this.txtCenovnikFilename.ReadOnly = true;
            this.txtCenovnikFilename.Size = new System.Drawing.Size(287, 23);
            this.txtCenovnikFilename.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 100);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Naziv Xml lagera";
            // 
            // txtLagerFilename
            // 
            this.txtLagerFilename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLagerFilename.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLagerFilename.Location = new System.Drawing.Point(8, 119);
            this.txtLagerFilename.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.txtLagerFilename.Name = "txtLagerFilename";
            this.txtLagerFilename.ReadOnly = true;
            this.txtLagerFilename.Size = new System.Drawing.Size(287, 23);
            this.txtLagerFilename.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 155);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Web protokol";
            // 
            // txtWebProtokol
            // 
            this.txtWebProtokol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWebProtokol.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWebProtokol.Location = new System.Drawing.Point(8, 174);
            this.txtWebProtokol.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.txtWebProtokol.Name = "txtWebProtokol";
            this.txtWebProtokol.ReadOnly = true;
            this.txtWebProtokol.Size = new System.Drawing.Size(287, 23);
            this.txtWebProtokol.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 210);
            this.label8.Margin = new System.Windows.Forms.Padding(3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "URL";
            // 
            // txtUrl
            // 
            this.txtUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUrl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUrl.Location = new System.Drawing.Point(8, 229);
            this.txtUrl.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.ReadOnly = true;
            this.txtUrl.Size = new System.Drawing.Size(287, 23);
            this.txtUrl.TabIndex = 8;
            // 
            // flowLayoutPanelRebateDetails
            // 
            this.flowLayoutPanelRebateDetails.Controls.Add(this.label9);
            this.flowLayoutPanelRebateDetails.Controls.Add(this.label5);
            this.flowLayoutPanelRebateDetails.Controls.Add(this.txtStopaPdvProc);
            this.flowLayoutPanelRebateDetails.Controls.Add(this.label4);
            this.flowLayoutPanelRebateDetails.Controls.Add(this.txtKursEvra);
            this.flowLayoutPanelRebateDetails.Controls.Add(this.label10);
            this.flowLayoutPanelRebateDetails.Controls.Add(this.txtRabatProc);
            this.flowLayoutPanelRebateDetails.Controls.Add(this.checkIsManualno);
            this.flowLayoutPanelRebateDetails.Controls.Add(this.lblManuelnoDescription);
            this.flowLayoutPanelRebateDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelRebateDetails.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelRebateDetails.Location = new System.Drawing.Point(710, 63);
            this.flowLayoutPanelRebateDetails.Name = "flowLayoutPanelRebateDetails";
            this.flowLayoutPanelRebateDetails.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanelRebateDetails.Size = new System.Drawing.Size(452, 284);
            this.flowLayoutPanelRebateDetails.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(10, 10);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 5, 5, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(137, 17);
            this.label9.TabIndex = 9;
            this.label9.Text = "Parametri kalkulacije";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Kurs evra";
            // 
            // txtKursEvra
            // 
            this.txtKursEvra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKursEvra.Location = new System.Drawing.Point(8, 102);
            this.txtKursEvra.Name = "txtKursEvra";
            this.txtKursEvra.Size = new System.Drawing.Size(108, 25);
            this.txtKursEvra.TabIndex = 3;
            this.txtKursEvra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateDecimalInput);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Stopa PDV [%]";
            // 
            // txtStopaPdvProc
            // 
            this.txtStopaPdvProc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStopaPdvProc.Enabled = false;
            this.txtStopaPdvProc.Location = new System.Drawing.Point(8, 58);
            this.txtStopaPdvProc.Name = "txtStopaPdvProc";
            this.txtStopaPdvProc.Size = new System.Drawing.Size(108, 25);
            this.txtStopaPdvProc.TabIndex = 6;
            this.txtStopaPdvProc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateDecimalInput);
            // 
            // checkIsManualno
            // 
            this.checkIsManualno.AutoSize = true;
            this.checkIsManualno.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkIsManualno.Location = new System.Drawing.Point(8, 177);
            this.checkIsManualno.Name = "checkIsManualno";
            this.checkIsManualno.Size = new System.Drawing.Size(85, 21);
            this.checkIsManualno.TabIndex = 10;
            this.checkIsManualno.Text = "Manualno";
            this.checkIsManualno.UseVisualStyleBackColor = true;
            this.checkIsManualno.CheckedChanged += new System.EventHandler(this.checkIsManualno_CheckedChanged);
            // 
            // lblManuelnoDescription
            // 
            this.lblManuelnoDescription.AutoSize = true;
            this.lblManuelnoDescription.BackColor = System.Drawing.Color.Gainsboro;
            this.lblManuelnoDescription.Location = new System.Drawing.Point(8, 201);
            this.lblManuelnoDescription.Name = "lblManuelnoDescription";
            this.lblManuelnoDescription.Size = new System.Drawing.Size(330, 51);
            this.lblManuelnoDescription.TabIndex = 11;
            this.lblManuelnoDescription.Text = "Fajlovi su spremni u Office-u i NNC je već pripremljena.\r\nKurs evra = 1\r\nKoeficij" +
    "ent marže = 1";
            this.lblManuelnoDescription.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnSnimi);
            this.flowLayoutPanel1.Controls.Add(this.btnOdustani);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(710, 603);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(452, 44);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnSnimi
            // 
            this.btnSnimi.Location = new System.Drawing.Point(327, 5);
            this.btnSnimi.Margin = new System.Windows.Forms.Padding(5);
            this.btnSnimi.Name = "btnSnimi";
            this.btnSnimi.Size = new System.Drawing.Size(120, 30);
            this.btnSnimi.TabIndex = 0;
            this.btnSnimi.Text = "Snimi";
            this.btnSnimi.UseVisualStyleBackColor = true;
            this.btnSnimi.Click += new System.EventHandler(this.btnSnimi_Click);
            // 
            // btnOdustani
            // 
            this.btnOdustani.Location = new System.Drawing.Point(197, 5);
            this.btnOdustani.Margin = new System.Windows.Forms.Padding(5);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(120, 30);
            this.btnOdustani.TabIndex = 1;
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.label2);
            this.flowLayoutPanel3.Controls.Add(this.lvDobavljaci);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(23, 63);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.tableLayoutPanel1.SetRowSpan(this.flowLayoutPanel3, 2);
            this.flowLayoutPanel3.Size = new System.Drawing.Size(223, 534);
            this.flowLayoutPanel3.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 5);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Dobavljači";
            // 
            // lvDobavljaci
            // 
            this.lvDobavljaci.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvDobavljaci.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNaziv});
            this.lvDobavljaci.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvDobavljaci.HideSelection = false;
            this.lvDobavljaci.Location = new System.Drawing.Point(3, 40);
            this.lvDobavljaci.MultiSelect = false;
            this.lvDobavljaci.Name = "lvDobavljaci";
            this.lvDobavljaci.Size = new System.Drawing.Size(217, 485);
            this.lvDobavljaci.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvDobavljaci.TabIndex = 9;
            this.lvDobavljaci.UseCompatibleStateImageBehavior = false;
            this.lvDobavljaci.View = System.Windows.Forms.View.Details;
            this.lvDobavljaci.ItemActivate += new System.EventHandler(this.lvDobavljaci_ItemActivate);
            this.lvDobavljaci.SelectedIndexChanged += new System.EventHandler(this.lvDobavljaci_SelectedIndexChanged);
            // 
            // colNaziv
            // 
            this.colNaziv.Text = "Naziv";
            this.colNaziv.Width = 199;
            // 
            // lblNaziv
            // 
            this.lblNaziv.AutoSize = true;
            this.lblNaziv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNaziv.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNaziv.ForeColor = System.Drawing.Color.DarkOrchid;
            this.lblNaziv.Location = new System.Drawing.Point(254, 25);
            this.lblNaziv.Margin = new System.Windows.Forms.Padding(5);
            this.lblNaziv.Name = "lblNaziv";
            this.lblNaziv.Size = new System.Drawing.Size(54, 21);
            this.lblNaziv.TabIndex = 0;
            this.lblNaziv.Text = "Naziv";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(8, 130);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Rabat [%]";
            // 
            // txtRabatProc
            // 
            this.txtRabatProc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRabatProc.Location = new System.Drawing.Point(8, 146);
            this.txtRabatProc.Name = "txtRabatProc";
            this.txtRabatProc.Size = new System.Drawing.Size(108, 25);
            this.txtRabatProc.TabIndex = 13;
            this.txtRabatProc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateDecimalInput);
            // 
            // marzeDobavljacaBindingSource
            // 
            this.marzeDobavljacaBindingSource.DataSource = typeof(WebCene.Model.B2B.MarzeDobavljaca);
            // 
            // frmKonfigDobavljaca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 670);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmKonfigDobavljaca";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Konfiguracije dobavljača";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanelModelDetails.ResumeLayout(false);
            this.flowLayoutPanelModelDetails.PerformLayout();
            this.flowLayoutPanelRebateDetails.ResumeLayout(false);
            this.flowLayoutPanelRebateDetails.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.marzeDobavljacaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblNaziv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnSnimi;
        private System.Windows.Forms.Button btnOdustani;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelModelDetails;
        private System.Windows.Forms.Label lab;
        private System.Windows.Forms.TextBox txtCenovnikFilename;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelRebateDetails;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtKursEvra;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.TextBox txtWebProtokol;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.TextBox txtLagerFilename;
        private System.Windows.Forms.TextBox txtStopaPdvProc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnDodajMarzu;
        private System.Windows.Forms.ListView lvDobavljaci;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader colNaziv;
        private System.Windows.Forms.Button btnIzmeniMarzu;
        private System.Windows.Forms.Button btniObrisiMarzu;
        private System.Windows.Forms.BindingSource marzeDobavljacaBindingSource;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.ListView lvMarzeDobavljaca;
        private System.Windows.Forms.ColumnHeader colNncDonjiLimit;
        private System.Windows.Forms.ColumnHeader colNncGornjiLimit;
        private System.Windows.Forms.ColumnHeader colMarzaProc;
        private System.Windows.Forms.ColumnHeader colId;
        private System.Windows.Forms.CheckBox checkIsManualno;
        private System.Windows.Forms.ColumnHeader colRabatProc;
        private System.Windows.Forms.Label lblManuelnoDescription;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtRabatProc;
    }
}