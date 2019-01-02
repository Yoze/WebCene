using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using extNS = WebCene.Model.B2B;

namespace WebCene.Model.B2B.ewe
{

    public class EWE_CENOVNIK
    {

        public List<B2B_Results_RowItem> b2B_Results_RowItems { get; set; }

        public EWE_CENOVNIK(KonfigDobavljaca konfigDobavljaca, LoadedXmlDocument ucitaniXmlDocument)
        {
            b2B_Results_RowItems = new List<B2B_Results_RowItem>();

            GenerisiPodatkeZaPrikaz(konfigDobavljaca, ucitaniXmlDocument);
        }


    
        private void GenerisiPodatkeZaPrikaz(KonfigDobavljaca konfigDobavljaca, LoadedXmlDocument ucitaniXmlDocument)
        {
            List<B2B_Results_RowItem> podaciZaPrikaz = new List<B2B_Results_RowItem>();
           
            extNS.ewe.products ewe = new extNS.ewe.products();
            var serializer = new XmlSerializer(typeof(extNS.ewe.products));

            using (XmlReader reader = new XmlNodeReader(ucitaniXmlDocument.LoadedXmlDocumentItem))
            {
                ewe = (extNS.ewe.products)serializer.Deserialize(reader);
            }

            foreach (var item in ewe.product)
            {
                if (ModelHelper.Instance.IsValidBarcode(item.ean))
                {
                    /*
                     4. EWE
	                    - price_rebate (NNC)
	                    - recommended_retail_price -> 
	
		                    if (recommended_retail_price) PMC == recommended_retail_price
		                    else {
			                    PMC = price_rebate *1.2 * profile.koefMarze;
		                    }
	                    Ewe.koefMarze = 1.1;
                     */

                    //  Kolicina
                    int kolicina = 1;

                    // NNC
                    bool isCena = double.TryParse(item.price_rebate, System.Globalization.NumberStyles.Any, new CultureInfo("en-US"), out  double nnc);


                    // PMC
                    bool isPmc = double.TryParse(item.recommended_retail_price, out double pmc);
                    //pmc = ( isPmc && pmc > 0 ) ? pmc : nnc * decimal.Multiply( 1.2m, konfigDobavljaca.KeoficijentMarze );


                    B2B_Results_RowItem podatakZaPrikaz = new B2B_Results_RowItem()
                    {
                        Barcode = item.ean,
                        Kolicina = kolicina,
                        NNC = ModelHelper.Instance.CalculateNNC(nnc, konfigDobavljaca),
                        PMC = 0, //TO DO: kalkulacija PMC
                        DatumUlistavanja = DateTime.Today,
                        PrimarniDobavljac = konfigDobavljaca.Naziv,
                        CenovnikDatum = ucitaniXmlDocument.XmlLastModified,
                        LagerDatum = ucitaniXmlDocument.XmlLastModified
                        
                    };
                    podaciZaPrikaz.Add(podatakZaPrikaz);
                }
            }
            b2B_Results_RowItems = podaciZaPrikaz;
        }

    }



    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class products
    {

        [System.Xml.Serialization.XmlElementAttribute("product")]
        public productsProduct[] product { get; set; }
    }

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class productsProduct
    {

        public string id { get; set; }

        public string manufacturer { get; set; }

        public string name { get; set; }

        public string category { get; set; }

        public string subcategory { get; set; }

        public string price { get; set; }

        public string price_rebate { get; set; }

        public string vat { get; set; }

        public string ean { get; set; }

        public string recommended_retail_price { get; set; }
    }





}
