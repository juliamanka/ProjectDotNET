using Praktyki_projectDotNET.Model;
using Microsoft.AspNetCore.Mvc;

namespace Praktyki_projectDotNET.Repositories
{
    public interface IProductService
    {
        public bool DoesProductExist(int productId);
        public IEnumerable<Product> GetAll();
        public Product GetById(int productId);
        public void AddProduct(Product product);
        public void UpdateProduct(int productId, Product product);
        public void Delete(int id);

    }
}
