using PlaceMe.Core.ResourceParameters;
using PlaceMe.Infrastructure.Entities;
using System.Collections.Generic;

namespace PlaceMe.Core.ServiceInterface
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProduct(ProductResourceParameters productResourceParameters);
        Product GetProductById(int id);
        void Create(Product product);
        void Update(Product product, int productId, int quantity);
        void Delete(int productId);
    }
}
