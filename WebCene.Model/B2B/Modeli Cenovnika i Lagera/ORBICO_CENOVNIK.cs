using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using extNS = WebCene.Model.B2B;


namespace WebCene.Model.B2B.orbico
{

    public class ORBICO_CENOVNIK
    {

        public List<B2B_Results_RowItem> b2B_Results_RowItems { get; set; }


        public ORBICO_CENOVNIK(KonfigDobavljaca konfigDobavljaca, LoadedXmlDocument ucitaniXmlDocument)
        {
            b2B_Results_RowItems = new List<B2B_Results_RowItem>();

            GenerisiPodatkeZaPrikaz(konfigDobavljaca, ucitaniXmlDocument);
        }


        private void GenerisiPodatkeZaPrikaz(KonfigDobavljaca konfigDobavljaca, LoadedXmlDocument ucitaniXmlDocument)
        {
            List<B2B_Results_RowItem> podaciZaPrikaz = new List<B2B_Results_RowItem>();

            extNS.orbico.Items orbicoCenovnik = new Items();


            var serializer = new XmlSerializer(typeof(extNS.orbico.Items));
            using (XmlReader reader = new XmlNodeReader(ucitaniXmlDocument.LoadedXmlDocumentItem))
            {
                orbicoCenovnik = (Items)serializer.Deserialize(reader);
            }


            foreach (var item in orbicoCenovnik.Item)
            {
                if (!(string.IsNullOrWhiteSpace(item.ean.ToString().TrimEnd())))
                {
                    // price rebate
                    decimal priceRebate = decimal.Zero;
                    bool isPriceRebate = decimal.TryParse(item.price_rebate, out priceRebate);

                    // price
                    decimal price = decimal.Zero;
                    bool isPrice = decimal.TryParse(item.price, out price);

                    B2B_Results_RowItem podatakZaPrikaz = new B2B_Results_RowItem()
                    {
                        Barcode = item.ean.ToString().TrimEnd(),
                        Kolicina = item.qty, 
                        NNC = priceRebate,
                        PMC = price,
                        DatumUlistavanja = DateTime.Today,
                        PrimarniDobavljac = konfigDobavljaca.Naziv,
                        CenovnikDatum = ucitaniXmlDocument.XmlLastModified
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
    public partial class Items
    {

        [System.Xml.Serialization.XmlElementAttribute("Item")]
        public ItemsItem[] Item { get; set; }
    }

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ItemsItem
    {

        public string id { get; set; }

        public string manufacturer { get; set; }

        public string name { get; set; }

        public string category { get; set; }

        public string subcategory { get; set; }

        public string price { get; set; }

        public string price_rebate { get; set; }

        public string vat { get; set; }

        public ushort qty { get; set; }

         public string ean { get; set; }
    }











}
