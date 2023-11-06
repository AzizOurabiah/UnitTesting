using ProductsStore.Models;

namespace ProductsStore.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetAllProductFromService();

        Task<Product> GetProductByIdFromService(int id);

        Task<Product>AddProductFromService(Product product);

        Task<Product> UpdateProductFromService(int id, Product product);

        Task<Product> DeleteProductFromService(int id);
    }
}
