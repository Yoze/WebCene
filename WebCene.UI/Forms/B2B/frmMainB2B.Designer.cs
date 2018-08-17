namespace WebCene.UI.Forms.B2B
{
    partial class frmMainB2B
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnWebService = new System.Windows.Forms.Button();
            this.btnLoadXmls = new System.Windows.Forms.Button();
            this.dgvStatus = new System.Windows.Forms.DataGridView();
            this.rbr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dobavljac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isLoaded = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberOfRecords = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvZbirniXml = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancelXmlLoading = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvZbirniXml)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "ftp";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(85, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(76, 32);
            this.button2.TabIndex = 1;
            this.button2.Text = "http";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // btnWebService
            // 
            this.btnWebService.Location = new System.Drawing.Point(167, 3);
            this.btnWebService.Name = "btnWebService";
            this.btnWebService.Size = new System.Drawing.Size(76, 32);
            this.btnWebService.TabIndex = 2;
            this.btnWebService.Text = "web service";
            this.btnWebService.UseVisualStyleBackColor = true;
            this.btnWebService.Visible = false;
            this.btnWebService.Click += new System.EventHandler(this.btnWebService_Click);
            // 
            // btnLoadXmls
            // 
            this.btnLoadXmls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadXmls.Location = new System.Drawing.Point(5, 5);
            this.btnLoadXmls.Margin = new System.Windows.Forms.Padding(5);
            this.btnLoadXmls.Name = "btnLoadXmls";
            this.btnLoadXmls.Size = new System.Drawing.Size(120, 30);
            this.btnLoadXmls.TabIndex = 3;
            this.btnLoadXmls.Text = "UČITAJ";
            this.btnLoadXmls.UseVisualStyleBackColor = true;
            this.btnLoadXmls.Click += new System.EventHandler(this.btnLoadXmls_Click);
            // 
            // dgvStatus
            // 
            this.dgvStatus.AllowUserToAddRows = false;
            this.dgvStatus.AllowUserToDeleteRows = false;
            this.dgvStatus.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvStatus.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvStatus.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rbr,
            this.dobavljac,
            this.isLoaded,
            this.numberOfRecords,
            this.statusDesc,
            this.dataSource});
            this.dgvStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStatus.Enabled = false;
            this.dgvStatus.Location = new System.Drawing.Point(3, 63);
            this.dgvStatus.MultiSelect = false;
            this.dgvStatus.Name = "dgvStatus";
            this.dgvStatus.ReadOnly = true;
            this.dgvStatus.RowHeadersVisible = false;
            this.dgvStatus.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvStatus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStatus.Size = new System.Drawing.Size(564, 515);
            this.dgvStatus.TabIndex = 5;
            // 
            // rbr
            // 
            this.rbr.HeaderText = "RB";
            this.rbr.Name = "rbr";
            this.rbr.ReadOnly = true;
            this.rbr.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.rbr.Width = 40;
            // 
            // dobavljac
            // 
            this.dobavljac.HeaderText = "Dobavljač";
            this.dobavljac.Name = "dobavljac";
            this.dobavljac.ReadOnly = true;
            this.dobavljac.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dobavljac.Width = 120;
            // 
            // isLoaded
            // 
            this.isLoaded.HeaderText = "Deserialized";
            this.isLoaded.Name = "isLoaded";
            this.isLoaded.ReadOnly = true;
            this.isLoaded.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.isLoaded.Width = 80;
            // 
            // numberOfRecords
            // 
            this.numberOfRecords.HeaderText = "Uk.Zapisa";
            this.numberOfRecords.Name = "numberOfRecords";
            this.numberOfRecords.ReadOnly = true;
            this.numberOfRecords.Width = 80;
            // 
            // statusDesc
            // 
            this.statusDesc.HeaderText = "Opis statusa";
            this.statusDesc.MinimumWidth = 50;
            this.statusDesc.Name = "statusDesc";
            this.statusDesc.ReadOnly = true;
            this.statusDesc.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.statusDesc.Width = 160;
            // 
            // dataSource
            // 
            this.dataSource.HeaderText = "Izvor";
            this.dataSource.Name = "dataSource";
            this.dataSource.ReadOnly = true;
            this.dataSource.Width = 80;
            // 
            // dgvZbirniXml
            // 
            this.dgvZbirniXml.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvZbirniXml.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvZbirniXml.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvZbirniXml.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvZbirniXml.Location = new System.Drawing.Point(600, 90);
            this.dgvZbirniXml.Margin = new System.Windows.Forms.Padding(10);
            this.dgvZbirniXml.MultiSelect = false;
            this.dgvZbirniXml.Name = "dgvZbirniXml";
            this.dgvZbirniXml.ReadOnly = true;
            this.dgvZbirniXml.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvZbirniXml.Size = new System.Drawing.Size(503, 581);
            this.dgvZbirniXml.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 590F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.dgvZbirniXml, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1273, 731);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Controls.Add(this.btnWebService);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(593, 684);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(384, 44);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.lblStatus, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.dgvStatus, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(10, 90);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(570, 581);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblStatus.Location = new System.Drawing.Point(3, 30);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(564, 17);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "status label";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Status";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnLoadXmls);
            this.flowLayoutPanel2.Controls.Add(this.btnCancelXmlLoading);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(1116, 83);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(134, 595);
            this.flowLayoutPanel2.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.label2.Location = new System.Drawing.Point(20, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(301, 21);
            this.label2.TabIndex = 11;
            this.label2.Text = "Učitavanje cenovnika i lagera dobavljača";
            // 
            // btnCancelXmlLoading
            // 
            this.btnCancelXmlLoading.Enabled = false;
            this.btnCancelXmlLoading.Location = new System.Drawing.Point(5, 45);
            this.btnCancelXmlLoading.Margin = new System.Windows.Forms.Padding(5);
            this.btnCancelXmlLoading.Name = "btnCancelXmlLoading";
            this.btnCancelXmlLoading.Size = new System.Drawing.Size(120, 30);
            this.btnCancelXmlLoading.TabIndex = 4;
            this.btnCancelXmlLoading.Text = "Prekini";
            this.btnCancelXmlLoading.UseVisualStyleBackColor = true;
            this.btnCancelXmlLoading.Click += new System.EventHandler(this.btnCancelXmlLoading_Click);
            // 
            // frmMainB2B
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1273, 731);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "frmMainB2B";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "B2B Cenovnici i lageri";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvZbirniXml)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnWebService;
        private System.Windows.Forms.Button btnLoadXmls;
        private System.Windows.Forms.DataGridView dgvStatus;
        private System.Windows.Forms.DataGridView dgvZbirniXml;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn rbr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dobavljac;
        private System.Windows.Forms.DataGridViewTextBoxColumn isLoaded;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberOfRecords;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataSource;
        private System.Windows.Forms.Button btnCancelXmlLoading;
    }
}