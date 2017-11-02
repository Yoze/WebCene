namespace WebCene.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BRAND")]
    public partial class BRAND
    {
        [Key]
        [StringLength(30)]
        public string PROIZVODJAC { get; set; }
    }
}
