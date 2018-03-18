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

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ITEM")]
        public ITEMSITEM[] ITEM { get; set; }
    }

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ITEMSITEM
    {

        public string id { get; set; }

        public string name { get; set; }

        public string barcode { get; set; }

        public object part_no { get; set; }

        public object image_url { get; set; }

        public string stock { get; set; }

        public object price { get; set; }

        public object currency { get; set; }

        public string category { get; set; }

        public string category2 { get; set; }
    }

}






