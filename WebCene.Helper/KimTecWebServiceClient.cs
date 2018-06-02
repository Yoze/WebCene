using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace WebCene.Helper
{
    public sealed class KimTecWebServiceClient
    {
        /** Singleton */
        static readonly KimTecWebServiceClient _instance = new KimTecWebServiceClient();

        public static KimTecWebServiceClient Instance
        {
            get { return _instance; }
        }

        KimTecWebServiceClient()
        {
            // intialize here
        }


        /*
         Creating the Web Service Proxy
         https://docs.microsoft.com/en-us/sql/reporting-services/report-server-web-service/net-framework/creating-the-web-service-proxy
         */

        //public void CallWebService()
        //{

        //    /* 
        //     * USER: elbraco.group
        //     * PSW: vthvAJZ3sqW
        //     * 
        //     * najnoviji psw: 1053
        //     */


        //    string certPath = @"D:\Temp\B2B ELBRACO GROUP d.o.o..p12";
        //    string certPassword = "1053";


        //    X509Certificate certificate = new X509Certificate(certPath, certPassword);

        //    string resultTrue = certificate.ToString(true);

        //    string resultFalse = certificate.ToString(false);



        //    //string certName = "<B2B ELBRACO GROUP d.o.o..p12>";



        //}




    }
}
