using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebCene.Model;

namespace WebCene.UI
{
    public partial class frmListaKrolova : Form
    {
        private WebCeneModel db = null;


        #region PROPERTIES
        private ObservableCollection<KrolGlava> kolekcijaKrolGlava;
        public ObservableCollection<KrolGlava> KolekcijaKrolGlava
        {
            get { return kolekcijaKrolGlava; }
            set
            {
                kolekcijaKrolGlava = value;
                NotifyPropertyChanged();
            }
        }

        KrolGlava odabraniKrol = null;
        public KrolGlava OdabraniKrol
        {
            get { return odabraniKrol; }
            set
            {
                odabraniKrol = value;
                NotifyPropertyChanged();
                if (odabraniKrol != null)
                {
                    UcitajDetaljeKrola(odabraniKrol.Id);
                }
            }
        }




        #endregion

        private void UcitajDetaljeKrola(object _odabraniKrolId)
        {
            int krolGlavaId = int.Parse(_odabraniKrolId.ToString());

            var query = (from detaljiKrola in db.viewKrolStavke
                         where detaljiKrola.Id == krolGlavaId
                         select detaljiKrola).ToList();


        }



















        public frmListaKrolova()
        {
            InitializeComponent();


            db = new WebCeneModel();
            db.Configuration.LazyLoadingEnabled = false;
            db.Configuration.AutoDetectChangesEnabled = false;

            // TO DO: init lists

        }






   



        private void btnOdustani_Click(object sender, EventArgs e)
        {
            Close();
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

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
