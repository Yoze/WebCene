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
    public partial class frmMarzeRabatiDobavljaca : Form
    {
        private int IdOdabraneMarze { get; set; }
        MarzeDobavljaca MarzaDobavljacaRabatProp { get; set; }
        KonfigDobavljaca KonfigDobavljacaProp { get; set; }


        public frmMarzeRabatiDobavljaca(KonfigDobavljaca konfigDobavljaca)
        {
            /** Dodavanje novog rabata i marže */

            InitializeComponent();

            KonfigDobavljacaProp = konfigDobavljaca;
            MarzaDobavljacaRabatProp = null;
        }


        public frmMarzeRabatiDobavljaca(KonfigDobavljaca konfigDobavljaca, int idOdabraneMarze)
        {
            /** Izmena postojećeg rabata i marže */

            InitializeComponent();

            IdOdabraneMarze = idOdabraneMarze;

            KonfigDobavljacaProp = konfigDobavljaca;

            MarzaDobavljacaRabatProp = new MarzeDobavljaca();
            MarzaDobavljacaRabatProp = DBHelper.Instance.GetSingleSupplierMarginByMarginId(idOdabraneMarze);

            MapPropsToControls();
        }


        private void MapPropsToControls()
        {
            txtNncDonji.Text = MarzaDobavljacaRabatProp.NncDonjiLimit.ToString();
            txtNncGornji.Text = MarzaDobavljacaRabatProp.NncGornjiLimit.ToString();
            txtMarzaProc.Text = MarzaDobavljacaRabatProp.MarzaProc.ToString("F2");
            txtRabatProc.Text = MarzaDobavljacaRabatProp.RabatProc.ToString("F2");
        }


        private void MapControlsToProps()
        {
            MarzaDobavljacaRabatProp.NncDonjiLimit = Convert.ToInt32(txtNncDonji.Text);
            MarzaDobavljacaRabatProp.NncGornjiLimit = Convert.ToInt32(txtNncGornji.Text);
            MarzaDobavljacaRabatProp.MarzaProc = Convert.ToDecimal(txtMarzaProc.Text);
            MarzaDobavljacaRabatProp.RabatProc = Convert.ToDecimal(txtRabatProc.Text);

            // IdDobavljaca foreign key
            //MarzaDobavljacaProp.KonfigDobavljaca = KonfigDobavljacaProp;
            MarzaDobavljacaRabatProp.IdDobavljaca = KonfigDobavljacaProp.Id;
        }


        private void LoadComboBrendovi()
        {
            using (KrolerContext db = new KrolerContext())
            {

            }

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
            if (MarzaDobavljacaRabatProp == null)
            {
                MarzaDobavljacaRabatProp = new MarzeDobavljaca();
                MapControlsToProps();

                if (DBHelper.Instance.CreateSupplierMargin(MarzaDobavljacaRabatProp))
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

                if (DBHelper.Instance.SaveSupplierMargin(MarzaDobavljacaRabatProp))
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
