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


        public string CreateRequestUri(KonfigDobavljaca konfigDobavljaca, string fileName)
        {
            // requestUriString = URL + CenovnikFilename / LagerFilename

            string requestUriString = string.Empty;

            if (konfigDobavljaca != null)
            {
                requestUriString = konfigDobavljaca.URL + "/" + fileName;
            }

            return requestUriString;
        }
        


        public LoadedXmlDocument LoadXmlDocumentForSupplier(KonfigDobavljaca konfigDobavljaca, string requestUriParam)
        {

            LoadedXmlDocument loadedXmlDocument = new LoadedXmlDocument();

            XmlDocument xmlDocument = new XmlDocument();
            StreamReader reader = null;

            string requestUri = CreateRequestUri(konfigDobavljaca, requestUriParam);

            try
            {
                /** FTP request - get xml file */

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(requestUri);
                request.Credentials = new NetworkCredential(konfigDobavljaca.Username, konfigDobavljaca.Password);
                request.KeepAlive = false;
                request.UseBinary = true;
                request.UsePassive = true;
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                // FTP response
                FtpWebResponse ftpResponse = (FtpWebResponse)request.GetResponse();

                // Stream and Stream Reader
                Stream responseStream = ftpResponse.GetResponseStream(); ;
                
                string readerResult;
                using (reader = new StreamReader(responseStream))
                {
                    readerResult = reader.ReadToEnd();
                }

                // Loaded Xml document from xml file
                xmlDocument.LoadXml(readerResult);

                // output object - xml document and status description
                loadedXmlDocument.LoadedXmlDocumentItem.LoadXml(readerResult);
                loadedXmlDocument.StatusDescription = ftpResponse.StatusDescription; // transfer completed

                //var exitMessage = ftpResponse.ExitMessage;
               
                
                // dispose ftp reponse
                if (ftpResponse != null) ftpResponse.Close();



                /** Ftp request - get xml file details */

                FtpWebRequest requestFileDetails = (FtpWebRequest)WebRequest.Create(requestUri);
                requestFileDetails.Credentials = new NetworkCredential(konfigDobavljaca.Username, konfigDobavljaca.Password);
                requestFileDetails.KeepAlive = false;
                requestFileDetails.UseBinary = true;
                requestFileDetails.UsePassive = true;
                requestFileDetails.Method = WebRequestMethods.Ftp.GetDateTimestamp;

                FtpWebResponse ftpFileDetailsResponse = (FtpWebResponse)requestFileDetails.GetResponse();
                
                // output object - loaded xml file details 
                loadedXmlDocument.XmlLastModified = ftpFileDetailsResponse.LastModified;

                // dispose ftp response object
                if (ftpFileDetailsResponse != null) ftpFileDetailsResponse.Close();



                // output result 
                return loadedXmlDocument;

            }
            catch (Exception xcp)
            {
                var msg = xcp.Message;
            }
            return loadedXmlDocument;

        }




     



    }
}


