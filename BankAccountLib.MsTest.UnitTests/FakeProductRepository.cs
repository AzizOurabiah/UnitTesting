using ProductsStore.Models;
using ProductsStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountLib.MsTest.UnitTests
{
    public class FakeProductRepository : IProductsRepository
    {
        private readonly List<Product> _products;

        public FakeProductRepository(List<Product> products)
        {
            _products = products;
        }
        
        public async Task<IEnumerable<Product>> GetAllProductsFromProductRepository()
        {
            return _products;
        }
        public async Task<Product> GetByIdFromProductRepository(int id)
        {
            return _products.Find(p => p.Id == id);
        }
        public async Task<Product> AddFromProductRepository(Product newItem)
        {
            _products.Add(newItem);
            return newItem;
        }  
        public async Task<Product> UpdateFromProductRepository(int id, Product product)
        {
            var prod = _products.Find(p => p.Id == id);
            prod.Name = product.Name;
            return prod;
        }

        public async Task<Product> DeleteFromProductRepository(int id)
        {
            var prod = _products.Find(p => p.Id == id);
            _products.Remove(prod);

            return prod;
        }
    }
}
