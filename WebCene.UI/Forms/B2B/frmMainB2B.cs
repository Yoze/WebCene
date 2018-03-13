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
using WebCene.Helper;


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
            string filePath = "ftp://elbraco@ftp.elbraco.rs/elvoxerg/erg.xml";

            FTPHelper.Instance.GetXmlFileFromFtp(filePath);



            MessageBox.Show(FTPHelper.Instance.Test());

            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            MessageBox.Show(HTTPSHelper.Instance.Test());
        }
    }
}
