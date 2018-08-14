using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WebCene.Model.B2B
{
    public class LoadedXmlDocument
    {

        public LoadedXmlDocument()
        {
            LoadedXmlDocumentItem = new XmlDocument();
        }

        public XmlDocument LoadedXmlDocumentItem { get; set; }

        public DateTime XmlLastModified { get; set; }

        public string StatusDescription { get; set; }

    }
}
