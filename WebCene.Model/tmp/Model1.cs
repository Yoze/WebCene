namespace WebCene.Model.tmp
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<viewKrolStavke> viewKrolStavke { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<viewKrolStavke>()
                .Property(e => e.Cena)
                .HasPrecision(10, 2);

            modelBuilder.Entity<viewKrolStavke>()
                .Property(e => e.ElSifraProizvoda)
                .IsUnicode(false);
        }
    }
}
