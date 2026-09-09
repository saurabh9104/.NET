using ProductManagementSystem.Models;
using ProductManagementSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManagementSystem.Service
{
    public class ProductService
    {
        ProductRepository repository = new ProductRepository();

        public List<Product> DisplayProducts()
        {
            return repository.GetAll();
        }

        public void AddProduct(Product product)
        {
            repository.Add(product);
        }
        public void UpdateProduct(Product product)
        {
            repository.Update(product);
        }
        public void DeleteProduct(int productId)
        {
            repository.Delete(productId);
        }
        public List<Product> SearchProduct(string name)
        {
            return repository.SearchByName(name);
        }
    }
}

