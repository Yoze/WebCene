namespace WebCene.UI.Forms.B2B
{
    partial class tempPwd
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
            this.txtPwd = new System.Windows.Forms.MaskedTextBox();
            this.lblPoruka = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPwd
            // 
            this.txtPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPwd.Location = new System.Drawing.Point(75, 72);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '-';
            this.txtPwd.PromptChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(162, 29);
            this.txtPwd.TabIndex = 1;
            this.txtPwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPwd.TextChanged += new System.EventHandler(this.txtPwd_TextChanged);
            // 
            // lblPoruka
            // 
            this.lblPoruka.AutoSize = true;
            this.lblPoruka.BackColor = System.Drawing.Color.Red;
            this.lblPoruka.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblPoruka.Location = new System.Drawing.Point(89, 132);
            this.lblPoruka.Margin = new System.Windows.Forms.Padding(5);
            this.lblPoruka.Name = "lblPoruka";
            this.lblPoruka.Padding = new System.Windows.Forms.Padding(5);
            this.lblPoruka.Size = new System.Drawing.Size(135, 31);
            this.lblPoruka.TabIndex = 2;
            this.lblPoruka.Text = "Pokušaj ponovo!";
            this.lblPoruka.Visible = false;
            // 
            // tempPwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 194);
            this.Controls.Add(this.lblPoruka);
            this.Controls.Add(this.txtPwd);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "tempPwd";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lozinka";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_NextControl);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox txtPwd;
        private System.Windows.Forms.Label lblPoruka;
    }
}