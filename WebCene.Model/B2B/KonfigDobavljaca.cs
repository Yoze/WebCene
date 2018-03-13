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
        public int Id { get; set; }

        [StringLength(50)]
        public string Naziv { get; set; }

        [StringLength(10)]
        public string WebProtokol { get; set; }

        [StringLength(250)]
        public string URL { get; set; }

        [StringLength(50)]
        public string Filename { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(500)]
        public string ExtraData { get; set; }
    }
}
