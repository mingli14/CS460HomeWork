namespace HW8.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HW8Context : DbContext
    {
        public HW8Context()
            : base("name=HW8Context")
        {
        }

        public virtual DbSet<Crews> Crews { get; set; }
        public virtual DbSet<Pirates> Pirates { get; set; }
        public virtual DbSet<Ships> Ships { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Crews>()
                .Property(e => e.Booty)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Pirates>()
                .HasMany(e => e.Crews)
                .WithRequired(e => e.Pirates)
                .HasForeignKey(e => e.PirateID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ships>()
                .HasMany(e => e.Crews)
                .WithRequired(e => e.Ships)
                .HasForeignKey(e => e.ShipID)
                .WillCascadeOnDelete(false);
        }
    }
}
