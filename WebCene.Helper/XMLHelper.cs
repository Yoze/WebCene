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
using WebCene.Model.PIN_ServiceReference;
using WebCene.Model.CT_ServiceReference;
using extNS = WebCene.Model.B2B;
using WebCene.Model;

namespace WebCene.Helper
{
    public sealed class XMLHelper
    {


        public static string StatusDescription { get; set; } // status description sa ftp-a



        public static XMLHelper Instance { get; } = new XMLHelper();

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

                            // ovo koristi glavna forma da bi imali Status Description u statusima
                            StatusDescription = supplierXmlDocument.StatusDescription;

                            priceList = XMLHelper.Instance.GetB2B_ResultsFromXmlDocument(konfigDobavljaca, konfigDobavljaca.ModelCenovnik, supplierXmlDocument);

                            b2B_Results_RowItems = priceList;
                        }


                        // Lager
                        List<B2B_Results_RowItem> stockList = null;
                        if (!(string.IsNullOrWhiteSpace(konfigDobavljaca.ModelLager)))
                        {
                            stockList = new List<B2B_Results_RowItem>();
                            LoadedXmlDocument loadedStockList = new LoadedXmlDocument();

                            loadedStockList = FTPHelper.Instance.LoadXmlDocumentForSupplier(konfigDobavljaca, konfigDobavljaca.LagerFilename);

                            // ovo koristi glavna forma da bi imali Status Description u statusima
                            StatusDescription = loadedStockList.StatusDescription;

                            stockList = XMLHelper.Instance.GetB2B_ResultsFromXmlDocument(konfigDobavljaca, konfigDobavljaca.ModelLager, loadedStockList);
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

                        // ovo koristi glavna forma da bi imali Status Description u statusima
                        StatusDescription = supplierXmlDocument.StatusDescription;

                        priceList = Instance.GetB2B_ResultsFromXmlDocument(konfigDobavljaca, konfigDobavljaca.ModelCenovnik, supplierXmlDocument);
                        b2B_Results_RowItems = priceList;

                        return b2B_Results_RowItems;
                    }


                case "webservice":
                    {
                        switch (konfigDobavljaca.ModelCenovnik)
                        {
                            case "PIN_CENOVNIK":
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
                                            if (ModelHelper.Instance.IsValidBarcode(pinItems[i].ean))
                                            {
                                                B2B_Results_RowItem xmlRezultat = new B2B_Results_RowItem()
                                                {
                                                    Barcode = pinItems[i].ean,
                                                    Kolicina = (int)pinItems[i].stock,
                                                    NNC = pinItems[i].price_with_discounts,
                                                    PMC = pinItems[i].retail_price,
                                                    DatumUlistavanja = DateTime.Now,
                                                    PrimarniDobavljac = konfigDobavljaca.Naziv,
                                                    CenovnikDatum = DateTime.Now,
                                                    LagerDatum = DateTime.Now
                                                };
                                                b2B_Results_RowItems.Add(xmlRezultat);
                                            }       
                                        }
                                        return b2B_Results_RowItems;
                                    }
                                }
                                break;

                            case "COMTRADE":
                                {
                                    // Napravljen je poseban utility koji se nalazi na elbraco cloud-u.
                                    // Ovaj utility preuzima podatke sa CT B2B i kopira generisani xml fajl na Elbraco Ftp 
                                    // u folder 'ftp://ftp.elbraco.rs/elcomtradeCenovnik'
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


        public List<B2B_Results_RowItem> GetB2B_ResultsFromXmlDocument(KonfigDobavljaca konfigDobavljaca, string model, LoadedXmlDocument ucitaniXmlDocument)
        {
            /** Dodavanje xml u jedinstvenu listu rezultata učitanih sa FTP  */

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

                case "ALCA_LAGER":
                    extNS.alcaLager.ALCA_LAGER alcaLager = new extNS.alcaLager.ALCA_LAGER(konfigDobavljaca, ucitaniXmlDocument);
                    return b2B_Results_RowItems = alcaLager.b2B_Results_RowItems;

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

                case "MISON_LAGER":
                    extNS.misonLager.MISON_LAGER misonLager = new extNS.misonLager.MISON_LAGER(konfigDobavljaca, ucitaniXmlDocument);
                    return b2B_Results_RowItems = misonLager.b2B_Results_RowItems;

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

                case "ORBICO_CENOVNIK":
                    extNS.orbico.ORBICO_CENOVNIK orbicoCenovnik = new extNS.orbico.ORBICO_CENOVNIK(konfigDobavljaca, ucitaniXmlDocument);
                    return b2B_Results_RowItems = orbicoCenovnik.b2B_Results_RowItems;

                case "COMTRADE_CENOVNIK":
                    extNS.comtrade.COMTRADE_CENOVNIK comtradeCenovnik = new extNS.comtrade.COMTRADE_CENOVNIK(konfigDobavljaca, ucitaniXmlDocument);
                    return b2B_Results_RowItems = comtradeCenovnik.b2B_Results_RowItems;

                default:
                    return b2B_Results_RowItems;
            }

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
                    priceList[i].LagerDatum = equalRow.LagerDatum.Date;
                }
                else
                {
                    priceList[i].Kolicina = 0;
                    priceList[i].LagerDatum = DateTime.MinValue.Date;
                }

            }
            return mergedPriceAndStockLists;
        }

     
    }
}
