using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using extNS = WebCene.Model.B2B;

namespace WebCene.Model.B2B.zomimpex
{


    public class ZOMIMPEX_CENOVNIK
    {
        public List<PodaciZaPrikaz> PodaciZaPrikaz { get; set; }

        public ZOMIMPEX_CENOVNIK(KonfigDobavljaca konfigDobavljaca, XmlDocument ucitaniXmlDocument)
        {
            PodaciZaPrikaz = new List<PodaciZaPrikaz>();

        }

        private void GenerisiPodatkeZaPrikaz(KonfigDobavljaca konfigDobavljaca, XmlDocument ucitaniXmlDocument)
        {
            List<PodaciZaPrikaz> podaciZaPrikaz = new List<PodaciZaPrikaz>();

            extNS.zomimpex.Artikl zomImpex = new extNS.zomimpex.Artikl();
            var serializer = new XmlSerializer(typeof(extNS.zomimpex.Artikl));

            using (XmlReader reader = new XmlNodeReader(ucitaniXmlDocument))
            {
                zomImpex = (extNS.zomimpex.Artikl)serializer.Deserialize(reader);
            }

            foreach (var item in zomImpex.InformacijeArtikla)
            {
                if (!(string.IsNullOrWhiteSpace(item.Bar_kod)))
                {
                    /*
                        ZOM - ako je inStock TRue -> kolicina = 5
	                    ako ima akcijskaCena onda NNC = akcijskaCena else NNC = cena
	                    PMC = NNC * 1.2 * koefMarze
                     */

                    //  količina
                    int kolicina = 0;
                    bool isKolicina = Int32.TryParse(item.Količina, out kolicina);
                    kolicina = (isKolicina && kolicina > 0) ? kolicina : 5;

                    // Akcijska cena
                    decimal akcijskaCena = decimal.Zero;
                    bool isAkcijska = decimal.TryParse(item.AkcijskaCena, out akcijskaCena);

                    // NNC
                    decimal nnc = decimal.Zero;
                    nnc = (isAkcijska && akcijskaCena > 0) ? akcijskaCena : item.Cena; 

                    // PMC
                    decimal pmc = decimal.Zero;
                    pmc =  nnc * decimal.Multiply( 1.2m, konfigDobavljaca.KeoficijentMarze);


                    PodaciZaPrikaz podatakZaPrikaz = new PodaciZaPrikaz()
                    {
                        Barcode = item.Bar_kod,
                        Kolicina = kolicina,
                        Cena = nnc,
                        PMC = pmc,
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
    public partial class Artikl
    {

        private ArtiklInformacijeArtikla[] informacijeArtiklaField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("InformacijeArtikla")]
        public ArtiklInformacijeArtikla[] InformacijeArtikla
        {
            get
            {
                return this.informacijeArtiklaField;
            }
            set
            {
                this.informacijeArtiklaField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ArtiklInformacijeArtikla
    {

        /// <remarks/>
        public string Šifra { get; set; }

        /// <remarks/>
        public string Naziv { get; set; }

        /// <remarks/>
        public string Opis { get; set; }

        /// <remarks/>
        public string Količina { get; set; }

        /// <remarks/>
        public decimal Cena { get; set; }

        /// <remarks/>
        public string AkcijskaCena { get; set; }

        /// <remarks/>
        public string LinkProizvoda { get; set; }

        /// <remarks/>
        public string Kategorija { get; set; }

        /// <remarks/>
        public string Slika { get; set; }

        /// <remarks/>
        public string Bar_kod { get; set; }
    }






}
