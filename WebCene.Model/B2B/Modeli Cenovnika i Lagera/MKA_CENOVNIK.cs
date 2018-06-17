using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCene.Model.B2B.mka
{

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Dokument
    {

        public string Tip { get; set; }

        public decimal Verzija { get; set; }

        [System.Xml.Serialization.XmlArrayItemAttribute("Stavka", IsNullable = false)]
        public DokumentStavka[] Stavke { get; set; }
    }

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DokumentStavka
    {

        public string Vrsta { get; set; }

        public string Naziv { get; set; }

        public string ArtID { get; set; }

        public decimal BarKod { get; set; }

        public string JM { get; set; }

        public decimal Kolicina { get; set; }

        public decimal CenaVP { get; set; }

        public decimal CenaMP { get; set; }

        public string Valuta { get; set; }

        public decimal PorezProc { get; set; }

        public string Proizvodjac { get; set; }
    }









}
