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

            ePonudaGetPrice();

        }


        public void ePonudaGetPrice()
        {
            // eponuda

            var html =
                @"http://www.eponuda.com/laptopovi/asus-x541na-go020-15-6-intel-n3350-dual-core-1-1ghz-2-4ghz-4gb-1tb-odd-crno-zlatni-laptop-cena-411347";

            // dokument
            HtmlWeb web = new HtmlWeb();
            var doc = web.Load(html);
            
            // lista filtriranih podataka iz tabele
            List<SM_DobijeniPodaci> DobijeniPodaci = new List<SM_DobijeniPodaci>();

            // svi <tr>
            var trs = doc.DocumentNode.Descendants("tr");
            
           

            //foreach (var tr in trs)
            //{
            //    // Prodavac
            //    string prodavac = tr.SelectSingleNode("//td[1]/a/img").GetAttributeValue("alt", "");
                
            //    // Datum ažuriranja cene
            //    string datumAzuriranjaCene = tr.SelectSingleNode("//td[3]/div").InnerHtml;
                
            //    // Cena
            //    string cena = tr.SelectSingleNode("//td[4]/b").InnerHtml;

            //    SM_DobijeniPodaci dobijeniPodaci = new SM_DobijeniPodaci()
            //    {
            //        Prodavac = prodavac,
            //        DatumAzuriranjaCene = datumAzuriranjaCene,
            //        Cena = cena
            //    };

            //    DobijeniPodaci.Add(dobijeniPodaci);                

            //}

            List<HtmlNode> listaTR = trs.ToList();

            int trsTotalElements = trs.Count();

            for (int i = 1; i < trsTotalElements; i++)
            {
                var tr = listaTR[i];

                //Prodavac
                string prodavac = tr.SelectSingleNode("td/a/img").GetAttributeValue("alt", "");

                // Datum ažuriranja cene
                string datumAzuriranjaCene = tr.SelectSingleNode("td/div").InnerHtml;

                // Cena
                string cena = tr.SelectSingleNode("td/b").InnerHtml;

                SM_DobijeniPodaci dobijeniPodaci = new SM_DobijeniPodaci()
                {
                    Prodavac = prodavac,
                    DatumAzuriranjaCene = datumAzuriranjaCene,
                    Cena = cena
                };

                DobijeniPodaci.Add(dobijeniPodaci);
            }

            string message = string.Empty;
            foreach (var item in DobijeniPodaci)
            {
                message += "Prodavac: " + item.Prodavac + " Datum:" + item.DatumAzuriranjaCene + " Cena:" + item.Cena + "\n";
            }

            MessageBox.Show(message);



            // prolaz kroz tr tabele
            //for (int tr = 1 ; tr < tableBody.ChildNodes.Count; tr ++)
            //{
            //    string prodavac = tableBody.ChildNodes[tr].InnerHtml;

            //    SM_DobijeniPodaci dobijeniPodatak = new SM_DobijeniPodaci()
            //    {

            //    };


            //}


            // petlja za prolaz kroz nodove tr




            //var cenaDatumAzuriranja = htmlDoc.DocumentNode.SelectSingleNode("//table[1]/tr[4]/td[3]/div");
            //var cena = htmlDoc.DocumentNode.SelectSingleNode("//table[1]/tr[4]/td[4]/b");

            //lblResult.Text = cena.InnerHtml + " datum: " + cenaDatumAzuriranja.InnerHtml;

        }



    }
}
