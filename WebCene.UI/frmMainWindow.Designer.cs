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
            this.prethodniKroloviToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programToolStripMenuItem,
            this.prooizvodToolStripMenuItem,
            this.prodavacToolStripMenuItem,
            this.krolToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1105, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // programToolStripMenuItem
            // 
            this.programToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.izlazToolStripMenuItem});
            this.programToolStripMenuItem.Name = "programToolStripMenuItem";
            this.programToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.programToolStripMenuItem.Text = "Program";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(93, 6);
            // 
            // izlazToolStripMenuItem
            // 
            this.izlazToolStripMenuItem.Name = "izlazToolStripMenuItem";
            this.izlazToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.izlazToolStripMenuItem.Text = "Izlaz";
            this.izlazToolStripMenuItem.Click += new System.EventHandler(this.izlazToolStripMenuItem_Click);
            // 
            // prooizvodToolStripMenuItem
            // 
            this.prooizvodToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noviProizvodToolStripMenuItem,
            this.listaProizvodaToolStripMenuItem});
            this.prooizvodToolStripMenuItem.Name = "prooizvodToolStripMenuItem";
            this.prooizvodToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.prooizvodToolStripMenuItem.Text = "Proizvod";
            // 
            // noviProizvodToolStripMenuItem
            // 
            this.noviProizvodToolStripMenuItem.Name = "noviProizvodToolStripMenuItem";
            this.noviProizvodToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.noviProizvodToolStripMenuItem.Text = "Novi proizvod";
            this.noviProizvodToolStripMenuItem.Click += new System.EventHandler(this.noviProizvodToolStripMenuItem_Click);
            // 
            // listaProizvodaToolStripMenuItem
            // 
            this.listaProizvodaToolStripMenuItem.Name = "listaProizvodaToolStripMenuItem";
            this.listaProizvodaToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.listaProizvodaToolStripMenuItem.Text = "Lista proizvoda";
            this.listaProizvodaToolStripMenuItem.Click += new System.EventHandler(this.listaProizvodaToolStripMenuItem_Click);
            // 
            // prodavacToolStripMenuItem
            // 
            this.prodavacToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noviProdavacToolStripMenuItem,
            this.listaProdavacaToolStripMenuItem});
            this.prodavacToolStripMenuItem.Name = "prodavacToolStripMenuItem";
            this.prodavacToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.prodavacToolStripMenuItem.Text = "Prodavac";
            // 
            // noviProdavacToolStripMenuItem
            // 
            this.noviProdavacToolStripMenuItem.Name = "noviProdavacToolStripMenuItem";
            this.noviProdavacToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.noviProdavacToolStripMenuItem.Text = "Novi prodavac";
            this.noviProdavacToolStripMenuItem.Click += new System.EventHandler(this.noviProdavacToolStripMenuItem_Click);
            // 
            // listaProdavacaToolStripMenuItem
            // 
            this.listaProdavacaToolStripMenuItem.Name = "listaProdavacaToolStripMenuItem";
            this.listaProdavacaToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.listaProdavacaToolStripMenuItem.Text = "Lista prodavaca";
            this.listaProdavacaToolStripMenuItem.Click += new System.EventHandler(this.listaProdavacaToolStripMenuItem_Click);
            // 
            // krolToolStripMenuItem
            // 
            this.krolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noviKrolToolStripMenuItem,
            this.prethodniKroloviToolStripMenuItem});
            this.krolToolStripMenuItem.Name = "krolToolStripMenuItem";
            this.krolToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.krolToolStripMenuItem.Text = "Krol";
            // 
            // noviKrolToolStripMenuItem
            // 
            this.noviKrolToolStripMenuItem.Name = "noviKrolToolStripMenuItem";
            this.noviKrolToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.noviKrolToolStripMenuItem.Text = "Novi krol";
            this.noviKrolToolStripMenuItem.Click += new System.EventHandler(this.noviKrolToolStripMenuItem_Click);
            // 
            // prethodniKroloviToolStripMenuItem
            // 
            this.prethodniKroloviToolStripMenuItem.Name = "prethodniKroloviToolStripMenuItem";
            this.prethodniKroloviToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.prethodniKroloviToolStripMenuItem.Text = "Lista krolova";
            this.prethodniKroloviToolStripMenuItem.Click += new System.EventHandler(this.prethodniKroloviToolStripMenuItem_Click);
            // 
            // frmMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 605);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
        private System.Windows.Forms.ToolStripMenuItem prethodniKroloviToolStripMenuItem;
    }
}

