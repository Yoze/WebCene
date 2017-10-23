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

namespace WebCene.UI
{
    public partial class frmProdavci : Form
    {
        public Prodavci odabraniProdavac { get; set; }


        public frmProdavci(Prodavci _prodavac)
        {
            InitializeComponent();

            if (_prodavac != null)
            {
                odabraniProdavac = _prodavac;
                MapirajModelNaKontrole();
            }
            if (_prodavac == null)
            {
                odabraniProdavac = new Prodavci();
            }
        }

        #region MAPIRANJE
        private void MapirajModelNaKontrole()
        {
            if (odabraniProdavac != null)
            {
                txtId.Text = odabraniProdavac.Id.ToString();
                txtNazivProdavca.Text = odabraniProdavac.NazivProdavca;
                txtSajt.Text = odabraniProdavac.SajtProdavca;
                txtSMId.Text = odabraniProdavac.SMId;
            }
        }

        private Prodavci MapirajKontroleNaModel(Prodavci _prodavac)
        {
            if (_prodavac != null)
            {
                _prodavac.Id = _prodavac.Id;
                _prodavac.NazivProdavca = txtNazivProdavca.Text;
                _prodavac.SajtProdavca = txtSajt.Text;
                _prodavac.SMId = txtSMId.Text;

                return _prodavac;
            }
            return null;
        }
        #endregion

        private void SnimiProdavca()
        {
            // Novi prodavac
            if (odabraniProdavac.Id == 0)
            {
                using (WebCeneModel db = new WebCeneModel())
                {
                    odabraniProdavac = MapirajKontroleNaModel(odabraniProdavac);

                    try
                    {
                        db.Prodavci.Add(odabraniProdavac);
                        db.SaveChanges();

                        //frmProizvodiLista frmListaProizvoda = new frmProizvodiLista();


                        MessageBox.Show("Prodavac je snimljen u bazu.", "Snimanje podataka");
                        Close();
                        return;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Greška u snimanju!", "Greška");
                        return;
                    }
                }
            }

            // Postojeći prodavac
            if (odabraniProdavac.Id > 0)
            {
                // 1.korak
                using (WebCeneModel db = new WebCeneModel())
                {
                    odabraniProdavac = db.Prodavci
                        .Where(x => x.Id == odabraniProdavac.Id)
                        .SingleOrDefault();
                }

                //2.korak
                if (odabraniProdavac != null)
                {
                    odabraniProdavac = MapirajKontroleNaModel(odabraniProdavac);
                }
                else
                {
                    MessageBox.Show("Proizvod ne postoji u bazi", "Greška");
                    return;
                }

                //3.korak
                using (WebCeneModel db = new WebCeneModel())
                {
                    try
                    {
                        // update baze
                        db.Entry(odabraniProdavac).State =
                            System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        // update liste proizvoda, podiže INotifyPropertyChanged 
                        AzurirajListuProizvoda();

                        MessageBox.Show("Izmene su snimljene", "Snimanje podataka");
                        Close();
                        return;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Greška u snimanju!", "Greška");
                        return;
                    }
                }
            }
        }

        private void AzurirajListuProizvoda()
        {
            // postojeći prodavac
            if (odabraniProdavac.Id > 0)
            {
                Prodavci _prodavac = frmProdavciLista.ListaProdavaca
                    .Find(p => p.Id == odabraniProdavac.Id);

                _prodavac.Id = odabraniProdavac.Id;
                _prodavac.NazivProdavca = odabraniProdavac.NazivProdavca;
                _prodavac.SajtProdavca = odabraniProdavac.SajtProdavca;
                _prodavac.SMId = odabraniProdavac.SMId;
            }
        }

        private void btnSnimi_Click(object sender, EventArgs e)
        {
            SnimiProdavca();
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
