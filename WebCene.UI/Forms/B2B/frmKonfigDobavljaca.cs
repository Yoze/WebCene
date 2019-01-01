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
    public partial class frmKonfigDobavljaca : Form
    {
        private KonfigDobavljaca KonfigDobavljacaProp { get; set; }
        private List<KonfigDobavljaca> SveKonfiguracijeDobavljaca { get; set; }
        private string NazivOdabranogDobavljaca { get; set; }
        private int IdOdabraneMarze { get; set; }
        

        public frmKonfigDobavljaca()
        {
            InitializeComponent();

            LoadAndDisplayListOfKonfigDobavljaca();
        }


        public frmKonfigDobavljaca(KonfigDobavljaca _konfigDobavljaca)
        {
            InitializeComponent();

            if (_konfigDobavljaca != null)
            {
                KonfigDobavljacaProp = _konfigDobavljaca;
                MapPropsToControls();
            }
            else KonfigDobavljacaProp = null;
        }



        private void MapPropsToControls()
        {
            lblNaziv.Text = KonfigDobavljacaProp.Naziv;
            txtCenovnikFilename.Text = KonfigDobavljacaProp.CenovnikFilename;
            txtLagerFilename.Text = KonfigDobavljacaProp.LagerFilename;
            txtUrl.Text = KonfigDobavljacaProp.URL;
            txtWebProtokol.Text = KonfigDobavljacaProp.WebProtokol;
            //txtStopaPdvProc.Text = KonfigDobavljacaProp.StopaPDVProc.ToString("F2");
            txtStopaPdvProc.Text = frmMainB2B.ParametriPDVa.Item1;
            txtKursEvra.Text = KonfigDobavljacaProp.KursEvra.ToString("F2");
            txtRabatProc.Text = KonfigDobavljacaProp.RabatProc.ToString("F2");
            checkIsManualno.Checked = KonfigDobavljacaProp.Manualno;

        }


        private void MapControlsToProps()
        {
            KonfigDobavljacaProp.Naziv = lblNaziv.Text;
            KonfigDobavljacaProp.CenovnikFilename = txtCenovnikFilename.Text;
            KonfigDobavljacaProp.LagerFilename = txtLagerFilename.Text;
            KonfigDobavljacaProp.URL = txtUrl.Text;
            KonfigDobavljacaProp.WebProtokol = txtWebProtokol.Text;
            //KonfigDobavljacaProp.StopaPDVProc = Convert.ToDecimal(txtStopaPdvProc.Text);
            KonfigDobavljacaProp.KursEvra = Convert.ToDouble(txtKursEvra.Text);
            KonfigDobavljacaProp.RabatProc = Convert.ToDouble(txtRabatProc.Text);
            KonfigDobavljacaProp.Manualno = checkIsManualno.Checked;
        }


        private void LoadAndDisplayListOfKonfigDobavljaca()
        {
            /** Učitavanje liste dobavljača i prikaz u list view kontroli - levo*/

            // konfiguracija
            lvDobavljaci.View = View.Details;
            lvDobavljaci.FullRowSelect = true;
            //lvDobavljaci.GridLines = true;
            lvDobavljaci.Sorting = SortOrder.Ascending;
            lvDobavljaci.LabelEdit = false;
            lvDobavljaci.AllowColumnReorder = false;


            SveKonfiguracijeDobavljaca = DBHelper.Instance.GetAllSupplierConfigurations();

            if (SveKonfiguracijeDobavljaca != null)
            {
                foreach (var konfigItem in SveKonfiguracijeDobavljaca)
                {
                    ListViewItem lvItem = new ListViewItem(konfigItem.Naziv);
                    lvDobavljaci.Items.Add(lvItem);
                }
            }
        }


        private void btnOdustani_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSnimi_Click(object sender, EventArgs e)
        {
            // snimanje izmena u konfigu dobavljača
            MapControlsToProps();

            if (DBHelper.Instance.SaveSupplierConfigs(KonfigDobavljacaProp))
            {
                MessageBox.Show("Snimljeno.");
                return;
            }
            MessageBox.Show("Greška.");
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


        private void lvDobavljaci_ItemActivate(object sender, EventArgs e)
        {
            // promena selektovanog dobavljača u list view dobavljači
            if (lvDobavljaci.SelectedItems.Count == 1)
            {
                NazivOdabranogDobavljaca = lvDobavljaci.SelectedItems[0].Text;

                LoadKonfigDobavljacaForSelectedItem(NazivOdabranogDobavljaca);
                DisplaySupplierMargins();
            }
        }


        private void lvDobavljaci_SelectedIndexChanged(object sender, EventArgs e)
        {
            // promena selektovanog dobavljača u list view dobavljači
            if (lvDobavljaci.SelectedItems.Count == 1)
            {
                NazivOdabranogDobavljaca = lvDobavljaci.SelectedItems[0].Text;

                LoadKonfigDobavljacaForSelectedItem(NazivOdabranogDobavljaca);
                DisplaySupplierMargins();
            }
        }


        private void LoadKonfigDobavljacaForSelectedItem(string nazivDobavljaca)
        {
            // učitavanje konfiguracije dobavljača i liste marži nakon promene selektovanog dobavljača u list view dobavljači
            lblNaziv.Text = NazivOdabranogDobavljaca;

            KonfigDobavljacaProp = DBHelper.Instance.GetSingleSupplierConfigurationByName(nazivDobavljaca);
            MapPropsToControls();
        }


        /** MARŽE */
        private void DisplaySupplierMargins()
        {
            // konfiguracija
            lvMarzeDobavljaca.View = View.Details;
            lvMarzeDobavljaca.FullRowSelect = true;
            //lvMarzeDobavljaca.GridLines = true;
            lvMarzeDobavljaca.Sorting = SortOrder.Ascending;
            lvMarzeDobavljaca.LabelEdit = false;
            lvMarzeDobavljaca.AllowColumnReorder = false;

            // ispis podataka o maržama u list view
            lvMarzeDobavljaca.Items.Clear();

            List<MarzeDobavljaca> marzeDobavljaca = new List<MarzeDobavljaca>();
            marzeDobavljaca = DBHelper.Instance.GetSupplierMarginsBySupplierName(NazivOdabranogDobavljaca);

            if (marzeDobavljaca != null && marzeDobavljaca.Count > 0)
            {
                foreach (MarzeDobavljaca item in marzeDobavljaca)
                {
                    string[] lvItemRow =
                        {                            
                            item.NncDonjiLimit.ToString(),
                            item.NncGornjiLimit.ToString(),
                            item.MarzaProc.ToString(),
                            item.RabatProc.ToString(),
                            item.Id.ToString()
                        };

                    ListViewItem lvMarzeItem = new ListViewItem(lvItemRow);

                    lvMarzeDobavljaca.Items.Add(lvMarzeItem);
                }

                // set Id column to invisible
                lvMarzeDobavljaca.Columns[4].Width = 0;
            }
        }

        
        private void btnDodajMarzu_Click(object sender, EventArgs e)
        {

            frmMarzeRabatiDobavljaca frmMarza = new frmMarzeRabatiDobavljaca(KonfigDobavljacaProp);
            frmMarza.ShowDialog();

            DisplaySupplierMargins();
        }


        private void btnIzmeniMarzu_Click(object sender, EventArgs e)
        {
            if (IdOdabraneMarze == 0) return;

            frmMarzeRabatiDobavljaca frmMarza = new frmMarzeRabatiDobavljaca(KonfigDobavljacaProp, IdOdabraneMarze);
            frmMarza.ShowDialog();

            DisplaySupplierMargins();

        }


        private void btniObrisiMarzu_Click(object sender, EventArgs e)
        {
            if (IdOdabraneMarze == 0) return;

            MarzeDobavljaca marzaDobavljaca = DBHelper.Instance.GetSingleSupplierMarginByMarginId(IdOdabraneMarze);

            if (DBHelper.Instance.DeleteSupplierMargin(marzaDobavljaca))
            {
                MessageBox.Show("Obrisano.");
                DisplaySupplierMargins();
                return;
            }
            MessageBox.Show("Greška.");
        }


        private void lvMarzeDobavljaca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvMarzeDobavljaca.SelectedItems.Count == 1)
            {
                IdOdabraneMarze = Convert.ToInt32(lvMarzeDobavljaca.SelectedItems[0].SubItems[4].Text); // Id odabrane marže se nalazi u 3. koloni
            }
        }


        private void lvMarzeDobavljaca_ItemActivate(object sender, EventArgs e)
        {
            if (lvMarzeDobavljaca.SelectedItems.Count == 1)
            {
                IdOdabraneMarze = Convert.ToInt32(lvMarzeDobavljaca.SelectedItems[0].SubItems[4].Text); // Id odabrane marže se nalazi u 3. koloni
            }
        }

        private void checkIsManualno_CheckedChanged(object sender, EventArgs e)
        {
            if (checkIsManualno.Checked)
            {
                txtKursEvra.Enabled = false;
                //txtStopaPdvProc.Enabled = false;
                lblManuelnoDescription.Visible = true;
            }
            else
            {
                txtKursEvra.Enabled = true;
                //txtStopaPdvProc.Enabled = true;
                lblManuelnoDescription.Visible = false;
            }
        }
    }
}
