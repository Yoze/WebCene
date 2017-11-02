namespace WebCene.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KATARTIK")]
    public partial class KATARTIK
    {
        [Key]
        [StringLength(12)]
        public string SHKAT { get; set; }

        [Required]
        [StringLength(30)]
        public string KAT1 { get; set; }

        [Required]
        [StringLength(30)]
        public string KAT2 { get; set; }

        [Required]
        [StringLength(30)]
        public string KAT3 { get; set; }
    }
}
