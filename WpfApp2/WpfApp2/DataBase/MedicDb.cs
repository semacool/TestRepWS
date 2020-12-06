namespace WpfApp2.DataBase
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MedicDb : DbContext
    {
        public MedicDb()
            : base("name=MedicDb")
        {
        }

        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Laborants> Laborants { get; set; }
        public virtual DbSet<Materials> Materials { get; set; }
        public virtual DbSet<Researches> Researches { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clients>()
                .HasMany(e => e.Materials)
                .WithRequired(e => e.Clients)
                .HasForeignKey(e => e.IdClient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Laborants>()
                .HasMany(e => e.Researches)
                .WithRequired(e => e.Laborants)
                .HasForeignKey(e => e.IdLaborant)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Materials>()
                .HasMany(e => e.Researches)
                .WithRequired(e => e.Materials)
                .HasForeignKey(e => e.IdMaterial)
                .WillCascadeOnDelete(false);
        }
    }
}
