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

namespace WebCene.UI.Forms.B2B
{
    public partial class frmKonfigDobavljaca : Form
    {
        private KonfigDobavljaca KonfigDobavljacaProp { get; set; }
        private List<KonfigDobavljaca> SveKonfiguracijeDobavljaca { get; set; }


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
            txtkoeficijentMarze.Text = KonfigDobavljacaProp.KeoficijentMarze.ToString("F2");
            txtKursEvra.Text = KonfigDobavljacaProp.KursEvra.ToString("F2");

        }


        private void MapControlsToProps()
        {
            KonfigDobavljacaProp.Naziv = lblNaziv.Text;
            KonfigDobavljacaProp.CenovnikFilename = txtCenovnikFilename.Text;
            KonfigDobavljacaProp.LagerFilename = txtLagerFilename.Text;
            KonfigDobavljacaProp.URL = txtUrl.Text;
            KonfigDobavljacaProp.WebProtokol = txtWebProtokol.Text;
            KonfigDobavljacaProp.KeoficijentMarze = Convert.ToDecimal(txtkoeficijentMarze.Text);
            KonfigDobavljacaProp.KursEvra = Convert.ToDecimal(txtKursEvra.Text);
        }

        private void LoadAndDisplayListOfKonfigDobavljaca()
        {
            // set list config
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
            if (lvDobavljaci.SelectedItems.Count == 1)
            {
                LoadKonfigDobavljacaForSelectedItem(lvDobavljaci.SelectedItems[0].Text);
            }
        }


        private void lvDobavljaci_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDobavljaci.SelectedItems.Count == 1)
            {
                LoadKonfigDobavljacaForSelectedItem(lvDobavljaci.SelectedItems[0].Text);
            }
        }


        private void LoadKonfigDobavljacaForSelectedItem(string nazivDobavljaca)
        {

            lblNaziv.Text = nazivDobavljaca;

            KonfigDobavljacaProp = DBHelper.Instance.GetSingleSupplierConfigurationByName(nazivDobavljaca);
            MapPropsToControls();

        }




    }
}
