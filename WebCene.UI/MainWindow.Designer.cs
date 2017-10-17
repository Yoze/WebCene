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
            this.btnDodajLink = new System.Windows.Forms.Button();
            this.btnUcitajHTML = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDodajLink
            // 
            this.btnDodajLink.Location = new System.Drawing.Point(39, 28);
            this.btnDodajLink.Name = "btnDodajLink";
            this.btnDodajLink.Size = new System.Drawing.Size(165, 44);
            this.btnDodajLink.TabIndex = 0;
            this.btnDodajLink.Text = "Dodaj link";
            this.btnDodajLink.UseVisualStyleBackColor = true;
            // 
            // btnUcitajHTML
            // 
            this.btnUcitajHTML.Location = new System.Drawing.Point(52, 118);
            this.btnUcitajHTML.Name = "btnUcitajHTML";
            this.btnUcitajHTML.Size = new System.Drawing.Size(133, 38);
            this.btnUcitajHTML.TabIndex = 1;
            this.btnUcitajHTML.Text = "Učitaj HTML";
            this.btnUcitajHTML.UseVisualStyleBackColor = true;
            this.btnUcitajHTML.Click += new System.EventHandler(this.btnUcitajHTML_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(56, 291);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(50, 20);
            this.lblResult.TabIndex = 2;
            this.lblResult.Text = "label1";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 605);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnUcitajHTML);
            this.Controls.Add(this.btnDodajLink);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Web Cene";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDodajLink;
        private System.Windows.Forms.Button btnUcitajHTML;
        private System.Windows.Forms.Label lblResult;
    }
}

