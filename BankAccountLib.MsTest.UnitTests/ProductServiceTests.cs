using ProductsStore.Models;
using ProductsStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountLib.MsTest.UnitTests
{
    [TestClass]
    public class ProductServiceTests
    {
        [TestMethod]
        public async Task GetById_ValidId_ReturnsExistingProduct()
        {
            //Arrange
            var repository = new FakeProductRepository(new List<Product> { new Product { Id = 1, Name = "Laptop" } });
            var sut = new ProductsService(repository);

            //Act
            var actual = await sut.GetProductByIdFromService(1);

            //Assert
            Assert.IsNotNull(actual);
        }
    }
}
