using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using WebCene.Model.B2B;
using System.Xml;
using System.Diagnostics;

namespace WebCene.Helper
{
    public sealed class FTPHelper
    {

        // C# Singleton pattern
        // https://www.dotnetperls.com/singleton
        //


        // VOX
        // ftp://elbraco@ftp.elbraco.rs/elvoxerg/erg.xml
        // elbraco
        // Jeev1oju


        static readonly FTPHelper _instance = new FTPHelper();

        public static FTPHelper Instance
        {
            get { return _instance; }
        }


        FTPHelper()
        {
            // initialize here

        }


        /**  Public methods  */
        public string Test()
        {
            return "Hello from FTP Singleton";
        }


        public XmlDocument GetXmlFileFromFtp(KonfigDobavljaca konfigDobavljaca)
        {
            // https://www.c-sharpcorner.com/UploadFile/0d5b44/ftp-using-C-Sharp-net/

            try
            {
                // FTP request
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(konfigDobavljaca.URL);

                request.Credentials = new NetworkCredential(konfigDobavljaca.Username, konfigDobavljaca.Password);
                request.KeepAlive = false;
                request.UseBinary = true;
                request.UsePassive = true;

                // FTP response
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                // Stream reader
                // http://csharp.net-tutorials.com/xml/reading-xml-with-the-xmlreader-class/
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);

                string readerResult = reader.ReadToEnd();
                                
                // Dispose reader
                if ( reader != null ) reader.Close();
                if ( response != null ) response.Close();


                // New Xml Document
                // https://docs.microsoft.com/en-us/dotnet/api/system.xml.xmldocument.-ctor?f1url=https%3A%2F%2Fmsdn.microsoft.com%2Fquery%2Fdev15.query%3FappId%3DDev15IDEF1%26l%3DEN-US%26k%3Dk(System.Xml.XmlDocument.%2523ctor);k(TargetFrameworkMoniker-.NETFramework,Version%3Dv4.6.1);k(DevLang-csharp)%26rd%3Dtrue&view=netframework-4.7.1

                XmlDocument xmlResult = new XmlDocument();
                xmlResult.LoadXml(readerResult);


                // test 
                foreach (XmlElement item in xmlResult)
                {
                    if (item.Attributes["name"] != null)  Debug.WriteLine(item.Attributes["name"].Value);
                }



                return xmlResult;
            }
            catch (Exception e)
            {
                throw new Exception("Greška: GetXmlFileFromFtp()\r\n" + e.Message);
            }
        }
        




    }
}
