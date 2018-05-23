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
using System.Xml.Serialization;
using System.Xml.Schema;

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


        public string CreateRequestUri(KonfigDobavljaca konfigDobavljaca)
        {
            // Create supplier specific request Uri string
            string requestUriString = string.Empty;

            if (konfigDobavljaca != null)
            {
                // konfigDobavljaca.Username == ftp supplier folder name
                requestUriString =
                    konfigDobavljaca.URL + "/" +
                    //konfigDobavljaca.Username + "/" +
                    konfigDobavljaca.Filename;
            }

            return requestUriString;
        }


        public XmlDocument GetXmlFileFromFtp(KonfigDobavljaca konfigDobavljaca)
        {
            // https://www.c-sharpcorner.com/UploadFile/0d5b44/ftp-using-C-Sharp-net/

            XmlDocument xmlResult = new XmlDocument();

            // requestUriString
            string requestUriString = CreateRequestUri(konfigDobavljaca);
            if (string.IsNullOrEmpty(requestUriString)) return null;

            try
            {
                // FTP request
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(requestUriString);

                request.Credentials = new NetworkCredential(konfigDobavljaca.Username, konfigDobavljaca.Password);
                request.KeepAlive = false;
                request.UseBinary = true;
                request.UsePassive = true;
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                // FTP response
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                string responseStatus = response.StatusDescription;

                Stream responseStream = response.GetResponseStream();

                StreamReader reader = null;
                //StreamReader reader = new StreamReader(responseStream);
                //string readerResult = reader.ReadToEnd();

                // Dispose resources
                //if (reader != null) reader.Close();
                //if (response != null) response.Close();


                switch (konfigDobavljaca.ExtraData)
                {
                    //case "GORENJE":
                    //    {
                    //        using (reader = new StreamReader(responseStream, Encoding.UTF8, true))
                    //        {

                    //            Root gorenje = new Root();
                    //            var serializer = new XmlSerializer(typeof(Root));

                    //            XmlReaderSettings xmlReaderSettings = new XmlReaderSettings();
                    //            xmlReaderSettings.ValidationType = ValidationType.DTD;
                    //            //xmlReaderSettings.ValidationEventHandler += new ValidationEventHandler(ValidationCallback);


                    //            XmlTextReader xmlNodeReader = new XmlTextReader(reader);


                    //            using (XmlReader xmlReader = XmlReader.Create(xmlNodeReader, xmlReaderSettings))
                    //            {

                    //                gorenje = (Root)serializer.Deserialize(xmlReader);
                    //            }





                    //            xmlResult.Load(reader);
                    //        }
                    //        if (response != null) response.Close();
                    //    }
                    //    return xmlResult;

                    default:
                        {
                            string readerResult; 

                            using (reader = new StreamReader(responseStream))
                            {
                                readerResult = reader.ReadToEnd();
                            }

                            xmlResult.LoadXml(readerResult);
                            if (response != null) response.Close();
                        }                       
                        return xmlResult;
                }
 
               


                
            }
            catch (Exception e)
            {
                throw new Exception("Greška: GetXmlFileFromFtp()\r\n" + e.Message);
            }
        }





    }
}
