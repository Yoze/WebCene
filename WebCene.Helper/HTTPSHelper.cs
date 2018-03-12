using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return "Hello from HTTPS Singleton";
        }






    }
}
