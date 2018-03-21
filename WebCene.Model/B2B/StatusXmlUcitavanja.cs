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
    public class StatusXmlUcitavanja : KonfigDobavljaca
    {
        public int Number { get; set; }

        public DateTime Date { get; set; }

        public bool isLoaded { get; set; }

        public bool isParsed { get; set; }

        public bool isValidated { get; set; }


    }
}
