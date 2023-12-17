using Catalog.Core.Entities;
using MongoDB.Driver;
using System.Text.Json;

namespace Catalog.Infrastructure.Data
{
    public class BrandContextSeed
    {
        public static void SeedData(IMongoCollection<ProductBrand> branchCollection)
        {
            bool checkBrands = branchCollection.Find(p => true).Any();

            Console.WriteLine("current Directory" + "Directory.GetCurrentDirectory()");
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Data/SeedData/brands.json");

            if (!checkBrands)
            {
                var brandsJson = File.ReadAllText(path);
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsJson);

                if (brands != null)
                {
                    foreach (var brand in brands)
                    {
                        branchCollection.InsertOneAsync(brand);
                    }
                }
            }
        }
    }
}
