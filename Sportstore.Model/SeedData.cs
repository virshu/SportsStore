namespace Sportstore.Model;

public partial class SportsStoreSourceContext
{
    private static void OnModelCreatingPartial(ModelBuilder modelBuilder)
    {
        List<Product> products =
        [
            new Product
            {
                ProductId = 1,
                Name = "Kayak",
                Description = "A boat for one person",
                Category = "Watersports", Price = 275
            },

            new Product
            {
                ProductId = 2,
                Name = "Lifejacket",
                Description = "Protective and fashionable",
                Category = "Watersports", Price = 48.95m
            },

            new Product
            {
                ProductId = 3,
                Name = "Soccer Ball",
                Description = "FIFA-approved size and weight",
                Category = "Soccer", Price = 19.50m
            },

            new Product
            {
                ProductId = 4,
                Name = "Corner Flags",
                Description = "Give your playing field a professional touch",
                Category = "Soccer", Price = 34.95m
            },

            new Product
            {
                ProductId = 5,
                Name = "Stadium",
                Description = "Flat-packed 35,000-seat stadium",
                Category = "Soccer", Price = 79500
            },

            new Product
            {
                ProductId = 6,
                Name = "Thinking Cap",
                Description = "Improve brain efficiency by 75%",
                Category = "Chess", Price = 16
            },

            new Product
            {
                ProductId = 7,
                Name = "Unsteady Chair",
                Description = "Secretly give your opponent a disadvantage",
                Category = "Chess", Price = 29.95m
            },

            new Product
            {
                ProductId = 8,
                Name = "Human Chess Board",
                Description = "A fun game for the family",
                Category = "Chess", Price = 75
            },

            new Product
            {
                ProductId = 9,
                Name = "Bling-Bling King",
                Description = "Gold-plated, diamond-studded King",
                Category = "Chess", Price = 1200
            }
        ];

        modelBuilder.Entity<Product>().HasData(products);
    }
}