namespace WebCene.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("infoekon_Bane.Prodavci")]
    public partial class Prodavci
    {
        
        public Prodavci()
        {
            KrolStavke = new HashSet<KrolStavke>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string NazivProdavca { get; set; }

        [StringLength(150)]
        public string SajtProdavca { get; set; }

        [StringLength(20)]
        public string SMId { get; set; }

        
        public virtual ICollection<KrolStavke> KrolStavke { get; set; }
    }
}
