﻿namespace WebCene.UI.Forms.Kroler
{
    partial class frmProizvodiLista
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvListaProizvoda = new System.Windows.Forms.DataGridView();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.contextDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNoviProizvod = new System.Windows.Forms.Button();
            this.proizvodBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaProizvoda)).BeginInit();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.proizvodBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 40);
            this.label1.TabIndex = 3;
            this.label1.Text = "LISTA ARTIKALA";
            // 
            // dgvListaProizvoda
            // 
            this.dgvListaProizvoda.AllowUserToAddRows = false;
            this.dgvListaProizvoda.AllowUserToResizeRows = false;
            this.dgvListaProizvoda.BackgroundColor = System.Drawing.Color.MintCream;
            this.dgvListaProizvoda.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvListaProizvoda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaProizvoda.ContextMenuStrip = this.contextMenu;
            this.dgvListaProizvoda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListaProizvoda.Location = new System.Drawing.Point(20, 100);
            this.dgvListaProizvoda.Margin = new System.Windows.Forms.Padding(20);
            this.dgvListaProizvoda.MultiSelect = false;
            this.dgvListaProizvoda.Name = "dgvListaProizvoda";
            this.dgvListaProizvoda.ReadOnly = true;
            this.dgvListaProizvoda.RowHeadersVisible = false;
            this.dgvListaProizvoda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaProizvoda.ShowCellToolTips = false;
            this.dgvListaProizvoda.ShowEditingIcon = false;
            this.dgvListaProizvoda.Size = new System.Drawing.Size(1018, 483);
            this.dgvListaProizvoda.TabIndex = 4;
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextEdit,
            this.toolStripSeparator1,
            this.contextDelete});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(110, 54);
            // 
            // contextEdit
            // 
            this.contextEdit.Name = "contextEdit";
            this.contextEdit.Size = new System.Drawing.Size(109, 22);
            this.contextEdit.Text = "Izmeni";
            this.contextEdit.Click += new System.EventHandler(this.contextEdit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(106, 6);
            // 
            // contextDelete
            // 
            this.contextDelete.ForeColor = System.Drawing.Color.Red;
            this.contextDelete.Name = "contextDelete";
            this.contextDelete.Size = new System.Drawing.Size(109, 22);
            this.contextDelete.Text = "Obriši";
            this.contextDelete.Click += new System.EventHandler(this.contextDelete_Click);
            // 
            // btnNoviProizvod
            // 
            this.btnNoviProizvod.Location = new System.Drawing.Point(10, 613);
            this.btnNoviProizvod.Margin = new System.Windows.Forms.Padding(10);
            this.btnNoviProizvod.Name = "btnNoviProizvod";
            this.btnNoviProizvod.Size = new System.Drawing.Size(121, 37);
            this.btnNoviProizvod.TabIndex = 5;
            this.btnNoviProizvod.Text = "Novi artikal";
            this.btnNoviProizvod.UseVisualStyleBackColor = true;
            this.btnNoviProizvod.Click += new System.EventHandler(this.btnNoviProizvod_Click);
            // 
            // proizvodBindingSource
            // 
            this.proizvodBindingSource.DataSource = typeof(WebCene.Model.Kroler.Proizvod);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.dgvListaProizvoda, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnNoviProizvod, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1058, 683);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // frmProizvodiLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 683);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmProizvodiLista";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Artikli";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_NextControl);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaProizvoda)).EndInit();
            this.contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.proizvodBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvListaProizvoda;
        private System.Windows.Forms.Button btnNoviProizvod;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem contextEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem contextDelete;
        private System.Windows.Forms.BindingSource proizvodBindingSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}