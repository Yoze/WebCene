using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCene.Model.B2B.extendNameSpace.orbico
{



    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Items
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Item")]
        public ItemsItem[] Item { get; set; }

    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ItemsItem
    {

        public string id { get; set; }

        public string manufacturer { get; set; }

        public string name { get; set; }

        public string category { get; set; }

        public string subcategory { get; set; }

        public string price { get; set; }

        public string price_rebate { get; set; }

        public string vat { get; set; }

        public ushort qty { get; set; }

        public ulong ean { get; set; }
    }







}
