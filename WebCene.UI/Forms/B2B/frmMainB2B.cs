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
using WebCene.Model.B2B;
using WebCene.Helper;
using System.Xml;
using System.Threading;
using WebCene.Model.PIN_ServiceReference;
using WebCene.Model.CT_ServiceReference;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Xml.Serialization;

namespace WebCene.UI.Forms.B2B
{
    public partial class frmMainB2B : Form
    {
        // podaci koji se prikazuju u datagrid-u
        private List<PodaciZaPrikaz> SviPodaciZaPrikaz;


        public frmMainB2B()
        {
            InitializeComponent();

            SviPodaciZaPrikaz = new List<PodaciZaPrikaz>();
            PrikaziStatusUcitavanja("", true);
        }
        


        private void btnWebService_Click(object sender, EventArgs e)
        {

            // web service

       
            ///** PIN */
            //StockWebserviceClient pinServiceClient = new StockWebserviceClient("StockWebservicePort");

            ////var allItems = pinServiceClient.getAllItems("c794398a-732c-4d5e-b6a4-783eb1a268c0", 4, false);

            //b2BWebServiceDAO pinResults = pinServiceClient.getAllItems("c794398a-732c-4d5e-b6a4-783eb1a268c0", 4, false);


            //List<item> pinItems = pinResults.item.ToList();

            
            //pinServiceClient.Close();
                        

        }



        private void btnLoadXmls_Click(object sender, EventArgs e)
        {
            // Xml rezultat za jednog dobavljača
            List<PodaciZaPrikaz> podatakZaPrikaz;
            List<KonfigDobavljaca> konfiguracijeDobavljaca = DBHelper.Instance.PreuzmiSveKonfiguracijeDobavljaca();
            int redniBroj = 1;


            ObrisiPrikazStatusaUcitavanja();
            PrikaziStatusUcitavanja("Učitavanje konfiguracija ", true);
            //PrikaziPodatke(SviPodaciZaPrikaz);            

           
            

            foreach (KonfigDobavljaca konfiguracijaDobavljaca in konfiguracijeDobavljaca)
            {
                podatakZaPrikaz = new List<PodaciZaPrikaz>();

                // učitavanje podataka
                StatusUcitavanja statusUcitavanja = new StatusUcitavanja();
                try
                {
                    PrikaziStatusUcitavanja("Učitavanje podataka " + konfiguracijaDobavljaca.Naziv, true);

                    podatakZaPrikaz = XMLHelper.Instance.UcitajPodatkeZaPrikazIzXmlDocumentaZaDobavljaca(konfiguracijaDobavljaca);



                    statusUcitavanja = SetStatusUcitavanja(redniBroj, konfiguracijaDobavljaca.Naziv, konfiguracijaDobavljaca.URL, true);

                }
                catch (Exception)
                {
                    PrikaziStatusUcitavanja("Greška " + konfiguracijaDobavljaca.Naziv, true);

                    statusUcitavanja = SetStatusUcitavanja(redniBroj, konfiguracijaDobavljaca.Naziv, konfiguracijaDobavljaca.URL, false);
                    PrikaziStatusUcitavanja(statusUcitavanja);
                    redniBroj++;
                    continue;
                }

                PrikaziStatusUcitavanja(statusUcitavanja);
                redniBroj++;


                // dodavanje u listu rezultata učitavanja
                SviPodaciZaPrikaz.AddRange(podatakZaPrikaz);
            }

            // prikaz svih rezultata učitavanja
            PrikaziPodatke(SviPodaciZaPrikaz);

            PrikaziStatusUcitavanja("Završeno.", true);
        }


        public void PrikaziStatusUcitavanja(string text, bool visibility)
        {
            lblStatus.Text = text + " ...";
            lblStatus.Refresh();

            //lblStatus.Visible = visibility;

        }

        private void ObrisiPrikazStatusaUcitavanja()
        {
            // status label
            PrikaziStatusUcitavanja("", true);

            // status tabela
            dgvStatus.Rows.Clear();
            dgvStatus.Refresh();

        }

        private StatusUcitavanja SetStatusUcitavanja(int redniBroj, string nazivDobavljaca, string url, bool isLoaded)
        {
            // status učitavanja
            StatusUcitavanja status = new StatusUcitavanja()
            {
                Number = redniBroj,
                Naziv = nazivDobavljaca,
                URL = url,
                isLoaded = isLoaded
            };
            return status;
        }


        private void PrikaziPodatke(List<PodaciZaPrikaz> podaciZaPrikaz)
        {
            // prikaz podataka

            DataTable dt = Helpers.Instance.ListToDataTable<PodaciZaPrikaz>(podaciZaPrikaz);
            dgvZbirniXml.DataSource = dt;
        }


        private void PrikaziStatusUcitavanja(StatusUcitavanja status)
        {
            // prikaz statusa učitavanja 

            dgvStatus.Rows.Add(status.Number, status.Naziv, status.isLoaded);
            dgvStatus.ClearSelection();
            dgvStatus.Refresh();
        }






        #region OBSOLETE

        //private List<XmlRezultat> UcitajXmlZaDobavljaca(KonfigDobavljaca konfigDobavljaca)
        //{
        //    // učutavanje xml podataka za dobavljača

        //    List<XmlRezultat> result = new List<XmlRezultat>();

        //    switch (konfigDobavljaca.WebProtokol.TrimEnd())
        //    {
        //        case "ftp":
        //            {
        //                XmlDocument xmlResult = FTPHelper.Instance.GetXmlFileFromFtp(konfigDobavljaca);
        //                result = XMLHelper.Instance.DeserializeXmlResult(konfigDobavljaca, xmlResult);
        //                return result;
        //            }                    

        //        case "http":
        //            {
        //                XmlDocument xmlResult = HTTPSHelper.Instance.GetXmlFromHttpRequest(konfigDobavljaca);
        //                result = XMLHelper.Instance.DeserializeXmlResult(konfigDobavljaca, xmlResult);
        //                return result;
        //            }


        //        case "webservice":
        //            // TO DO
        //            break;

        //        default:
        //            break;
        //    }



        //    return result;
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            //int idDobavljaca = 3; 

            //KonfigDobavljaca konfigDobavljaca = DBHelper.Instance.GetKonfigDobavljaca(idDobavljaca);

            //XmlDocument xmlResult = FTPHelper.Instance.GetXmlFileFromFtp(konfigDobavljaca);

            //// Error reading xml file from Ftp
            //if (xmlResult == null) return;


            //List<XmlRezultat> result = XMLHelper.Instance.DeserializeXmlResult(konfigDobavljaca, xmlResult);


            //MessageBox.Show(FTPHelper.Instance.Test());

        }

        private void button2_Click(object sender, EventArgs e)
        {

            //int idDobavljaca = 1; // Ewe

            //KonfigDobavljaca konfigDobavljaca = DBHelper.Instance.GetKonfigDobavljaca(idDobavljaca);

            //XmlDocument xmlResult = HTTPSHelper.Instance.GetXmlFromHttpRequest(konfigDobavljaca);

            //// Error reading xml file from Ftp
            //if (xmlResult == null) return;

            //List<XmlRezultat> result = XMLHelper.Instance.DeserializeXmlResult(konfigDobavljaca, xmlResult);

            //MessageBox.Show(HTTPSHelper.Instance.Test());
        }


        #endregion

    }
}
