using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using extNS = WebCene.Model.B2B;

namespace WebCene.Model.B2B.bosch
{

    public class BOSCH_CENOVNIK
    {
        public List<B2B_Results_RowItem> b2B_Results_RowItems { get; set; }

        public BOSCH_CENOVNIK(KonfigDobavljaca konfigDobavljaca, LoadedXmlDocument ucitaniXmlDocument)
        {
            b2B_Results_RowItems = new List<B2B_Results_RowItem>();

            GenerisiPodatkeZaPrikaz(konfigDobavljaca, ucitaniXmlDocument);
        }


        private void GenerisiPodatkeZaPrikaz(KonfigDobavljaca konfigDobavljaca, LoadedXmlDocument ucitaniXmlDocument)
        {
            List<B2B_Results_RowItem> podaciZaPrikaz = new List<B2B_Results_RowItem>();

            extNS.bosch.izdelki bosch = new extNS.bosch.izdelki();
            var serializer = new XmlSerializer(typeof(extNS.bosch.izdelki));

            using (XmlReader reader = new XmlNodeReader(ucitaniXmlDocument.LoadedXmlDocumentItem))
            {
                bosch = (izdelki)serializer.Deserialize(reader);
            }

            foreach (var item in bosch.izdelek)
            {
                if (! string.IsNullOrEmpty(item.ean.ToString()))
                {
                    /**
                    cena     -> Vaša nabavna cena.
                    ppc      -> Tako zvana cena za trgovaca. Cena koja je osnova za rabate. Nadam se da imate mogućnost koristiti ovo
                    zaloga   -> Lager; stanje zalihe.
                    davek    -> % poreza.
                     */

                    bool isnabavnaCena = double.TryParse(item.cena, out double nabavnaCena);

                    bool isPpc = double.TryParse(item.ppc, out double ppc);

                    B2B_Results_RowItem podatakZaPrikaz = new B2B_Results_RowItem()
                    {
                        Barcode = item.ean.ToString().TrimEnd(),
                        Kolicina = item.zaloga,
                        NNC = ModelHelper.Instance.CalculateNNC(ppc, konfigDobavljaca), 
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
    public partial class izdelki
    {

        [System.Xml.Serialization.XmlElementAttribute("izdelek")]
        public izdelkiIzdelek[] izdelek { get; set; }
    }


    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class izdelkiIzdelek
    {

        public string sifra { get; set; }

        public string naziv { get; set; }

        public string cena { get; set; }

        public byte zaloga { get; set; }

        public object rabat { get; set; }

        public string ppc { get; set; }

        public ulong ean { get; set; }

        public byte davek { get; set; }

        public object opis { get; set; }

        public uint bruto_teza { get; set; }

        public ushort sirina { get; set; }

        public ushort visina { get; set; }

        public ushort globina { get; set; }
    }




}
