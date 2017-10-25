using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using WebCene.Model;


namespace WebCene.UI.Kroleri
{
    public class EponudaKroler
    {

        //private List<EponudaRezultat> RezultatKrola { get; set; } // lista dobijenih rezultata za url

        private List<KrolStavke> KrolStavkeFullLista { get; set; } // sve rezultati krola

        private List<KrolStavke> KrolStavkePreciscenaLista { get; set; } // rezultati krola sa odabranim prodavcima
        private List<Prodavci> ListaProdavaca { get; set; }


        public bool EponudaStartKrol(Proizvod _proizvodZaKrol, int _krolGlavaId)
        {
            //RezultatKrola = new List<EponudaRezultat>();
            //List<KrolStavke> KrolStavkeLista = new List<KrolStavke>();


            ListaProdavaca = new List<Prodavci>();
            using (WebCeneModel db = new WebCeneModel())
            {
                ListaProdavaca = db.Prodavci.ToList();
            }


            // dokument url
            var url = _proizvodZaKrol.ShopmaniaURL;

            // dokument
            HtmlWeb destinationWebPage = new HtmlWeb();
            var htmlDocument = destinationWebPage.Load(url);

            // svi <tr>
            var tableRows = htmlDocument.DocumentNode.Descendants("tr");

            // lista <tr> nodova
            List<HtmlNode> listaTableRows = tableRows.ToList();

            int trsTotalElements = tableRows.Count();

            for (int i = 1; i < trsTotalElements; i++)
            {
                var tableRow = listaTableRows[i];

                // Prodavac alt
                string prodavac = tableRow.SelectSingleNode("td/a/img").GetAttributeValue("alt", "");

                // Datum ažuriranja cene
                //string datumAzuriranjaCene = tableRow.SelectSingleNode("td/div").InnerHtml;

                // Cena
                string cena = tableRow.SelectSingleNode("td/b").InnerHtml;



                /*  kompletan rezultat za pisanje u bazu */

                // id prodavca na osnovu alt atributa
                Prodavci prodavacAltToProdavacId =
                    ListaProdavaca
                    .Where(p => p.SMId == prodavac)
                    .First();

                int? prodavacId = null;

                if (prodavacAltToProdavacId != null)
                {
                    prodavacId = prodavacAltToProdavacId.Id;
                }


                KrolStavke krolStavka = new KrolStavke()
                {
                    KrolGlavaId = _krolGlavaId,
                    ProizvodId = _proizvodZaKrol.Id,
                    ProdavciId = prodavacId,
                    Cena = Convert.ToDecimal(cena)
                };

                KrolStavkeFullLista.Add(krolStavka);

            }

            return true;

            //return _krolStavkeLista;

        }


        //var cenaDatumAzuriranja = htmlDoc.DocumentNode.SelectSingleNode("//table[1]/tr[4]/td[3]/div");
        //var cena = htmlDoc.DocumentNode.SelectSingleNode("//table[1]/tr[4]/td[4]/b");

        //lblResult.Text = cena.InnerHtml + " datum: " + cenaDatumAzuriranja.InnerHtml;

        //private void KreirajListuProdavaca()
        //{
        //    //ListaProdavaca = new List<Prodavci>();

        //    //using (WebCeneModel db = new WebCeneModel())
        //    //{
        //    //    ListaProdavaca = db.Prodavci.ToList();
        //    //}
        //}

    }
}
