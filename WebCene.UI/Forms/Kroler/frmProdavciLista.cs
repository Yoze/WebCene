﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebCene.Model.Kroler;

namespace WebCene.UI.Forms.Kroler
{
    public partial class frmProdavciLista : Form
    {
        public Prodavci odabraniProdavac { get; set; }
        private int indeksOdabranogProdavca { get; set; }

        public static List<Prodavci> ListaProdavaca { get; set; }
        private BindingSource bindingSourceListaProdavaca { get; set; }



        public frmProdavciLista()
        {
            InitializeComponent();

            UcitajListuProdavaca();
            PrikaziListuProdavaca();
        }


        private void UcitajListuProdavaca()
        {
            using (KrolerContext db = new KrolerContext())
            {
                ListaProdavaca = db.Prodavci
                    .Where(x => !x.EponudaId.StartsWith("00"))
                    .ToList();

                if (ListaProdavaca != null)
                {
                    // Binding list
                    var bindingListProdavci = new BindingList<Prodavci>(ListaProdavaca);
                    bindingSourceListaProdavaca = new BindingSource(bindingListProdavci, null);

                    // Data source
                    dgvListaProdavaca.DataSource = bindingSourceListaProdavaca;
                }
            }
        }


        private void PrikaziListuProdavaca()
        {
            // dgvProdavci props
            dgvListaProdavaca.Columns["Id"].Visible = false;

            dgvListaProdavaca.Columns["NazivProdavca"].Visible = true;
            dgvListaProdavaca.Columns["NazivProdavca"].HeaderText = "Naziv";
            dgvListaProdavaca.Columns["NazivProdavca"].Width = 250;

            dgvListaProdavaca.Columns["SajtProdavca"].Visible = true;
            dgvListaProdavaca.Columns["SajtProdavca"].HeaderText = "Sajt prodavca";
            dgvListaProdavaca.Columns["SajtProdavca"].Width = 250;

            dgvListaProdavaca.Columns["EponudaId"].Visible = true;
            dgvListaProdavaca.Columns["EponudaId"].HeaderText = "ePonuda Id";
            dgvListaProdavaca.Columns["EponudaId"].Width = 130;

            dgvListaProdavaca.Columns["KrolStavke"].Visible = false;

        }


        private bool PronadjiProdavca()
        {
            // pretraga baze za prodavce na osnovu selekcije u dgv
            // rezultat se smešta u prop odabraniProdavac
            // funkcija vraća true ako je prodavac pronađen

            if (dgvListaProdavaca.CurrentRow == null)
            {
                MessageBox.Show("Odaberi stavku");
                return false;
            }
            else
            {
                // odabrani red
                Prodavci odabraniRed = (Prodavci)dgvListaProdavaca.CurrentRow.DataBoundItem;

                // indeks odabranog zapisa
                indeksOdabranogProdavca = dgvListaProdavaca.CurrentCell.RowIndex;

                // id odabranog zapisa
                int idOdabranogProdavca = odabraniRed.Id;

                using (KrolerContext db = new KrolerContext())
                {
                    Prodavci _odabraniProdavac = new Prodavci();

                    try
                    {
                        _odabraniProdavac = db.Prodavci
                            .Where(p => p.Id == idOdabranogProdavca)
                            .FirstOrDefault();

                        if (_odabraniProdavac != null)
                        {
                            odabraniProdavac = _odabraniProdavac;
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Prodavac ne postoji u bazi"); ;
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

        private void ObrisiProdavca()
        {
            PronadjiProdavca();

            using (KrolerContext db = new KrolerContext())
            {
                if (odabraniProdavac != null)
                {
                    DialogResult dr =
                        MessageBox.Show("Prodavac će biti obrisan iz baze!\r\nDa li želite da nastavite?", "Brisanje prodavca",
                        MessageBoxButtons.YesNo);

                    if (dr == DialogResult.Yes)
                    {
                        try
                        {
                            // brisanje iz baze
                            db.Entry(odabraniProdavac).State = System.Data.Entity.EntityState.Deleted;
                            db.SaveChanges();

                            // brisanje iz dgv
                            dgvListaProdavaca.Rows.RemoveAt(this.dgvListaProdavaca.SelectedRows[0].Index);

                            // osvežavanje dgv
                            UcitajListuProdavaca();

                            MessageBox.Show("Prodavac je obrisan.", "Brisanje prodavca");

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

        private void IzmeniProdavca()
        {
            bool prodavacPostoji = PronadjiProdavca();

            if (prodavacPostoji == true)
            {
                frmProdavci izmeniProdavca = new frmProdavci(odabraniProdavac);
                izmeniProdavca.ShowDialog();
            }
        }


        private void izmeniContextMenu_Click(object sender, EventArgs e)
        {
            IzmeniProdavca();
        }

        private void obrisiContextMenu_Click(object sender, EventArgs e)
        {
            ObrisiProdavca();
        }

        private void btnNoviProdavac_Click(object sender, EventArgs e)
        {
            frmProdavci noviProdavac = new frmProdavci(null);
            noviProdavac.ShowDialog();

            UcitajListuProdavaca();
            PrikaziListuProdavaca();
            
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
