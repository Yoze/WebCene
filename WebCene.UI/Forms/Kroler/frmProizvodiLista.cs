using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebCene.Model.Kroler;
using System.Data.SqlClient;

namespace WebCene.UI.Forms.Kroler
{
    public partial class frmProizvodiLista : Form
    {

        Proizvod odabraniProizvod { get; set; }
        private int indeksOdabranogProizvoda { get; set; }


        public static List<Proizvod> ListaProizvoda { get; set; }
        private BindingSource dataGridBindingSource { get; set; }

        public frmProizvodiLista()
        {
            InitializeComponent();

            UcitajListuProizvoda();
            PrikaziListuProizvoda();
        }

        private void btnNoviProizvod_Click(object sender, EventArgs e)
        {
            // forma za novi proizvod
            frmProizvodi noviProizvod = new frmProizvodi(null);
            noviProizvod.ShowDialog();

            UcitajListuProizvoda();
            dgvListaProizvoda.Refresh();

        }


        public void UcitajListuProizvoda()
        {
            using (KrolerContext db = new KrolerContext())
            {
                ListaProizvoda = db.Proizvod.ToList();

                if (ListaProizvoda != null)
                {
                    // Binding list
                    var bindingListaProizvodaView = new BindingList<Proizvod>(ListaProizvoda);
                    dataGridBindingSource = new BindingSource(bindingListaProizvodaView, null);

                    // Data source
                    dgvListaProizvoda.DataSource = dataGridBindingSource;
                }
            }

        }


        public void PrikaziListuProizvoda()
        {
            // DGV Props
            dgvListaProizvoda.Columns["Id"].Visible = false;

            dgvListaProizvoda.Columns["ElSifraProizvoda"].Visible = true;
            dgvListaProizvoda.Columns["ElSifraProizvoda"].HeaderText = "Šifra";

            dgvListaProizvoda.Columns["ElEAN"].Visible = true;
            dgvListaProizvoda.Columns["ElEAN"].HeaderText = "Barkod";

            dgvListaProizvoda.Columns["Naziv"].Visible = true;
            dgvListaProizvoda.Columns["Naziv"].HeaderText = "Naziv";
            dgvListaProizvoda.Columns["Naziv"].Width = 200;

            dgvListaProizvoda.Columns["ElKat"].Visible = false;
            dgvListaProizvoda.Columns["ElKat"].HeaderText = "Kategorija";

            dgvListaProizvoda.Columns["Brend"].Visible = true;
            dgvListaProizvoda.Columns["Brend"].HeaderText = "Brend";

            dgvListaProizvoda.Columns["Dobavljac"].Visible = true;
            dgvListaProizvoda.Columns["Dobavljac"].HeaderText = "Dobavljač";

            dgvListaProizvoda.Columns["ePonudaURL"].Visible = true;
            dgvListaProizvoda.Columns["ePonudaURL"].HeaderText = "URL ePonuda";
            dgvListaProizvoda.Columns["ePonudaURL"].Width = 800;

            dgvListaProizvoda.Columns["KrolStavke"].Visible = false;
            dgvListaProizvoda.Columns["KrolStavke"].HeaderText = "Stavke krola";

        }


        private void IzmeniProizvod()
        {
            bool proizvodPostoji = PronadjiProizvod();

            if (proizvodPostoji == true)
            {
                PronadjiProizvod();
                frmProizvodi izmeniProizvod = new frmProizvodi(odabraniProizvod);

                izmeniProizvod.ShowDialog();
                UcitajListuProizvoda();
            }
        }


        private bool PronadjiProizvod()
        {
            // pretraga baze za proizvodom na osnovu selekcije u dgv
            // rezultat se smešta u prop odabraniProizvod
            // funkcija vraća true ako je proizvod pronađen

            if (dgvListaProizvoda.CurrentRow == null)
            {
                MessageBox.Show("Odaberi stavku");
                return false;
            }
            else
            {
                // odabrani red
                Proizvod odabraniRed = (Proizvod)dgvListaProizvoda.CurrentRow.DataBoundItem;

                // indeks odabranog zapisa
                indeksOdabranogProizvoda = dgvListaProizvoda.CurrentCell.RowIndex;

                // id odabranog zapisa
                int idOdabranogProizvoda = odabraniRed.Id;

                using (KrolerContext db = new KrolerContext())
                {
                    Proizvod _odabraniProizvod = new Proizvod();

                    try
                    {
                        _odabraniProizvod = db.Proizvod
                        .Where(x => x.Id == idOdabranogProizvoda)
                        .FirstOrDefault();

                        if (_odabraniProizvod != null)
                        {
                            odabraniProizvod = _odabraniProizvod;
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Proizvod ne postoji u bazi"); ;
                            return false;
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Došlo je do greške!", "Greška");
                        return false;
                    }
                }
            }
        }


        private void ObrisiProizvod()
        {
            PronadjiProizvod();

            using (KrolerContext db = new KrolerContext())
            {
                if (odabraniProizvod != null)
                {
                    DialogResult dr =
                        MessageBox.Show("Proizvod će biti obrisan!\r\nDa li želite da nastavite?", "Brisanje proizvoda",
                        MessageBoxButtons.YesNo);

                    if (dr == DialogResult.Yes)
                    {
                        try
                        {
                            // brisanje iz baze
                            db.Entry(odabraniProizvod).State = System.Data.Entity.EntityState.Deleted;
                            db.SaveChanges();

                            // brisanje iz dgv
                            dgvListaProizvoda.Rows.RemoveAt(this.dgvListaProizvoda.SelectedRows[0].Index);
                            
                            // osvežavanje dgv
                            UcitajListuProizvoda();

                            //MessageBox.Show("Proizvod je obrisan.", "Brisanje proizvoda");
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Greška u brisanju!", "Brisanje podataka");
                            return;
                        }
                    }
                    if (dr == DialogResult.No)
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Podatak ne postoji u bazi.", "Greška");
                }
            }
        }


        private void contextEdit_Click(object sender, EventArgs e)
        {
            IzmeniProizvod();
        }

        private void contextDelete_Click(object sender, EventArgs e)
        {
            ObrisiProizvod();
        }

        private void Enter_NextControl(object sender, KeyEventArgs e)
        {

            /* prelazak na iduću kontrolu pomoću <enter> i close sa <esc> */


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
