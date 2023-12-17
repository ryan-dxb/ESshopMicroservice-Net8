using Catalog.Core.Entities;
using MongoDB.Driver;
using System.Text.Json;

namespace Catalog.Infrastructure.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool checkProducts = productCollection.Find(p => true).Any();

            Console.WriteLine("current Directory" + "Directory.GetCurrentDirectory()");
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Data/SeedData/products.json");

            if (!checkProducts)
            {
                var productsJson = File.ReadAllText(path);
                var products = JsonSerializer.Deserialize<List<Product>>(productsJson);

                if (products != null)
                {
                    foreach (var item in products)
                    {
                        productCollection.InsertOneAsync(item);
                    }
                }
            }
        }
    }
}
