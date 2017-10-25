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
using HtmlAgilityPack;
using WebCene.UI.Kroleri;

namespace WebCene.UI
{
    public partial class frmStartKrol : Form
    {
        //private static System.Timers.Timer krolTimer;

        // liste za ispis u listbox-ovima
        public List<Proizvod> ListaProizvoda;
        public List<Prodavci> ListaProdavaca;


        // lista proizvoda za krolovanje
        private List<Proizvod> ListaOdabranihProizvodaZaKrol;
        // lista prodavaca za krolovanje
        private List<Prodavci> ListaOdabranihProdavacaZaKrol;


        // rezultati krola
        private List<KrolStavke> KrolStavkePreciscenaLista; // rezultati krola sa odabranim prodavcima



        public frmStartKrol()
        {
            InitializeComponent();

            PuniListuProdavaca();
            PrikaziListuProdavaca();

            PuniListuProizvoda();
            PrikaziListuProizvoda();

        }

      


        // TO DO: PROGRESS BAR, SNIMANJE ZAGLAVLJA, GRUPISANJE I PRIKAZ REZULTATA




        #region BgWorkerProgress
        private void bgWorkerKrol_DoWork(object sender, DoWorkEventArgs e)
        {
            //bgWorkerKrol.ReportProgress(iterationNumber);

            int _brojOdabranihProizvodaZaKrol = (int)e.Argument;
            int i = 1;

            
            while (i <= _brojOdabranihProizvodaZaKrol)
            {
               
                i++;
            }
            
        }

        private void bgWorkerKrol_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressKrol.Value = e.ProgressPercentage;

            this.Text = e.ProgressPercentage.ToString();
        }
        #endregion


        private void btnStartKrol_Click(object sender, EventArgs e)
        {
            bool pokreniKrol = KreirajListeZaKrol();

            if (pokreniKrol)
            {
                PosaljiZahteveZaKrolProizvoda();
            }
            else return;

        }

