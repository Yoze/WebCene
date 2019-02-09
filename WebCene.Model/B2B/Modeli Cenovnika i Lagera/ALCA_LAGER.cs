﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using extNS = WebCene.Model.B2B;

namespace WebCene.Model.B2B.alcaLager
{

    public class ALCA_LAGER
    {
        public List<B2B_Results_RowItem> b2B_Results_RowItems { get; set; }

        public ALCA_LAGER(KonfigDobavljaca konfigDobavljaca, LoadedXmlDocument ucitaniXmlDocument)
        {
            b2B_Results_RowItems = new List<B2B_Results_RowItem>();

            GenerisiPodatkeZaPrikaz(konfigDobavljaca, ucitaniXmlDocument);
        }


        private void GenerisiPodatkeZaPrikaz(KonfigDobavljaca konfigDobavljaca, LoadedXmlDocument ucitaniXmlDocument)
        {
            List<B2B_Results_RowItem> podaciZaPrikaz = new List<B2B_Results_RowItem>();

            extNS.alcaLager.Root alcaLager = new Root();


            var serializer = new XmlSerializer(typeof(extNS.alcaLager.Root));
            using (XmlReader reader = new XmlNodeReader(ucitaniXmlDocument.LoadedXmlDocumentItem))
            {
                alcaLager = (Root)serializer.Deserialize(reader);
            }


            foreach (var item in alcaLager.Row)
            {
                if (ModelHelper.Instance.IsValidBarcode(item.barcode.ToString().TrimEnd()))
                {

                    // NNC - nije potrebna, učitava se samo lager
                    //double nnc = Convert.ToDouble(item.NNC);
                    //if (!konfigDobavljaca.Manualno)
                    //{
                    //    nnc = ModelHelper.Instance.CalculateNNC(nnc, konfigDobavljaca);
                    //}

                    B2B_Results_RowItem podatakZaPrikaz = new B2B_Results_RowItem()
                    {
                        Barcode = item.barcode.ToString().TrimEnd(),
                        Kolicina = item.kolicina,
                        NNC = 0,
                        PMC = 0,
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

        public ulong barcode { get; set; }

        public byte kolicina { get; set; }
    }








}
