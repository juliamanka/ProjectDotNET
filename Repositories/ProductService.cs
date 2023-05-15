using Praktyki_projectDotNET.Model;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Praktyki_projectDotNET.Repositories
{
    public class ProductService : IProductService
    {

        private List<Product> _products;

        public ProductService()
        {
            _products = new List<Product>()
        {
            new Product{Id = 1,Name="milk",Price=12.5,Category="groceries" },
            new Product{Id=2, Name="TV",Price=340.8,Category="household"}
        };
        }


        public void AddProduct(Product product)
        {

            _products.Add(new Product
            {
                Id = product.Id,Name=product.Name,Price=product.Price,Category=product.Category
            });
            
        }

        public void Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id==id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }

        public bool DoesProductExist(int productId)
        {
            if (_products.Contains(GetById(productId))) return true;
            else 
                return false;
        }

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Product GetById(int productId)
        {
            var product = _products.FirstOrDefault(p => p.Id == productId);
            return product;
            
        }

        public void UpdateProduct(int idProduct, Product product)
        {
           Product p = _products.FirstOrDefault(p => p.Id == idProduct);

            if (p != null)
            {
                p.Name = product.Name;
                p.Price = product.Price;
                p.Category = product.Category;
            }

           
        }
    }
}
