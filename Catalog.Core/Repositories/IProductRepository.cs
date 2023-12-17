using Catalog.Core.Entities;

namespace Catalog.Core.Repositories
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetAllProducts();
        public Task<Product> GetProduct(string id);

        public Task<IEnumerable<Product>> GetProductsByName(string name);

        public Task<IEnumerable<Product>> GetProductsByBrand(string brand);

        public Task<Product> CreateProduct(Product product);

        public Task<bool> UpdateProduct(Product product);

        public Task<bool> DeleteProduct(string id);
    }
}
