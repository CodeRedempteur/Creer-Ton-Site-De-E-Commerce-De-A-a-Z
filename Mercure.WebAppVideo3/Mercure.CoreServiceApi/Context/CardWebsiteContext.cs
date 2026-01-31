using Microsoft.EntityFrameworkCore;
using Mercure.Data.Cards;
namespace Mercure.CoreServiceApi.Context
{
    public class CardWebsiteContext : DbContext
    {
        public CardWebsiteContext(DbContextOptions<CardWebsiteContext> options)
            : base(options)
        {
        }

        public DbSet<Test> Tests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Test>(entity =>
            {
                entity.ToTable("tests");
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Id).HasColumnName("id");
                entity.Property(t => t.Nom)
                .HasColumnName("nom")
                .HasMaxLength(255)
                .IsRequired();
            });
        }
    }
}
