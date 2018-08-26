using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCene.Model.B2B;

namespace WebCene.Model.B2B
{

    [NotMapped]
    public class LoadedXmlStatus : KonfigDobavljaca
    {
        public int Number { get; set; }

        public DateTime Date { get; set; }

        public bool IsLoaded { get; set; }

        public int NumberOfRecords { get; set; }       
        
        public string StatusDescription { get; set; }

        public string DataSource { get; set; }

        public KonfigDobavljaca konfigDobavljaca { get; set; }

    }
}
