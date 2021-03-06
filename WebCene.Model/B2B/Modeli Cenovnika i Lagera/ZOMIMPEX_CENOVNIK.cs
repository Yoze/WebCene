﻿using System;
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
        public List<B2B_Results_RowItem> b2B_Results_RowItems { get; set; }

        public ZOMIMPEX_CENOVNIK(KonfigDobavljaca konfigDobavljaca, LoadedXmlDocument ucitaniXmlDocument)
        {
            b2B_Results_RowItems = new List<B2B_Results_RowItem>();

            GenerisiPodatkeZaPrikaz(konfigDobavljaca, ucitaniXmlDocument);
        }

        private void GenerisiPodatkeZaPrikaz(KonfigDobavljaca konfigDobavljaca, LoadedXmlDocument ucitaniXmlDocument)
        {
            List<B2B_Results_RowItem> podaciZaPrikaz = new List<B2B_Results_RowItem>();

            extNS.zomimpex.Artikl zomImpex = new extNS.zomimpex.Artikl();
            var serializer = new XmlSerializer(typeof(extNS.zomimpex.Artikl));

            using (XmlReader reader = new XmlNodeReader(ucitaniXmlDocument.LoadedXmlDocumentItem))
            {
                zomImpex = (extNS.zomimpex.Artikl)serializer.Deserialize(reader);
            }

            foreach (var item in zomImpex.InformacijeArtikla)
            {
                if (ModelHelper.Instance.IsValidBarcode(item.Bar_kod))
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
                    double akcijskaCena = 0;
                    bool isAkcijska = double.TryParse(item.AkcijskaCena, out akcijskaCena);

                    // NNC
                    double nnc = 0;
                    nnc = (isAkcijska && akcijskaCena > 0) ? akcijskaCena : Convert.ToDouble(item.Cena); 

                    // PMC
                    double pmc = 0;
                    //pmc =  nnc * decimal.Multiply( 1.2m, konfigDobavljaca.KeoficijentMarze);

                    if (!konfigDobavljaca.Manualno)
                    {
                        // TODO: kalkulacija NNC i PMC, kako?
                    }
                    

                    B2B_Results_RowItem podatakZaPrikaz = new B2B_Results_RowItem()
                    {
                        Barcode = item.Bar_kod,
                        Kolicina = kolicina,
                        NNC = ModelHelper.Instance.CalculateNNC(nnc, konfigDobavljaca),
                        PMC = pmc, //TO DO: kalkulacija PMC
                        DatumUlistavanja = DateTime.Now,
                        PrimarniDobavljac = konfigDobavljaca.Naziv,
                        CenovnikDatum = DateTime.Now,
                        LagerDatum = DateTime.Now
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
