namespace WebCene.UI
{
    partial class frmMainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.programToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.izlazToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prooizvodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noviProizvodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaProizvodaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prodavacToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noviProdavacToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaProdavacaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.krolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noviKrolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripGrouped = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripCrosstab = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programToolStripMenuItem,
            this.prooizvodToolStripMenuItem,
            this.prodavacToolStripMenuItem,
            this.krolToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1105, 25);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // programToolStripMenuItem
            // 
            this.programToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.izlazToolStripMenuItem});
            this.programToolStripMenuItem.Name = "programToolStripMenuItem";
            this.programToolStripMenuItem.Size = new System.Drawing.Size(71, 21);
            this.programToolStripMenuItem.Text = "Program";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(98, 6);
            // 
            // izlazToolStripMenuItem
            // 
            this.izlazToolStripMenuItem.Name = "izlazToolStripMenuItem";
            this.izlazToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.izlazToolStripMenuItem.Text = "Izlaz";
            this.izlazToolStripMenuItem.Click += new System.EventHandler(this.izlazToolStripMenuItem_Click);
            // 
            // prooizvodToolStripMenuItem
            // 
            this.prooizvodToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noviProizvodToolStripMenuItem,
            this.listaProizvodaToolStripMenuItem});
            this.prooizvodToolStripMenuItem.Name = "prooizvodToolStripMenuItem";
            this.prooizvodToolStripMenuItem.Size = new System.Drawing.Size(52, 21);
            this.prooizvodToolStripMenuItem.Text = "Artikli";
            // 
            // noviProizvodToolStripMenuItem
            // 
            this.noviProizvodToolStripMenuItem.Name = "noviProizvodToolStripMenuItem";
            this.noviProizvodToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.noviProizvodToolStripMenuItem.Text = "Novi artikal";
            this.noviProizvodToolStripMenuItem.Click += new System.EventHandler(this.noviProizvodToolStripMenuItem_Click);
            // 
            // listaProizvodaToolStripMenuItem
            // 
            this.listaProizvodaToolStripMenuItem.Name = "listaProizvodaToolStripMenuItem";
            this.listaProizvodaToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.listaProizvodaToolStripMenuItem.Text = "Lista artikala";
            this.listaProizvodaToolStripMenuItem.Click += new System.EventHandler(this.listaProizvodaToolStripMenuItem_Click);
            // 
            // prodavacToolStripMenuItem
            // 
            this.prodavacToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noviProdavacToolStripMenuItem,
            this.listaProdavacaToolStripMenuItem});
            this.prodavacToolStripMenuItem.Name = "prodavacToolStripMenuItem";
            this.prodavacToolStripMenuItem.Size = new System.Drawing.Size(74, 21);
            this.prodavacToolStripMenuItem.Text = "Prodavac";
            // 
            // noviProdavacToolStripMenuItem
            // 
            this.noviProdavacToolStripMenuItem.Name = "noviProdavacToolStripMenuItem";
            this.noviProdavacToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.noviProdavacToolStripMenuItem.Text = "Novi prodavac";
            this.noviProdavacToolStripMenuItem.Click += new System.EventHandler(this.noviProdavacToolStripMenuItem_Click);
            // 
            // listaProdavacaToolStripMenuItem
            // 
            this.listaProdavacaToolStripMenuItem.Name = "listaProdavacaToolStripMenuItem";
            this.listaProdavacaToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.listaProdavacaToolStripMenuItem.Text = "Lista prodavaca";
            this.listaProdavacaToolStripMenuItem.Click += new System.EventHandler(this.listaProdavacaToolStripMenuItem_Click);
            // 
            // krolToolStripMenuItem
            // 
            this.krolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noviKrolToolStripMenuItem,
            this.toolStripSeparator2,
            this.toolStripCrosstab,
            this.toolStripGrouped});
            this.krolToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.krolToolStripMenuItem.Name = "krolToolStripMenuItem";
            this.krolToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.krolToolStripMenuItem.Text = "Krol";
            // 
            // noviKrolToolStripMenuItem
            // 
            this.noviKrolToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.noviKrolToolStripMenuItem.Name = "noviKrolToolStripMenuItem";
            this.noviKrolToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.noviKrolToolStripMenuItem.Text = "Novi krol";
            this.noviKrolToolStripMenuItem.Click += new System.EventHandler(this.noviKrolToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(159, 6);
            // 
            // toolStripGrouped
            // 
            this.toolStripGrouped.Name = "toolStripGrouped";
            this.toolStripGrouped.Size = new System.Drawing.Size(162, 22);
            this.toolStripGrouped.Text = "Grupisana lista";
            this.toolStripGrouped.Click += new System.EventHandler(this.toolStripGrouped_Click);
            // 
            // toolStripCrosstab
            // 
            this.toolStripCrosstab.Name = "toolStripCrosstab";
            this.toolStripCrosstab.Size = new System.Drawing.Size(162, 22);
            this.toolStripCrosstab.Text = "Crosstab lista";
            this.toolStripCrosstab.Click += new System.EventHandler(this.toolStripCrosstab_Click);
            // 
            // frmMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 604);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Web Crawler";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMainWindow_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem programToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem izlazToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prooizvodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noviProizvodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaProizvodaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prodavacToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noviProdavacToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaProdavacaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem krolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noviKrolToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripGrouped;
        private System.Windows.Forms.ToolStripMenuItem toolStripCrosstab;
    }
}

