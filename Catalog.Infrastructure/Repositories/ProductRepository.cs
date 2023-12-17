using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository, IBrandRepository, ITypesRepository
    {
        private readonly ICatalogContext catalogContext;

        public ProductRepository(ICatalogContext catalogContext)
        {
            this.catalogContext = catalogContext;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await catalogContext.Products.Find(p => true).ToListAsync();
        }

        public Task<Product> GetProduct(string id)
        {
            return catalogContext.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByName(string name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.ElemMatch(p => p.Name, name);

            return await catalogContext.Products.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByBrand(string name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.ElemMatch(p => p.Brands.Name, name);

            return await catalogContext.Products.Find(filter).ToListAsync();
        }

        public async Task<Product> CreateProduct(Product product)
        {
            await catalogContext.Products.InsertOneAsync(product);

            return product;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var updateResult = await catalogContext.Products.ReplaceOneAsync(filter: p => p.Id == product.Id, replacement: product);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteProduct(string id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await catalogContext.Products.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<ProductBrand>> GetAllBrands()
        {
            return await catalogContext.ProductBrands.Find(p => true).ToListAsync();
        }



        public async Task<IEnumerable<ProductType>> GetAllTypes()
        {
            return await catalogContext.ProductTypes.Find(p => true).ToListAsync();
        }

    }
}
