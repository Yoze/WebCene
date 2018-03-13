namespace WebCene.UI.Forms.Kroler
{
    partial class frmProdavciLista
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNoviProdavac = new System.Windows.Forms.Button();
            this.dgvListaProdavaca = new System.Windows.Forms.DataGridView();
            this.contextMenuProdavci = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.izmeniContextMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.obrisiContextMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaProdavaca)).BeginInit();
            this.contextMenuProdavci.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Fuchsia;
            this.label1.Location = new System.Drawing.Point(6, -6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "LISTA PRODAVACA";
            // 
            // btnNoviProdavac
            // 
            this.btnNoviProdavac.Location = new System.Drawing.Point(12, 497);
            this.btnNoviProdavac.Name = "btnNoviProdavac";
            this.btnNoviProdavac.Size = new System.Drawing.Size(121, 37);
            this.btnNoviProdavac.TabIndex = 18;
            this.btnNoviProdavac.Text = "Novi prodavac";
            this.btnNoviProdavac.UseVisualStyleBackColor = true;
            this.btnNoviProdavac.Click += new System.EventHandler(this.btnNoviProdavac_Click);
            // 
            // dgvListaProdavaca
            // 
            this.dgvListaProdavaca.AllowUserToAddRows = false;
            this.dgvListaProdavaca.AllowUserToResizeRows = false;
            this.dgvListaProdavaca.BackgroundColor = System.Drawing.Color.MintCream;
            this.dgvListaProdavaca.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListaProdavaca.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListaProdavaca.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaProdavaca.ContextMenuStrip = this.contextMenuProdavci;
            this.dgvListaProdavaca.Location = new System.Drawing.Point(13, 45);
            this.dgvListaProdavaca.Margin = new System.Windows.Forms.Padding(10);
            this.dgvListaProdavaca.MultiSelect = false;
            this.dgvListaProdavaca.Name = "dgvListaProdavaca";
            this.dgvListaProdavaca.ReadOnly = true;
            this.dgvListaProdavaca.RowHeadersVisible = false;
            this.dgvListaProdavaca.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaProdavaca.Size = new System.Drawing.Size(634, 371);
            this.dgvListaProdavaca.TabIndex = 19;
            // 
            // contextMenuProdavci
            // 
            this.contextMenuProdavci.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.izmeniContextMenu,
            this.toolStripSeparator1,
            this.obrisiContextMenu});
            this.contextMenuProdavci.Name = "contextMenuProdavci";
            this.contextMenuProdavci.Size = new System.Drawing.Size(110, 54);
            // 
            // izmeniContextMenu
            // 
            this.izmeniContextMenu.Name = "izmeniContextMenu";
            this.izmeniContextMenu.Size = new System.Drawing.Size(109, 22);
            this.izmeniContextMenu.Text = "Izmeni";
            this.izmeniContextMenu.Click += new System.EventHandler(this.izmeniContextMenu_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(106, 6);
            // 
            // obrisiContextMenu
            // 
            this.obrisiContextMenu.ForeColor = System.Drawing.Color.Red;
            this.obrisiContextMenu.Name = "obrisiContextMenu";
            this.obrisiContextMenu.Size = new System.Drawing.Size(109, 22);
            this.obrisiContextMenu.Text = "Obriši";
            this.obrisiContextMenu.Click += new System.EventHandler(this.obrisiContextMenu_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dgvListaProdavaca);
            this.groupBox1.Location = new System.Drawing.Point(23, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(660, 429);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // frmProdavciLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 546);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnNoviProdavac);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmProdavciLista";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prodavci";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_NextControl);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaProdavaca)).EndInit();
            this.contextMenuProdavci.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNoviProdavac;
        private System.Windows.Forms.DataGridView dgvListaProdavaca;
        private System.Windows.Forms.ContextMenuStrip contextMenuProdavci;
        private System.Windows.Forms.ToolStripMenuItem izmeniContextMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem obrisiContextMenu;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}