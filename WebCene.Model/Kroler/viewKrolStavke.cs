namespace WebCene.Model.Kroler
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.CompilerServices;

    [Table("infoekon_Bane.viewKrolStavke")]
    public partial class viewKrolStavke
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KrolGLId { get; set; }

        [StringLength(40)]
        public string Naziv { get; set; }

        [StringLength(50)]
        public string NazivProdavca { get; set; }

        [Key]
        [Column(Order = 1)]
        public decimal Cena { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(8)]
        public string ElSifraProizvoda { get; set; }

        [StringLength(20)]
        public string ElKat { get; set; }

        [StringLength(50)]
        public string Brend { get; set; }
    }
}
