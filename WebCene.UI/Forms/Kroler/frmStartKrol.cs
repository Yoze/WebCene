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
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace WebCene.UI.Forms.Kroler
{
    public partial class frmStartKrol : Form
    {
        static BackgroundWorker _bw;

        // liste za ispis u listbox-ovima
        public List<Proizvod> ListaProizvoda { get; set; }
        public List<Prodavci> ListaProdavaca { get; set; }

        // lista podešavanja krola
        public List<Podesavanja> ListaPodesavanjaKrola { get; set; }

        // lista proizvoda za krolovanje
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

            // combo filteri
            NapuniListeZaCombo();
            UcitajComboKategorije();
            UcitajComboBrendovi();

            // combo Podešavanja krola
            PuniListuPodesavanjaKrola();
            PrikaziListuPodesavanjaKrola(-1);

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
                btnSnimiPodesavanjaKrola.Enabled = true;
                btnFilter.Enabled = true;
                btnStopKrol.Visible = false;

                listBoxProizvodi.Enabled = true;
                listBoxProdavci.Enabled = true;
                listBoxArtikliZaKrol.Enabled = true;

                comboPodesavanjaKrola.Enabled = true;
                comboBrendovi.Enabled = true;
                comboKategorije.Enabled = true;
                checkSviProdavci.Enabled = true;
                checkSviProizvodi.Enabled = true;

                groupBoxZaglavlje.Enabled = true;

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
                btnSnimiPodesavanjaKrola.Enabled = false;
                btnFilter.Enabled = false;

                listBoxProizvodi.Enabled = false;
                listBoxProdavci.Enabled = false;
                listBoxArtikliZaKrol.Enabled = false;

                comboPodesavanjaKrola.Enabled = false;
                comboBrendovi.Enabled = false;
                comboKategorije.Enabled = false;

                checkSviProdavci.Enabled = false;
                checkSviProizvodi.Enabled = false;

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

                    if (cancelWorker)
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
                                        MessageBox.Show("Proverite da li je web adresa ispravno upisana.\r\nProizvod:\r\n- " + _proizvodZaKrol.Naziv
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
           
            int brojRezultataKrola = KrolStavkePreciscenaLista.Count;
            RezultatKrolaZaPrikaz stavkaZaPrikaz;

            ListaZaPrikazRezultataKrola = new List<RezultatKrolaZaPrikaz>();

            if (brojRezultataKrola > 0)
            {

                List<Prodavci> elbracoRowsFromProdavciTable = GetElbracoRowsFromProdavciTable();

                foreach (KrolStavke item in KrolStavkePreciscenaLista) 
                {
                    string nazivProizvoda;
                    string nazivProdavca;

                    if(elbracoRowsFromProdavciTable.Exists(p => p.Id == item.ProdavciId))
                    {
                        nazivProizvoda = ListaProizvoda.Find(p => p.Id.Equals(item.ProizvodId)).Naziv;
                        nazivProdavca = elbracoRowsFromProdavciTable.Find(p => p.Id.Equals(item.ProdavciId)).NazivProdavca;
                    }
                    else
                    {
                        nazivProizvoda = ListaProizvoda.Find(p => p.Id.Equals(item.ProizvodId)).Naziv;
                        nazivProdavca = ListaProdavaca.Find(p => p.Id.Equals(item.ProdavciId)).NazivProdavca;
                    }

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

            // provera na status 404
            if (destinationWebPage.StatusCode == HttpStatusCode.OK)
            {
                // svi <tr>
                var tableRows = htmlDocument.DocumentNode.Descendants("tr");

                // lista <tr> nodova
                List<HtmlNode> listaTableRows = new List<HtmlNode>(tableRows.ToList());

                int trsTotalElements = tableRows.Count();

                // Prodavac
                string prodavac = string.Empty;
                // Cena
                string cena = string.Empty;
              

                try
                {
                    for (int i = 1; i < trsTotalElements; i++)
                    {

                        // Prodavac
                        try
                        {
                            prodavac = listaTableRows[i]
                                .Descendants("img")
                                .First()
                                .Attributes["alt"].Value;
                        }
                        catch (Exception xcp)
                        {
                            MessageBox.Show("Greška prodavac tag\r\nSrc: " + xcp.Source + "\r\nMsg: " + xcp.Message, "Greška krol");
                        }

                        // Cena
                        cena = listaTableRows[i]
                            .Descendants("div")
                            .Where(x => x.Attributes.Contains("class") && x.Attributes["class"].Value.Contains("c-table__row__price__real"))
                            .First()
                            .InnerHtml;


                        // Traži Id prodavca
                        if (ListaOdabranihProdavacaZaKrol.Exists(e => e.EponudaId.Equals(prodavac)))
                        {
                            int prodavacId = ListaOdabranihProdavacaZaKrol.Find(p => p.EponudaId.Equals(prodavac)).Id;

                            // Novi krolStavkaObjekat
                            KrolStavke krolStavka = new KrolStavke()
                            {
                                KrolGlavaId = _krolGlavaId,
                                ProizvodId = _proizvodZaKrol.Id,
                                ProdavciId = prodavacId,
                                Cena = Convert.ToDecimal(cena)
                            };

                            // Kolekcija krol stavki
                            KrolStavkePreciscenaLista.Add(krolStavka);
                        }
                        else continue;
                    }


                    /** Kolona CenaM za svaki proizvod */

                    decimal cenaM = decimal.Zero;
                    int elbsCENAMKolona = PronadjiProdavnicaIdFromKrolProdavci("000");
                    cenaM = PronadjiCenaMZaProizvod(_proizvodZaKrol);

                    KrolStavke kolonaCenaM = new KrolStavke
                    {
                        KrolGlavaId = _krolGlavaId,
                        ProizvodId = _proizvodZaKrol.Id,
                        ProdavciId = elbsCENAMKolona,
                        Cena = cenaM
                    };
                    KrolStavkePreciscenaLista.Add(kolonaCenaM);



                    /** Kolona CENAMALO * 0.9 iz tabele ARTPROD -> za svaki proizvod i za svaku prodavnicu */
                    for ( int shpro = 1; shpro <= 5; shpro ++ )
                    {
                        // loop kroz sve prodavnice i pretraga po šifri proizvoda za vrednošću kolone CENAMALO
                        decimal CENAMALOx09zaProdavnicu = PronadjiCenaMaloFromArtProd(_proizvodZaKrol, "00" + shpro.ToString());

                        int elbsProdavnicaId = PronadjiProdavnicaIdFromKrolProdavci("00" + shpro.ToString());

                        KrolStavke kolonaCENAMALOx09ZaProdavnicu = new KrolStavke()
                        {
                            KrolGlavaId = _krolGlavaId,
                            ProizvodId = _proizvodZaKrol.Id,
                            ProdavciId = elbsProdavnicaId,
                            Cena = CENAMALOx09zaProdavnicu
                        };
                        KrolStavkePreciscenaLista.Add(kolonaCENAMALOx09ZaProdavnicu);
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

        private List<Prodavci> GetElbracoRowsFromProdavciTable()
        {
            List<Prodavci> result = new List<Prodavci>();

            using(WebCeneModel db = new WebCeneModel())
            {
                Prodavci elbsRow = new Prodavci();

                foreach (Prodavci item in db.Prodavci.Where(x => x.EponudaId.Contains("00")))
                {
                    elbsRow = item;
                    if (elbsRow != null) result.Add(item);
                    else throw new Exception("Greška: GetElbracoRowsFromProdavciTable()");
                }
            }

            return result;
        }


        private int PronadjiProdavnicaIdFromKrolProdavci(string shpro)
        {
            int elbsProdavnicaId = 0;

            using (WebCeneModel db = new WebCeneModel())
            {
                // ne prikazuje CENAM u listi prodavaca
                elbsProdavnicaId = db.Prodavci
                    .Where(x => x.EponudaId == shpro)
                    .Select(p => p.Id)
                    .FirstOrDefault();
            }

            if (elbsProdavnicaId > 0) return elbsProdavnicaId;
            else throw new Exception("Elbraco prodavnica pod šifrom " + shpro + " nije pronađena u tabeli ELBS_WebKroler.Prodavci!\r\nUkoliko nisi B.Šoškić pozovi ga i pročitaj mu poruku.");
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="proizvod"></param>
        /// <param name="sifraProdavnice"></param>
        /// <returns>CENAMALO * 0.9</returns>
        private decimal PronadjiCenaMaloFromArtProd(Proizvod proizvod, string sifraProdavnice)
        {
            string artikal = string.Empty;
            decimal CENAMALO = decimal.Zero;
            decimal multiplier = 0.9M;

            using (SqlConnection elbsConn = new SqlConnection(Properties.Settings.Default.ELBS_2018_ConnString))
            {
                elbsConn.Open();
                if (elbsConn.State == System.Data.ConnectionState.Open)
                {
                    try
                    {
                        string sqlQuery = "SELECT artikal, cenamalo FROM artprod WHERE artikal ='" + proizvod.ElSifraProizvoda + "' AND" + " sifrapro='" + sifraProdavnice + "'";

                        SqlCommand cmd = new SqlCommand(sqlQuery, elbsConn);

                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                artikal = dr.GetString(0);
                                CENAMALO = (decimal)dr.GetDouble(1);
                            }
                        }

                        dr.Close();
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show("Greška: PronadjiCenaMZaProizvod()\r\nErr: " + err.Message, "Greška");
                    }
                }
            }
            return decimal.Multiply(CENAMALO, multiplier);
        }


        private decimal PronadjiCenaMZaProizvod(Proizvod proizvod)
        {
            decimal cenaM = decimal.Zero;
            string sifra = string.Empty;

            using (SqlConnection elbsConn = new SqlConnection(Properties.Settings.Default.ELBS_2018_ConnString))
            {
                elbsConn.Open();
                if (elbsConn.State == System.Data.ConnectionState.Open)
                {
                    try
                    {
                        string sqlQuery = "SELECT artikal, cenam FROM nabcene WHERE artikal ='" + proizvod.ElSifraProizvoda + "'";

                        SqlCommand cmd = new SqlCommand(sqlQuery, elbsConn);

                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                sifra = dr.GetString(0);
                                cenaM = (decimal)dr.GetDouble(1);
                            }
                        }

                        dr.Close();
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show("Greška: PronadjiCenaMZaProizvod()\r\nErr: " + err.Message, "Greška");
                    }
                }
            }
            return cenaM;
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

            // samo jedinstveni artikli idu u listu za krol
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
                // ne prikazuje CENAM u listi prodavaca
                ListaProdavaca = db.Prodavci
                    .Where(x => !x.EponudaId.StartsWith("00"))
                    .ToList();
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


        /**
          * PODEŠAVANJA KROLA
          */
        private string GenerisiPodesavanjaKrolaJSON()
        {
            // ovde se generiše podatak za snimanje podešavanja o odabranim artiklima 

            string listaPodesavanjaProizvodaJSON = string.Empty;

            if (ListaOdabranihProizvodaZaKrol.Count > 0)
            {
                List<int> setovanjaProizvoda = new List<int>();

                for (int i = 0; i < ListaOdabranihProizvodaZaKrol.Count; i++)
                {
                    int idProizvoda = ListaOdabranihProizvodaZaKrol[i].Id;

                    if (idProizvoda > 0) setovanjaProizvoda.Add(idProizvoda);
                    else continue;
                }
                listaPodesavanjaProizvodaJSON = JsonConvert.SerializeObject(setovanjaProizvoda, Formatting.None);
            }
            return listaPodesavanjaProizvodaJSON;
        }
        
        private void SnimiPodesavanjaKrola()
        {
            // snimanje generisanih podešavanja krola o odabranim artiklima

            if (ListaOdabranihProizvodaZaKrol.Count == 0)
            {
                MessageBox.Show("Lista odabranih proizvoda je prazna.\r\nPodešavanja neće biti snimljena", "Nema odabranih proizvoda");
                return;
            }
            else
            {
                // pop up za naslov podesavanja
                frmKrolSetovanjePopUp popUp = new frmKrolSetovanjePopUp();
                popUp.ShowDialog();

                string naslovPodesavanja = popUp.naslovPodesavanja;
                if (string.IsNullOrEmpty(naslovPodesavanja)) return;

                string listaPodesavanjaProizvoda;

                listaPodesavanjaProizvoda = GenerisiPodesavanjaKrolaJSON();

                Podesavanja podesavanja = new Podesavanja()
                {
                    NazivPodesavanja = naslovPodesavanja,
                    OdabraniProizvodiIds = listaPodesavanjaProizvoda
                };
                try
                {
                    using (WebCeneModel db = new WebCeneModel())
                    {
                        db.Podesavanja.Add(podesavanja);
                        db.SaveChanges();
                        PuniListuPodesavanjaKrola();
                        PrikaziListuPodesavanjaKrola(ListaPodesavanjaKrola.Count -1);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Greška u snimanju podešavanja !", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private void PuniListuPodesavanjaKrola()
        {
            using (WebCeneModel db = new WebCeneModel())
            {
                ListaPodesavanjaKrola = db.Podesavanja
                    .ToList();
            }
        }

        private void PrikaziListuPodesavanjaKrola(int selectedIndex)
        {
            comboPodesavanjaKrola.DataSource = ListaPodesavanjaKrola;
            comboPodesavanjaKrola.DisplayMember = "NazivPodesavanja";
            comboPodesavanjaKrola.ValueMember = "Id";
            comboPodesavanjaKrola.SelectedIndex = selectedIndex;
        }

        private void UcitajPodesavanjaKrola(string podesavanjaJSON)
        {

            if (string.IsNullOrEmpty(podesavanjaJSON))
            {
                MessageBox.Show("Došlo je do greške u učitavanju podešavanja", "Greška u učitavanju");
                return;
            }

            // nova lista odabranih proizvoda učitaa iz podešavanja
            List<int> setovanjaProizvoda = new List<int>();

            // deserijalizacija učitanih podešavanja
            setovanjaProizvoda = JsonConvert.DeserializeObject<List<int>>(podesavanjaJSON);

            using (WebCeneModel db = new WebCeneModel())
            {

                    // pražnjenje postojeće liste odabranih proizvoda za krol
                    ListaOdabranihProizvodaZaKrol.Clear();

                    // kreiranje nove list odabranih proizvoda za krol
                    foreach (int item in setovanjaProizvoda)
                    {
                        Proizvod p = db.Proizvod
                            .Where(x => x.Id == item)
                            .First();
                        if (p != null) ListaOdabranihProizvodaZaKrol.Add(p);
                    }
                    PrikaziListuOdabranihArtikalaZaKrol();
            }
        }
        
        private void comboPodesavanjaKrola_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
     
            Podesavanja p = (Podesavanja)cmb.SelectedItem;
            int podesavanjaId;
            string podesavanjaJSON;

            if (p != null)
            {
                podesavanjaId = p.Id;
                podesavanjaJSON = p.OdabraniProizvodiIds;

                UcitajPodesavanjaKrola(podesavanjaJSON);
            }
            else return;
        }

        private void btnSnimiPodesavanjaKrola_Click(object sender, EventArgs e)
        {
            SnimiPodesavanjaKrola();
        }
        
        private void btnObrisiPodesavanjaKrola_Click(object sender, EventArgs e)
        {
            if (comboPodesavanjaKrola.SelectedIndex > -1)
            {
                Podesavanja p = (Podesavanja)comboPodesavanjaKrola.SelectedItem;
                if(p != null)
                {
                    DialogResult dr = MessageBox.Show("Odabrano podešavanje će biti obrisano.\r\nDa li želiš da nastaviš?", "Brisanje podešavanja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    switch (dr)
                    {                        
                        case DialogResult.Yes:
                            using (WebCeneModel db = new WebCeneModel())
                            {
                                try
                                {
                                    db.Entry(p).State = System.Data.Entity.EntityState.Deleted;
                                    db.SaveChanges();

                                    // čišćenje 
                                    // lista odabranih proizvoda
                                    ListaOdabranihProizvodaZaKrol.Clear();
                                    PrikaziListuOdabranihArtikalaZaKrol();
                                    
                                    // lista podešavanja krola
                                    PuniListuPodesavanjaKrola();
                                    PrikaziListuPodesavanjaKrola(-1);
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("Greška u brisanju podešavanja.", "Greška");
                                }
                            }
                            break;
                        case DialogResult.No:
                            return;
                        default:
                            break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Odaberi podešavanje koje želiš obrisati.", "Greška");
            }
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
                    MessageBox.Show("Da li želite da snimite rezultate krola?", "Snimanje podataka", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                                Cena = item.Cena,
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
                        string _katTrimmed = _ElKat.TrimEnd();
                        string _brendTrimmed = _Brend.TrimEnd();

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
            comboPodesavanjaKrola.SelectedIndex = -1;
        }

        private void contextOdabraniArtObrisiStavku_Click(object sender, EventArgs e)
        {
            BrisiOdabraneArtZaKrol();
            PrikaziListuOdabranihArtikalaZaKrol();
        }

        private void picFilter_Click(object sender, EventArgs e)
        {
            PonistiFilter();
            PrikaziListuProizvoda(ListaProizvoda);
        }

        
    }


}
