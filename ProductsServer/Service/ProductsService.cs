using ProductsServer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsServer.Service
{
    class ProductsService : IProducts
    {
        // Populate array of products for display on website
        ProductData[] products =
            new[]
                {
                    new ProductData{ Id = "1", Name = "Rock",
                                     Quantity = "1"},
                    new ProductData{ Id = "2", Name = "Paper",
                                     Quantity = "3"},
                    new ProductData{ Id = "3", Name = "Scissors",
                                     Quantity = "5"},
                    new ProductData{ Id = "4", Name = "Well",
                                     Quantity = "2500"},
                    new ProductData{ Id = "5", Name = "Toto",
                                     Quantity = "2500"}
                };

        // Display a message in the service console application
        // when the list of products is retrieved.
        public IList<ProductData> GetProducts()
        {
            Console.WriteLine("GetProducts called.");
            return products;
        }
    }
}
