using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using WebCene.Model.B2B;

namespace WebCene.Helper
{
    public sealed class HTTPSHelper
    {

        // C# Singleton pattern
        // https://www.dotnetperls.com/singleton
        //

        static readonly HTTPSHelper _instance = new HTTPSHelper();

        public static HTTPSHelper Instance
        {
            get { return _instance; }
        }
        
        HTTPSHelper()
        {
            // initialize here
        }



        /** Public methods */
        public string Test()
        {
            return "Hello from HTTP Singleton";
        }
        
        public XmlDocument GetXmlFromHttpRequest(KonfigDobavljaca konfigDobavljaca)
        {

            var xmlPath = konfigDobavljaca.URL;

            string downloadResult;

            // Get XML from http request
            using (var webClient = new WebClient())
            {
                downloadResult = webClient.DownloadString(xmlPath);
            }


            // New Xml Document
            // https://docs.microsoft.com/en-us/dotnet/api/system.xml.xmldocument.-ctor?f1url=https%3A%2F%2Fmsdn.microsoft.com%2Fquery%2Fdev15.query%3FappId%3DDev15IDEF1%26l%3DEN-US%26k%3Dk(System.Xml.XmlDocument.%2523ctor);k(TargetFrameworkMoniker-.NETFramework,Version%3Dv4.6.1);k(DevLang-csharp)%26rd%3Dtrue&view=netframework-4.7.1

            // http://csharp.net-tutorials.com/xml/reading-xml-with-the-xmldocument-class/

            XmlDocument xmlResult = new XmlDocument();
            xmlResult.LoadXml(downloadResult);


            return xmlResult;
        }



    }
}
