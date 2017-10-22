namespace WebCene.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("infoekon_Bane.KrolGlava")]
    public partial class KrolGlava
    {
        public KrolGlava()
        {
            KrolStavke = new HashSet<KrolStavke>();
        }

        public int Id { get; set; }

        public DateTime? DatumKrola { get; set; }

        [StringLength(50)]
        public string IzvrsilacKrola { get; set; }

        public virtual ICollection<KrolStavke> KrolStavke { get; set; }
    }
}
