using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using WebCene.Model.B2B;


namespace WebCene.Helper
{
    public sealed class XMLHelper
    {

        // C# Singleton pattern
        // https://www.dotnetperls.com/singleton
        //

        static readonly XMLHelper _instance = new XMLHelper();

        public static XMLHelper Instance
        {
            get { return _instance; }
        }

        XMLHelper()
        {
            // initialize here
        }




        /** Public methods */

        public bool ValidateLoadedXml(XmlDocument xmlToValidate)
        {

            try
            {
                
            }
            catch (Exception)
            {

                throw;
            }

            return true;
        }




    }
}
