﻿namespace WebCene.UI
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnNoviProdavac = new System.Windows.Forms.Button();
            this.dgvListaProdavaca = new System.Windows.Forms.DataGridView();
            this.contextMenuProdavci = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.izmeniContextMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.obrisiContextMenu = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaProdavaca)).BeginInit();
            this.contextMenuProdavci.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lista prodavaca";
            // 
            // btnNoviProdavac
            // 
            this.btnNoviProdavac.Location = new System.Drawing.Point(12, 418);
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
            this.dgvListaProdavaca.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaProdavaca.ContextMenuStrip = this.contextMenuProdavci;
            this.dgvListaProdavaca.Location = new System.Drawing.Point(12, 54);
            this.dgvListaProdavaca.MultiSelect = false;
            this.dgvListaProdavaca.Name = "dgvListaProdavaca";
            this.dgvListaProdavaca.ReadOnly = true;
            this.dgvListaProdavaca.RowHeadersVisible = false;
            this.dgvListaProdavaca.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaProdavaca.Size = new System.Drawing.Size(634, 336);
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
            // frmProdavciLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 476);
            this.Controls.Add(this.dgvListaProdavaca);
            this.Controls.Add(this.btnNoviProdavac);
            this.Controls.Add(this.label1);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNoviProdavac;
        private System.Windows.Forms.DataGridView dgvListaProdavaca;
        private System.Windows.Forms.ContextMenuStrip contextMenuProdavci;
        private System.Windows.Forms.ToolStripMenuItem izmeniContextMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem obrisiContextMenu;
    }
}