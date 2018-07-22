using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using extNS = WebCene.Model.B2B;

namespace WebCene.Model.B2B._220BCenovnik
{
    public class _220B_CENOVNIK
    {

        public List<B2B_Results_RowItem> b2B_Results_RowItems { get; set; }

        public _220B_CENOVNIK(KonfigDobavljaca konfigDobavljaca, XmlDocument ucitaniXmlDocument)
        {
            b2B_Results_RowItems = new List<B2B_Results_RowItem>();

            GenerisiPodatkeZaPrikaz(konfigDobavljaca, ucitaniXmlDocument);
        }


        private void GenerisiPodatkeZaPrikaz(KonfigDobavljaca konfigDobavljaca, XmlDocument ucitaniXmlDocument)
        {
            List<B2B_Results_RowItem> podaciZaPrikaz = new List<B2B_Results_RowItem>();

            extNS._220BCenovnik.Root _220bCenovnik = new Root();


            var serializer = new XmlSerializer(typeof(extNS._220BCenovnik.Root));
            using (XmlReader reader = new XmlNodeReader(ucitaniXmlDocument))
            {
                _220bCenovnik = (Root)serializer.Deserialize(reader);
            }


            foreach (var item in _220bCenovnik.Row)
            {
                if (!(string.IsNullOrWhiteSpace(item.barcod.ToString().TrimEnd())))
                {

                    B2B_Results_RowItem podatakZaPrikaz = new B2B_Results_RowItem()
                    {
                        Barcode = item.barcod.ToString().TrimEnd(),
                        Kolicina = 0, // postoji lager
                        Cena = item.NNC,
                        PMC = item.PMC,
                        DatumUlistavanja = DateTime.Today,
                        PrimarniDobavljac = konfigDobavljaca.Naziv
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
    public partial class Root
    {

        [System.Xml.Serialization.XmlElementAttribute("Row")]
        public RootRow[] Row { get; set; }
    }


    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class RootRow
    {

        public ulong barcod { get; set; }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool barcodSpecified { get; set; }

        public decimal NNC { get; set; }

        public uint PMC { get; set; }
    }




}
