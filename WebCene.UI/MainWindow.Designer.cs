namespace WebCene.UI
{
    partial class MainWindow
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
            this.btnProizvodi = new System.Windows.Forms.Button();
            this.btnKrol = new System.Windows.Forms.Button();
            this.btnProdavci = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // btnProizvodi
            // 
            this.btnProizvodi.Location = new System.Drawing.Point(25, 22);
            this.btnProizvodi.Name = "btnProizvodi";
            this.btnProizvodi.Size = new System.Drawing.Size(121, 37);
            this.btnProizvodi.TabIndex = 0;
            this.btnProizvodi.Text = "Proizvodi";
            this.btnProizvodi.UseVisualStyleBackColor = true;
            this.btnProizvodi.Click += new System.EventHandler(this.btnProizvodi_Click);
            // 
            // btnKrol
            // 
            this.btnKrol.Location = new System.Drawing.Point(279, 22);
            this.btnKrol.Name = "btnKrol";
            this.btnKrol.Size = new System.Drawing.Size(121, 37);
            this.btnKrol.TabIndex = 1;
            this.btnKrol.Text = "Start krol";
            this.btnKrol.UseVisualStyleBackColor = true;
            this.btnKrol.Click += new System.EventHandler(this.btnKrol_Click);
            // 
            // btnProdavci
            // 
            this.btnProdavci.Location = new System.Drawing.Point(152, 22);
            this.btnProdavci.Name = "btnProdavci";
            this.btnProdavci.Size = new System.Drawing.Size(121, 37);
            this.btnProdavci.TabIndex = 3;
            this.btnProdavci.Text = "Prodavci";
            this.btnProdavci.UseVisualStyleBackColor = true;
            this.btnProdavci.Click += new System.EventHandler(this.btnProdavci_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(28, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(896, 228);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Krol";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(28, 346);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(895, 218);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detalji krola";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 605);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnProdavci);
            this.Controls.Add(this.btnKrol);
            this.Controls.Add(this.btnProizvodi);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Web Crawler";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProizvodi;
        private System.Windows.Forms.Button btnKrol;
        private System.Windows.Forms.Button btnProdavci;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

