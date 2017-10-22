using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebCene.Model;
using System.Data.SqlClient;

namespace WebCene.UI
{
    public partial class frmProizvodiLista : Form
    {
        Proizvod odabraniProizvod { get; set; }

        public List<Proizvod> ListaProizvoda { get; set; }

        private int indeksOdabranogProizvoda { get; set; }

        public frmProizvodiLista()
        {
            InitializeComponent();

            UcitajListuProizvoda();

        }

        private void btnNoviProizvod_Click(object sender, EventArgs e)
        {
            frmProizvodi noviProizvod = new frmProizvodi(null);
            noviProizvod.ShowDialog();

        }


        public void UcitajListuProizvoda()
        {
            using (WebCeneModel db = new WebCeneModel())
            {
                ListaProizvoda = db.Proizvod.ToList();                
            }
           
        }


        public void PrikaziListuProizvoda()
        {
           // UcitajListuProizvoda();

            if (ListaProizvoda != null)
            {
                var bindingListaProizvodaView = new BindingList<Proizvod>(this.ListaProizvoda);
                var dataGridSource = new BindingSource(bindingListaProizvodaView, null);

                dgvListaProizvoda.DataSource = dataGridSource;

                dgvListaProizvoda.Columns["Id"].Visible = false;

                dgvListaProizvoda.Columns["ElSifraProizvoda"].Visible = true;
                dgvListaProizvoda.Columns["ElEAN"].Visible = true;
                dgvListaProizvoda.Columns["Naziv"].Visible = true;
                dgvListaProizvoda.Columns["ElKat"].Visible = true;
                dgvListaProizvoda.Columns["Brend"].Visible = true;
                dgvListaProizvoda.Columns["Dobavljac"].Visible = true;
                dgvListaProizvoda.Columns["ShopmaniaURL"].Visible = true;
                dgvListaProizvoda.Columns["KrolStavke"].Visible = false;              

            }
        }


        private void IzmeniProizvod()
        {
            bool proizvodPostoji = PronadjiProizvod();
           
            if (proizvodPostoji == true)
            {
                frmProizvodi izmeniProizvod = new frmProizvodi(odabraniProizvod);
                izmeniProizvod.ShowDialog();
            }

            
        }




        private bool PronadjiProizvod()
        {
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
                
                using (WebCeneModel db = new WebCeneModel())
                {
                    Proizvod _odabraniProizvod = new Proizvod();

                    _odabraniProizvod = db.Proizvod
                        .Where(x => x.Id == idOdabranogProizvoda)
                        .First();

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
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //UcitajListuProizvoda();
            PrikaziListuProizvoda();
        }

        private void contextEdit_Click(object sender, EventArgs e)
        {
            IzmeniProizvod();
        }
    }
}
