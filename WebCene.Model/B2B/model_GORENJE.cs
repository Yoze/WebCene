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
    public partial class Root
    {

        private RootRow[] rowField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Row")]
        public RootRow[] Row
        {
            get
            {
                return this.rowField;
            }
            set
            {
                this.rowField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class RootRow
    {

        private string modelField;

        private uint ifraField;

        private bool ifraFieldSpecified;

        private uint ifra2Field;

        private ulong eAN_codeField;

        private byte komField;

        /// <remarks/>
        public string Model
        {
            get
            {
                return this.modelField;
            }
            set
            {
                this.modelField = value;
            }
        }

        /// <remarks/>
        public uint ifra
        {
            get
            {
                return this.ifraField;
            }
            set
            {
                this.ifraField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ifraSpecified
        {
            get
            {
                return this.ifraFieldSpecified;
            }
            set
            {
                this.ifraFieldSpecified = value;
            }
        }

        /// <remarks/>
        public uint ifra2
        {
            get
            {
                return this.ifra2Field;
            }
            set
            {
                this.ifra2Field = value;
            }
        }

        /// <remarks/>
        public ulong EAN_code
        {
            get
            {
                return this.eAN_codeField;
            }
            set
            {
                this.eAN_codeField = value;
            }
        }

        /// <remarks/>
        public byte kom
        {
            get
            {
                return this.komField;
            }
            set
            {
                this.komField = value;
            }
        }
    }








}
