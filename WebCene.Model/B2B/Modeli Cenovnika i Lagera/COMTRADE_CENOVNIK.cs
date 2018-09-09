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

                    decimal nabavnaCena = decimal.Zero;
                    bool isnabavnaCena = decimal.TryParse(item.PRICE, out nabavnaCena);

                    decimal ppc = decimal.Zero;
                    bool isPpc = decimal.TryParse(item.RETAILPRICE, out ppc);

                    decimal exchangeRate = decimal.Zero;
                    bool isExchangeRate = decimal.TryParse(item.EUR_ExchangeRate, out exchangeRate);


                    B2B_Results_RowItem podatakZaPrikaz = new B2B_Results_RowItem()
                    {
                        Barcode = item.BARCODE.ToString().TrimEnd(),
                        Kolicina = item.QTTYINSTOCK,
                        NNC = nabavnaCena * exchangeRate * 1.2m,
                        PMC = ppc * exchangeRate * konfigDobavljaca.KeoficijentMarze,
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




    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class ArrayOfCTPRODUCT
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CTPRODUCT")]
        public ArrayOfCTPRODUCTCTPRODUCT[] CTPRODUCT { get; set; }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ArrayOfCTPRODUCTCTPRODUCT
    {

        /// <remarks/>
        public object ExtensionData { get; set; }

        /// <remarks/>
        public string CODE { get; set; }

        /// <remarks/>
        public string PRODUCTGROUPCODE { get; set; }

        /// <remarks/>
        public string NAME { get; set; }

        /// <remarks/>
        public string MANUFACTURER { get; set; }

        /// <remarks/>
        public string MANUFACTURERCODE { get; set; }

        /// <remarks/>
        public byte QTTYINSTOCK { get; set; }

        /// <remarks/>
        public byte TAX { get; set; }

        /// <remarks/>
        public string PRICE { get; set; }

        /// <remarks/>
        public string RETAILPRICE { get; set; }

        /// <remarks/>
        public string SHORT_DESCRIPTION { get; set; }

        /// <remarks/>
        public string WARRANTY { get; set; }

        /// <remarks/>
        public string EUR_ExchangeRate { get; set; }

        /// <remarks/>
        public string BARCODE { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
        public string[] IMAGE_URLS { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ProductAttribute", IsNullable = false)]
        public ArrayOfCTPRODUCTCTPRODUCTProductAttribute[] ATTRIBUTES { get; set; }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ArrayOfCTPRODUCTCTPRODUCTProductAttribute
    {

        /// <remarks/>
        public object ExtensionData { get; set; }

        /// <remarks/>
        public string AttributeValue { get; set; }

        /// <remarks/>
        public string AttributeCode { get; set; }
    }




}
