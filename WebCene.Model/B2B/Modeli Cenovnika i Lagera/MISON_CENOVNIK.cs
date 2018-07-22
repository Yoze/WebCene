using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using extNS = WebCene.Model.B2B;

namespace WebCene.Model.B2B.mison
{

    public class MISON_CENOVNIK
    {

        public List<B2B_Results_RowItem> b2B_Results_RowItems { get; set; }

        public MISON_CENOVNIK(KonfigDobavljaca konfigDobavljaca, XmlDocument ucitaniXmlDocument)
        {
            b2B_Results_RowItems = new List<B2B_Results_RowItem>();

            GenerisiPodatkeZaPrikaz(konfigDobavljaca, ucitaniXmlDocument);
        }


        private void GenerisiPodatkeZaPrikaz(KonfigDobavljaca konfigDobavljaca, XmlDocument ucitaniXmlDocument)
        {
            List<B2B_Results_RowItem> podaciZaPrikaz = new List<B2B_Results_RowItem>();

            extNS.mison.Root misonCenovnik = new Root();


            var serializer = new XmlSerializer(typeof(extNS.mison.Root));
            using (XmlReader reader = new XmlNodeReader(ucitaniXmlDocument))
            {
                misonCenovnik = (Root)serializer.Deserialize(reader);
            }


            foreach (var item in misonCenovnik.Row)
            {
                if (!(string.IsNullOrWhiteSpace(item.barcod.ToString().TrimEnd())))
                {

                    B2B_Results_RowItem podatakZaPrikaz = new B2B_Results_RowItem()
                    {
                        Barcode = item.barcod.ToString().TrimEnd(),
                        Kolicina = item.kolicina,
                        Cena = item.VP__Cena_u_DIN,
                        PMC = item.PREPORU_ENA_MP_CENA,
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

        public byte kolicina { get; set; }

        public decimal VP__Cena_u_DIN { get; set; }

        public uint PREPORU_ENA_MP_CENA { get; set; }
    }







}
