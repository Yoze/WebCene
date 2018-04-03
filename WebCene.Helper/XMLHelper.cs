﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using WebCene.Model.B2B;
using WebCene.Helper;
using System.IO;
using System.Xml.Schema;

namespace WebCene.Helper
{
    public sealed class XMLHelper
    {

        // C# Singleton pattern
        // https://www.dotnetperls.com/singleton
        //

        static readonly XMLHelper _instance = new XMLHelper();

        public static XMLHelper Instance
        {
            get { return _instance; }
        }

        XMLHelper()
        {
            // initialize here
        }




        /** Public methods */

        public bool ValidateLoadedXml(XmlDocument xmlToValidate)
        {
            // TO DO
            try
            {

            }
            catch (Exception)
            {

                throw;
            }

            return true;
        }

        /** KONFIGURACIJE DOBAVLJAČA ZA DESERIJALIZACIJU PODATAKA */
        /// <param name="konfigDobavljaca"> kofiguracija dobavljača iz tabele KonfigDobavljaca</param>
        /// <param name="loadedXmlDocument"> učitani XML dokument (http, ftp,) </param>
        /// <returns> </returns>
        public List<XmlRezultat> DeserializeXmlResult(KonfigDobavljaca konfigDobavljaca, XmlDocument loadedXmlDocument)
        {
            // deserijalizacija učitanih xml podataka u odgovarajući .NET objekat

            // result object
            //dynamic result = null;
            List<XmlRezultat> xmlRezultats = new List<XmlRezultat>();

            switch (konfigDobavljaca.ExtraData)
            {
                case "EWE":
                    {
                        products ewe = new products();
                        var serializer = new XmlSerializer(typeof(products));

                        using (XmlReader reader = new XmlNodeReader(loadedXmlDocument))
                        {
                            ewe = (products)serializer.Deserialize(reader);
                        }

                        foreach (var item in ewe.product)
                        {
                            if (!(string.IsNullOrWhiteSpace(item.ean)))
                            {

                                decimal cena = decimal.Zero;
                                bool isCena = decimal.TryParse(item.price_rebate, System.Globalization.NumberStyles.Any, new CultureInfo("en-US"), out cena);


                                decimal pmc = decimal.Zero;
                                bool isPmc = decimal.TryParse(item.recommended_retail_price, out pmc);

                                XmlRezultat xmlRezultat = new XmlRezultat()
                                {
                                    Barcode = item.ean,
                                    Kolicina = 1,
                                    Cena = cena,
                                    PMC = pmc,
                                    DatumUlistavanja = DateTime.Today,
                                    PrimarniDobavljac = konfigDobavljaca.Naziv
                                };
                                xmlRezultats.Add(xmlRezultat);
                            }
                        }
                    }
                    return xmlRezultats;
                case "ERG":
                    {
                        var serializer = new XmlSerializer(typeof(ITEMS));
                        ITEMS erg = new ITEMS();

                        using (XmlReader reader = new XmlNodeReader(loadedXmlDocument))
                        {
                            erg = (ITEMS)serializer.Deserialize(reader);
                        }

                        foreach (var item in erg.ITEM)
                        {
                            if (!(string.IsNullOrWhiteSpace(item.barcode)))
                            {

                                // kolicina
                                int kolicina = 0;
                                bool isKolicina;

                                if (item.stock.Contains(">")) kolicina = 10;
                                else isKolicina = Int32.TryParse(item.stock.ToString(), out kolicina);

                                //cena
                                decimal cena = decimal.Zero;
                                bool isCena = decimal.TryParse(item.price.ToString(), out cena);

                                XmlRezultat xmlRezultat = new XmlRezultat()
                                {
                                    Barcode = item.barcode.TrimEnd(),
                                    Kolicina = kolicina,
                                    Cena = cena,
                                    PMC = 0,
                                    DatumUlistavanja = DateTime.Today,
                                    PrimarniDobavljac = konfigDobavljaca.Naziv
                                };

                                xmlRezultats.Add(xmlRezultat);
                            }
                        }
                    }
                    return xmlRezultats;
                case "BOSCH":
                    {
                        izdelki bsh = new izdelki();
                        var serializer = new XmlSerializer(typeof(izdelki));

                        using (XmlReader reader = new XmlNodeReader(loadedXmlDocument))
                        {
                            bsh = (izdelki)serializer.Deserialize(reader);
                        }

                        foreach (var item in bsh.izdelek)
                        {
                            if (item.ean > 0)
                            {
                                // cena
                                decimal cena = decimal.Zero;
                                bool isCena = decimal.TryParse(item.cena, out cena);

                                // PMC
                                decimal pmc = decimal.Zero;
                                bool isPmc = decimal.TryParse(item.ppc, out pmc);

                                XmlRezultat xmlRezultat= new XmlRezultat()
                                {
                                    Barcode = item.ean.ToString(),
                                    Kolicina = item.zaloga,
                                    Cena = cena,
                                    PMC = pmc,
                                    DatumUlistavanja = DateTime.Today,
                                    PrimarniDobavljac = konfigDobavljaca.Naziv
                                };
                                xmlRezultats.Add(xmlRezultat);
                            }
                        }
                    }
                    return xmlRezultats;
                case "GORENJE":
                    {
                        Root gorenje = new Root();
                        var serializer = new XmlSerializer(typeof(Root));

                        using (XmlNodeReader reader = new XmlNodeReader(loadedXmlDocument))
                        {

                            gorenje = (Root)serializer.Deserialize(reader);
                        }

                        // Provere cena, barkoda, ...
                        //


                        foreach (var item in gorenje.Row)
                        {
                            XmlRezultat xmlRezultat = new XmlRezultat()
                            {
                                Barcode = item.EAN_code.ToString(),
                                Kolicina = item.kom,
                                Cena = 0,
                                PMC = 0,
                                DatumUlistavanja = DateTime.Today,
                                PrimarniDobavljac = konfigDobavljaca.Naziv
                            };

                            xmlRezultats.Add(xmlRezultat);
                        }
                    }
                    return xmlRezultats;
                case "ZOMIMPEX":
                    {
                        Artikl zomImpex = new Artikl();
                        var serializer = new XmlSerializer(typeof(Artikl));

                       
                        using (XmlReader reader = new XmlNodeReader(loadedXmlDocument))
                        {
                           
                            zomImpex = (Artikl)serializer.Deserialize(reader);
                        }

                        foreach (var item in zomImpex.InformacijeArtikla)
                        {

                            // količina
                            int kolicina = 0;
                            bool isKolicina = Int32.TryParse(item.Količina, out kolicina);

                            // cena


                            XmlRezultat xmlRezultat = new XmlRezultat()
                            {
                                Barcode = item.Bar_kod,
                                Kolicina = kolicina,
                                Cena = item.Cena,
                                PMC = 0,
                                DatumUlistavanja = DateTime.Today,
                                PrimarniDobavljac = konfigDobavljaca.Naziv
                            };

                            xmlRezultats.Add(xmlRezultat);
                        }

                    }
                    return xmlRezultats;
                case "MKA":
                    {
                        Dokument mka = new Dokument();
                        var serializer = new XmlSerializer(typeof(Dokument));

                        using (XmlReader reader = new XmlNodeReader(loadedXmlDocument))
                        {
                            mka = (Dokument)serializer.Deserialize(reader);
                        }


                        foreach (var item in mka.Stavke)
                        {
                            // konverzije ... ako treba


                            XmlRezultat xmlRezultat = new XmlRezultat()
                            {
                                Barcode = item.BarKod.ToString(),
                                Kolicina = Convert.ToInt32(item.Kolicina),
                                Cena = item.CenaVP,
                                PMC = item.CenaMP,
                                DatumUlistavanja = DateTime.Today,
                                PrimarniDobavljac = konfigDobavljaca.Naziv
                            };
                            xmlRezultats.Add(xmlRezultat);
                        }

                    }
                    return xmlRezultats;

                default:
                    return xmlRezultats;
            }




        }

        private static void ValidationCallback(object sender, ValidationEventArgs e)
        {
            Debug.WriteLine(e.Message);
            //throw new NotImplementedException();
        }
    }
}
