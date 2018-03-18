namespace WebCene.Model.Kroler
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using WebCene.Model.B2B;

    public partial class ELBSModel : DbContext
    {
        public ELBSModel()
            : base("name=ELBSModelConn")
        {
        }

        public virtual DbSet<BRAND> BRAND { get; set; }
        public virtual DbSet<KATARTIK> KATARTIK { get; set; }
        public virtual DbSet<C099_pravi> C099_pravi { get; set; }
        public virtual DbSet<DARTIKLI> DARTIKLI { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BRAND>()
                .Property(e => e.PROIZVODJAC)
                .IsUnicode(false);

            modelBuilder.Entity<KATARTIK>()
                .Property(e => e.SHKAT)
                .IsUnicode(false);

            modelBuilder.Entity<KATARTIK>()
                .Property(e => e.KAT1)
                .IsUnicode(false);

            modelBuilder.Entity<KATARTIK>()
                .Property(e => e.KAT2)
                .IsUnicode(false);

            modelBuilder.Entity<KATARTIK>()
                .Property(e => e.KAT3)
                .IsUnicode(false);

            modelBuilder.Entity<C099_pravi>()
                .Property(e => e.BARCODE)
                .IsUnicode(false);

            modelBuilder.Entity<C099_pravi>()
                .Property(e => e.SIFRAMAG)
                .IsUnicode(false);

            modelBuilder.Entity<C099_pravi>()
                .Property(e => e.ARTIKAL)
                .IsUnicode(false);

            modelBuilder.Entity<C099_pravi>()
                .Property(e => e.NAZIV)
                .IsUnicode(false);

            modelBuilder.Entity<C099_pravi>()
                .Property(e => e.JEDMERE)
                .IsUnicode(false);

            modelBuilder.Entity<C099_pravi>()
                .Property(e => e.TARIFA)
                .IsUnicode(false);

            modelBuilder.Entity<C099_pravi>()
                .Property(e => e.SHKAT)
                .IsUnicode(false);

            modelBuilder.Entity<C099_pravi>()
                .Property(e => e.PROIZVODJAC)
                .IsUnicode(false);

            modelBuilder.Entity<DARTIKLI>()
               .Property(e => e.SIFRAMAG)
               .IsUnicode(false);

            modelBuilder.Entity<DARTIKLI>()
                .Property(e => e.ARTIKAL)
                .IsUnicode(false);

            modelBuilder.Entity<DARTIKLI>()
                .Property(e => e.BARCODE)
                .IsUnicode(false);

            modelBuilder.Entity<DARTIKLI>()
                .Property(e => e.NAZIV)
                .IsUnicode(false);

            modelBuilder.Entity<DARTIKLI>()
                .Property(e => e.PROIZVODJAC)
                .IsUnicode(false);

            modelBuilder.Entity<DARTIKLI>()
                .Property(e => e.URLSLIKE)
                .IsUnicode(false);

            modelBuilder.Entity<DARTIKLI>()
                .Property(e => e.OPISARTIKLA)
                .IsUnicode(false);

            modelBuilder.Entity<DARTIKLI>()
                .Property(e => e.URLARTIKLAVENDOR)
                .IsUnicode(false);

            modelBuilder.Entity<DARTIKLI>()
                .Property(e => e.PRIMARNIDOBAVLJAC)
                .IsUnicode(false);
        }
    }
}
