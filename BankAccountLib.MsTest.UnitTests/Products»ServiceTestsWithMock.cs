using Bogus;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using Moq;
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
    public class Products_ServiceTestsWithMock
    {
        private readonly Mock<IProductsRepository> _mockProductsRepository;
        private Product _product;
        private IEnumerable<Product> _products;

        public Products_ServiceTestsWithMock()
        {
            _product = new Product
            {
                Id = 1,
                Name = "Laptop"
            };

            _products = new List<Product> { _product };

            _mockProductsRepository = new Mock<IProductsRepository>();
        }
        [TestMethod]
        public async Task GetAllProducts_ReturnsAvailableProducts()
        {
            //Arrange
            _mockProductsRepository.Setup(x => x.GetAllProductsFromProductRepository()).Returns(Task.FromResult(_products)); 
            
            var sut = new ProductsService(_mockProductsRepository.Object);

            //Act 
            var actual = await sut.GetAllProductFromService();

            //Assert
            Assert.IsTrue(actual.ToList().Count > 0);
        }
        [TestMethod]
        public async Task GetById_ValidId_ReturnsProduct1()
        {
            //Arrange
            _mockProductsRepository.Setup(x => x.GetByIdFromProductRepository(It.IsAny<int>())).Returns(Task.FromResult(_product));

            var sut = new ProductsService(_mockProductsRepository.Object);


            //Act
            var actual = await sut.GetProductByIdFromService(1);

            //Assert
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public async Task Add_Emplty_ResultNull()
        {
            //Arrange
            _mockProductsRepository.Setup(x => x.AddFromProductRepository(_product)).Returns(Task.FromResult(_product));
            var sut = new ProductsService(_mockProductsRepository.Object);

            //Act
            var actual = await sut.AddProductFromService(_product);

            //Assert
            Assert.IsTrue(actual.Id == 1);
            Assert.IsTrue(actual.Name == "Laptop");
        }

        [TestMethod]
        public async Task GetAllProducts_ReturnsAvailableProductsWithBogus()
        {
            //Arrange
            var id = 1;
            var names = new[] { "Laptop", "TV", "SmartPhone", "Tablette" };
            var faker = new Faker<Product>()
                .RuleFor(p => p.Id, f => id++)
                .RuleFor(p => p.Name, f => f.PickRandom(names));

            IEnumerable<Product> products = faker.Generate(10000);

            _mockProductsRepository.Setup(x => x.GetAllProductsFromProductRepository()).Returns(Task.FromResult(products));

            var sut = new ProductsService(_mockProductsRepository.Object);

            //Act 
            var actual = await sut.GetAllProductFromService();

            //Assert
            Assert.IsTrue(actual.ToList().Count > 0);
        }
    }
}
