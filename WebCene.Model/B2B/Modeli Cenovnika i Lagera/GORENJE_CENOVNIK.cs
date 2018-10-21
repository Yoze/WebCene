using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using extNS = WebCene.Model.B2B;

namespace WebCene.Model.B2B.gorenje
{

    public class GORENJE_CENOVNIK
    {
        public List<B2B_Results_RowItem> b2B_Results_RowItems { get; set; }


        public GORENJE_CENOVNIK(KonfigDobavljaca konfigDobavljaca, LoadedXmlDocument ucitaniXmlDocument)
        {
            b2B_Results_RowItems = new List<B2B_Results_RowItem>();

            GenerisiPodatkeZaPrikaz(konfigDobavljaca, ucitaniXmlDocument);
        }


        private void GenerisiPodatkeZaPrikaz(KonfigDobavljaca konfigDobavljaca, LoadedXmlDocument ucitaniXmlDocument)
        {
            List<B2B_Results_RowItem> podaciZaPrikaz = new List<B2B_Results_RowItem>();

            extNS.gorenje.Root gorenjeCenovnik = new Root();


            var serializer = new XmlSerializer(typeof(extNS.gorenje.Root));
            using (XmlReader reader = new XmlNodeReader(ucitaniXmlDocument.LoadedXmlDocumentItem))
            {
                gorenjeCenovnik = (Root)serializer.Deserialize(reader);
            }

            foreach (var item in gorenjeCenovnik.Row)
            {
                if (!(string.IsNullOrWhiteSpace(item.barcode.ToString())))
                {

                    int kolicina = 0;                   

                    B2B_Results_RowItem podatakZaPrikaz = new B2B_Results_RowItem()
                    {
                        Barcode = item.barcode.ToString().TrimEnd(),
                        Kolicina = kolicina,
                        NNC = item.NNC,
                        PMC = item.PMC,
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

    

    //// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    ///// <remarks/>
    //[System.SerializableAttribute()]
    //[System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    //[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    //public partial class Root
    //{

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("Row")]
    //    public RootRow[] Row { get; set; }
    //}

    ///// <remarks/>
    //[System.SerializableAttribute()]
    //[System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    //public partial class RootRow
    //{

    //    /// <remarks/>
    //    public ulong barcode { get; set; }

    //    /// <remarks/>
    //    public uint NNC { get; set; }

    //    /// <remarks/>
    //    public uint PMC { get; set; }
    //}




    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Root
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Row")]
        public RootRow[] Row { get; set; }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class RootRow
    {

        /// <remarks/>
        public ulong barcode { get; set; }

        /// <remarks/>
        public decimal NNC { get; set; }

        /// <remarks/>
        public uint PMC { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PMCSpecified { get; set; }
    }






}
