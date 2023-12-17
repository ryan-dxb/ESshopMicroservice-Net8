using Catalog.Core.Entities;

namespace Catalog.Core.Repositories
{
    public interface ITypesRepository
    {
        public Task<IEnumerable<ProductType>> GetAllTypes();
    }
}