        private void PosaljiZahteveZaKrolProizvoda()
        {
            int brojOdabranihProizvodaZaKrol = ListaOdabranihProizvodaZaKrol.Count;

            if (brojOdabranihProizvodaZaKrol > 0)
            {
                KrolStavkePreciscenaLista = new List<KrolStavke>();

                progressKrol.Minimum = 0;
                progressKrol.Maximum = brojOdabranihProizvodaZaKrol;
                progressKrol.Step = 1;

                int iterationNumber = 1;

                //bgWorkerKrol.RunWorkerAsync(brojOdabranihProizvodaZaKrol);

                foreach (var _proizvodZaKrol in ListaOdabranihProizvodaZaKrol)
                {


                    int randomTime = GetRandomTimerInterval();

                    Thread.Sleep(randomTime);

                    bool result;

                    try
                    {
                        if (_proizvodZaKrol != null)
                        {
                            result = KrolujProizvode(_proizvodZaKrol, 1); //promeni -1- u krolGlavaId
                            if (result)
                            {
                                progressKrol.PerformStep();
                                iterationNumber++;
                                //bgWorkerKrol.ReportProgress(iterationNumber);
                            }
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Greška u krolovanju!" + "\r\n" + e.Message, "Greška");
                        return;
                    }
                }
                // ispis rezultata msgbox
                string res = string.Empty;
                foreach (var item in KrolStavkePreciscenaLista)
                {
                    res += "Id: " + item.Id
                        + " GlavaId: " + item.KrolGlavaId
                        + " ProizvodId: " + item.ProizvodId
                        + " PradavacId: " + item.ProdavciId
                        + " Cena: " + item.Cena.ToString()
                        + "\r\n";
                }

                MessageBox.Show("Krolovanje je uspešno završeno. \r\n" + res, "Krolovanje");

            }
            else
            {
                MessageBox.Show("Lista proizvoda je prazna.", "Greška");
                return;
            }
        }



        private bool KrolujProizvode(Proizvod _proizvodZaKrol, int _krolGlavaId)
        {

            // dokument url
            var url = _proizvodZaKrol.ShopmaniaURL;

            // dokument
            HtmlWeb destinationWebPage = new HtmlWeb();
            var htmlDocument = destinationWebPage.Load(url);

            // svi <tr>
            var tableRows = htmlDocument.DocumentNode.Descendants("tr");

            // lista <tr> nodova
            List<HtmlNode> listaTableRows = tableRows.ToList();

            int trsTotalElements = tableRows.Count();

            try
            {
                for (int i = 1; i < trsTotalElements; i++)
                {
                    var tableRow = listaTableRows[i];

                    // Prodavac alt
                    string prodavac = tableRow.SelectSingleNode("td/a/img").GetAttributeValue("alt", "");

                    // Datum ažuriranja cene
                    //string datumAzuriranjaCene = tableRow.SelectSingleNode("td/div").InnerHtml;

                    // Cena
                    string cena = tableRow.SelectSingleNode("td/b").InnerHtml;




                    // id prodavca na osnovu alt atributa
                    //Prodavci prodavacAltToProdavacId = new Prodavci();
                    //int prodavacId;

                    //try
                    //{
                    //    prodavacAltToProdavacId =
                    //    ListaProdavaca
                    //    .Where(p => p.SMId.Equals(prodavac))
                    //    .First();
                    //}
                    //catch (Exception)
                    //{
                    //    continue;
                    //}




                    //if (prodavacAltToProdavacId == null)
                    //{
                    //    //prodavacId = null;
                    //    continue;
                    //}
                    //if (prodavacAltToProdavacId != null)

                    if (ListaOdabranihProdavacaZaKrol.Exists(e => e.SMId.Equals(prodavac)))
                    {
                        int prodavacId = ListaOdabranihProdavacaZaKrol.Find(p => p.SMId.Equals(prodavac)).Id;

                        KrolStavke krolStavka = new KrolStavke()
                        {
                            KrolGlavaId = _krolGlavaId,
                            ProizvodId = _proizvodZaKrol.Id,
                            ProdavciId = prodavacId,
                            Cena = Convert.ToDecimal(cena)
                        };

                        KrolStavkePreciscenaLista.Add(krolStavka);
                    }
                    else continue;


                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Greška KrolujProizvode()" + "\r\n" + e.Message, "Greška");
                return false;
            }

        }





        private bool KreirajListeZaKrol()
        {
            if (listBoxProizvodi.SelectedItems.Count > 0 && listBoxProdavci.SelectedItems.Count > 0)
            {
                KreirajListuProdavacaZaKrol();
                KreirajListuProizvodaZaKrol();
            }
            if (listBoxProizvodi.SelectedItems.Count == 0 || listBoxProdavci.SelectedItems.Count == 0)
            {
                MessageBox.Show("Označi proizvode/prodavce za krol!", "Selekcija");
                return false;
            }
            return true;
        }


        private void KreirajListuProizvodaZaKrol()
        {
            // Proizvodi
            ListaOdabranihProizvodaZaKrol = new List<Proizvod>();

            foreach (var item in listBoxProizvodi.SelectedItems)
            {
                Proizvod oznaceniProizvod = (Proizvod)item;
                ListaOdabranihProizvodaZaKrol.Add(oznaceniProizvod);
            }
        }


        private void KreirajListuProdavacaZaKrol()
        {
            // Prodavci
            ListaOdabranihProdavacaZaKrol = new List<Prodavci>();

            foreach (var item in listBoxProdavci.SelectedItems)
            {
                Prodavci oznaceniProdavac = (Prodavci)item;
                ListaOdabranihProdavacaZaKrol.Add(oznaceniProdavac);
            }
        }


        private void PuniListuProdavaca()
        {
            using (WebCeneModel db = new WebCeneModel())
            {
                ListaProdavaca = db.Prodavci.ToList();
            }
        }


        private void PuniListuProizvoda()
        {
            using (WebCeneModel db = new WebCeneModel())
            {
                ListaProizvoda = db.Proizvod.ToList();
            }
        }

        private void PrikaziListuProdavaca()
        {
            listBoxProdavci.DataSource = ListaProdavaca;
            listBoxProdavci.DisplayMember = "NazivProdavca";
            listBoxProdavci.ValueMember = "Id";
        }

        private void PrikaziListuProizvoda()
        {
            listBoxProizvodi.DataSource = ListaProizvoda;
            listBoxProizvodi.DisplayMember = "Naziv";
            listBoxProizvodi.ValueMember = "Id";
        }


        private void IzvrsiKrol(object source, ElapsedEventArgs e)
        {
            PosaljiZahteveZaKrolProizvoda();
        }



        private void btnStopKrol_Click(object sender, EventArgs e)
        {
            //StopTimer();

            // TO DO

        }







        #region TIMER
        /* T I M E R */
        //private void TimerSettings()
        //{
        //    krolTimer = new System.Timers.Timer();

        //    krolTimer.Elapsed += new ElapsedEventHandler(IzvrsiKrol); // metoda koja se izvršava
        //    krolTimer.AutoReset = true;
        //    //krolTimer.Enabled = true;

        //}

        //private void StopTimer()
        //{
        //    // zaustavlja izvršavanje timera
        //    try
        //    {
        //        krolTimer.Stop();
        //        krolTimer.Close();
        //        //MessageBox.Show("Timer stopped and disposed");
        //    }
        //    catch (Exception)
        //    {
        //        //MessageBox.Show("Timer is not initialized.");
        //    }
        //}


        #endregion

        private static int GetRandomTimerInterval()
        {

            Random rnd = new Random();
            int _rnd = rnd.Next(1000, 3500); // miliseconds           

            return _rnd;
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

        private void checkSviProizvodi_CheckedChanged(object sender, EventArgs e)
        {
            if (checkSviProizvodi.Checked)
            {
                listBoxProizvodi.BeginUpdate();
                for (int i = 0; i < listBoxProizvodi.Items.Count; i++)
                {
                    listBoxProizvodi.SetSelected(i, true);
                }
                listBoxProizvodi.EndUpdate();
            }
            if (!checkSviProizvodi.Checked)
            {
                listBoxProizvodi.BeginUpdate();
                for (int i = 0; i < listBoxProizvodi.Items.Count; i++)
                {
                    listBoxProizvodi.SetSelected(i, false);
                }
                listBoxProizvodi.EndUpdate();
            }
        }

        private void checkSviProdavci_CheckedChanged(object sender, EventArgs e)
        {
            if (checkSviProdavci.Checked)
            {
                listBoxProdavci.BeginUpdate();
                for (int i = 0; i < listBoxProdavci.Items.Count; i++)
                {
                    listBoxProdavci.SetSelected(i, true);
                }
                listBoxProdavci.EndUpdate();
            }
            if (!checkSviProdavci.Checked)
            {
                listBoxProdavci.BeginUpdate();
                for (int i = 0; i < listBoxProdavci.Items.Count; i++)
                {
                    listBoxProdavci.SetSelected(i, false);
                }
                listBoxProdavci.EndUpdate();
            }
        }


    }


}
