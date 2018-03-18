using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCene.Model.B2B
{
   
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class izdelki
    {

        [System.Xml.Serialization.XmlElementAttribute("izdelek")]
        public izdelkiIzdelek[] izdelek { get; set; }
    }


    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class izdelkiIzdelek
    {

        public string sifra { get; set; }

        public string naziv { get; set; }

        public string cena { get; set; }

        public byte zaloga { get; set; }

        public object rabat { get; set; }

        public string ppc { get; set; }

        public ulong ean { get; set; }

        public byte davek { get; set; }

        public object opis { get; set; }

        public uint bruto_teza { get; set; }

        public ushort sirina { get; set; }

        public ushort visina { get; set; }

        public ushort globina { get; set; }
    }




}
