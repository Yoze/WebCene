using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using extNS = WebCene.Model.B2B;

namespace WebCene.Model.B2B.comtrade
{
    public class COMTRADE_CENOVNIK
    {
        public List<B2B_Results_RowItem> b2B_Results_RowItems { get; set; }


        public COMTRADE_CENOVNIK(KonfigDobavljaca konfigDobavljaca, LoadedXmlDocument ucitaniXmlDocument)
        {
            b2B_Results_RowItems = new List<B2B_Results_RowItem>();

            GenerisiPodatkeZaPrikaz(konfigDobavljaca, ucitaniXmlDocument);
        }


        private void GenerisiPodatkeZaPrikaz(KonfigDobavljaca konfigDobavljaca, LoadedXmlDocument ucitaniXmlDocument)
        {
            List<B2B_Results_RowItem> podaciZaPrikaz = new List<B2B_Results_RowItem>();

            extNS.comtrade.ArrayOfCTPRODUCT comtrade = new extNS.comtrade.ArrayOfCTPRODUCT();
            var serializer = new XmlSerializer(typeof(extNS.comtrade.ArrayOfCTPRODUCT));

            using (XmlReader reader = new XmlNodeReader(ucitaniXmlDocument.LoadedXmlDocumentItem))
            {
                comtrade = (extNS.comtrade.ArrayOfCTPRODUCT)serializer.Deserialize(reader);
            }

            foreach (var item in comtrade.CTPRODUCT)
            {
                if (!string.IsNullOrEmpty(item.BARCODE.ToString()))
                {

                    bool isnabavnaCena = double.TryParse(item.PRICE, out double nabavnaCena);

                    bool isPpc = double.TryParse(item.RETAILPRICE, out double ppc);

                    bool isExchangeRate = double.TryParse(item.EUR_ExchangeRate, out double exchangeRate);


                    B2B_Results_RowItem podatakZaPrikaz = new B2B_Results_RowItem()
                    {
                        Barcode = item.BARCODE.ToString().TrimEnd(),
                        Kolicina = item.QTTYINSTOCK,
                        NNC = nabavnaCena * exchangeRate,
                        PMC = 0,
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
    public partial class ArrayOfCTPRODUCT
    {

        [System.Xml.Serialization.XmlElementAttribute("CTPRODUCT")]
        public ArrayOfCTPRODUCTCTPRODUCT[] CTPRODUCT { get; set; }
    }

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ArrayOfCTPRODUCTCTPRODUCT
    {

        public object ExtensionData { get; set; }

        public string CODE { get; set; }

        public string PRODUCTGROUPCODE { get; set; }

        public string NAME { get; set; }

        public string MANUFACTURER { get; set; }

        public string MANUFACTURERCODE { get; set; }

        public byte QTTYINSTOCK { get; set; }

        public byte TAX { get; set; }

        public string PRICE { get; set; }

        public string RETAILPRICE { get; set; }

        public string SHORT_DESCRIPTION { get; set; }

        public string WARRANTY { get; set; }

        public string EUR_ExchangeRate { get; set; }

        public string BARCODE { get; set; }

        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public string[] IMAGE_URLS { get; set; }

        [System.Xml.Serialization.XmlArrayItemAttribute("ProductAttribute", IsNullable = false)]
        public ArrayOfCTPRODUCTCTPRODUCTProductAttribute[] ATTRIBUTES { get; set; }
    }

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ArrayOfCTPRODUCTCTPRODUCTProductAttribute
    {

        public object ExtensionData { get; set; }

        public string AttributeValue { get; set; }

        public string AttributeCode { get; set; }
    }




}
