using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using extNS = WebCene.Model.B2B;

namespace WebCene.Model.B2B.erg
{

    public class ERG_CENOVNIK
    {

        public List<PodaciZaPrikaz> PodaciZaPrikaz { get; set; }


        public ERG_CENOVNIK(KonfigDobavljaca konfigDobavljaca, XmlDocument ucitaniXmlDocument)
        {
            PodaciZaPrikaz = new List<PodaciZaPrikaz>();

            GenerisiPodatkeZaPrikaz(konfigDobavljaca, ucitaniXmlDocument);
        }

        private void GenerisiPodatkeZaPrikaz(KonfigDobavljaca konfigDobavljaca, XmlDocument ucitaniXmlDocument)
        {
            List<PodaciZaPrikaz> podaciZaPrikaz = new List<PodaciZaPrikaz>();

            extNS.erg.ITEMS erg = new extNS.erg.ITEMS();
            var serializer = new XmlSerializer(typeof(extNS.ewe.products));

            using (XmlReader reader = new XmlNodeReader(ucitaniXmlDocument))
            {
                erg = (extNS.erg.ITEMS)serializer.Deserialize(reader);
            }

            foreach (var item in erg.ITEM)
            {
                if (!(string.IsNullOrWhiteSpace(item.barcode)))
                {

                    //decimal cena = decimal.Zero;
                    //bool isCena = decimal.TryParse(item.price, System.Globalization.NumberStyles.Any, new CultureInfo("en-US"), out cena);


                    //decimal pmc = decimal.Zero;
                    //bool isPmc = decimal.TryParse(item.recommended_retail_price, out pmc);

                    int kolicina = 0;
                    bool isKolicina = Int32.TryParse(item.stock, out kolicina);


                    PodaciZaPrikaz podatakZaPrikaz = new PodaciZaPrikaz()
                    {
                        Barcode = item.barcode,
                        Kolicina = kolicina,
                        Cena = item.price * konfigDobavljaca.KeoficijentMarze, // da li je ovo nabavna cena ?
                        PMC = 0, //TO DO: kalkulacija PMC
                        DatumUlistavanja = DateTime.Today,
                        PrimarniDobavljac = konfigDobavljaca.Naziv
                    };
                    podaciZaPrikaz.Add(podatakZaPrikaz);
                }
            }
            PodaciZaPrikaz = podaciZaPrikaz;
        }



    }

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class ITEMS
    {

        private ITEMSITEM[] iTEMField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ITEM")]
        public ITEMSITEM[] ITEM
        {
            get
            {
                return this.iTEMField;
            }
            set
            {
                this.iTEMField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ITEMSITEM
    {

        /// <remarks/>
        public string id { get; set; }

        /// <remarks/>
        public string name { get; set; }

        /// <remarks/>
        public string barcode { get; set; }

        /// <remarks/>
        public object part_no { get; set; }

        /// <remarks/>
        public object image_url { get; set; }

        /// <remarks/>
        public string stock { get; set; }

        /// <remarks/>
        public decimal price { get; set; }

        /// <remarks/>
        public object currency { get; set; }

        /// <remarks/>
        public string category { get; set; }

        /// <remarks/>
        public string category2 { get; set; }
    }



}






