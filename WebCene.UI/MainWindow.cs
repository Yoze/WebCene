using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace WebCene.UI
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnUcitajHTML_Click(object sender, EventArgs e)
        {
            // eponuda

            var html =
                @"http://www.eponuda.com/laptopovi/asus-x541na-go020-15-6-intel-n3350-dual-core-1-1ghz-2-4ghz-4gb-1tb-odd-crno-zlatni-laptop-cena-411347";

            
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(html);


            var cenaDatumAzuriranja = htmlDoc.DocumentNode.SelectSingleNode("//table[1]/tr[4]/td[3]/div");
            var cena = htmlDoc.DocumentNode.SelectSingleNode("//table[1]/tr[4]/td[4]/b");

            lblResult.Text = cena.InnerHtml + " datum: " + cenaDatumAzuriranja.InnerHtml;

        }
    }
}
