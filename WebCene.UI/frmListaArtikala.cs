using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebCene.Model;

namespace WebCene.UI
{
    public partial class frmListaArtikala : Form
    {
     
        private DataTable dataTableArtikli { get; set; }
        private DataView dataViewArtikli { get; set; }
        private Proizvod odabraniArtikal { get; set; }

        public static string sifraOdabranogArtiklaString { get; set; }


        public frmListaArtikala()
        {
            InitializeComponent();
                
            // dataset tabela sa artiklima       
            dataTableArtikli = UcitajArtikle();

            PrikaziListuArtikala();


        }


        private DataTable UcitajArtikle()
        {
            string connString = ConfigurationManager.ConnectionStrings["ELBS_2018ADOConn"].ConnectionString;

            using (SqlConnection connELBS_2018  = new SqlConnection(connString))
            {
                try
                {                  
                    SqlDataAdapter da =
                       new SqlDataAdapter("SELECT barcode, artikal, naziv, proizvodjac, shkat FROM [099 pravi]", connELBS_2018);

                    DataSet ds = new DataSet();
                    da.Fill(ds, "Artikli");
                    DataTable dt = ds.Tables["Artikli"];

                    return dt;
                }
                catch (Exception)
                {
                    MessageBox.Show("Greška u konekciji sa ELBS MSSQL serverom", "Greška");
                    return null;                    
                }
            }
        }
        


        private void PrikaziListuArtikala()
        {
            dataViewArtikli = new DataView(dataTableArtikli);
            dgvArtikli.DataSource = dataViewArtikli;

            // DGV Props
            dgvArtikli.Columns["BARCODE"].Visible = true;
            dgvArtikli.Columns["BARCODE"].HeaderText = "Barkod";
            dgvArtikli.Columns["BARCODE"].Width = 120;

            dgvArtikli.Columns["ARTIKAL"].Visible = true;
            dgvArtikli.Columns["ARTIKAL"].HeaderText = "Artikal";
            dgvArtikli.Columns["ARTIKAL"].Width = 70;

            dgvArtikli.Columns["NAZIV"].Visible = true;
            dgvArtikli.Columns["NAZIV"].HeaderText = "Naziv";
            dgvArtikli.Columns["NAZIV"].Width = 200;

            dgvArtikli.Columns["PROIZVODJAC"].Visible = true;
            dgvArtikli.Columns["PROIZVODJAC"].HeaderText = "Proizvođač";
            dgvArtikli.Columns["PROIZVODJAC"].Width = 200;

            dgvArtikli.Columns["SHKAT"].Visible = false;

        }


        private void txtNadjiArtikal_TextChanged(object sender, EventArgs e)
        {
            lblPoruka.Visible = false;

            // filter prikaza
            string filter = string.Format("naziv LIKE '%{0}%'", txtNadjiArtikal.Text);
            dataViewArtikli.RowFilter = filter;

            if (dataViewArtikli.Count < 1)
            {
                lblPoruka.Visible = true;
                return;
            }

            dgvArtikli.DataSource = dataViewArtikli;
        }

        private void ValidacijaUnosaDozvoljenihKaraktera(object sender, KeyPressEventArgs e)
        {
            // dozvoljava samo unos brojeva i tačke i backspace
            // ascii codes
            // 46 .
            // 44 ,
            // 8 backspace

            TextBox _sender = (TextBox)sender;

            char ch = e.KeyChar;

            if (!char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && ch != 8)
            {
                e.Handled = true;
                return;
            }
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

        private void dgvArtikli_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            int odabraniArtikli = dgvArtikli.SelectedRows.Count;

            if (odabraniArtikli > 0)
            {
                for (int i = 0; i < odabraniArtikli; i++)
                {
                    DataGridViewRow odabraniRed = (DataGridViewRow)dgvArtikli.SelectedRows[i];

                    sifraOdabranogArtiklaString = Convert.ToString(odabraniRed.Cells["ARTIKAL"].Value);
              
                    Close();
                }
            }
        }



                
    }
}
