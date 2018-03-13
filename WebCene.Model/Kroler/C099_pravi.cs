namespace WebCene.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("099 pravi")]
    public partial class C099_pravi
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(13)]
        public string BARCODE { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(3)]
        public string SIFRAMAG { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(7)]
        public string ARTIKAL { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(30)]
        public string NAZIV { get; set; }

        [StringLength(3)]
        public string JEDMERE { get; set; }

        [StringLength(3)]
        public string TARIFA { get; set; }

        public double? CENAMALO { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(12)]
        public string SHKAT { get; set; }

        public byte? AKCIJA { get; set; }

        public byte? NOVO { get; set; }

        public byte? ARHIVA { get; set; }

        public byte? PRIKAZI { get; set; }

        [StringLength(30)]
        public string PROIZVODJAC { get; set; }

        public double? CENA { get; set; }

        public double? CENAEUR { get; set; }
    }
}
