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
            int idDobavljaca = 2; // Vox

            XmlDocument xmlResult = FTPHelper.Instance.GetXmlFileFromFtp(DBHelper.Instance.GetKonfigDobavljaca(idDobavljaca));
            
            MessageBox.Show(FTPHelper.Instance.Test());
                        
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int idDobavljaca = 1; // Ewe

            XmlDocument xmlResult = HTTPSHelper.Instance.GetXmlFromHttpRequest(DBHelper.Instance.GetKonfigDobavljaca(idDobavljaca));

            MessageBox.Show(HTTPSHelper.Instance.Test());
        }





    }
}
