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
using System.ServiceModel;
using System.ServiceModel.Description;

namespace WebCene.UI.Forms.B2B
{
    public partial class frmMainB2B : Form
    {

        private List<XmlRezultat> zbirniXml;


        public frmMainB2B()
        {
            InitializeComponent();

            SetStatusLabel("", true);
        }


        //public static void Configure(ServiceConfiguration config)
        //{

        //    // Configuring WCF Services in Code

        //    ServiceEndpoint se = new ServiceEndpoint(new ContractDescription("PIN_ServiceReference.StockWebservice"), new BasicHttpsBinding(), new EndpointAddress("https://partner.pinsoft.com/StockWebservice/StockWebservice"));

        //    /*  ServiceModel Metadata Utility Tool (Svcutil.exe) 
        //     *  
        //     *  https://docs.microsoft.com/en-us/dotnet/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe
        //     *  */





        //  }




        private void btnWebService_Click(object sender, EventArgs e)
        {

            // web service

            //KimTecWebServiceClient.Instance.CallWebService();


            //StockWebserviceClient pinServiceClient = new StockWebserviceClient("StockWebservicePort", "https://partner.pinsoft.com/StockWebservice/StockWebservice");


            StockWebserviceClient pinServiceClient = new StockWebserviceClient();

            var allItems = pinServiceClient.getAllItems("c794398a-732c-4d5e-b6a4-783eb1a268c0", 4, true);

            pinServiceClient.Close();


            /**
            'How to: Configure a Basic Windows Communication Foundation Client'
            https://docs.microsoft.com/en-us/dotnet/framework/wcf/how-to-configure-a-basic-wcf-client

             'How to: Use a Windows Communication Foundation Client'
             https://docs.microsoft.com/en-us/dotnet/framework/wcf/how-to-use-a-wcf-client
             */

        }

        private void btnLoadXmls_Click(object sender, EventArgs e)
        {
            ClearAll();


            SetStatusLabel("Učitavanje konfiguracija ", true);


            // zbirni Xml rezultati za sve dobavljače
            zbirniXml = new List<XmlRezultat>();

            // clear dgb
            PrikaziSveUcitanePodatke(zbirniXml);

            // Xml rezultat za jednog dobavljača
            List<XmlRezultat> pojedinacniXml;

            List<KonfigDobavljaca> listaKonfigDobavljaca = DBHelper.Instance.GetKonfigDobavljacaList();

            ///** T E S T  ===>  učitava listaKonfigDobavljaca.Count - x dobavljača */
            //listaKonfigDobavljaca.RemoveRange(0, listaKonfigDobavljaca.Count - 7);


            int redniBroj = 1;

            foreach (KonfigDobavljaca item in listaKonfigDobavljaca)
            {
                pojedinacniXml = new List<XmlRezultat>();

                SetStatusLabel("Povezivanje na server ", true);

                // učitavanje podataka
                StatusXmlUcitavanja status = new StatusXmlUcitavanja();
                try
                {
                    SetStatusLabel("Učitavanje podataka " + item.Naziv, true);

                    pojedinacniXml = XMLHelper.Instance.UcitajXmlZaDobavljaca(item);
                    status = SetStatusUcitavanja(redniBroj, item.Naziv, item.URL, true);

                    //bool isLoaded = pojedinacniXml.Count > 0 ? true : false;
                }
                catch (Exception)
                {
                    SetStatusLabel("Greška " + item.Naziv, true);

                    status = SetStatusUcitavanja(redniBroj, item.Naziv, item.URL, false);
                    PrikaziStatusUcitavanja(status);
                    redniBroj++;
                    continue;
                }

                PrikaziStatusUcitavanja(status);
                redniBroj++;


                // dodavanje u listu rezultata učitavanja
                zbirniXml.AddRange(pojedinacniXml);
            }

            // prikaz svih rezultata učitavanja
            PrikaziSveUcitanePodatke(zbirniXml);

            SetStatusLabel("Završeno.", true);
        }


        public void SetStatusLabel(string text, bool visibility)
        {
            lblStatus.Text = text + " ...";
            lblStatus.Refresh();

            //lblStatus.Visible = visibility;

        }

        private void ClearAll()
        {
            // status label
            SetStatusLabel("", true);

            // status tabela
            dgvStatus.Rows.Clear();
            dgvStatus.Refresh();

        }

        private StatusXmlUcitavanja SetStatusUcitavanja(int redniBroj, string nazivDobavljaca, string url, bool isLoaded)
        {
            // status učitavanja
            StatusXmlUcitavanja status = new StatusXmlUcitavanja()
            {
                Number = redniBroj,
                Naziv = nazivDobavljaca,
                URL = url,
                isLoaded = isLoaded
            };
            return status;
        }


        private void PrikaziSveUcitanePodatke(List<XmlRezultat> zbirniXml)
        {
            // prikaz podataka

            DataTable dt = Helpers.Instance.ListToDataTable<XmlRezultat>(zbirniXml);
            dgvZbirniXml.DataSource = dt;
        }


        private void PrikaziStatusUcitavanja(StatusXmlUcitavanja status)
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
