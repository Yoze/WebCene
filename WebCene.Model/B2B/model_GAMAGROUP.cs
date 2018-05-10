using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCene.Model.B2B
{
   
    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Cenovnik
    {

        private CenovnikArtikal[] artikalField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Artikal")]
        public CenovnikArtikal[] Artikal
        {
            get
            {
                return this.artikalField;
            }
            set
            {
                this.artikalField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CenovnikArtikal
    {

        /// <remarks/>
        public string Ident { get; set; }

        /// <remarks/>
        public string Naziv { get; set; }

        /// <remarks/>
        public string EAN { get; set; }

        /// <remarks/>
        public uint Price { get; set; }

        /// <remarks/>
        public uint PMPC { get; set; }

        /// <remarks/>
        public ushort Stock { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StockSpecified { get; set; }

        /// <remarks/>
        public string Img { get; set; }
    }















}
