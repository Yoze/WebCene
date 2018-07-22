using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using extNS = WebCene.Model.B2B;

namespace WebCene.Model.B2B.gorenjeLager
{

    public class GORENJE_LAGER
    {
        public List<B2B_Results_RowItem> b2B_Results_RowItems { get; set; }


        public GORENJE_LAGER(KonfigDobavljaca konfigDobavljaca, XmlDocument ucitaniXmlDocument)
        {
            b2B_Results_RowItems = new List<B2B_Results_RowItem>();

            GenerisiPodatkeZaPrikaz(konfigDobavljaca, ucitaniXmlDocument);
        }


        private void GenerisiPodatkeZaPrikaz(KonfigDobavljaca konfigDobavljaca, XmlDocument ucitaniXmlDocument)
        {
            List<B2B_Results_RowItem> podaciZaPrikaz = new List<B2B_Results_RowItem>();

            extNS.gorenjeLager.Root gorenjeLager = new Root();


            var serializer = new XmlSerializer(typeof(extNS.gorenjeLager.Root));
            using (XmlReader reader = new XmlNodeReader(ucitaniXmlDocument))
            {
                gorenjeLager = (Root)serializer.Deserialize(reader); 
            }


            foreach (var item in gorenjeLager.Row)
            {
                if (!(string.IsNullOrWhiteSpace(item.barcode.ToString())))
                {

                    B2B_Results_RowItem podatakZaPrikaz = new B2B_Results_RowItem()
                    {
                        Barcode = item.barcode.ToString().TrimEnd(),
                        Kolicina = item.kolicina,
                        //Cena = item.price * konfigDobavljaca.KeoficijentMarze, 
                        //PMC = 0, //TO DO: kalkulacija PMC
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

        public string barcode { get; set; }

        public int kolicina { get; set; }
    }



}
