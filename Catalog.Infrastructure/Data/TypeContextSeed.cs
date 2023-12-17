using Catalog.Core.Entities;
using MongoDB.Driver;
using System.Text.Json;

namespace Catalog.Infrastructure.Data
{
    public class TypeContextSeed
    {
        public static void SeedData(IMongoCollection<ProductType> typeCollection)
        {
            bool checkTypes = typeCollection.Find(p => true).Any();

            Console.WriteLine("current Directory" + "Directory.GetCurrentDirectory()");
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Data/SeedData/types.json");

            if (!checkTypes)
            {
                var typesJson = File.ReadAllText(path);
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesJson);

                if (types != null)
                {
                    foreach (var item in types)
                    {
                        typeCollection.InsertOneAsync(item);
                    }
                }
            }
        }
    }
}
