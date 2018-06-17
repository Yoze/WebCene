using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WebCene.Model.B2B
{
    public class RezultatSaFtp
    {

        public RezultatSaFtp()
        {
            UcitaniXmlDocument = new XmlDocument();
        }

        public XmlDocument UcitaniXmlDocument { get; set; }

        public DateTime LastModified { get; set; }

    }
}
