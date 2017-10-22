namespace WebCene.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("infoekon_Bane.Proizvod")]
    public partial class Proizvod
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proizvod()
        {
            KrolStavke = new HashSet<KrolStavke>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(8)]
        public string ElSifraProizvoda { get; set; }

        [StringLength(20)]
        public string ElEAN { get; set; }

        [StringLength(40)]
        public string Naziv { get; set; }

        [StringLength(20)]
        public string ElKat { get; set; }

        [StringLength(50)]
        public string Brend { get; set; }

        [StringLength(50)]
        public string Dobavljac { get; set; }

        [StringLength(250)]
        public string ShopmaniaURL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KrolStavke> KrolStavke { get; set; }
    }
}
