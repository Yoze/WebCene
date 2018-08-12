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

            LoadedXmlDocument loadedxmlFromHttpRequst = new LoadedXmlDocument();

            var xmlPath = konfigDobavljaca.URL;

            string downloadResult;

            // Get XML from http request
            using (var webClient = new WebClient())
            {
                downloadResult = webClient.DownloadString(xmlPath);

                XmlDocument loadedXmlDocFromHttpRequest = new XmlDocument();

                switch (konfigDobavljaca.ModelCenovnik)
                {
                    case "ZOMIMPEX_CENOVNIK":
                        {
                            Stream stream = webClient.OpenRead(xmlPath);

                            //using (StreamReader reader = new StreamReader(stream, Encoding.UTF8, true))
                            //{

                            //    //extNS.zomimpex.ZOMIMPEX_CENOVNIK zomImpexCenovnikCenovnik = new extNS.zomimpex.ZOMIMPEX_CENOVNIK(konfigDobavljaca, ucitaniXmlDocument);
                            //    //return b2B_Results_RowItems = gorenjeCenovnik.b2B_Results_RowItems;

                            //    XmlSerializer serializer = new XmlSerializer(typeof(extNS.zomimpex.Artikl));

                            //    object result = serializer.Deserialize(reader); // exception here!

                            //    loadedXmlDocFromHttpRequest.Load(reader);

                            //    loadedxmlFromHttpRequst.LoadedXmlDocumentItem.Load(reader);
                            //}
                        }
                        return loadedxmlFromHttpRequst;





                    default:
                        loadedxmlFromHttpRequst.LoadedXmlDocumentItem.LoadXml(downloadResult);
                        return loadedxmlFromHttpRequst;
                }

            }

        }



    }
}
