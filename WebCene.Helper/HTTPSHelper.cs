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
using extNS = WebCene.Model.B2B;

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


        public LoadedXmlDocument LoadXmlDocWithHttpRequest(KonfigDobavljaca konfigDobavljaca)
        {
            // xml document u koji se deserijalizuju učitani podaci
            XmlDocument xmlDocument = new XmlDocument();

            // model u koji se smeštaju deserijaliovani xml document i ostali detalji transfera
            LoadedXmlDocument loadedXmlDocFromHttpRequest = new LoadedXmlDocument();

            // http putanja sa koje se učitavaju podaci
            var xmlPath = konfigDobavljaca.URL;
                       

            // Get XML from http request
            using (var webClient = new WebClient())
            {
                // download xml-a kao stringa
                string downloadResult;
                downloadResult = webClient.DownloadString(xmlPath);
               
                // rezultat učitavanja strema reader-a 
                string readerResults = string.Empty;

                try
                {
                    using (Stream stream = webClient.OpenRead(xmlPath))
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {

                            readerResults = reader.ReadToEnd();

                            xmlDocument.LoadXml(readerResults);

                            loadedXmlDocFromHttpRequest.LoadedXmlDocumentItem.LoadXml(readerResults);

                            return loadedXmlDocFromHttpRequest;
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }





    }
}
