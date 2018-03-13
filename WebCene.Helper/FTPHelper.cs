using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using WebCene.Model.B2B;

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


        public string GetXmlFileFromFtp(KonfigDobavljaca konfigDobavljaca)
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
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);

                string result = reader.ReadToEnd();


                // Dispose
                reader.Close();
                response.Close();

                return result;
            }
            catch (Exception e)
            {
                throw new Exception("Greška: GetXmlFileFromFtp()\r\n" + e.Message);
            }
        }
        




    }
}
