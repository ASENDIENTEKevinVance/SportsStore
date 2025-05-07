using Microsoft.EntityFrameworkCore;
namespace SportsStore.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            StoreDBContext context = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<StoreDBContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product { Name = "Kayak", Description = "A boat for one person.", Category = "Watersports", Price = 499.95m },
                    new Product { Name = "Lifejacket", Description = "Protective and fashionable.", Category = "Watersports", Price = 249.95m }
                );
            }

            // Gaming Mouse products
            AddProductIfMissing(context, "Razer DeathAdder Elite", "High-precision gaming mouse with 16,000 DPI optical sensor", "Gaming Mouse", 69.99m);
            AddProductIfMissing(context, "Logitech G Pro X Superlight", "Ultra-lightweight wireless gaming mouse for esports professionals", "Gaming Mouse", 149.99m);
            AddProductIfMissing(context, "SteelSeries Rival 600", "Gaming mouse with dual optical sensors and customizable weight", "Gaming Mouse", 79.99m);
            AddProductIfMissing(context, "Corsair Scimitar RGB Elite", "MMO gaming mouse with 17 programmable buttons", "Gaming Mouse", 89.99m);
            AddProductIfMissing(context, "Glorious Model O", "Ultralight honeycomb shell gaming mouse with RGB lighting", "Gaming Mouse", 59.99m);

            // Gaming Keyboard products
            AddProductIfMissing(context, "Corsair K100 RGB", "Mechanical gaming keyboard with per-key RGB lighting and optical switches", "Gaming Keyboard", 229.99m);
            AddProductIfMissing(context, "SteelSeries Apex Pro TKL", "Compact gaming keyboard with adjustable mechanical switches", "Gaming Keyboard", 179.99m);
            AddProductIfMissing(context, "Razer Huntsman Elite", "Gaming keyboard with opto-mechanical switches and multi-function digital dial", "Gaming Keyboard", 199.99m);
            AddProductIfMissing(context, "Logitech G915 TKL", "Low-profile wireless mechanical gaming keyboard", "Gaming Keyboard", 229.99m);
            AddProductIfMissing(context, "HyperX Alloy Origins Core", "Compact mechanical gaming keyboard with RGB lighting", "Gaming Keyboard", 109.99m);

            // Gaming Monitor products
            AddProductIfMissing(context, "ASUS ROG Swift PG279QM", "27-inch 1440p gaming monitor with 240Hz refresh rate and G-Sync", "Gaming Monitor", 799.99m);
            AddProductIfMissing(context, "LG UltraGear 34GP950G", "34-inch ultrawide curved gaming monitor with Nano IPS panel", "Gaming Monitor", 1299.99m);
            AddProductIfMissing(context, "Samsung Odyssey G7", "32-inch curved QLED gaming monitor with 240Hz refresh rate", "Gaming Monitor", 699.99m);
            AddProductIfMissing(context, "Alienware AW2721D", "27-inch QHD gaming monitor with NVIDIA G-Sync Ultimate", "Gaming Monitor", 899.99m);
            AddProductIfMissing(context, "MSI Optix MAG274QRF-QD", "27-inch Rapid IPS gaming monitor with Quantum Dot technology", "Gaming Monitor", 499.99m);

            // Gaming Laptop products
            AddProductIfMissing(context, "MSI GE76 Raider", "17.3-inch gaming laptop with RTX 3080 and 11th Gen Intel Core i9", "Gaming Laptop", 2999.99m);
            AddProductIfMissing(context, "ASUS ROG Zephyrus G14", "14-inch ultraportable gaming laptop with RTX 3060 and AMD Ryzen 9", "Gaming Laptop", 1799.99m);
            AddProductIfMissing(context, "Alienware x17 R2", "17.3-inch premium gaming laptop with advanced cooling system", "Gaming Laptop", 3299.99m);
            AddProductIfMissing(context, "Lenovo Legion 5 Pro", "16-inch gaming laptop with QHD display and RTX 3070", "Gaming Laptop", 1599.99m);
            AddProductIfMissing(context, "Razer Blade 15", "15.6-inch gaming laptop with aluminum unibody design", "Gaming Laptop", 2499.99m);

            // Gaming Headphones products
            AddProductIfMissing(context, "SteelSeries Arctis Pro Wireless", "Premium wireless gaming headset with dual-battery system", "Gaming Headphones", 329.99m);
            AddProductIfMissing(context, "HyperX Cloud Alpha", "Gaming headset with dual chamber drivers for enhanced sound clarity", "Gaming Headphones", 99.99m);
            AddProductIfMissing(context, "Logitech G Pro X", "Professional gaming headset with Blue VO!CE microphone technology", "Gaming Headphones", 129.99m);
            AddProductIfMissing(context, "Razer BlackShark V2 Pro", "Wireless gaming headset with THX Spatial Audio", "Gaming Headphones", 179.99m);
            AddProductIfMissing(context, "Corsair Virtuoso RGB Wireless", "High-fidelity gaming headset with premium comfort", "Gaming Headphones", 179.99m);

            context.SaveChanges();
        }

        private static void AddProductIfMissing(StoreDBContext context, string name, string desc, string category, decimal price)
        {
            if (!context.Products.Any(p => p.Name == name))
            {
                context.Products.Add(new Product
                {
                    Name = name,
                    Description = desc,
                    Category = category,
                    Price = price
                });
            }
        }
    }
}