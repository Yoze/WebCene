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
using System.Collections.ObjectModel;

namespace WebCene.UI
{
    public partial class frmStartKrol : Form
    {
        static BackgroundWorker _bw;

        // liste za ispis u listbox-ovima
        public List<Proizvod> ListaProizvoda { get; set; }
        public List<Prodavci> ListaProdavaca { get; set; }

        // lista proizvoda za krolovanje
        //private List<Proizvod> ListaOdabranihProizvodaZaKrol { get; set; }
        private List<Proizvod> ListaOdabranihProizvodaZaKrol { get; set; }
        // lista prodavaca za krolovanje
        private List<Prodavci> ListaOdabranihProdavacaZaKrol { get; set; }

        // rezultati krola sa odabranim prodavcima
        private List<KrolStavke> KrolStavkePreciscenaLista { get; set; }

        private List<KrolStavke> _tempKrolStavkePreciscenaLista { get; set; }

        // rezultati krola za prikaz u pregledu; ProizvodId i ProdavacId su povezani sa njihovim nazivima
        private List<RezultatKrolaZaPrikaz> ListaZaPrikazRezultataKrola { get; set; }

        // brojač krol lupova
        private int iterationCounter { get; set; }
        private int brojOdabranihProizvodaZaKrol { get; set; }
        
        // prekidač za BackgroundWorker _bw
        private bool cancelWorker;

        // comboboxovi za filter
        private List<KATARTIK> ListaKategorija { get; set; }
        private List<BRAND> ListaBrendova { get; set; }

        // odabrane vrednosti comboboxa
        private string odabraniBrend { get; set; }
        private string odabranaKategorija { get; set; }

        // lista proizvoda rezultat filtera
        private List<Proizvod> FilteredListaProizvoda { get; set; }

        // lista artikala za krol binding source
        BindingSource ArtikliZaKrolBindingSrc { get; set; }


        public frmStartKrol()
        {
            InitializeComponent();

            // sprečava implicitnu validaciju kontrole kada izgubi fokus
            AutoValidate = System.Windows.Forms.AutoValidate.Disable;

            lblSacekajte.Visible = false;

            //BgWorker
            _bw = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            _bw.DoWork += _bw_DoWork;
            _bw.ProgressChanged += _bw_ProgressChanged;
            _bw.RunWorkerCompleted += _bw_RunWorkerCompleted;

            // lista proizvoda
            PuniListuProizvoda();
            FiltrirajListuArtikala(null, null);

            // init lista odabranih artikala za krol
            ListaOdabranihProizvodaZaKrol = new List<Proizvod>();
            PrikaziListuOdabranihArtikalaZaKrol();

            // lista prodavaca
            PuniListuProdavaca();
            PrikaziListuProdavaca();

            // combor filteri
            NapuniListeZaCombo();
            UcitajComboKategorije();
            UcitajComboBrendovi();

        }


