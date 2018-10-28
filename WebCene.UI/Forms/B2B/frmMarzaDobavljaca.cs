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
using WebCene.Helper;
using WebCene.Model.Kroler;

namespace WebCene.UI.Forms.B2B
{
    public partial class frmMarzaDobavljaca : Form
    {
        private int IdOdabraneMarze { get; set; }
        MarzeDobavljaca MarzaDobavljacaProp { get; set; }
        KonfigDobavljaca KonfigDobavljacaProp { get; set; }


        public frmMarzaDobavljaca(KonfigDobavljaca konfigDobavljaca)
        {
            InitializeComponent();

            KonfigDobavljacaProp = konfigDobavljaca;
            MarzaDobavljacaProp = null;
        }


        public frmMarzaDobavljaca(KonfigDobavljaca konfigDobavljaca, int idOdabraneMarze)
        {
            InitializeComponent();

            IdOdabraneMarze = idOdabraneMarze;

            KonfigDobavljacaProp = konfigDobavljaca;

            MarzaDobavljacaProp = new MarzeDobavljaca();
            MarzaDobavljacaProp = DBHelper.Instance.GetSingleSupplierMarginByMarginId(idOdabraneMarze);

            MapPropsToControls();
        }


        private void MapPropsToControls()
        {
            txtNncDonji.Text = MarzaDobavljacaProp.NncDonjiLimit.ToString();
            txtNncGornji.Text = MarzaDobavljacaProp.NncGornjiLimit.ToString();
            txtMarzaProc.Text = MarzaDobavljacaProp.MarzaProc.ToString("F2");
        }


        private void MapControlsToProps()
        {
            MarzaDobavljacaProp.NncDonjiLimit = Convert.ToInt32(txtNncDonji.Text);
            MarzaDobavljacaProp.NncGornjiLimit = Convert.ToInt32(txtNncGornji.Text);
            MarzaDobavljacaProp.MarzaProc = Convert.ToDecimal(txtMarzaProc.Text);

            // IdDobavljaca foreign key
            //MarzaDobavljacaProp.KonfigDobavljaca = KonfigDobavljacaProp;
            MarzaDobavljacaProp.IdDobavljaca = KonfigDobavljacaProp.Id;
        }




        public void ValidateDecimalInput(object sender, KeyPressEventArgs e)
        {
            // dozvoljava samo unos brojeva i tačke i backspace
            // ascii codes
            // 46 .
            // 44 ,
            // 8 backspace

            TextBox _sender = (TextBox)sender;

            char ch = e.KeyChar;

            if (ch == 44 && _sender.Text.IndexOf(',') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 44)
            {
                e.Handled = true;
            }
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSnimiMarzu_Click(object sender, EventArgs e)
        {
            if (MarzaDobavljacaProp == null)
            {
                MarzaDobavljacaProp = new MarzeDobavljaca();
                MapControlsToProps();

                if (DBHelper.Instance.CreateSupplierMargin(MarzaDobavljacaProp))
                {
                    MessageBox.Show("Dodato u bazu.");
                    Close();
                }
                else
                {
                    MessageBox.Show("Greška.");
                }
            }
            else
            {
                MapControlsToProps();

                if (DBHelper.Instance.SaveSupplierMargin(MarzaDobavljacaProp))
                {
                    MessageBox.Show("Snimljeno.");
                    Close();
                }
                else
                {
                    MessageBox.Show("Greška.");
                }
            }            
        }





    }
}
