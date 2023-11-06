using Microsoft.EntityFrameworkCore;
using ProductsStore.Models;

namespace ProductsStore.Data
{
    public class ProductsContext : DbContext
    {
        public ProductsContext(DbContextOptions<ProductsContext> options) 
            : base(options)
            { }

        //Création de la base de donnée
        public DbSet<Product> Products { get; set; }
    }
}
