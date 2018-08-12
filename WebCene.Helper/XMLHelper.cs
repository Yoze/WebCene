using System;
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
using WebCene.Model.PIN_ServiceReference;
using WebCene.Model.CT_ServiceReference;
using extNS = WebCene.Model.B2B;

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

        //XMLHelper()
        //{
        //    // initialize here
        //}


        public List<B2B_Results_RowItem> GetB2B_Results_RowItems_PerSupplier(KonfigDobavljaca konfigDobavljaca)
        {
            // učitavanje xml podataka za dobavljača

            List<B2B_Results_RowItem> b2B_Results_RowItems = new List<B2B_Results_RowItem>();


            switch (konfigDobavljaca.WebProtokol.TrimEnd().ToLower())
            {

                case "ftp":
                    {
                        LoadedXmlDocument supplierXmlDocument = new LoadedXmlDocument();

                        // Cenovnik
                        List<B2B_Results_RowItem> priceList = null;
                        if (!(string.IsNullOrWhiteSpace(konfigDobavljaca.ModelCenovnik)))
                        {
                            priceList = new List<B2B_Results_RowItem>();

                            supplierXmlDocument = FTPHelper.Instance.LoadXmlDocumentForSupplier(konfigDobavljaca, konfigDobavljaca.CenovnikFilename);
                            priceList = XMLHelper.Instance.GetB2B_ResultsFromXmlDocument(konfigDobavljaca, konfigDobavljaca.ModelCenovnik, supplierXmlDocument.LoadedXmlDocumentItem);


                            b2B_Results_RowItems = priceList;
                        }


                        // Lager
                        List<B2B_Results_RowItem> stockList = null;
                        if (!(string.IsNullOrWhiteSpace(konfigDobavljaca.ModelLager)))
                        {
                            stockList = new List<B2B_Results_RowItem>();
                            LoadedXmlDocument loadedStockList = new LoadedXmlDocument();

                            loadedStockList = FTPHelper.Instance.LoadXmlDocumentForSupplier(konfigDobavljaca, konfigDobavljaca.LagerFilename);
                            stockList = XMLHelper.Instance.GetB2B_ResultsFromXmlDocument(konfigDobavljaca, konfigDobavljaca.ModelLager, loadedStockList.LoadedXmlDocumentItem);

                        }

                        // Povezivanje Cenovnika sa lagerom u jedinstvenu listu
                        if (priceList != null && stockList != null)
                        {
                            b2B_Results_RowItems = MergePriceListAndStockList(priceList, stockList);
                        }


                        return b2B_Results_RowItems;
                    }


                case "http":
                    {
                        LoadedXmlDocument supplierXmlDocument = new LoadedXmlDocument();

                        // Cenovnik i lager
                        List<B2B_Results_RowItem> priceList = new List<B2B_Results_RowItem>();


                        supplierXmlDocument = HTTPSHelper.Instance.LoadXmlDocWithHttpRequest(konfigDobavljaca);
                        //priceList = XMLHelper.Instance.XmlDocumentUPodaciZaPrikaz(konfigDobavljaca, konfigDobavljaca.ModelCenovnik, supplierXmlDocument);
                        //return b2B_Results_RowItems;

                        break;
                    }


                case "webservice":
                    {
                        switch (konfigDobavljaca.ModelCenovnik)
                        {
                            case "PIN":
                                {
                                    /** PIN CLient */
                                    StockWebserviceClient pinServiceClient = new StockWebserviceClient("StockWebservicePort");

                                    UInt32 password = 0;
                                    try
                                    {
                                        password = Convert.ToUInt32(konfigDobavljaca.Password);
                                    }
                                    catch (Exception e)
                                    {
                                        throw new Exception("Greška u parametru za pristup servisu!\r\n" + e.Message);
                                    }

                                    //b2BWebServiceDAO pinResults = pinServiceClient.getAllItems("c794398a-732c-4d5e-b6a4-783eb1a268c0", 4, false); // proveriti zasto true param izbacuje error !
                                    b2BWebServiceDAO pinResults = pinServiceClient.getAllItems(konfigDobavljaca.Username, password, false); // proveriti zasto true param izbacuje error !
                                    pinServiceClient.Close();

                                    /** PIN Items*/
                                    List<item> pinItems = pinResults.item.ToList();

                                    if (pinItems.Count != 0)
                                    {
                                        for (int i = 0; i < pinItems.Count; i++)
                                        {
                                            B2B_Results_RowItem xmlRezultat = new B2B_Results_RowItem()
                                            {
                                                Barcode = pinItems[i].ean,
                                                Kolicina = (int)pinItems[i].stock,
                                                Cena = (decimal)pinItems[i].price_with_discounts,
                                                PMC = (decimal)pinItems[i].retail_price,
                                                DatumUlistavanja = DateTime.Today,
                                                PrimarniDobavljac = konfigDobavljaca.Naziv
                                            };
                                            b2B_Results_RowItems.Add(xmlRezultat);
                                        }
                                        return b2B_Results_RowItems;
                                    }
                                }
                                break;

                            case "COMTRADE":
                                {
                                    // TO DO comtrade web service
                                }
                                break;

                            default:
                                break;
                        }
                    }
                    break;

                default:
                    break;
            }
            return b2B_Results_RowItems;
        }


        public List<B2B_Results_RowItem> GetB2B_ResultsFromXmlDocument(KonfigDobavljaca konfigDobavljaca, string model, XmlDocument ucitaniXmlDocument)
        {
            /** Instance  */

            List<B2B_Results_RowItem> b2B_Results_RowItems = new List<B2B_Results_RowItem>();

            switch (model)
            {
                case "EWE_CENOVNIK":
                    extNS.ewe.EWE_CENOVNIK eweCenovnik = new extNS.ewe.EWE_CENOVNIK(konfigDobavljaca, ucitaniXmlDocument);
                    return b2B_Results_RowItems = eweCenovnik.b2B_Results_RowItems;

                case "ERG_CENOVNIK":
                    extNS.erg.ERG_CENOVNIK ergCenovnik = new extNS.erg.ERG_CENOVNIK(konfigDobavljaca, ucitaniXmlDocument);
                    return b2B_Results_RowItems = ergCenovnik.b2B_Results_RowItems;

                case "ZOMIMPEX_CENOVNIK":
                    extNS.zomimpex.ZOMIMPEX_CENOVNIK zomCenovnik = new extNS.zomimpex.ZOMIMPEX_CENOVNIK(konfigDobavljaca, ucitaniXmlDocument);
                    return b2B_Results_RowItems = zomCenovnik.b2B_Results_RowItems;

                case "BOSCH_CENOVNIK":
                    extNS.bosch.BOSCH_CENOVNIK boschCenovnik = new extNS.bosch.BOSCH_CENOVNIK(konfigDobavljaca, ucitaniXmlDocument);
                    return b2B_Results_RowItems = boschCenovnik.b2B_Results_RowItems;

                case "GORENJE_CENOVNIK":
                    extNS.gorenje.GORENJE_CENOVNIK gorenjeCenovnik = new extNS.gorenje.GORENJE_CENOVNIK(konfigDobavljaca, ucitaniXmlDocument);
                    return b2B_Results_RowItems = gorenjeCenovnik.b2B_Results_RowItems;

                case "GORENJE_LAGER":
                    extNS.gorenjeLager.GORENJE_LAGER gorenjeLager = new extNS.gorenjeLager.GORENJE_LAGER(konfigDobavljaca, ucitaniXmlDocument);
                    return b2B_Results_RowItems = gorenjeLager.b2B_Results_RowItems;

                case "ALFAPLAM_CENOVNIK":
                    extNS.AlfaPlamCenovnik.ALFAPLAM_CENOVNIK alfaPlamCenovnik = new extNS.AlfaPlamCenovnik.ALFAPLAM_CENOVNIK(konfigDobavljaca, ucitaniXmlDocument);
                    return b2B_Results_RowItems = alfaPlamCenovnik.b2B_Results_RowItems;

                case "MBS_CENOVNIK":
                    extNS.MbsCenovnik.MBS_CENOVNIK mbsCenovnik = new extNS.MbsCenovnik.MBS_CENOVNIK(konfigDobavljaca, ucitaniXmlDocument);
                    return b2B_Results_RowItems = mbsCenovnik.b2B_Results_RowItems;

                case "ACRMOBILE_CENOVNIK":
                    extNS.acrmobile.ACRMOBILE_CENOVNIK acrMobileCenovnik = new extNS.acrmobile.ACRMOBILE_CENOVNIK(konfigDobavljaca, ucitaniXmlDocument);
                    return b2B_Results_RowItems = acrMobileCenovnik.b2B_Results_RowItems;

                case "ALCA_CENOVNIK":
                    extNS.alca.ALCA_CENOVNIK alcaCenovnik = new extNS.alca.ALCA_CENOVNIK(konfigDobavljaca, ucitaniXmlDocument);
                    return b2B_Results_RowItems = alcaCenovnik.b2B_Results_RowItems;

                case "CANDY_CENOVNIK":
                    extNS.candy.CANDY_CENOVNIK candyCenovnik = new extNS.candy.CANDY_CENOVNIK(konfigDobavljaca, ucitaniXmlDocument);
                    return b2B_Results_RowItems = candyCenovnik.b2B_Results_RowItems;

                case "CANDY_LAGER":
                    extNS.candyLager.CANDY_LAGER candyLager = new extNS.candyLager.CANDY_LAGER(konfigDobavljaca, ucitaniXmlDocument);
                    return b2B_Results_RowItems = candyLager.b2B_Results_RowItems;

                case "220B_CENOVNIK":
                    extNS._220BCenovnik._220B_CENOVNIK _220BCenovnik = new extNS._220BCenovnik._220B_CENOVNIK(konfigDobavljaca, ucitaniXmlDocument);
                    return b2B_Results_RowItems = _220BCenovnik.b2B_Results_RowItems;

                case "220B_LAGER":
                    extNS._220BLager._220B_LAGER _220BLager = new extNS._220BLager._220B_LAGER(konfigDobavljaca, ucitaniXmlDocument);
                    return b2B_Results_RowItems = _220BLager.b2B_Results_RowItems;

                case "MKA_CENOVNIK":
                    extNS.mkaCenovnik.MKA_CENOVNIK mkaCenovnik = new extNS.mkaCenovnik.MKA_CENOVNIK(konfigDobavljaca, ucitaniXmlDocument);
                    return b2B_Results_RowItems = mkaCenovnik.b2B_Results_RowItems;

                case "MISON_CENOVNIK":
                    extNS.mison.MISON_CENOVNIK misonCenovnik = new extNS.mison.MISON_CENOVNIK(konfigDobavljaca, ucitaniXmlDocument);
                    return b2B_Results_RowItems = misonCenovnik.b2B_Results_RowItems;

                case "HUAWEI_CENOVNIK":
                    extNS.huawei.HUAWEI_CENOVNIK huaweiCenovnik = new extNS.huawei.HUAWEI_CENOVNIK(konfigDobavljaca, ucitaniXmlDocument);
                    return b2B_Results_RowItems = huaweiCenovnik.b2B_Results_RowItems;

                case "ROAMING_CENOVNIK":
                    extNS.roaming.ROAMING_CENOVNIK roamingCenovnik = new extNS.roaming.ROAMING_CENOVNIK(konfigDobavljaca, ucitaniXmlDocument);
                    return b2B_Results_RowItems = roamingCenovnik.b2B_Results_RowItems;

                case "TANDEM_CENOVNIK":
                    extNS.tandem.TANDEM_CENOVNIK tandemCenovnik = new extNS.tandem.TANDEM_CENOVNIK(konfigDobavljaca, ucitaniXmlDocument);
                    return b2B_Results_RowItems = tandemCenovnik.b2B_Results_RowItems;

                case "TANDEM_LAGER":
                    extNS.tandemLager.TANDEM_LAGER tandemLager = new extNS.tandemLager.TANDEM_LAGER(konfigDobavljaca, ucitaniXmlDocument);
                    return b2B_Results_RowItems = tandemLager.b2B_Results_RowItems;

                case "WHIRLPOOL_CENOVNIK":
                    extNS.whirlpoolCenovnik.WHIRLPOOL_CENOVNIK whirlpoolCenovnik = new extNS.whirlpoolCenovnik.WHIRLPOOL_CENOVNIK(konfigDobavljaca, ucitaniXmlDocument);
                    return b2B_Results_RowItems = whirlpoolCenovnik.b2B_Results_RowItems;

                case "WHIRLPOOL_LAGER":
                    extNS.whirlpoolLager.WHIRLPOOL_LAGER whirlpoolLager = new extNS.whirlpoolLager.WHIRLPOOL_LAGER(konfigDobavljaca, ucitaniXmlDocument);
                    return b2B_Results_RowItems = whirlpoolLager.b2B_Results_RowItems;


                default:
                    return b2B_Results_RowItems;
            }



            #region oldCode


            // switch (konfigDobavljaca.ModelCenovnik)
            //{
            //case "EWE":
            //    {
            //        extNS.ewe.products ewe = new extNS.ewe.products();
            //        var serializer = new XmlSerializer(typeof(extNS.ewe.products));

            //        using (XmlReader reader = new XmlNodeReader(ucitaniXmlDocument))
            //        {
            //            ewe = (extNS.ewe.products)serializer.Deserialize(reader);
            //        }

            //        foreach (var item in ewe.product)
            //        {
            //            if (!(string.IsNullOrWhiteSpace(item.ean)))
            //            {

            //                decimal cena = decimal.Zero;
            //                bool isCena = decimal.TryParse(item.price_rebate, System.Globalization.NumberStyles.Any, new CultureInfo("en-US"), out cena);


            //                decimal pmc = decimal.Zero;
            //                bool isPmc = decimal.TryParse(item.recommended_retail_price, out pmc);

            //                PodaciZaPrikaz podatakZaPrikaz = new PodaciZaPrikaz()
            //                {
            //                    Barcode = item.ean,
            //                    Kolicina = 1,
            //                    Cena = cena,
            //                    PMC = pmc,
            //                    DatumUlistavanja = DateTime.Today,
            //                    PrimarniDobavljac = konfigDobavljaca.Naziv
            //                };
            //                podaciZaPrikaz.Add(podatakZaPrikaz);
            //            }
            //        }
            //    }
            //    return podaciZaPrikaz;

            //case "ERG":
            //    {
            //        var serializer = new XmlSerializer(typeof(ITEMS));
            //        ITEMS erg = new ITEMS();

            //        using (XmlReader reader = new XmlNodeReader(ucitaniXmlDocument))
            //        {
            //            erg = (ITEMS)serializer.Deserialize(reader);
            //        }

            //        foreach (var item in erg.ITEM)
            //        {
            //            string barcodeTrimmed = item.barcode.TrimEnd();

            //            if (!(string.IsNullOrWhiteSpace(barcodeTrimmed)))
            //            {

            //                // kolicina
            //                int kolicina = 0;
            //                bool isKolicina;

            //                if (item.stock.Contains(">")) kolicina = 10;
            //                else isKolicina = Int32.TryParse(item.stock.ToString(), out kolicina);

            //                //cena
            //                //decimal cena = decimal.Zero;

            //                //cena = item.price;

            //                //bool isCena = decimal.TryParse(price, out cena);



            //                PodaciZaPrikaz podatakZaPrikaz = new PodaciZaPrikaz()
            //                {
            //                    Barcode = item.barcode.TrimEnd(),
            //                    Kolicina = kolicina,
            //                    Cena = item.price,
            //                    PMC = 0,
            //                    DatumUlistavanja = DateTime.Today,
            //                    PrimarniDobavljac = konfigDobavljaca.Naziv
            //                };

            //                podaciZaPrikaz.Add(podatakZaPrikaz);
            //            }
            //        }
            //    }
            //    return podaciZaPrikaz;

            //case "BOSCH":
            //    {
            //        izdelki bsh = new izdelki();
            //        var serializer = new XmlSerializer(typeof(izdelki));

            //        using (XmlReader reader = new XmlNodeReader(ucitaniXmlDocument))
            //        {
            //            bsh = (izdelki)serializer.Deserialize(reader);
            //        }

            //        foreach (var item in bsh.izdelek)
            //        {
            //            if (item.ean > 0)
            //            {
            //                // cena
            //                decimal cena = decimal.Zero;
            //                bool isCena = decimal.TryParse(item.cena, out cena);

            //                // PMC
            //                decimal pmc = decimal.Zero;
            //                bool isPmc = decimal.TryParse(item.ppc, out pmc);

            //                PodaciZaPrikaz podatakZaPrikaz = new PodaciZaPrikaz()
            //                {
            //                    Barcode = item.ean.ToString(),
            //                    Kolicina = item.zaloga,
            //                    Cena = cena,
            //                    PMC = pmc,
            //                    DatumUlistavanja = DateTime.Today,
            //                    PrimarniDobavljac = konfigDobavljaca.Naziv
            //                };
            //                podaciZaPrikaz.Add(podatakZaPrikaz);
            //            }
            //        }
            //    }
            //    return podaciZaPrikaz;

            //case "GORENJE":
            //    {
            //        extendedNamespace.gorenje.Root gorenje = new extendedNamespace.gorenje.Root();
            //        var serializer = new XmlSerializer(typeof(extendedNamespace.gorenje.Root));

            //        using (XmlReader reader = new XmlNodeReader(ucitaniXmlDocument))
            //        {
            //            gorenje = (extendedNamespace.gorenje.Root)serializer.Deserialize(reader); // throw exception here !!!
            //        }

            //        foreach (var item in gorenje.Row)
            //        {
            //            PodaciZaPrikaz podatakZaPrikaz = new PodaciZaPrikaz()
            //            {
            //                Barcode = item.EAN.ToString(),
            //                Kolicina = 0,
            //                Cena = item.Neto_prodajna_cena,
            //                PMC = item.PREP_MPC,
            //                DatumUlistavanja = DateTime.Today,
            //                PrimarniDobavljac = konfigDobavljaca.Naziv
            //            };
            //            podaciZaPrikaz.Add(podatakZaPrikaz);
            //        }
            //    }
            //    return podaciZaPrikaz;

            //case "GORENJELAGER":
            //    {
            //        extendedNamespace.gorenje.lager.model_GORENJE_LAGER.Root gorenjeLager = new extendedNamespace.gorenje.lager.model_GORENJE_LAGER.Root();
            //        var serializer = new XmlSerializer(typeof(extendedNamespace.gorenje.lager.model_GORENJE_LAGER.Root));

            //        using (XmlReader reader = new XmlNodeReader(ucitaniXmlDocument))
            //        {
            //            gorenjeLager = (extendedNamespace.gorenje.lager.model_GORENJE_LAGER.Root)serializer.Deserialize(reader);
            //        }

            //        foreach (var item in gorenjeLager.Row)
            //        {
            //            PodaciZaPrikaz podatakZaPrikaz = new PodaciZaPrikaz()
            //            {
            //                Barcode = item.barcod,
            //                Kolicina = item.kolicina
            //            };
            //            podaciZaPrikaz.Add(podatakZaPrikaz);
            //        }
            //    }
            //    return podaciZaPrikaz;

            //case "ZOMIMPEX":
            //    {
            //        Artikl zomImpex = new Artikl();
            //        var serializer = new XmlSerializer(typeof(Artikl));

            //        using (XmlReader reader = new XmlNodeReader(ucitaniXmlDocument))
            //        {                           
            //            zomImpex = (Artikl)serializer.Deserialize(reader);
            //        }

            //        foreach (var item in zomImpex.InformacijeArtikla)
            //        {

            //            // količina
            //            int kolicina = 0;
            //            bool isKolicina = Int32.TryParse(item.Količina, out kolicina);

            //            // cena


            //            PodaciZaPrikaz podatakZaPrikaz = new PodaciZaPrikaz()
            //            {
            //                Barcode = item.Bar_kod,
            //                Kolicina = kolicina,
            //                Cena = item.Cena,
            //                PMC = 0,
            //                DatumUlistavanja = DateTime.Today,
            //                PrimarniDobavljac = konfigDobavljaca.Naziv
            //            };

            //            podaciZaPrikaz.Add(podatakZaPrikaz);
            //        }

            //    }
            //    return podaciZaPrikaz;

            //case "MKA":
            //    {
            //        Dokument mka = new Dokument();
            //        var serializer = new XmlSerializer(typeof(Dokument));

            //        using (XmlReader reader = new XmlNodeReader(ucitaniXmlDocument))
            //        {
            //            mka = (Dokument)serializer.Deserialize(reader);
            //        }


            //        foreach (var item in mka.Stavke)
            //        {
            //            // konverzije ... ako treba


            //            PodaciZaPrikaz podatakZaPrikaz = new PodaciZaPrikaz()
            //            {
            //                Barcode = item.BarKod.ToString(),
            //                Kolicina = Convert.ToInt32(item.Kolicina),
            //                Cena = item.CenaVP,
            //                PMC = item.CenaMP,
            //                DatumUlistavanja = DateTime.Today,
            //                PrimarniDobavljac = konfigDobavljaca.Naziv
            //            };
            //            podaciZaPrikaz.Add(podatakZaPrikaz);
            //        }

            //    }
            //    return podaciZaPrikaz;

            //case "CANDY":
            //    {
            //        extendedNamespace.candy.Root candy = new extendedNamespace.candy.Root();
            //        var serializer = new XmlSerializer(typeof(extendedNamespace.candy.Root));

            //        using (XmlReader reader = new XmlNodeReader(ucitaniXmlDocument))
            //        {
            //            candy = (extendedNamespace.candy.Root)serializer.Deserialize(reader);
            //        }


            //        foreach (var item in candy.Row)
            //        {
            //            PodaciZaPrikaz podatakZaPrikaz = new PodaciZaPrikaz()
            //            {
            //                Barcode = item.barkod.ToString(),
            //                Kolicina = item.Kolicina,
            //                Cena = decimal.Zero,
            //                PMC = decimal.Zero,
            //                DatumUlistavanja = DateTime.Today,
            //                PrimarniDobavljac = konfigDobavljaca.Naziv
            //            };
            //            podaciZaPrikaz.Add(podatakZaPrikaz);
            //        }

            //    }
            //    return podaciZaPrikaz;

            //case "ORBICO":
            //    {
            //        extendedNamespace.orbico.Items orbico = new extendedNamespace.orbico.Items();
            //        var serializer = new XmlSerializer(typeof(extendedNamespace.orbico.Items));

            //        using (XmlReader reader = new XmlNodeReader(ucitaniXmlDocument))
            //        {
            //            orbico = (extendedNamespace.orbico.Items)serializer.Deserialize(reader);
            //        }

            //        foreach (var item in orbico.Item)
            //        {
            //            // cena sa popustom (price_rebate)
            //            decimal cena = decimal.Zero;
            //            bool isParsedPriceRebate = decimal.TryParse(item.price_rebate, out cena);

            //            // PMC
            //            decimal pmc = decimal.Zero;
            //            bool isParsedPrice = decimal.TryParse(item.price, out pmc);


            //            PodaciZaPrikaz podatakZaPrikaz = new PodaciZaPrikaz()
            //            {
            //                Barcode = item.ean.ToString(),
            //                Kolicina = item.qty,
            //                Cena = cena,
            //                PMC = pmc,
            //                DatumUlistavanja = DateTime.Today,
            //                PrimarniDobavljac = konfigDobavljaca.Naziv
            //            };
            //            podaciZaPrikaz.Add(podatakZaPrikaz);
            //        }

            //    }
            //    return podaciZaPrikaz;

            //case "ACRMOBILE":
            //    {
            //        extendedNamespace.acrmobile.Root acrmobile = new extendedNamespace.acrmobile.Root();
            //        var serializer = new XmlSerializer(typeof(extendedNamespace.acrmobile.Root));

            //        using (XmlReader reader = new XmlNodeReader(ucitaniXmlDocument))
            //        {
            //            acrmobile = (extendedNamespace.acrmobile.Root)serializer.Deserialize(reader);
            //        }

            //        foreach (var item in acrmobile.Row)
            //        {
            //            PodaciZaPrikaz podatakZaPrikaz = new PodaciZaPrikaz()
            //            {
            //                Barcode = item.barcod,
            //                Kolicina = item.kolicina,
            //                Cena = item.VP_cena,
            //                PMC = 0,
            //                DatumUlistavanja = DateTime.Today,
            //                PrimarniDobavljac = konfigDobavljaca.Naziv
            //            };
            //            podaciZaPrikaz.Add(podatakZaPrikaz);
            //        }
            //    }
            //    return podaciZaPrikaz;

            //case "ALCA":
            //    {
            //        extendedNamespace.alca.Root alcatrgovina = new extendedNamespace.alca.Root();
            //        var serializer = new XmlSerializer(typeof(extendedNamespace.alca.Root));


            //        using (XmlReader reader = new XmlNodeReader(ucitaniXmlDocument))
            //        {
            //            alcatrgovina = (extendedNamespace.alca.Root)serializer.Deserialize(reader);
            //        }

            //        foreach (var item in alcatrgovina.Row)
            //        {
            //            PodaciZaPrikaz podatakZaPrikaz = new PodaciZaPrikaz()
            //            {
            //                Barcode = item.barcod.ToString(),
            //                Kolicina = item.kolicina,
            //                Cena = item.Prodajna_cena,
            //                PMC = item.Prodajna_cena_s_PDVom,
            //                DatumUlistavanja = DateTime.Today,
            //                PrimarniDobavljac = konfigDobavljaca.Naziv
            //            };
            //            podaciZaPrikaz.Add(podatakZaPrikaz);
            //        }
            //    }
            //    return podaciZaPrikaz;

            //case "MISON":
            //    {
            //        extendedNamespace.mison.Root mison = new extendedNamespace.mison.Root();
            //        var serializer = new XmlSerializer(typeof(extendedNamespace.mison.Root));

            //        using (XmlReader reader = new XmlNodeReader(ucitaniXmlDocument))
            //        {
            //            mison = (extendedNamespace.mison.Root)serializer.Deserialize(reader);
            //        }

            //        foreach (var item in mison.Row)
            //        {
            //            PodaciZaPrikaz podatakZaPrikaz = new PodaciZaPrikaz()
            //            {
            //                Barcode = item.barcod.ToString(),
            //                Kolicina = item.kolicina,
            //                Cena = item.VP__Cena_u_DIN,
            //                PMC = item.PREPORU_ENA_MP_CENA,
            //                DatumUlistavanja = DateTime.Today,
            //                PrimarniDobavljac = konfigDobavljaca.Naziv
            //            };
            //            podaciZaPrikaz.Add(podatakZaPrikaz);
            //        }
            //    }
            //    return podaciZaPrikaz;

            //case "HUAWEI":
            //    {
            //        extendedNamespace.huawei.Root huawei = new extendedNamespace.huawei.Root();
            //        var serializer = new XmlSerializer(typeof(extendedNamespace.huawei.Root));

            //        using (XmlReader reader = new XmlNodeReader(ucitaniXmlDocument))
            //        {
            //            huawei = (extendedNamespace.huawei.Root)serializer.Deserialize(reader);
            //        }

            //        foreach (var item in huawei.Row)
            //        {
            //            PodaciZaPrikaz podatakZaPrikaz = new PodaciZaPrikaz()
            //            {
            //                Barcode = item.barcod.ToString(),
            //                Kolicina = item.kolicina,
            //                Cena = item.Neto_VP_za_valutu,
            //                PMC = item.RRP,
            //                DatumUlistavanja = DateTime.Today,
            //                PrimarniDobavljac = konfigDobavljaca.Naziv
            //            };
            //            podaciZaPrikaz.Add(podatakZaPrikaz);
            //        }
            //    }
            //    return podaciZaPrikaz;

            //default:
            //    return podaciZaPrikaz;
            // }

            #endregion
        }



       


        private List<B2B_Results_RowItem> MergePriceListAndStockList(List<B2B_Results_RowItem> priceList, List<B2B_Results_RowItem> stockList)
        {
            List<B2B_Results_RowItem> mergedPriceAndStockLists = new List<B2B_Results_RowItem>();
            mergedPriceAndStockLists = priceList;

            for (int i = 0; i < priceList.Count; i++)
            {

                B2B_Results_RowItem equalRow = stockList.Find(ean => ean.Barcode.Equals(priceList[i].Barcode));

                if (equalRow != null)
                {

                    priceList[i].Kolicina = equalRow.Kolicina;
                }
                else
                {
                    priceList[i].Kolicina = 0;
                }

            }
            return mergedPriceAndStockLists;
        }

     
    }
}
