using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebCene.Model.B2B;

namespace WebCene.UI.Forms.B2B
{
    public partial class frmKonfigDobavljaca : Form
    {
        private KonfigDobavljaca KonfigDobavljaca { get; set; }


        public frmKonfigDobavljaca(KonfigDobavljaca konfigDobavljaca)
        {
            InitializeComponent();

            if (konfigDobavljaca != null)
            {
                KonfigDobavljaca = konfigDobavljaca;
                lblNaziv.Text = konfigDobavljaca.Naziv;
            }            
        }



        private void btnOdustani_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
