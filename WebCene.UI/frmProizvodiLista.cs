﻿using System;
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

        }


        private void UcitajListuProizvoda()
        {
            using (WebCeneModel db = new WebCeneModel())
            {
                ListaProizvoda = db.Proizvod.ToList();
            }

        }


        public void PrikaziListuProizvoda()
        {
            if (ListaProizvoda != null)
            {
                // Binding list
                var bindingListaProizvodaView = new BindingList<Proizvod>(ListaProizvoda);
                dataGridBindingSource = new BindingSource(bindingListaProizvodaView, null);

                // Data source
                dgvListaProizvoda.DataSource = dataGridBindingSource;
                //dgvListaProizvoda.DataSource = bindingListaProizvodaView;

                // DGV Props
                dgvListaProizvoda.Columns["Id"].Visible = false;

                dgvListaProizvoda.Columns["ElSifraProizvoda"].Visible = true;
                dgvListaProizvoda.Columns["ElSifraProizvoda"].HeaderText = "Šifra";

                dgvListaProizvoda.Columns["ElEAN"].Visible = true;
                dgvListaProizvoda.Columns["ElEAN"].HeaderText = "Barkod";

                dgvListaProizvoda.Columns["Naziv"].Visible = true;
                dgvListaProizvoda.Columns["Naziv"].HeaderText = "Naziv";
                dgvListaProizvoda.Columns["Naziv"].Width = 200;

                dgvListaProizvoda.Columns["ElKat"].Visible = true;
                dgvListaProizvoda.Columns["ElKat"].HeaderText = "Kategorija";

                dgvListaProizvoda.Columns["Brend"].Visible = true;
                dgvListaProizvoda.Columns["Brend"].HeaderText = "Brend";

                dgvListaProizvoda.Columns["Dobavljac"].Visible = true;
                dgvListaProizvoda.Columns["Dobavljac"].HeaderText = "Dobavljač";

                dgvListaProizvoda.Columns["ShopmaniaURL"].Visible = true;
                dgvListaProizvoda.Columns["ShopmaniaURL"].HeaderText = "URL Sm";
                dgvListaProizvoda.Columns["ShopmaniaURL"].Width = 800;

                dgvListaProizvoda.Columns["KrolStavke"].Visible = false;
                dgvListaProizvoda.Columns["KrolStavke"].HeaderText = "Stavke krola";
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

                using (WebCeneModel db = new WebCeneModel())
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

            using (WebCeneModel db = new WebCeneModel())
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

                            // ažuriranje liste, podiže INotifyPropertyChanged interfejs
                            //ListaProizvoda.Remove(odabraniProizvod);
                            dataGridBindingSource.Remove(odabraniProizvod);
                            

                            MessageBox.Show("Proizvod je obrisan.", "Brisanje proizvoda");
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

        private void button1_Click(object sender, EventArgs e)
        {
            //UcitajListuProizvoda();
            //PrikaziListuProizvoda();
        }

        private void contextEdit_Click(object sender, EventArgs e)
        {
            IzmeniProizvod();
        }

        private void contextDelete_Click(object sender, EventArgs e)
        {
            ObrisiProizvod();
        }
    }
}