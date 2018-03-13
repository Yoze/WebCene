namespace WebCene.Model.Kroler
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Podesavanja")]
    public partial class Podesavanja
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string NazivPodesavanja { get; set; }

        [Required]
        [StringLength(4000)]
        public string OdabraniProizvodiIds { get; set; }
    }
}
