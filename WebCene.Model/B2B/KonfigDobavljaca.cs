namespace WebCene.Model.B2B
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KonfigDobavljaca")]
    public partial class KonfigDobavljaca
    {
        public KonfigDobavljaca()
        {
            MarzeDobavljaca = new HashSet<MarzeDobavljaca>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Naziv { get; set; }

        [StringLength(10)]
        public string WebProtokol { get; set; }

        [StringLength(250)]
        public string URL { get; set; }

        [StringLength(50)]
        public string CenovnikFilename { get; set; }

        [StringLength(50)]
        public string LagerFilename { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(50)]
        public string ModelCenovnik { get; set; }

        [StringLength(50)]
        public string ModelLager { get; set; }

        public double RabatProc { get; set; }

        public double KursEvra { get; set; }

        public bool Manualno { get; set; }

        public virtual ICollection<MarzeDobavljaca> MarzeDobavljaca { get; set; }

    }
}
