namespace WebCene.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WebCeneModel : DbContext
    {
        public WebCeneModel()
            : base("name=WebCeneModel")
        {
        }

        // Tables
        public DbSet<KrolGlava> KrolGlava { get; set; }
        public DbSet<KrolStavke> KrolStavke { get; set; }
        public DbSet<Prodavci> Prodavci { get; set; }
        public DbSet<Proizvod> Proizvod { get; set; }
        public DbSet<Podesavanja> Podesavanja { get; set; }

        // Views
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
