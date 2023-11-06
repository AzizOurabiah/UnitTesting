using ProductsStore.Models;

namespace ProductsStore.Services
{
    public class ProductsService : IProductsService
    {
        private IProductsRepository _repository;

        /// <summary>
        /// Should introduce IProductsRepository
        /// instead of using ProductsContext
        /// </summary>
        /// <param name="context"></param>
        public ProductsService(IProductsRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Product>> GetAllProductFromService()
        {
            return await _repository.GetAllProductsFromProductRepository();        
        }

        public async Task<Product> GetProductByIdFromService(int id)
        {
            if (id < 0) return null;

            return await _repository.GetByIdFromProductRepository(id);
        }

        public async Task<Product> AddProductFromService(Product product)
        {
            if (string.IsNullOrEmpty(product.Name)) return null;

            return await _repository.AddFromProductRepository(product);
        }
        public async Task<Product> UpdateProductFromService(int id, Product product)
        {
            if (id != product.Id) return null;

            return await _repository.UpdateFromProductRepository(id, product);
        }

        public async Task<Product> DeleteProductFromService(int id)
        {
            if (id < 0) return null;

            return await _repository.DeleteFromProductRepository(id);
        }

       

        

        
    }
}
