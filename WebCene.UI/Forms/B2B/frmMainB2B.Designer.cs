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
            this.listViewStatus = new System.Windows.Forms.ListView();
            this.dgvStatus = new System.Windows.Forms.DataGridView();
            this.rbr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dobavljac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isLoaded = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 56);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "ftp";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(29, 102);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 40);
            this.button2.TabIndex = 1;
            this.button2.Text = "http";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnWebService
            // 
            this.btnWebService.Location = new System.Drawing.Point(29, 148);
            this.btnWebService.Name = "btnWebService";
            this.btnWebService.Size = new System.Drawing.Size(136, 40);
            this.btnWebService.TabIndex = 2;
            this.btnWebService.Text = "web service";
            this.btnWebService.UseVisualStyleBackColor = true;
            this.btnWebService.Click += new System.EventHandler(this.btnWebService_Click);
            // 
            // btnLoadXmls
            // 
            this.btnLoadXmls.Location = new System.Drawing.Point(29, 262);
            this.btnLoadXmls.Name = "btnLoadXmls";
            this.btnLoadXmls.Size = new System.Drawing.Size(136, 40);
            this.btnLoadXmls.TabIndex = 3;
            this.btnLoadXmls.Text = "Load XMLs";
            this.btnLoadXmls.UseVisualStyleBackColor = true;
            this.btnLoadXmls.Click += new System.EventHandler(this.btnLoadXmls_Click);
            // 
            // listViewStatus
            // 
            this.listViewStatus.AutoArrange = false;
            this.listViewStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewStatus.FullRowSelect = true;
            this.listViewStatus.Location = new System.Drawing.Point(369, 38);
            this.listViewStatus.MultiSelect = false;
            this.listViewStatus.Name = "listViewStatus";
            this.listViewStatus.Size = new System.Drawing.Size(634, 132);
            this.listViewStatus.TabIndex = 4;
            this.listViewStatus.TabStop = false;
            this.listViewStatus.UseCompatibleStateImageBehavior = false;
            this.listViewStatus.View = System.Windows.Forms.View.List;
            // 
            // dgvStatus
            // 
            this.dgvStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rbr,
            this.dobavljac,
            this.isLoaded});
            this.dgvStatus.Location = new System.Drawing.Point(369, 245);
            this.dgvStatus.Name = "dgvStatus";
            this.dgvStatus.Size = new System.Drawing.Size(634, 150);
            this.dgvStatus.TabIndex = 5;
            // 
            // rbr
            // 
            this.rbr.HeaderText = "RB";
            this.rbr.Name = "rbr";
            this.rbr.ReadOnly = true;
            // 
            // dobavljac
            // 
            this.dobavljac.HeaderText = "Dobavljač";
            this.dobavljac.Name = "dobavljac";
            this.dobavljac.ReadOnly = true;
            // 
            // isLoaded
            // 
            this.isLoaded.HeaderText = "Učitan XML";
            this.isLoaded.Name = "isLoaded";
            this.isLoaded.ReadOnly = true;
            // 
            // frmMainB2B
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 637);
            this.Controls.Add(this.dgvStatus);
            this.Controls.Add(this.listViewStatus);
            this.Controls.Add(this.btnLoadXmls);
            this.Controls.Add(this.btnWebService);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "frmMainB2B";
            this.Text = "frmMainB2B";
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnWebService;
        private System.Windows.Forms.Button btnLoadXmls;
        private System.Windows.Forms.ListView listViewStatus;
        private System.Windows.Forms.DataGridView dgvStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn rbr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dobavljac;
        private System.Windows.Forms.DataGridViewTextBoxColumn isLoaded;
    }
}