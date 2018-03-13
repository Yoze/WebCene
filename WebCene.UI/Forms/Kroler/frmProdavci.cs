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

namespace WebCene.UI.Forms.Kroler
{
    public partial class frmProdavci : Form
    {
        public Prodavci odabraniProdavac { get; set; }


        public frmProdavci(Prodavci _prodavac)
        {
            InitializeComponent();

            // isključuje implicitnu validaciju kontrole nakon gubljenja fokusa 
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;

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
                txtEponudaId.Text = odabraniProdavac.EponudaId;
            }
        }

        private Prodavci MapirajKontroleNaModel(Prodavci _prodavac)
        {
            if (_prodavac != null)
            {
                _prodavac.Id = _prodavac.Id;
                _prodavac.NazivProdavca = txtNazivProdavca.Text;
                _prodavac.SajtProdavca = txtSajt.Text;
                _prodavac.EponudaId = txtEponudaId.Text;

                return _prodavac;
            }
            return null;
        }
        #endregion

        private bool ProdavacVecPostoji(Prodavci _odabraniProdavac)
        {
            // provera da li je prodavac postoji u bazi za krol

            using (KrolerContext db = new KrolerContext())
            {
                var prodavac = db.Prodavci
                    .Where(p => p.EponudaId == _odabraniProdavac.EponudaId)
                    .SingleOrDefault();

                if (prodavac != null)
                    return true;
                else
                    return false;
            }
        }



        private void SnimiProdavca()
        {
            // Novi prodavac
            if (odabraniProdavac.Id == 0)
            {
                using (KrolerContext db = new KrolerContext())
                {
                    odabraniProdavac = MapirajKontroleNaModel(odabraniProdavac);

                    bool prodavacPostoji = ProdavacVecPostoji(odabraniProdavac);

                    if (prodavacPostoji)
                    {
                        MessageBox.Show("Prodavac postoji u bazi za krol.",
                            "Postojeći prodavac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    try
                    {
                        db.Prodavci.Add(odabraniProdavac);
                        db.SaveChanges();

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
                using (KrolerContext db = new KrolerContext())
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
                using (KrolerContext db = new KrolerContext())
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
                _prodavac.EponudaId = odabraniProdavac.EponudaId;
            }
        }

        private void btnSnimi_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                SnimiProdavca();
                Close();
            }
            else
            {
                MessageBox.Show("Morate popuniti obeležena polja.", "Greška pri unosu");
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

        private void txtNazivProdavca_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;

            if (!string.IsNullOrWhiteSpace(txtNazivProdavca.Text))
            {
                // prolazi validaciju
                cancel = false;
            }
            else
            {
                // ne prolazi validaciju
                cancel = true;
                errorProviderProdavci.SetError(txtNazivProdavca, "Obavezan podatak.");
            }
            e.Cancel = cancel;
        }

        private void txtNazivProdavca_Validated(object sender, EventArgs e)
        {
            errorProviderProdavci.SetError(txtNazivProdavca, string.Empty);
        }

        private void txtSMId_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;

            if (!string.IsNullOrWhiteSpace(txtEponudaId.Text))
            {
                // prolazi validaciju
                cancel = false;
            }
            else
            {
                // ne prolazi validaciju
                cancel = true;
                errorProviderProdavci.SetError(txtEponudaId, "Obavezan podatak.");
            }
            e.Cancel = cancel;
        }

        private void txtSMId_Validated(object sender, EventArgs e)
        {
            errorProviderProdavci.SetError(txtEponudaId, string.Empty);
        }
    }
}
