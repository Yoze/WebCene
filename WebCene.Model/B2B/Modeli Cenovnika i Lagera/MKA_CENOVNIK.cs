using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using extNS = WebCene.Model.B2B;

namespace WebCene.Model.B2B.mkaCenovnik
{

    public class MKA_CENOVNIK
    {

        public List<B2B_Results_RowItem> b2B_Results_RowItems { get; set; }

        public MKA_CENOVNIK(KonfigDobavljaca konfigDobavljaca, LoadedXmlDocument ucitaniXmlDocument)
        {
            b2B_Results_RowItems = new List<B2B_Results_RowItem>();

            GenerisiPodatkeZaPrikaz(konfigDobavljaca, ucitaniXmlDocument);
        }


        private void GenerisiPodatkeZaPrikaz(KonfigDobavljaca konfigDobavljaca, LoadedXmlDocument ucitaniXmlDocument)
        {
            List<B2B_Results_RowItem> podaciZaPrikaz = new List<B2B_Results_RowItem>();

            Dokument mkaCenovnik = new Dokument();


            var serializer = new XmlSerializer(typeof(extNS.mkaCenovnik.Dokument));
            using (XmlReader reader = new XmlNodeReader(ucitaniXmlDocument.LoadedXmlDocumentItem))
            {
                mkaCenovnik = (Dokument)serializer.Deserialize(reader);
            }


            foreach (var item in mkaCenovnik.Stavke)
            {
                if (!(string.IsNullOrWhiteSpace(item.BarKod.ToString().TrimEnd())))
                {

                    B2B_Results_RowItem podatakZaPrikaz = new B2B_Results_RowItem()
                    {
                        Barcode = item.BarKod.ToString().TrimEnd(),
                        Kolicina = (int)item.Kolicina,
                        NNC = item.CenaVP, // pomnožiti VP cenu sa kursom evra 
                        PMC = item.CenaMP,
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
    public partial class Dokument
    {

        public string Tip { get; set; }

        public decimal Verzija { get; set; }

        [System.Xml.Serialization.XmlArrayItemAttribute("Stavka", IsNullable = false)]
        public DokumentStavka[] Stavke { get; set; }
    }

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DokumentStavka
    {

        public string Vrsta { get; set; }

        public string Naziv { get; set; }

        public string ArtID { get; set; }

        public decimal BarKod { get; set; }

        public string JM { get; set; }

        public decimal Kolicina { get; set; }

        public decimal CenaVP { get; set; }

        public decimal CenaMP { get; set; }

        public string Valuta { get; set; }

        public decimal PorezProc { get; set; }

        public string Proizvodjac { get; set; }
    }







}
