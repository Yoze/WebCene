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


            var result = XMLHelper.Instance.DeserializeXmlResult(konfigDobavljaca, xmlResult);


            MessageBox.Show(FTPHelper.Instance.Test());
                        
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int idDobavljaca = 1; // Ewe

            KonfigDobavljaca konfigDobavljaca = DBHelper.Instance.GetKonfigDobavljaca(idDobavljaca);

            XmlDocument xmlResult = HTTPSHelper.Instance.GetXmlFromHttpRequest(konfigDobavljaca);

            // Error reading xml file from Ftp
            if (xmlResult == null) return;

            var result = XMLHelper.Instance.DeserializeXmlResult(konfigDobavljaca, xmlResult);

            MessageBox.Show(HTTPSHelper.Instance.Test());
        }

        private void btnWebService_Click(object sender, EventArgs e)
        {

            // web service

            KimTecWebServiceClient.Instance.CallWebService();



        }




    }
}
