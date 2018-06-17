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


        public string KreirajRequestUri(KonfigDobavljaca konfigDobavljaca, string fileName)
        {
            string requestUriString = string.Empty;

            if (konfigDobavljaca != null)
            {
                requestUriString = konfigDobavljaca.URL + "/" + fileName;
            }

            return requestUriString;
        }
        


        public RezultatSaFtp UcitajXmlZaDobavljaca(KonfigDobavljaca konfigDobavljaca, string requestUriParam)
        {

            //RezultatZaPrikaz rezultatUcitavanja = new RezultatZaPrikaz();
            RezultatSaFtp rezultatSaFtp = new RezultatSaFtp();

            XmlDocument xmlResult = new XmlDocument();
            StreamReader reader = null;

            string requestUri = KreirajRequestUri(konfigDobavljaca, requestUriParam);

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
                Stream responseStream = ftpResponse.GetResponseStream();                

                // Učitavanje XMLa
                string readerResult;
                using (reader = new StreamReader(responseStream))
                {
                    readerResult = reader.ReadToEnd();
                }

                xmlResult.LoadXml(readerResult);
                //rezultatUcitavanja.UcitaniXmlDocument.LoadXml(readerResult);
                //rezultatUcitavanja.LastModifiedDate = ftpResponse.LastModified;
                rezultatSaFtp.UcitaniXmlDocument.LoadXml(readerResult);
                rezultatSaFtp.LastModified = ftpResponse.LastModified;

                if (ftpResponse != null) ftpResponse.Close();

                return rezultatSaFtp;
            }
            catch (Exception)
            {

                throw;
            }


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


