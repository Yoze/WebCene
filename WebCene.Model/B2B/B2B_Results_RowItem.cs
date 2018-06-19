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

        public DateTime KolicinaDatum { get; set; }

        public decimal Cena { get; set; }

        public DateTime CenaDatum { get; set; }

        public decimal PMC { get; set; }

        public DateTime DatumUlistavanja { get; set; }

        public string PrimarniDobavljac { get; set; }      


    }
}
