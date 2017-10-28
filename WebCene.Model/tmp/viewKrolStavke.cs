namespace WebCene.Model.tmp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
    }
}
