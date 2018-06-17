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

        public List<PodaciZaPrikaz> PodaciZaPrikaz { get; set; }

        public EWE_CENOVNIK(KonfigDobavljaca konfigDobavljaca, XmlDocument ucitaniXmlDocument)
        {
            PodaciZaPrikaz = new List<PodaciZaPrikaz>();

            GenerisiPodatkeZaPrikaz(konfigDobavljaca, ucitaniXmlDocument);
        }


    
        private void GenerisiPodatkeZaPrikaz(KonfigDobavljaca konfigDobavljaca, XmlDocument ucitaniXmlDocument)
        {
            List<PodaciZaPrikaz> podaciZaPrikaz = new List<PodaciZaPrikaz>();
           
            extNS.ewe.products ewe = new extNS.ewe.products();
            var serializer = new XmlSerializer(typeof(extNS.ewe.products));

            using (XmlReader reader = new XmlNodeReader(ucitaniXmlDocument))
            {
                ewe = (extNS.ewe.products)serializer.Deserialize(reader);
            }

            foreach (var item in ewe.product)
            {
                if (!(string.IsNullOrWhiteSpace(item.ean)))
                {

                    decimal cena = decimal.Zero;
                    bool isCena = decimal.TryParse(item.price_rebate, System.Globalization.NumberStyles.Any, new CultureInfo("en-US"), out cena);


                    decimal pmc = decimal.Zero;
                    bool isPmc = decimal.TryParse(item.recommended_retail_price, out pmc);

                    PodaciZaPrikaz podatakZaPrikaz = new PodaciZaPrikaz()
                    {
                        Barcode = item.ean,
                        Kolicina = 1,
                        Cena = cena * konfigDobavljaca.KeoficijentMarze,
                        PMC = pmc,
                        DatumUlistavanja = DateTime.Today,
                        PrimarniDobavljac = konfigDobavljaca.Naziv
                    };
                    podaciZaPrikaz.Add(podatakZaPrikaz);
                }
            }
            PodaciZaPrikaz = podaciZaPrikaz;
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
