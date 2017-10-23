using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using WebCene.Model;

namespace WebCene.UI
{
    public partial class frmStartKrol : Form
    {
        private static System.Timers.Timer krolTimer;

        public List<Proizvod> ListaProizvodaKrol { get; set; }
        public List<Prodavci> ListaProdavacaKrol { get; set; }

        private List<int> IdProizvodaZaKrol { get; set; }
        private List<int> IdProdavacaZaKrol { get; set; }


        public frmStartKrol()
        {
            InitializeComponent();

            PuniListuProdavaca();
            PrikaziListuProdavaca();

            PuniListuProizvoda();
            PrikaziListuProizvoda();

        }

        private void btnStartKrol_Click(object sender, EventArgs e)
        {

            //StartTimer();

            KreirajListeZaKrol();






        }

        private void KreirajListeZaKrol()
        {
            // proizvodi za krol
            if (listBoxProizvodi.SelectedItems.Count > 0)
            {
                if (listBoxProdavci.SelectedItems.Count > 0)
                {
                    KreirajListuProdavacaZaKrol();
                }
                if (listBoxProdavci.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Označi prodavce za krol!", "Selekcija");
                    return;
                }
                KreirajListuProizvodaZaKrol();
            }
            if (listBoxProizvodi.SelectedItems.Count == 0)
            {
                MessageBox.Show("Označi proizvode za krol!", "Selekcija");
                return;
            }

            //// prodavci za krol
            //if (listBoxProdavci.SelectedItems.Count > 0)
            //{
            //    KreirajListuProdavacaZaKrol();
            //}
            //if (listBoxProdavci.SelectedItems.Count == 0)
            //{
            //    MessageBox.Show("Označi prodavce za krol!", "Selekcija");
            //    return;
            //}
        }


        private void KreirajListuProizvodaZaKrol()
        {
            // Proizvodi
            IdProizvodaZaKrol = new List<int>();

            foreach (var item in listBoxProizvodi.SelectedItems)
            {
                Proizvod oznaceniProizvod = (Proizvod)item;
                IdProizvodaZaKrol.Add(oznaceniProizvod.Id);
            }
        }


        private void KreirajListuProdavacaZaKrol()
        {
            // Prodavci
            IdProdavacaZaKrol = new List<int>();

            foreach (var item in listBoxProdavci.SelectedItems)
            {
                Prodavci oznaceniProdavac = (Prodavci)item;
                IdProdavacaZaKrol.Add(oznaceniProdavac.Id);
            }
        }


        private void PuniListuProdavaca()
        {
            using (WebCeneModel db = new WebCeneModel())
            {
                ListaProdavacaKrol = db.Prodavci.ToList();
            }
        }


        private void PuniListuProizvoda()
        {
            using (WebCeneModel db = new WebCeneModel())
            {
                ListaProizvodaKrol = db.Proizvod.ToList();
            }
        }

        private void PrikaziListuProdavaca()
        {
            listBoxProdavci.DataSource = ListaProdavacaKrol;
            listBoxProdavci.DisplayMember = "NazivProdavca";
            listBoxProdavci.ValueMember = "Id";
        }

        private void PrikaziListuProizvoda()
        {
            listBoxProizvodi.DataSource = ListaProizvodaKrol;
            listBoxProizvodi.DisplayMember = "Naziv";
            listBoxProizvodi.ValueMember = "Id";
        }


        private void IzvrsiKrol(object source, ElapsedEventArgs e)
        {
            krolTimer.Interval = GetRandomTimerInterval();
            System.Timers.Timer _timer = (System.Timers.Timer)source;
            int interval = Convert.ToInt32(_timer.Interval);
            Console.WriteLine("interval: {0}", interval.ToString());
        }



        private void btnStopKrol_Click(object sender, EventArgs e)
        {
            StopTimer();
        }















        #region TIMER
        /* T I M E R */
        private void StartTimer()
        {
            krolTimer = new System.Timers.Timer();

            krolTimer.Elapsed += new ElapsedEventHandler(IzvrsiKrol);
            krolTimer.AutoReset = false;
            krolTimer.Enabled = true;

        }

        private void StopTimer()
        {
            // zaustavlja izvršavanje timera
            try
            {
                krolTimer.Close();
                MessageBox.Show("Timer stopped and disposed");
            }
            catch (Exception)
            {
                MessageBox.Show("Timer is not initialized.");
            }
        }

        private static int GetRandomTimerInterval()
        {

            Random rnd = new Random();
            int _rnd = rnd.Next(1000, 3500); // miliseconds           

            return _rnd;
        }
        #endregion


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
