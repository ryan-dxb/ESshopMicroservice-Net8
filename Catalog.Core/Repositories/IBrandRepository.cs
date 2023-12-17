using Catalog.Core.Entities;

namespace Catalog.Core.Repositories
{
    public interface IBrandRepository
    {
        public Task<IEnumerable<ProductBrand>> GetAllBrands();
    }
}
