using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WebCene.Model.B2B
{
    public class RezultatZaPrikaz
    {

        public RezultatZaPrikaz()
        {
            CenovnikLagerZaDobavljaca = new List<PodaciZaPrikaz>();
        }


        public DateTime CenovnikLastModified { get; set; }
        public DateTime LagerLastModified { get; set; }

        public List<PodaciZaPrikaz> CenovnikLagerZaDobavljaca { get; set; }

    }
}
