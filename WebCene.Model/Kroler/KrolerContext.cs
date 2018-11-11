namespace WebCene.Model.Kroler
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using WebCene.Model.B2B;

    public partial class KrolerContext : DbContext
    {
        public KrolerContext()
            : base("name=KrolerContext")
        {
        }


        // Tables
        public DbSet<KrolGlava> KrolGlava { get; set; }
        public DbSet<KrolStavke> KrolStavke { get; set; }
        public DbSet<Prodavci> Prodavci { get; set; }
        public DbSet<Proizvod> Proizvod { get; set; }
        public DbSet<Podesavanja> Podesavanja { get; set; }
        public DbSet<KonfigDobavljaca> KonfigDobavljaca { get; set; }
        public virtual DbSet<MarzeDobavljaca> MarzeDobavljaca { get; set; }
        public virtual DbSet<Brendovi> Brendovi { get; set; }

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

            modelBuilder.Entity<KonfigDobavljaca>()
               .Property(e => e.WebProtokol)
               .IsFixedLength();

            modelBuilder.Entity<KonfigDobavljaca>()
                .Property(e => e.KeoficijentMarze)
                .HasPrecision(5, 2);

            modelBuilder.Entity<KonfigDobavljaca>()
                .Property(e => e.KursEvra)
                .HasPrecision(5, 2);

            modelBuilder.Entity<KonfigDobavljaca>()
                .HasMany(e => e.MarzeDobavljaca)
                .WithRequired(e => e.KonfigDobavljaca)
                .HasForeignKey(e => e.IdDobavljaca);

            modelBuilder.Entity<MarzeDobavljaca>()
                .Property(e => e.MarzaProc)
                .HasPrecision(4, 2);

            modelBuilder.Entity<MarzeDobavljaca>()
                .Property(e => e.RabatProc)
                .HasPrecision(4, 2);

            modelBuilder.Entity<Brendovi>()
               .Property(e => e.BarcodeSegment)
               .IsFixedLength();

            modelBuilder.Entity<Brendovi>()
                .HasMany(e => e.MarzeDobavljaca)
                .WithOptional(e => e.Brendovi)
                .HasForeignKey(e => e.Brend);
        }
    }
}
