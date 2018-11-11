namespace WebCene.Model.B2B
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MarzeDobavljaca")]
    public partial class MarzeDobavljaca
    {
        public int Id { get; set; }

        public int IdDobavljaca { get; set; }

        public int NncDonjiLimit { get; set; }

        public int NncGornjiLimit { get; set; }

        public decimal MarzaProc { get; set; }

        public decimal RabatProc { get; set; }

        public int? Brend { get; set; }

        public virtual Brendovi Brendovi { get; set; }

        public virtual KonfigDobavljaca KonfigDobavljaca { get; set; }
    }
}
