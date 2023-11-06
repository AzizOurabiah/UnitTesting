using ProductsStore.Models;

namespace ProductsStore.Services
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> GetAllProductsFromProductRepository();

        Task<Product> GetByIdFromProductRepository(int id);

        Task<Product> AddFromProductRepository(Product newItem);

        Task<Product> UpdateFromProductRepository(int id, Product product);

        Task<Product> DeleteFromProductRepository(int id);
    }
}