        #region BackgroundWorker
        private void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                return;
            }
            else if (e.Error != null)
            {
                MessageBox.Show("Background worker je otkazao.", "Greška");
                return;
            }
            else
            {
                KreirajListuZaPregledRezultataKrola();
                PrikaziListViewRezultataKrola();
                lblSacekajte.Visible = false;
                if (cancelWorker)
                    lblKorisnikStopKrolPoruka.Visible = true;
                
                btnStartKrol.Enabled = true;
                btnSnimi.Enabled = true;
                btnOdustani.Enabled = true;
                listBoxProizvodi.Enabled = true;
                listBoxProdavci.Enabled = true;
                listBoxArtikliZaKrol.Enabled = true;

                comboBrendovi.Enabled = true;
                comboKategorije.Enabled = true;
                btnFilter.Enabled = true;
                checkSviProdavci.Enabled = true;
                checkSviProizvodi.Enabled = true;
                linkPonisti.Enabled = true;

                groupBoxZaglavlje.Enabled = true;

                btnStopKrol.Visible = false;
            }
        }

        private void _bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressKrol.PerformStep();
            lblKompletirano.Text = 
                string.Format("Kompletirano {0}/{1}", iterationCounter, brojOdabranihProizvodaZaKrol);

        }

        private void _bw_DoWork(object sender, DoWorkEventArgs e)
        {
            if (_bw.CancellationPending == true)
            {
                e.Cancel = true;
                return;
            }
            else
            {
                PosaljiZahteveZaKrolProizvoda();
            }
            
        }

        #endregion


        #region ComboBox Filteri

        private void NapuniListeZaCombo()
        {
            try
            {
                using (ELBSModel db = new ELBSModel())
                {
                    ListaKategorija = new List<KATARTIK>();
                    ListaKategorija = db.KATARTIK
                        .OrderBy(k => k.KAT2)
                        .ToList();

                    ListaBrendova = new List<BRAND>();
                    ListaBrendova = db.BRAND
                        .OrderBy(b => b.PROIZVODJAC)
                        .ToList();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Greška pri učitavanju podataka za combo.", "Greška");
            }
        }

        private void UcitajComboKategorije()
        {
            comboKategorije.DataSource = ListaKategorija;
            comboKategorije.ValueMember = "SHKAT";
            comboKategorije.DisplayMember = "KAT2";
            comboKategorije.SelectedIndex = -1;

        }

        private void UcitajComboBrendovi()
        {
            comboBrendovi.DataSource = ListaBrendova;
            comboBrendovi.ValueMember = "PROIZVODJAC";
            comboBrendovi.DisplayMember = "PROIZVODJAC";
            comboBrendovi.SelectedIndex = -1;
        }



        #endregion



        private void btnStartKrol_Click(object sender, EventArgs e)
        {
            lblKompletirano.Text = string.Empty;
            lblKorisnikStopKrolPoruka.Visible = false;

            bool pokreniKrol = KreirajListeZaKrol();

            if (pokreniKrol)
            {
                lblSacekajte.Visible = true;
                btnStopKrol.Visible = true;

                /* disable za offline test */
                if (_bw.IsBusy != true)
                {
                    _bw.RunWorkerAsync();
                }
                

                btnStartKrol.Enabled = false;
                btnOdustani.Enabled = false;
                listBoxProizvodi.Enabled = false;
                listBoxProdavci.Enabled = false;
                listBoxArtikliZaKrol.Enabled = false;

                comboBrendovi.Enabled = false;
                comboKategorije.Enabled = false;
                btnFilter.Enabled = false;
                checkSviProdavci.Enabled = false;
                checkSviProizvodi.Enabled = false;
                linkPonisti.Enabled = false;

                groupBoxZaglavlje.Enabled = false;

                progressKrol.Value = 0;
                progressKrol.Minimum = 0;
                progressKrol.Maximum = brojOdabranihProizvodaZaKrol;
                progressKrol.Step = 1;
            }
            else if (!pokreniKrol) return;
        }

        private void PosaljiZahteveZaKrolProizvoda()
        {
            brojOdabranihProizvodaZaKrol = ListaOdabranihProizvodaZaKrol.Count;
            
            if (brojOdabranihProizvodaZaKrol > 0)
            {
                KrolStavkePreciscenaLista = new List<KrolStavke>();
                    
                iterationCounter = 0;
                cancelWorker = false;

                foreach (var _proizvodZaKrol in ListaOdabranihProizvodaZaKrol)
                {
                    int randomTime = GetRandomTimerInterval();
                    Thread.Sleep(randomTime);
                    bool result;

                    if(cancelWorker)
                    {
                        _bw.CancelAsync();
                        MessageBox.Show("Tekući krol je stopiran.", "Krol");                        
                        return;
                    }
                    else
                    {
                        try
                        {
                            if (_proizvodZaKrol != null)
                            {
                                result = KrolujProizvode(_proizvodZaKrol, 1); //promeni -1- u krolGlavaId
                                if (result)
                                {
                                    iterationCounter++;
                                    int progressPercentage = (iterationCounter / brojOdabranihProizvodaZaKrol) * 100;

                                    _bw.ReportProgress(progressPercentage);

                                }
                                if (!result)
                                {
                                    DialogResult dr =
                                        MessageBox.Show("Web adresa ne postoji. Proverite da li je ispravno upisana.\r\nProizvod:\r\n- " + _proizvodZaKrol.Naziv
                                        + "\r\nWeb adresa:\r\n" + _proizvodZaKrol.ePonudaURL
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
                }

                //// ispis rezultata u msgboxu
                //string res = string.Empty;
                //if (KrolStavkePreciscenaLista.Count > 0)
                //{
                //    foreach (var item in KrolStavkePreciscenaLista)
                //    {
                //        res += "Id: " + item.Id
                //            + " GlavaId: " + item.KrolGlavaId
                //            + " ProizvodId: " + item.ProizvodId
                //            + " PradavacId: " + item.ProdavciId
                //            + " Cena: " + item.Cena.ToString()
                //            + "\r\n";
                //    }
                //}
                //else if (KrolStavkePreciscenaLista.Count == 0)
                //    res = "Za dati kriterijum nema rezultata pretrage.";

                //MessageBox.Show("Krolovanje je uspešno završeno. \r\n" + res, "Krolovanje");
            }
            else
            {
                MessageBox.Show("Lista proizvoda je prazna.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnStartKrol.Enabled = true;
                return;
            }
        }


        private void KreirajListuZaPregledRezultataKrola()
        {
            /* PRIVREMENI PODACI ZA OFFLINE TEST */
            //_tempKrolStavkePreciscenaLista = new List<KrolStavke>(); // umesto KrolStavkePreciscenaLista OFFLINE

            //KrolStavke s1 = new KrolStavke() { ProizvodId = 1, ProdavciId = 2, Cena = 35990 };
            //KrolStavke s2 = new KrolStavke() { ProizvodId = 1, ProdavciId = 3, Cena = 36990 };
            //KrolStavke s3 = new KrolStavke() { ProizvodId = 1, ProdavciId = 4, Cena = 37999 };
            //KrolStavke s4 = new KrolStavke() { ProizvodId = 2, ProdavciId = 3, Cena = 38997 };
            //KrolStavke s5 = new KrolStavke() { ProizvodId = 3, ProdavciId = 3, Cena = 32994 };
            //KrolStavke s6 = new KrolStavke() { ProizvodId = 4, ProdavciId = 2, Cena = 39990 };
            //KrolStavke s7 = new KrolStavke() { ProizvodId = 4, ProdavciId = 3, Cena = 44991 };

            //_tempKrolStavkePreciscenaLista.Add(s1);
            //_tempKrolStavkePreciscenaLista.Add(s2);
            //_tempKrolStavkePreciscenaLista.Add(s3);
            //_tempKrolStavkePreciscenaLista.Add(s4);
            //_tempKrolStavkePreciscenaLista.Add(s5);
            //_tempKrolStavkePreciscenaLista.Add(s6);
            //_tempKrolStavkePreciscenaLista.Add(s7);



            int brojRezultataKrola = KrolStavkePreciscenaLista.Count; /* disable za offline test */
            //int brojRezultataKrola = _tempKrolStavkePreciscenaLista.Count;
            RezultatKrolaZaPrikaz stavkaZaPrikaz;

            ListaZaPrikazRezultataKrola = new List<RezultatKrolaZaPrikaz>();

            if (brojRezultataKrola > 0)
            {
                foreach (KrolStavke item in KrolStavkePreciscenaLista) /* disable za offline test */
                //foreach (KrolStavke item in _tempKrolStavkePreciscenaLista)
                {
                    string nazivProizvoda = ListaProizvoda.Find(p => p.Id.Equals(item.ProizvodId)).Naziv;

                    string nazivProdavca = ListaProdavaca.Find(p => p.Id.Equals(item.ProdavciId)).NazivProdavca;
                 
                    stavkaZaPrikaz = new RezultatKrolaZaPrikaz()
                    {
                        _ProizvodNaziv = nazivProizvoda,
                        _ProdavacNaziv = nazivProdavca,
                        _Cena = (decimal)item.Cena
                    };
                    ListaZaPrikazRezultataKrola.Add(stavkaZaPrikaz);
                }
            }

            else if (brojRezultataKrola == 0)
            {
                MessageBox.Show("Nema rezultata za odabrani kriterijum.", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }


        private void PrikaziListViewRezultataKrola()
        {
            lstViewRezultat.BeginUpdate();
            lstViewRezultat.Groups.Clear();

            ListaZaPrikazRezultataKrola
                .GroupBy(proizv => proizv._ProizvodNaziv, KreirajListViewGrupe)
                .ToList();

            lstViewRezultat.EndUpdate();
        }


        private ListViewGroup KreirajListViewGrupe(string _proizvodNaziv, IEnumerable<RezultatKrolaZaPrikaz> _listaZaPrikazRezultataKrola)
        {
            var group = new ListViewGroup(_proizvodNaziv);

            lstViewRezultat.Groups.Add(group);

            foreach (var stavkaListe in _listaZaPrikazRezultataKrola)
            {
                var item = new ListViewItem(new string[] {
                    string.Empty,
                    stavkaListe._ProdavacNaziv,
                    stavkaListe._Cena.ToString("N2")
                }, group);

                lstViewRezultat.Items.Add(item);
            }
            return group;
        }


        private bool KrolujProizvode(Proizvod _proizvodZaKrol, int _krolGlavaId)
        {

            // dokument url
            var url = _proizvodZaKrol.ePonudaURL;



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


                        if (ListaOdabranihProdavacaZaKrol.Exists(e => e.EponudaId.Equals(prodavac)))
                        {
                            int prodavacId = ListaOdabranihProdavacaZaKrol.Find(p => p.EponudaId.Equals(prodavac)).Id;

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
            int countListaZaKrol = ListaOdabranihProizvodaZaKrol.Count;

            if (countListaZaKrol > 0 && listBoxProdavci.SelectedItems.Count > 0)
            {
                KreirajListuProdavacaZaKrol();                
            }
            if (countListaZaKrol == 0 || listBoxProdavci.SelectedItems.Count == 0)
            {
                MessageBox.Show("Dodaj artikle i označi prodavce za krol!", "Selekcija");
                return false;
            }
            return true;
        }


     


        private void DodajArtikalListiZaKrol()
        {
            // Proizvodi
            List<Proizvod> tempListaOdabranihProizvodaZaKrol = new List<Proizvod>();

            foreach (var item in listBoxProizvodi.SelectedItems)
            {
                Proizvod oznaceniProizvod = (Proizvod)item;
                ListaOdabranihProizvodaZaKrol.Add(oznaceniProizvod);
            }

            // samo unikatni artikli idu u listu za krol
            tempListaOdabranihProizvodaZaKrol =
                ListaOdabranihProizvodaZaKrol.Distinct().ToList();

            ListaOdabranihProizvodaZaKrol.Clear();
            ListaOdabranihProizvodaZaKrol.AddRange(tempListaOdabranihProizvodaZaKrol);
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
            PrikaziListuOdabranihArtikalaZaKrol();
        }


        private void BrisiOdabraneArtZaKrol()
        {
            if (listBoxArtikliZaKrol.SelectedItems.Count == 0)
            {
                return;
            }
            else
            {
                foreach (var item in listBoxArtikliZaKrol.SelectedItems)
                {
                    Proizvod oznaceniProizvod = (Proizvod)item;
                    ListaOdabranihProizvodaZaKrol.Remove(oznaceniProizvod);
                }
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

        private void PrikaziListuProizvoda(List<Proizvod> _listaProizvoda)
        {
            listBoxProizvodi.DataSource = _listaProizvoda;
            listBoxProizvodi.DisplayMember = "Naziv";
            listBoxProizvodi.ValueMember = "Id";
        }

        private void PrikaziListuOdabranihArtikalaZaKrol()
        {
            BindingList<Proizvod> listaArtikalaZaKrol = new BindingList<Proizvod>(ListaOdabranihProizvodaZaKrol);
            ArtikliZaKrolBindingSrc = new BindingSource(listaArtikalaZaKrol, null);

            listBoxArtikliZaKrol.DataSource = ArtikliZaKrolBindingSrc;
            listBoxArtikliZaKrol.DisplayMember = "Naziv";
            listBoxArtikliZaKrol.ValueMember = "Id";

            lblOdabraniArt.Text =
                "Odabrani artikli (" + ListaOdabranihProizvodaZaKrol.Count + ")";
        }

        private void btnStopKrol_Click(object sender, EventArgs e)
        {
            cancelWorker = true;          
        }


        private static int GetRandomTimerInterval()
        {
            Random rnd = new Random();
            int _rnd = rnd.Next(1250, 3550); // miliseconds           

            return _rnd;
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

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            if (_bw.IsBusy == true)
            {
                _bw.CancelAsync();

                MessageBox.Show("btnOdustani _bw Stopped");
            }            
            Close();
        }

        private void btnSnimi_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {

                DialogResult dr = 
                    MessageBox.Show("Da li želite da snimite rezultate krola?", "Snimanje podataka", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                switch (dr)
                {
                    case DialogResult.Yes:
                        {
                            if (SnimiRezultateKrola())
                            {
                                MessageBox.Show("Podaci su snimljeni u bazu.", "Snimanje");
                                btnSnimi.Enabled = false;
                            }
                            else if (!SnimiRezultateKrola())
                            {
                                MessageBox.Show("Greška pri snimanju podataka. Err...", "Snimanje");
                                btnSnimi.Enabled = false;
                            }
                        }
                        break;
                    case DialogResult.No:
                        return;
                    default:
                        MessageBox.Show("Case default.", "Interna greška");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Morate popuniti obeležena polja.", "Greška pri unosu");                
            }
        }


        private bool SnimiRezultateKrola()
        {
            using (WebCeneModel db = new WebCeneModel())
            {
                KrolGlava noviKrolGlava = new KrolGlava()
                {
                    NazivKrola = txtNAzivKrola.Text,
                    DatumKrola = dateTimeDatumKrola.Value,
                    IzvrsilacKrola = txtIzvrsilacKrola.Text
                };

                try
                {
                    db.KrolGlava.Add(noviKrolGlava);
                    int resultGlava = db.SaveChanges();

                    if (resultGlava > 0)
                    {
                        //uspešno

                        foreach (KrolStavke item in KrolStavkePreciscenaLista)
                        //foreach (KrolStavke item in _tempKrolStavkePreciscenaLista) /* TEST OFFLINE LISTA*/
                        {
                            // snimanje stavki krola

                            KrolStavke novaKrolStavka = new KrolStavke()
                            {
                                KrolGlavaId = noviKrolGlava.Id,
                                ProizvodId = item.ProizvodId,
                                ProdavciId = item.ProdavciId,
                                Cena = item.Cena
                            };
                            try
                            {
                                db.KrolStavke.Add(novaKrolStavka);
                                int resultStavke = db.SaveChanges();

                                if (resultStavke > 0) continue;
                                else throw new Exception();
                                
                            }
                            catch (Exception)
                            {
                                throw new Exception();
                            }
                        }
                        return true;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception xcp)
                {
                    MessageBox.Show("Greška prilikom snimanja podataka.\r\n\r\n" + xcp.Message, "Greška");
                    return false;
                }
            }
        }

        private void txtNAzivKrola_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;

            if (!(string.IsNullOrWhiteSpace(txtNAzivKrola.Text)))
            {
                // prolazi validaciju
                cancel = false;
            }
            else
            {
                // ne prolazi validaciju
                cancel = true;
                errProviderNoviKrol.SetError(txtNAzivKrola, "Obavezan podatak.");
            }
            e.Cancel = cancel;
        }

        private void txtNAzivKrola_Validated(object sender, EventArgs e)
        {
            errProviderNoviKrol.SetError(txtNAzivKrola, string.Empty);
        }

        private void txtIzvrsilacKrola_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;

            if (!(string.IsNullOrWhiteSpace(txtIzvrsilacKrola.Text)))
            {
                // prolazi validaciju
                cancel = false;
            }
            else
            {
                // ne prolazi validaciju
                cancel = true;
                errProviderNoviKrol.SetError(txtIzvrsilacKrola, "Obavezan podatak.");
            }
            e.Cancel = cancel;
        }

        private void txtIzvrsilacKrola_Validated(object sender, EventArgs e)
        {
            errProviderNoviKrol.SetError(txtIzvrsilacKrola, string.Empty);
        }

        private void dateTimeDatumKrola_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;

            if (!(dateTimeDatumKrola.Value > DateTime.Now.Date.AddDays(1)))
            {
                cancel = false;
            }
            else
            {
                cancel = true;
                errProviderNoviKrol.SetError(dateTimeDatumKrola, "Datum krola ne može biti veći od današnjeg.");
            }
            e.Cancel = cancel;
        }

        private void dateTimeDatumKrola_Validated(object sender, EventArgs e)
        {
            errProviderNoviKrol.SetError(dateTimeDatumKrola, string.Empty);
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            odabranaKategorija =
                (string)comboKategorije.SelectedValue;

            odabraniBrend =
                (string)comboBrendovi.SelectedValue;

            if (comboBrendovi.SelectedIndex == -1 && comboKategorije.SelectedIndex == -1)
                picFilter.Visible = false;
            else
                picFilter.Visible = true;

            FiltrirajListuArtikala(odabranaKategorija, odabraniBrend);
        }


        private void FiltrirajListuArtikala(string _ElKat, string _Brend)
        {
            // ispitivanje parametara radi kreiranja sql upita
            string linqParametri = string.Empty;

            // obaNull
            if (string.IsNullOrEmpty(_ElKat) && string.IsNullOrEmpty(_Brend)) linqParametri = "obaNull";

            // KatNullBrendNotNull
            if (string.IsNullOrEmpty(_ElKat) && !(string.IsNullOrEmpty(_Brend))) linqParametri = "KatNullBrendNotNull";

            // KatNotNullBrendNull
            if (!(string.IsNullOrEmpty(_ElKat)) && string.IsNullOrEmpty(_Brend)) linqParametri = "KatNotNullBrendNull";

            // obaNotNull
            if (!(string.IsNullOrEmpty(_ElKat)) && !(string.IsNullOrEmpty(_Brend))) linqParametri = "obaNotNull";


            FilteredListaProizvoda = new List<Proizvod>();

            switch (linqParametri)
            {
                case "obaNull":
                    {
                        FilteredListaProizvoda = ListaProizvoda;
                        break;
                    }

                case "KatNullBrendNotNull":
                    {
                        string _brendTrimmed = _Brend.TrimEnd();

                        var tempLista = ListaProizvoda
                            .Where(x => x.Brend.Equals(_brendTrimmed))
                            .ToList();

                        FilteredListaProizvoda = tempLista;
                        break;
                    }

                case "KatNotNullBrendNull":
                    {
                        string _katTrimmed = _ElKat.TrimEnd();

                        var tempLista = ListaProizvoda
                            .Where(x => x.ElKat.Equals(_katTrimmed))
                            .ToList();

                        FilteredListaProizvoda = tempLista;
                        break;
                    }

                case "obaNotNull":
                    {
                        string _brendTrimmed = _Brend.TrimEnd();
                        string _katTrimmed = _ElKat.TrimEnd();

                        var tempLista = ListaProizvoda
                            .Where(k => k.ElKat.Equals(_katTrimmed))
                            .Where(b => b.Brend.Equals(_brendTrimmed))
                            .ToList();

                        FilteredListaProizvoda = tempLista;
                        break;
                    }

                default:
                    break;
            }
            PrikaziListuProizvoda(FilteredListaProizvoda);
        }

        private void linkPonisti_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PonistiFilter();
            PrikaziListuProizvoda(ListaProizvoda);
        }

        private void PonistiFilter()
        {
            comboBrendovi.SelectedIndex = -1;
            comboKategorije.SelectedIndex = -1;

            picFilter.Visible = false;
        }

        private void contextMenuDodajZaKrol_Click(object sender, EventArgs e)
        {
            DodajArtikalListiZaKrol();
            PrikaziListuOdabranihArtikalaZaKrol();
        }

        private void contextOdabraniArtObrisiSve_Click(object sender, EventArgs e)
        {
            ListaOdabranihProizvodaZaKrol.Clear();
            PrikaziListuOdabranihArtikalaZaKrol(); 
        }

        private void contextOdabraniArtObrisiStavku_Click(object sender, EventArgs e)
        {
            BrisiOdabraneArtZaKrol();
            PrikaziListuOdabranihArtikalaZaKrol();
        }

       
    }


}
