using System;
using System.Collections.Generic;

namespace ProductManagementSystem.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public DateTime LastUpdate { get; set; }

        public ICollection<Product> Products { get; set; }

        public Category()
        {
            Products = new List<Product>();
        }

        public Category(int categoryId, string categoryName, string description, DateTime lastUpdate)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
            Description = description;
            LastUpdate = lastUpdate;
            Products = new List<Product>();
        }
    }
}
