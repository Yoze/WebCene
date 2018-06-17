using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
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
        


        //public RezultatZaPrikaz PreuzmiXml_HttpRequest(KonfigDobavljaca konfigDobavljaca)
        //{

        //    RezultatZaPrikaz rezultatHttpZahteva = new RezultatZaPrikaz();

        //    var xmlPath = konfigDobavljaca.URL;

        //    string downloadResult;

        //    // Get XML from http request
        //    using (var webClient = new WebClient())
        //    {
        //        downloadResult = webClient.DownloadString(xmlPath);

        //        //XmlDocument xmlResult = new XmlDocument();

        //        switch (konfigDobavljaca.ModelCenovnik)
        //        {
        //            case "ZOMIMPEX":                  
        //                { 
        //                    Stream stream = webClient.OpenRead(xmlPath);

        //                    using (StreamReader reader = new StreamReader(stream, Encoding.UTF8, true))
        //                    {
        //                        //XmlSerializer serializer = new XmlSerializer(typeof(Artikl));

        //                        //object result = serializer.Deserialize(reader);

        //                        //xmlResult.Load(reader);

        //                        rezultatHttpZahteva.UcitaniXmlDocument.Load(reader);
        //                    }                            
        //                }
        //                return rezultatHttpZahteva;

        //            default:
        //                rezultatHttpZahteva.UcitaniXmlDocument.LoadXml(downloadResult);
        //                return rezultatHttpZahteva;
        //        }

        //    }
            
        //}



    }
}
