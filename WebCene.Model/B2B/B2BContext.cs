namespace WebCene.Model.B2B
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class B2BContext : DbContext
    {
        public B2BContext()
            : base("name=B2BContext")
        {
        }

        public virtual DbSet<KonfigDobavljaca> KonfigDobavljaca { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KonfigDobavljaca>()
                .Property(e => e.WebProtokol)
                .IsFixedLength();
        }
    }
}
