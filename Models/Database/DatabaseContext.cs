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

        public DbSet<PointItem> PointItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<int>("Id").IncrementsBy(1);

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

            modelBuilder.Entity<Item>().HasData(
                        new { Id = 1, Title = "Lâmpadas", Image = "lampadas.svg" },
                        new { Id = 2, Title = "Pilhas e Baterias", Image = "baterias.svg" },
                        new { Id = 3, Title = "Papéis e Papelão", Image = "papeis-papelao.svg" },
                        new { Id = 4, Title = "Resíduos Eletrônicos", Image = "eletronicos.svg" },
                        new { Id = 5, Title = "Resíduos Orgânicos", Image = "organicos.svg" },
                        new { Id = 6, Title = "Óleo de Cozinha", Image = "oleo.svg" });
        }
    }
}