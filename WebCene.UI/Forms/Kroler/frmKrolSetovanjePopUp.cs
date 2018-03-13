using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebCene.UI.Forms.Kroler
{
    public partial class frmKrolSetovanjePopUp : Form
    {
        public string naslovPodesavanja { get; set; }

        public frmKrolSetovanjePopUp()
        {
            InitializeComponent();

            naslovPodesavanja = string.Empty;

            this.ActiveControl = txtNazivSetovanjaKrola;
        }

        private void NaslovPodesavanja()
        {
            naslovPodesavanja = txtNazivSetovanjaKrola.Text;

            if (string.IsNullOrEmpty(naslovPodesavanja))
            {
                DialogResult dr = MessageBox.Show("Naslov podešavanja nije upisan.\r\nPokušaj ponovo?", "Greška", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                switch (dr)
                {                    
                    case DialogResult.Yes:
                        this.ActiveControl = txtNazivSetovanjaKrola;
                        return;
                    case DialogResult.No:
                        Close();
                        break;
                    default:
                        break;
                }
            }

            this.Close();
        }

        private void btnSnimiSetovanjaKrola_Click(object sender, EventArgs e)
        {
            NaslovPodesavanja();
        }


        private void Enter_NextControl(object sender, KeyEventArgs e)
        {
            Control nextControl;

            if (e.KeyCode == Keys.Enter)
            {
                nextControl = GetNextControl(ActiveControl, !e.Shift);
                if (nextControl == null)
                {
                    nextControl = GetNextControl(null, true);
                }
                nextControl.Focus();
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
