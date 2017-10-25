using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using WebCene.Model;
using HtmlAgilityPack;
using System.Net;

namespace WebCene.UI
{
    public partial class frmStartKrol : Form
    {
        //private static System.Timers.Timer krolTimer;
        static BackgroundWorker _bw;

        // liste za ispis u listbox-ovima
        public List<Proizvod> ListaProizvoda;
        public List<Prodavci> ListaProdavaca;

        // lista proizvoda za krolovanje
        private List<Proizvod> ListaOdabranihProizvodaZaKrol;
        // lista prodavaca za krolovanje
        private List<Prodavci> ListaOdabranihProdavacaZaKrol;

        // rezultati krola
        private List<KrolStavke> KrolStavkePreciscenaLista; // rezultati krola sa odabranim prodavcima

        // brojač krol lupova
        private int iterationCounter;


        public frmStartKrol()
        {
            InitializeComponent();

            //// osvežavanje UI iz drugog thread-a
            //_bw = new BackgroundWorker
            //{
            //    WorkerReportsProgress = true,
            //    WorkerSupportsCancellation = true
            //};
            //_bw.DoWork += _bw_DoWork;
            //_bw.ProgressChanged += _bw_ProgressChanged;
            //_bw.RunWorkerCompleted += _bw_RunWorkerCompleted;

            PuniListuProdavaca();
            PrikaziListuProdavaca();

            PuniListuProizvoda();
            PrikaziListuProizvoda();
        }

        private void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled) return;
            else if (e.Error != null)
            {
                MessageBox.Show("Background worker je otkazao.", "Greška");
                return;
            }            
        }

        private void _bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressKrol.Value = e.ProgressPercentage;
        }

        private void _bw_DoWork(object sender, DoWorkEventArgs e)
        {
            //iterationCounter++;
            int _brojOdabranihProizvodaZaKrol = (int)e.Argument;

            for (iterationCounter = 0; iterationCounter < _brojOdabranihProizvodaZaKrol; iterationCounter++)
            {
                _bw.ReportProgress(iterationCounter);

                //lblKompletirano.Text = string.Format("Kompletirano {0}/{1}", iterationCounter, _brojOdabranihProizvodaZaKrol);
            }
        }



        // TO DO: SNIMANJE ZAGLAVLJA, GRUPISANJE I PRIKAZ REZULTATA





        private void btnStartKrol_Click(object sender, EventArgs e)
        {
            lblKompletirano.Text = "Kompletirano";

            bool pokreniKrol = KreirajListeZaKrol();

            if (pokreniKrol)
            {
                btnStartKrol.Enabled = false;
                PosaljiZahteveZaKrolProizvoda();
                btnStartKrol.Enabled = true;
            }
            else return;

        }

        private void PosaljiZahteveZaKrolProizvoda()
        {
            int brojOdabranihProizvodaZaKrol = ListaOdabranihProizvodaZaKrol.Count;

            if (brojOdabranihProizvodaZaKrol > 0)
            {
                KrolStavkePreciscenaLista = new List<KrolStavke>();

                progressKrol.Value = 0;
                progressKrol.Minimum = 0;
                progressKrol.Maximum = brojOdabranihProizvodaZaKrol;
                progressKrol.Step = 1;

                iterationCounter = 0;

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
                                //_bw.RunWorkerAsync(brojOdabranihProizvodaZaKrol);

                                iterationCounter++;

                                lblKompletirano.Text =
                                    string.Format("Kompletirano {0}/{1}", iterationCounter, brojOdabranihProizvodaZaKrol);

                                progressKrol.PerformStep();
                            }
                            if (!result)
                            {
                                DialogResult dr =
                                    MessageBox.Show("Web adresa ne postoji. Proverite da li je ispravno upisana.\r\nProizvod:\r\n- " + _proizvodZaKrol.Naziv
                                    + "\r\nWeb adresa:\r\n" + _proizvodZaKrol.ShopmaniaURL
                                     + "\r\n\r\nDa li želite da nastavite krol ostalih proizvoda?",
                                    "Pogrešna web adresa", MessageBoxButtons.YesNo);

                                if (dr == DialogResult.Yes)
                                {
                                    continue;
                                }
                                if (dr == DialogResult.No)
                                {
                                    return;
                                }
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
                        btnStartKrol.Enabled = true;
                        return;
                    }
                }

                // ispis rezultata u msgboxu
                string res = string.Empty;
                if (KrolStavkePreciscenaLista.Count > 0)
                {
                    foreach (var item in KrolStavkePreciscenaLista)
                    {
                        res += "Id: " + item.Id
                            + " GlavaId: " + item.KrolGlavaId
                            + " ProizvodId: " + item.ProizvodId
                            + " PradavacId: " + item.ProdavciId
                            + " Cena: " + item.Cena.ToString()
                            + "\r\n";
                    }
                }
                else if (KrolStavkePreciscenaLista.Count == 0)
                    res = "Za dati kriterijum nema rezultata pretrage.";

                MessageBox.Show("Krolovanje je uspešno završeno. \r\n" + res, "Krolovanje");
            }
            else
            {
                MessageBox.Show("Lista proizvoda je prazna.", "Greška");
                btnStartKrol.Enabled = true;
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

            // provera odgovora na status 404
            if (destinationWebPage.StatusCode == HttpStatusCode.OK)
            {
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
                        string prodavac =
                            tableRow.SelectSingleNode("td/a/img").GetAttributeValue("alt", "");

                        // Datum ažuriranja cene
                        //string datumAzuriranjaCene = 
                        //    tableRow.SelectSingleNode("td/div").InnerHtml;

                        // Cena
                        string cena =
                            tableRow.SelectSingleNode("td/b").InnerHtml;


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
            else
            {
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
