using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace test.Data
{
    public partial class troskovidbContext : DbContext
    {
        public troskovidbContext()
        {
        }

        public troskovidbContext(DbContextOptions<troskovidbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ShoppingList> ShoppingList { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ShoppingList>(entity =>
            {
                entity.ToTable("shopping_lista");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Napomena)
                    .HasMaxLength(100)
                    .HasColumnName("napomena");

                entity.Property(e => e.Naziv)
                    .HasMaxLength(50)
                    .HasColumnName("naziv");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
