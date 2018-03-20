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
        public frmMainB2B()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int idDobavljaca = 3; 

            KonfigDobavljaca konfigDobavljaca = DBHelper.Instance.GetKonfigDobavljaca(idDobavljaca);

            XmlDocument xmlResult = FTPHelper.Instance.GetXmlFileFromFtp(konfigDobavljaca);

            // Error reading xml file from Ftp
            if (xmlResult == null) return;


            List<XmlRezultat> result = XMLHelper.Instance.DeserializeXmlResult(konfigDobavljaca, xmlResult);


            MessageBox.Show(FTPHelper.Instance.Test());
                        
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int idDobavljaca = 1; // Ewe

            KonfigDobavljaca konfigDobavljaca = DBHelper.Instance.GetKonfigDobavljaca(idDobavljaca);

            XmlDocument xmlResult = HTTPSHelper.Instance.GetXmlFromHttpRequest(konfigDobavljaca);

            // Error reading xml file from Ftp
            if (xmlResult == null) return;

            List<XmlRezultat> result = XMLHelper.Instance.DeserializeXmlResult(konfigDobavljaca, xmlResult);

            MessageBox.Show(HTTPSHelper.Instance.Test());
        }

        private void btnWebService_Click(object sender, EventArgs e)
        {

            // web service

            KimTecWebServiceClient.Instance.CallWebService();

            
        }

        private void btnLoadXmls_Click(object sender, EventArgs e)
        {

            List<KonfigDobavljaca> listaKonfigDobavljaca = DBHelper.Instance.GetKonfigDobavljacaList();

            int redniBroj = 1;

            foreach (KonfigDobavljaca item in listaKonfigDobavljaca)
            {
                StatusXmlUcitavanja status = new StatusXmlUcitavanja()
                {
                    Number = redniBroj,
                    Naziv = item.Naziv,
                    URL = item.URL,
                    isLoaded = true
                };

                PrikaziStatusUcitavanja(status);

                redniBroj++;

               
            }
        }



        private void PrikaziStatusUcitavanja(StatusXmlUcitavanja status)
        {
          
            dgvStatus.Rows.Add(status.Number, status.Naziv, status.isLoaded);

        }



    }
}
