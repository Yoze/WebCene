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
    public partial class frmProizvodi : Form
    {
        public Proizvod odabraniProizvod { get; set; }


        public frmProizvodi(Proizvod _proizvod)
        {
            InitializeComponent();

            // sprečava implicitnu validaciju kada kontrola izgubi fokus
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;

            if (_proizvod != null)
            {
                odabraniProizvod = _proizvod;
                MapirajModelNaKontrole();
            }
            if (_proizvod == null)
            {
                odabraniProizvod = new Proizvod();
            }
        }


        private void MapirajModelNaKontrole()
        {

            if (odabraniProizvod != null)
            {
                txtId.Text = odabraniProizvod.Id.ToString();
                txtSifraArtikla.Text = odabraniProizvod.ElSifraProizvoda;
                txtEAN.Text = odabraniProizvod.ElEAN;
                txtNazivProizvoda.Text = odabraniProizvod.Naziv;
                txtKatProizvoda.Text = odabraniProizvod.ElKat;
                txtBrend.Text = odabraniProizvod.Brend;
                txtDobavljac.Text = odabraniProizvod.Dobavljac;
                txtShopmaniaURL.Text = odabraniProizvod.ShopmaniaURL;
            }

        }

        private Proizvod MapirajKontroleNaModel(Proizvod _proizvod)
        {
            if (_proizvod != null)
            {
                _proizvod.Id = _proizvod.Id;
                _proizvod.ElSifraProizvoda = txtSifraArtikla.Text;
                _proizvod.ElEAN = txtEAN.Text;
                _proizvod.Naziv = txtNazivProizvoda.Text;
                _proizvod.ElKat = txtKatProizvoda.Text;
                _proizvod.Brend = txtBrend.Text;
                _proizvod.Dobavljac = txtDobavljac.Text;
                _proizvod.ShopmaniaURL = txtShopmaniaURL.Text;

                return _proizvod;
            }

            return null;
        }


        private void SnimiProizvod()
        {
            // Novi proizvod
            if (odabraniProizvod.Id == 0)
            {
                using (WebCeneModel db = new WebCeneModel())
                {
                    odabraniProizvod = MapirajKontroleNaModel(odabraniProizvod);

                    try
                    {
                        db.Proizvod.Add(odabraniProizvod);
                        db.SaveChanges();                        
                        
                        MessageBox.Show("Proizvod je snimljen u bazu.", "Snimanje podataka");
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

            // Postojeći proizvod
            if (odabraniProizvod.Id > 0)
            {
                // 1.korak
                using (WebCeneModel db = new WebCeneModel())
                {
                    odabraniProizvod = db.Proizvod
                        .Where(x => x.Id == odabraniProizvod.Id)
                        .SingleOrDefault();
                }

                //2.korak
                if (odabraniProizvod != null)
                {
                    odabraniProizvod = MapirajKontroleNaModel(odabraniProizvod);
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
                        db.Entry(odabraniProizvod).State =
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
            // postojeći proizvod
            if (odabraniProizvod.Id > 0)
            {
                Proizvod _proizvod = frmProizvodiLista.ListaProizvoda
                            .Find(x => x.Id == odabraniProizvod.Id);

                _proizvod.Id = odabraniProizvod.Id;
                _proizvod.ElSifraProizvoda = odabraniProizvod.ElSifraProizvoda;
                _proizvod.ElEAN = odabraniProizvod.ElEAN;
                _proizvod.Naziv = odabraniProizvod.Naziv;
                _proizvod.ElKat = odabraniProizvod.ElKat;
                _proizvod.Brend = odabraniProizvod.Brend;
                _proizvod.Dobavljac = odabraniProizvod.Dobavljac;
                _proizvod.ShopmaniaURL = odabraniProizvod.ShopmaniaURL;
            }
        }

        private void btnSnimi_Click(object sender, EventArgs e)
        {
           
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                SnimiProizvod();
                Close();
            }
            else
            {
                MessageBox.Show("Morate popuniti obeležena polja.", "Greška kod unosa");
            }
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

        private void txtSifraArtikla_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;

            if (!(string.IsNullOrWhiteSpace(txtSifraArtikla.Text)))
            {
                // prolazi validaciju
                cancel = false;
            }
            else
            {
                // ne prolazi validaciju
                cancel = true;
                errProviderProizvodi.SetError(txtSifraArtikla, "Obavezan podatak.");
            }
            e.Cancel = cancel;
        }

        private void txtSifraArtikla_Validated(object sender, EventArgs e)
        {
            errProviderProizvodi.SetError(txtSifraArtikla, string.Empty);
        }

        private void txtNazivProizvoda_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;

            if (!(string.IsNullOrWhiteSpace(txtNazivProizvoda.Text)))
            {
                // prolazi validaciju
                cancel = false;
            }
            else
            {
                // ne prolazi validaciju
                cancel = true;
                errProviderProizvodi.SetError(txtNazivProizvoda, "Obavezan podatak.");
            }
            e.Cancel = cancel;
        }

        private void txtNazivProizvoda_Validated(object sender, EventArgs e)
        {
            errProviderProizvodi.SetError(txtNazivProizvoda, string.Empty);
        }

        private void txtShopmaniaURL_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;

            if (!(string.IsNullOrWhiteSpace(txtShopmaniaURL.Text)))
            {
                // prolazi validaciju
                cancel = false;
            }
            else
            {
                // ne prolazi validaciju
                cancel = true;
                errProviderProizvodi.SetError(txtShopmaniaURL, "Obavezan podatak.");
            }
            e.Cancel = cancel;
        }

        private void txtShopmaniaURL_Validated(object sender, EventArgs e)
        {
            errProviderProizvodi.SetError(txtShopmaniaURL, string.Empty);
        }
    }
}
