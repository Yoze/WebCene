namespace WebCene.Model.B2B
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DARTIKLI")]
    public partial class DARTIKLI
    {
        [Required]
        [StringLength(3)]
        public string SIFRAMAG { get; set; }

        [Required]
        [StringLength(7)]
        public string ARTIKAL { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(13)]
        public string BARCODE { get; set; }

        [Required]
        [StringLength(30)]
        public string NAZIV { get; set; }

        public double? KOLICINA { get; set; }

        public double? CENA { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string PROIZVODJAC { get; set; }

        public double? ASSUME { get; set; }

        [StringLength(60)]
        public string URLSLIKE { get; set; }

        [StringLength(400)]
        public string OPISARTIKLA { get; set; }

        [StringLength(60)]
        public string URLARTIKLAVENDOR { get; set; }

        public double? NNC { get; set; }

        public double? PMC { get; set; }

        public byte? AKTIVAN { get; set; }

        public byte? OZNAKA { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DATUMULISTAVANJA { get; set; }

        [StringLength(30)]
        public string PRIMARNIDOBAVLJAC { get; set; }
    }
}
