namespace WebCene.UI
{
    partial class frmProizvodi
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
            this.txtSifraArtikla = new System.Windows.Forms.TextBox();
            this.proizvodBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtEAN = new System.Windows.Forms.TextBox();
            this.txtNazivProizvoda = new System.Windows.Forms.TextBox();
            this.txtKatProizvoda = new System.Windows.Forms.TextBox();
            this.txtBrend = new System.Windows.Forms.TextBox();
            this.txtDobavljac = new System.Windows.Forms.TextBox();
            this.txtEPonudaURL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtKatIspisNaziva = new System.Windows.Forms.TextBox();
            this.btnArtikli = new System.Windows.Forms.Button();
            this.btnSnimi = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.errProviderProizvodi = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.proizvodBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderProizvodi)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSifraArtikla
            // 
            this.txtSifraArtikla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSifraArtikla.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.proizvodBindingSource, "ElSifraProizvoda", true));
            this.txtSifraArtikla.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSifraArtikla.ForeColor = System.Drawing.Color.Black;
            this.txtSifraArtikla.Location = new System.Drawing.Point(125, 58);
            this.txtSifraArtikla.MaxLength = 8;
            this.txtSifraArtikla.Name = "txtSifraArtikla";
            this.txtSifraArtikla.ReadOnly = true;
            this.txtSifraArtikla.Size = new System.Drawing.Size(133, 25);
            this.txtSifraArtikla.TabIndex = 1;
            this.txtSifraArtikla.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_NextControl);
            this.txtSifraArtikla.Validating += new System.ComponentModel.CancelEventHandler(this.txtSifraArtikla_Validating);
            this.txtSifraArtikla.Validated += new System.EventHandler(this.txtSifraArtikla_Validated);
            // 
            // proizvodBindingSource
            // 
            this.proizvodBindingSource.DataSource = typeof(WebCene.Model.Proizvod);
            // 
            // txtEAN
            // 
            this.txtEAN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEAN.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.proizvodBindingSource, "ElEAN", true));
            this.txtEAN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEAN.ForeColor = System.Drawing.Color.Black;
            this.txtEAN.Location = new System.Drawing.Point(125, 89);
            this.txtEAN.MaxLength = 20;
            this.txtEAN.Name = "txtEAN";
            this.txtEAN.ReadOnly = true;
            this.txtEAN.Size = new System.Drawing.Size(133, 25);
            this.txtEAN.TabIndex = 2;
            // 
            // txtNazivProizvoda
            // 
            this.txtNazivProizvoda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNazivProizvoda.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.proizvodBindingSource, "Naziv", true));
            this.txtNazivProizvoda.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNazivProizvoda.ForeColor = System.Drawing.Color.Black;
            this.txtNazivProizvoda.Location = new System.Drawing.Point(125, 120);
            this.txtNazivProizvoda.MaxLength = 40;
            this.txtNazivProizvoda.Name = "txtNazivProizvoda";
            this.txtNazivProizvoda.ReadOnly = true;
            this.txtNazivProizvoda.Size = new System.Drawing.Size(243, 25);
            this.txtNazivProizvoda.TabIndex = 3;
            this.txtNazivProizvoda.Validating += new System.ComponentModel.CancelEventHandler(this.txtNazivProizvoda_Validating);
            this.txtNazivProizvoda.Validated += new System.EventHandler(this.txtNazivProizvoda_Validated);
            // 
            // txtKatProizvoda
            // 
            this.txtKatProizvoda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKatProizvoda.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.proizvodBindingSource, "ElKat", true));
            this.txtKatProizvoda.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKatProizvoda.ForeColor = System.Drawing.Color.Black;
            this.txtKatProizvoda.Location = new System.Drawing.Point(388, 151);
            this.txtKatProizvoda.MaxLength = 20;
            this.txtKatProizvoda.Name = "txtKatProizvoda";
            this.txtKatProizvoda.ReadOnly = true;
            this.txtKatProizvoda.Size = new System.Drawing.Size(63, 25);
            this.txtKatProizvoda.TabIndex = 4;
            this.txtKatProizvoda.Visible = false;
            // 
            // txtBrend
            // 
            this.txtBrend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBrend.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.proizvodBindingSource, "Brend", true));
            this.txtBrend.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBrend.ForeColor = System.Drawing.Color.Black;
            this.txtBrend.Location = new System.Drawing.Point(125, 182);
            this.txtBrend.MaxLength = 50;
            this.txtBrend.Name = "txtBrend";
            this.txtBrend.ReadOnly = true;
            this.txtBrend.Size = new System.Drawing.Size(243, 25);
            this.txtBrend.TabIndex = 5;
            // 
            // txtDobavljac
            // 
            this.txtDobavljac.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDobavljac.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.proizvodBindingSource, "Dobavljac", true));
            this.txtDobavljac.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDobavljac.ForeColor = System.Drawing.Color.Black;
            this.txtDobavljac.Location = new System.Drawing.Point(125, 213);
            this.txtDobavljac.MaxLength = 50;
            this.txtDobavljac.Name = "txtDobavljac";
            this.txtDobavljac.ReadOnly = true;
            this.txtDobavljac.Size = new System.Drawing.Size(243, 25);
            this.txtDobavljac.TabIndex = 6;
            // 
            // txtEPonudaURL
            // 
            this.txtEPonudaURL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEPonudaURL.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.proizvodBindingSource, "ePonudaURL", true));
            this.txtEPonudaURL.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEPonudaURL.ForeColor = System.Drawing.Color.Black;
            this.txtEPonudaURL.Location = new System.Drawing.Point(125, 244);
            this.txtEPonudaURL.MaxLength = 250;
            this.txtEPonudaURL.Multiline = true;
            this.txtEPonudaURL.Name = "txtEPonudaURL";
            this.txtEPonudaURL.Size = new System.Drawing.Size(423, 70);
            this.txtEPonudaURL.TabIndex = 7;
            this.txtEPonudaURL.Validating += new System.ComponentModel.CancelEventHandler(this.txtShopmaniaURL_Validating);
            this.txtEPonudaURL.Validated += new System.EventHandler(this.txtShopmaniaURL_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(19, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Šifra";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(19, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Barkod";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(19, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Naziv";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(19, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Kategorija";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(19, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Brend";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(19, 216);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "Dobavljač";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(19, 247);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "ePonuda URL";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtKatIspisNaziva);
            this.groupBox1.Controls.Add(this.btnArtikli);
            this.groupBox1.Controls.Add(this.txtSifraArtikla);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtEPonudaURL);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtEAN);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtDobavljac);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtNazivProizvoda);
            this.groupBox1.Controls.Add(this.txtBrend);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtKatProizvoda);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(20, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(573, 349);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "NOVI ARTIKAL ZA KROL";
            // 
            // txtKatIspisNaziva
            // 
            this.txtKatIspisNaziva.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKatIspisNaziva.Location = new System.Drawing.Point(125, 151);
            this.txtKatIspisNaziva.Name = "txtKatIspisNaziva";
            this.txtKatIspisNaziva.ReadOnly = true;
            this.txtKatIspisNaziva.Size = new System.Drawing.Size(243, 25);
            this.txtKatIspisNaziva.TabIndex = 16;
            // 
            // btnArtikli
            // 
            this.btnArtikli.BackColor = System.Drawing.Color.Gainsboro;
            this.btnArtikli.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnArtikli.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnArtikli.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArtikli.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArtikli.ForeColor = System.Drawing.Color.DimGray;
            this.btnArtikli.Image = global::WebCene.UI.Properties.Resources.google_web_search_26;
            this.btnArtikli.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnArtikli.Location = new System.Drawing.Point(412, 51);
            this.btnArtikli.Name = "btnArtikli";
            this.btnArtikli.Size = new System.Drawing.Size(136, 37);
            this.btnArtikli.TabIndex = 15;
            this.btnArtikli.Text = " Odaberi";
            this.btnArtikli.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnArtikli.UseVisualStyleBackColor = false;
            this.btnArtikli.Click += new System.EventHandler(this.btnArtikli_Click);
            // 
            // btnSnimi
            // 
            this.btnSnimi.Location = new System.Drawing.Point(487, 392);
            this.btnSnimi.Name = "btnSnimi";
            this.btnSnimi.Size = new System.Drawing.Size(121, 37);
            this.btnSnimi.TabIndex = 15;
            this.btnSnimi.Text = "Snimi";
            this.btnSnimi.UseVisualStyleBackColor = true;
            this.btnSnimi.Click += new System.EventHandler(this.btnSnimi_Click);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(240, 393);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(34, 25);
            this.txtId.TabIndex = 15;
            this.txtId.Visible = false;
            // 
            // errProviderProizvodi
            // 
            this.errProviderProizvodi.ContainerControl = this;
            // 
            // frmProizvodi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 441);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnSnimi);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmProizvodi";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Artikal";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_NextControl);
            ((System.ComponentModel.ISupportInitialize)(this.proizvodBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderProizvodi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtSifraArtikla;
        private System.Windows.Forms.TextBox txtEAN;
        private System.Windows.Forms.TextBox txtNazivProizvoda;
        private System.Windows.Forms.TextBox txtKatProizvoda;
        private System.Windows.Forms.TextBox txtBrend;
        private System.Windows.Forms.TextBox txtDobavljac;
        private System.Windows.Forms.TextBox txtEPonudaURL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSnimi;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.BindingSource proizvodBindingSource;
        private System.Windows.Forms.ErrorProvider errProviderProizvodi;
        private System.Windows.Forms.Button btnArtikli;
        private System.Windows.Forms.TextBox txtKatIspisNaziva;
    }
}