namespace Final.Views.Shared
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FinalContext : DbContext
    {
        public FinalContext()
            : base("name=FinalContext")
        {
        }

        public virtual DbSet<Artists> Artists { get; set; }
        public virtual DbSet<ArtWorks> ArtWorks { get; set; }
        public virtual DbSet<Classifications> Classifications { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artists>()
                .HasMany(e => e.ArtWorks)
                .WithRequired(e => e.Artists)
                .HasForeignKey(e => e.ArtistID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ArtWorks>()
                .HasMany(e => e.Classifications)
                .WithRequired(e => e.ArtWorks)
                .HasForeignKey(e => e.ArtWorkID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Genres>()
                .HasMany(e => e.Classifications)
                .WithRequired(e => e.Genres)
                .HasForeignKey(e => e.GenreID)
                .WillCascadeOnDelete(false);
        }
    }
}
