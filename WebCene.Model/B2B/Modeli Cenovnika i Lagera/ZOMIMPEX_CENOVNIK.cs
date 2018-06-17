using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCene.Model.B2B.zomimpex
{
   
        // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class Artikl
        {

            private ArtiklInformacijeArtikla[] informacijeArtiklaField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("InformacijeArtikla")]
            public ArtiklInformacijeArtikla[] InformacijeArtikla
            {
                get
                {
                    return this.informacijeArtiklaField;
                }
                set
                {
                    this.informacijeArtiklaField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class ArtiklInformacijeArtikla
        {

            /// <remarks/>
            public string Šifra { get; set; }

            /// <remarks/>
            public string Naziv { get; set; }

            /// <remarks/>
            public string Opis { get; set; }

            /// <remarks/>
            public string Količina { get; set; }

            /// <remarks/>
            public decimal Cena { get; set; }

            /// <remarks/>
            public string AkcijskaCena { get; set; }

            /// <remarks/>
            public string LinkProizvoda { get; set; }

            /// <remarks/>
            public string Kategorija { get; set; }

            /// <remarks/>
            public string Slika { get; set; }

            /// <remarks/>
            public string Bar_kod { get; set; }
        }





    
}
