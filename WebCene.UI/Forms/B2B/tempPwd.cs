using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebCene.UI.Forms.B2B
{
    public partial class tempPwd : Form
    {
        public DialogResult dialogResult { get; set; }

        public tempPwd()
        {
            InitializeComponent();

            txtPwd.Focus();
        }


        private bool openMain()
        {
            lblPoruka.Visible = false;

            if (txtPwd.Text == "1305")
            {                
                return true;
            }
            else
            {
                lblPoruka.Visible = true;
                return false;
            }
        }


        private void Enter_NextControl(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (openMain())
                {
                    dialogResult = DialogResult.OK;
                    Close();
                }
            }

            if (e.KeyCode == Keys.Escape)
            {
                dialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void txtPwd_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtPwd.Text)) lblPoruka.Visible = false;
        }


    }
}
