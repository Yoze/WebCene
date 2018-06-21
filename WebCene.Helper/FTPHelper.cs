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
                // FTP request
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(requestUri);
                request.Credentials = new NetworkCredential(konfigDobavljaca.Username, konfigDobavljaca.Password);
                request.KeepAlive = false;
                request.UseBinary = true;
                request.UsePassive = true;
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                // FTP response
                FtpWebResponse ftpResponse = (FtpWebResponse)request.GetResponse();
                Stream responseStream = ftpResponse.GetResponseStream(); ;

                // Stream Reader
                string readerResult;
                using (reader = new StreamReader(responseStream))
                {
                    readerResult = reader.ReadToEnd();
                }

                // Xml
                xmlDocument.LoadXml(readerResult);
                loadedXmlDocument.LoadedXmlDocumentItem.LoadXml(readerResult);

                var exitMessage = ftpResponse.ExitMessage;
                var statusDescription = ftpResponse.StatusDescription; // transfer completed
                var lastModified = ftpResponse.LastModified;


                loadedXmlDocument.XmlLastModified = ftpResponse.LastModified;


                if (ftpResponse != null) ftpResponse.Close();

                return loadedXmlDocument;

            }
            catch (Exception xcp)
            {
                var msg = xcp.Message;
            }
            return loadedXmlDocument;

        }


      
      





        //    #region old
        //    //try
        //    //{
        //    //    // FTP request
        //    //    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(requestUriString);

        //    //    request.Credentials = new NetworkCredential(konfigDobavljaca.Username, konfigDobavljaca.Password);
        //    //    request.KeepAlive = false;
        //    //    request.UseBinary = true;
        //    //    request.UsePassive = true;
        //    //    request.Method = WebRequestMethods.Ftp.DownloadFile;

        //    //    // FTP response
        //    //    FtpWebResponse response = (FtpWebResponse)request.GetResponse();

        //    //    Stream responseStream = response.GetResponseStream();

        //    //    StreamReader reader = null;

        //    //    #region obs
        //    //    //StreamReader reader = new StreamReader(responseStream);
        //    //    //string readerResult = reader.ReadToEnd();

        //    //    // Dispose resources
        //    //    //if (reader != null) reader.Close();
        //    //    //if (response != null) response.Close();
        //    //    #endregion

        //    //    string readerResult;

        //    //    using (reader = new StreamReader(responseStream))
        //    //    {
        //    //        readerResult = reader.ReadToEnd();
        //    //    }

        //    //    xmlResult.LoadXml(readerResult);
        //    //    rezultatFtpUcitavanja.UcitaniXmlDocument.LoadXml(readerResult);
        //    //    rezultatFtpUcitavanja.LastModifiedDate = response.LastModified;


        //    //    if (response != null) response.Close();

        //    //    return rezultatFtpUcitavanja;

        //    //   




        //    //    //    default:
        //    //    //        {
        //    //    //            //string readerResult; 

        //    //    //            //using (reader = new StreamReader(responseStream))
        //    //    //            //{
        //    //    //            //    readerResult = reader.ReadToEnd();
        //    //    //            //}

        //    //    //            //xmlResult.LoadXml(readerResult);
        //    //    //            //rezultatFtpUcitavanja.UcitaniXmlDocument.LoadXml(readerResult);

        //    //    //            //if (response != null) response.Close();
        //    //    //        }                       
        //    //    //        //return xmlResult;
        //    //    //        //return rezultatFtpUcitavanja;
        //    //    //}

        //    //    #endregion


        //    //}
        //    //catch (Exception e)
        //    //{
        //    //    throw new Exception("Greška: GetXmlFileFromFtp()\r\n" + e.Message);
        //    //}

        //    #endregion
        //}

        //private void UcitajXmlDocumentSaFtp()
        //{

        //    try
        //    {
                
        //        // FTP request
        //        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(requestUriString);

        //        request.Credentials = new NetworkCredential(konfigDobavljaca.Username, konfigDobavljaca.Password);
        //        request.KeepAlive = false;
        //        request.UseBinary = true;
        //        request.UsePassive = true;
        //        request.Method = WebRequestMethods.Ftp.DownloadFile;

        //        // FTP response
        //        FtpWebResponse response = (FtpWebResponse)request.GetResponse();

        //        Stream responseStream = response.GetResponseStream();

        //        StreamReader reader = null;

        //        string readerResult;

        //        using (reader = new StreamReader(responseStream))
        //        {
        //            readerResult = reader.ReadToEnd();
        //        }

        //        xmlResult.LoadXml(readerResult);
        //        rezultatFtpUcitavanja.UcitaniXmlDocument.LoadXml(readerResult);
        //        rezultatFtpUcitavanja.LastModifiedDate = response.LastModified;


        //        if (response != null) response.Close();

        //        return rezultatFtpUcitavanja;



        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception("Greška: GetXmlFileFromFtp()\r\n" + e.Message);
        //    }
        //}



    }
}


