namespace WebCene.Model.B2B
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Brendovi")]
    public partial class Brendovi
    {
        public Brendovi()
        {
            MarzeDobavljaca = new HashSet<MarzeDobavljaca>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Naziv { get; set; }

        [StringLength(10)]
        public string BarcodeSegment { get; set; }

        public virtual ICollection<MarzeDobavljaca> MarzeDobavljaca { get; set; }
    }
}
