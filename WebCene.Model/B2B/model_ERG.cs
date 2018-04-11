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
    public partial class ITEMS
    {

        private ITEMSITEM[] iTEMField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ITEM")]
        public ITEMSITEM[] ITEM
        {
            get
            {
                return this.iTEMField;
            }
            set
            {
                this.iTEMField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ITEMSITEM
    {

        /// <remarks/>
        public string id { get; set; }

        /// <remarks/>
        public string name { get; set; }

        /// <remarks/>
        public string barcode { get; set; }

        /// <remarks/>
        public object part_no { get; set; }

        /// <remarks/>
        public object image_url { get; set; }

        /// <remarks/>
        public string stock { get; set; }

        /// <remarks/>
        public decimal price { get; set; }

        /// <remarks/>
        public object currency { get; set; }

        /// <remarks/>
        public string category { get; set; }

        /// <remarks/>
        public string category2 { get; set; }
    }



}






