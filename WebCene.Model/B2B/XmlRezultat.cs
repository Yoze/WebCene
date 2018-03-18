using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCene.Model.B2B
{
    public class XmlRezultat
    {

        public string Barcode { get; set; }

        public int Kolicina { get; set; }

        public decimal Cena { get; set; }

        public decimal PMC { get; set; }

        public DateTime DatumUlistavanja { get; set; }

        public string PrimarniDobavljac { get; set; }
        


    }
}
