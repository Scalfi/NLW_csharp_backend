using Microsoft.EntityFrameworkCore;


namespace NLW.Models.Database
{

    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
                : base(options)
        {
        }
        public DbSet<Point> Points { get; set; }
        public DbSet<Item> Items { get; set; }

        public DbSet<PointItems> PointItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Point>()
                        .HasMany(points => points.PointItems)
                        .WithOne(poitnsItems => poitnsItems.Points)
                        .HasForeignKey(poitnsItems => poitnsItems.Point_id)
                        .HasPrincipalKey(points => points.Id)
                        .IsRequired(true);

            modelBuilder.Entity<Item>()
                .HasMany(items => items.PointItems)
                .WithOne(poitnsItems => poitnsItems.Items)
                .HasForeignKey(poitnsItems => poitnsItems.Item_id)
                .HasPrincipalKey(items => items.Id)
                .IsRequired(true);
        }
    }
}