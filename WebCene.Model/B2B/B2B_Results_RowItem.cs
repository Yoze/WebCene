using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCene.Model.B2B
{
    public class B2B_Results_RowItem
    {

        public List<B2B_Results_RowItem> Results_RowItems { get; set; }


        public string Barcode { get; set; }

        public int Kolicina { get; set; }

        public DateTime LagerDatum { get; set; }

        public double NNC { get; set; }

        public DateTime CenovnikDatum { get; set; }

        public double PMC { get; set; }

        public DateTime DatumUlistavanja { get; set; }

        public string PrimarniDobavljac { get; set; }      


    }
}
