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
                MapPropsToControls(KonfigDobavljaca);
            }            
        }


        private void MapPropsToControls(KonfigDobavljaca konfigDobavljaca)
        {
            lblNaziv.Text = konfigDobavljaca.Naziv;
            txtCenovnikFilename.Text = konfigDobavljaca.CenovnikFilename;
            txtLagerFilename.Text = konfigDobavljaca.LagerFilename;
            txtUrl.Text = konfigDobavljaca.URL;
            txtWebProtokol.Text = konfigDobavljaca.WebProtokol;
            txtkoeficijentMarze.Text = konfigDobavljaca.KeoficijentMarze.ToString("F2");
            txtKursEvra.Text = konfigDobavljaca.KursEvra.ToString("F2");
        }


        private void MapControlsToProps()
        {

        }



        private void btnOdustani_Click(object sender, EventArgs e)
        {
            Close();
        }

      
    }
}
