using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebCene.Model.B2B;
using WebCene.Helper;
using System.Xml;
using System.Threading;

namespace WebCene.UI.Forms.B2B
{
    public partial class frmMainB2B : Form
    {

        private List<XmlRezultat> zbirniXml;


        public frmMainB2B()
        {
            InitializeComponent();
        }

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

        private void btnWebService_Click(object sender, EventArgs e)
        {

            // web service

            KimTecWebServiceClient.Instance.CallWebService();

            
        }

        private void btnLoadXmls_Click(object sender, EventArgs e)
        {

            // zbirni Xml rezultati za sve dobavljače
            zbirniXml = new List<XmlRezultat>();

            // Xml rezultat za jednog dobavljača
            List<XmlRezultat> pojedinacniXml;

            List<KonfigDobavljaca> listaKonfigDobavljaca = DBHelper.Instance.GetKonfigDobavljacaList();


            /** T E S T  ===>  učitava listaKonfigDobavljaca.Count - x dobavljača */
            listaKonfigDobavljaca.RemoveRange(0, listaKonfigDobavljaca.Count - 3);


            int redniBroj = 1;

            foreach (KonfigDobavljaca item in listaKonfigDobavljaca)
            {
                pojedinacniXml = new List<XmlRezultat>();

                
                // učitavanje podataka
                pojedinacniXml = UcitajXmlZaDobavljaca(item);
                bool isLoaded = pojedinacniXml.Count > 0 ? true : false;


                // prikaz statusa učitavanja
                StatusXmlUcitavanja status = new StatusXmlUcitavanja()
                {
                    Number = redniBroj,
                    Naziv = item.Naziv,
                    URL = item.URL,
                    isLoaded = isLoaded
                };                
                PrikaziStatusUcitavanja(status);
                redniBroj++;


                
                // dodavanje u listu rezultata učitavanja
                zbirniXml.AddRange(pojedinacniXml);
            }
            
            // prikaz svih rezultata učitavanja
            PrikaziSveUcitanePodatke(zbirniXml);

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
            dgvStatus.Refresh();
        }


        private List<XmlRezultat> UcitajXmlZaDobavljaca(KonfigDobavljaca konfigDobavljaca)
        {
            // učutavanje xml podataka za dobavljača

            List<XmlRezultat> result = new List<XmlRezultat>();

            switch (konfigDobavljaca.WebProtokol.TrimEnd())
            {
                case "ftp":
                    {
                        XmlDocument xmlResult = FTPHelper.Instance.GetXmlFileFromFtp(konfigDobavljaca);
                        result = XMLHelper.Instance.DeserializeXmlResult(konfigDobavljaca, xmlResult);
                        return result;
                    }                    

                case "http":
                    {
                        XmlDocument xmlResult = HTTPSHelper.Instance.GetXmlFromHttpRequest(konfigDobavljaca);
                        result = XMLHelper.Instance.DeserializeXmlResult(konfigDobavljaca, xmlResult);
                        return result;
                    }
                    

                case "webservice":
                    // TO DO
                    break;

                default:
                    break;
            }



            return result;
        }


    }
}
