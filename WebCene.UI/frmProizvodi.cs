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

            if (_proizvod != null)
            {
                odabraniProizvod = _proizvod;
                MapirajModelNaKontrole();
            }
            else
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

        private void MapirajKontroleNaModel()
        {
            odabraniProizvod.Id = Convert.ToInt32(txtId.Text);
            odabraniProizvod.ElSifraProizvoda = txtSifraArtikla.Text;
            odabraniProizvod.ElEAN = txtEAN.Text;
            odabraniProizvod.Naziv = txtNazivProizvoda.Text;
            odabraniProizvod.ElKat = txtKatProizvoda.Text;
            odabraniProizvod.Brend = txtBrend.Text;
            odabraniProizvod.Dobavljac = txtDobavljac.Text;
            odabraniProizvod.ShopmaniaURL = txtShopmaniaURL.Text;

        }




    }
}
