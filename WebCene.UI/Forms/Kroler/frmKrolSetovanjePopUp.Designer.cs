namespace WebCene.UI.Forms.Kroler
{
    partial class frmKrolSetovanjePopUp
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
            this.btnSnimiSetovanjaKrola = new System.Windows.Forms.Button();
            this.txtNazivSetovanjaKrola = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSnimiSetovanjaKrola
            // 
            this.btnSnimiSetovanjaKrola.Location = new System.Drawing.Point(229, 146);
            this.btnSnimiSetovanjaKrola.Name = "btnSnimiSetovanjaKrola";
            this.btnSnimiSetovanjaKrola.Size = new System.Drawing.Size(80, 25);
            this.btnSnimiSetovanjaKrola.TabIndex = 1;
            this.btnSnimiSetovanjaKrola.Text = "Snimi";
            this.btnSnimiSetovanjaKrola.UseVisualStyleBackColor = true;
            this.btnSnimiSetovanjaKrola.Click += new System.EventHandler(this.btnSnimiSetovanjaKrola_Click);
            // 
            // txtNazivSetovanjaKrola
            // 
            this.txtNazivSetovanjaKrola.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNazivSetovanjaKrola.Location = new System.Drawing.Point(27, 73);
            this.txtNazivSetovanjaKrola.MaxLength = 50;
            this.txtNazivSetovanjaKrola.Name = "txtNazivSetovanjaKrola";
            this.txtNazivSetovanjaKrola.Size = new System.Drawing.Size(272, 25);
            this.txtNazivSetovanjaKrola.TabIndex = 0;
            this.txtNazivSetovanjaKrola.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(96, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Naziv podešavanja";
            // 
            // frmKrolSetovanjePopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 183);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNazivSetovanjaKrola);
            this.Controls.Add(this.btnSnimiSetovanjaKrola);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmKrolSetovanjePopUp";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Snimanje podešavanja krola";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_NextControl);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSnimiSetovanjaKrola;
        private System.Windows.Forms.TextBox txtNazivSetovanjaKrola;
        private System.Windows.Forms.Label label2;
    }
}