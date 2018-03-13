namespace WebCene.Model.Kroler
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("infoekon_Bane.KrolStavke")]
    public partial class KrolStavke
    {
        public int Id { get; set; }

        public int KrolGlavaId { get; set; }

        public int ProizvodId { get; set; }

        public int ProdavciId { get; set; }

        public decimal Cena { get; set; }
      
        public virtual KrolGlava KrolGlava { get; set; }

        public virtual Prodavci Prodavci { get; set; }

        public virtual Proizvod Proizvod { get; set; }
    }
}
