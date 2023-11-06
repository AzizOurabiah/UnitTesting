using Microsoft.EntityFrameworkCore;
using ProductsStore.Data;
using ProductsStore.Models;

namespace ProductsStore.Services
{
    public class ProductsRepository : IProductsRepository
    {
        private ProductsContext _context;

        /// <summary>
        ///  Should introduce IProductsRepository
        ///  instead of using ProductsContext.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>

        //Injection de dépendance de context qui crée la base de donnée
        public ProductsRepository(ProductsContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetAllProductsFromProductRepository()
        {
            return await _context.Products.ToListAsync();
        } 
        public async Task<Product> GetByIdFromProductRepository(int id)
        {
            return await _context.Products.FindAsync(id);
        }
        public async Task<Product> AddFromProductRepository(Product newItem)
        {
            var entry = _context.Add(newItem);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }
        public async Task<Product> UpdateFromProductRepository(int id, Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> DeleteFromProductRepository(int id)
        {
            var product = await GetByIdFromProductRepository(id);
            _context.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        } 
    }
}
