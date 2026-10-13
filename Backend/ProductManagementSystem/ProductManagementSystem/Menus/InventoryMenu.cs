using System;
using System.Collections.Generic;
using System.Linq;
using ProductManagementSystem.Models;
using ProductManagementSystem.Service;
using ProductManagementSystem.Services;

namespace ProductManagementSystem.Menus
{
    public class InventoryMenu
    {
        public static void Display()
        {
            ProductService productService = new ProductService();
            CategoryService categoryService = new CategoryService();

            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();

                Console.WriteLine("========== INVENTORY MENU ==========");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. View All Products");
                Console.WriteLine("3. Search Product");
                Console.WriteLine("4. Update Product");
                Console.WriteLine("5. Delete Product");
                Console.WriteLine("6. Update Stock Quantity");
                Console.WriteLine("7. View Low-Stock Products");
                Console.WriteLine("8. Update Reorder Level");
                Console.WriteLine("9. View Categories");
                Console.WriteLine("10. Logout");
                Console.WriteLine("====================================");
                Console.Write("Select an option (1-10): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Product newProduct = new Product();

                        Console.Write("Product Name : ");
                        newProduct.ProductName = Console.ReadLine();

                        Console.Write("Category Id : ");
                        newProduct.CategoryId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Price : ");
                        newProduct.Price = Convert.ToDecimal(Console.ReadLine());

                        Console.Write("Quantity : ");
                        newProduct.Quantity = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Reorder Level : ");
                        newProduct.ReorderLevel = Convert.ToInt32(Console.ReadLine());

                        productService.AddProduct(newProduct);

                        Console.WriteLine("Product Added Successfully.");


                        break;

                    case "2":
                        List<Product> products = productService.DisplayProducts();

                        foreach (Product product in products)
                        {
                            Console.WriteLine("----------------------------------------");
                            Console.WriteLine($"Id             : {product.ProductId}");
                            Console.WriteLine($"Name           : {product.ProductName}");
                            Console.WriteLine($"Category Id    : {product.CategoryId}");
                            Console.WriteLine($"Price          : {product.Price}");
                            Console.WriteLine($"Quantity       : {product.Quantity}");
                            Console.WriteLine($"Reorder Level  : {product.ReorderLevel}");
                        }
                        break;

                    case "3":
                        Console.Write("Enter Product Name : ");
                        string productName = Console.ReadLine();

                        List<Product> searchProducts = productService.SearchProduct(productName);

                        foreach (Product product in searchProducts)
                        {
                            Console.WriteLine("----------------------------------------");
                            Console.WriteLine($"Id             : {product.ProductId}");
                            Console.WriteLine($"Name           : {product.ProductName}");
                            Console.WriteLine($"Category Id    : {product.CategoryId}");
                            Console.WriteLine($"Price          : {product.Price}");
                            Console.WriteLine($"Quantity       : {product.Quantity}");
                            Console.WriteLine($"Reorder Level  : {product.ReorderLevel}");
                        }
                        break;

                    case "4":
                        Product updateProduct = new Product();

                        Console.Write("Product Id : ");
                        updateProduct.ProductId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Product Name : ");
                        updateProduct.ProductName = Console.ReadLine();

                        Console.Write("Category Id : ");
                        updateProduct.CategoryId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Price : ");
                        updateProduct.Price = Convert.ToDecimal(Console.ReadLine());

                        Console.Write("Quantity : ");
                        updateProduct.Quantity = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Reorder Level : ");
                        updateProduct.ReorderLevel = Convert.ToInt32(Console.ReadLine());

                        productService.UpdateProduct(updateProduct);

                        Console.WriteLine("Product Updated Successfully.");
                        break;

                    case "5":
                        Console.Write("Enter Product Id : ");
                        int productId = Convert.ToInt32(Console.ReadLine());

                        productService.DeleteProduct(productId);

                        Console.WriteLine("Product Deleted Successfully.");
                        break;

                    case "6":
                        //UpdateStockQuantity(productService);
                        Console.Write("Enter Product Id : ");
                        int updateProductId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter New Quantity : ");
                        int newQuantity = Convert.ToInt32(Console.ReadLine());
                        productService.updateProductQuantity(updateProductId, newQuantity);
                        break;

                    case "7":
                       // ViewLowStockProducts(productService);
                       List<Product> lowStockProducts = productService.DisplayLowStockProducts();
                        foreach (Product product in lowStockProducts)
                        {
                            Console.WriteLine("----------------------------------------");
                            Console.WriteLine($"Id             : {product.ProductId}");
                            Console.WriteLine($"Name           : {product.ProductName}");
                            Console.WriteLine($"Quantity       : {product.Quantity}");
                            Console.WriteLine($"Reorder Level  : {product.ReorderLevel}");
                            Console.WriteLine("Stock Status   : LOW STOCK");
                        }

                        break;

                    case "8":
                       Console.Write("Enter Product Id : ");
                        int reorderProductId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter New Reorder Level : ");
                        int newReorderLevel = Convert.ToInt32(Console.ReadLine());
                        productService.updateProductReorderLevel(reorderProductId, newReorderLevel);
                        break;

                    case "9":
                        //ViewCategories(categoryService);
                        Console.Write("Enter Category Name : ");
                        string categoryName = Console.ReadLine();

                        List<Category> categories = categoryService.SearchCategory(categoryName);

                        foreach (Category category in categories)
                        {
                            Console.WriteLine("----------------------------------------");
                            Console.WriteLine($"Id          : {category.CategoryId}");
                            Console.WriteLine($"Name        : {category.CategoryName}");
                            Console.WriteLine($"Description : {category.Description}");
                        }       


                        break;

                    case "10":
                        isRunning = false;
                        Console.WriteLine("Logged out successfully.");
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

                if (isRunning)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        //private static void AddProduct(ProductService service)
        //{
        //    Console.Clear();
        //    Console.WriteLine("========== ADD PRODUCT ==========");

        //    Product product = new Product();

        //    Console.Write("Product Name: ");
        //    product.ProductName = Console.ReadLine();

        //    Console.Write("Category Id: ");
        //    product.CategoryId =
        //        Convert.ToInt32(Console.ReadLine());

        //    Console.Write("Price: ");
        //    product.Price =
        //        Convert.ToDecimal(Console.ReadLine());

        //    Console.Write("Initial Quantity: ");
        //    product.Quantity =
        //        Convert.ToInt32(Console.ReadLine());

        //    Console.Write("Reorder Level: ");
        //    product.ReorderLevel =
        //        Convert.ToInt32(Console.ReadLine());

        //    service.AddProduct(product);

        //    Console.WriteLine("Product added successfully.");
        //}

        //private static void ViewAllProducts(ProductService service)
        //{
        //    Console.Clear();
        //    Console.WriteLine("========== ALL PRODUCTS ==========");

        //    List<Product> products = service.DisplayProducts();

        //    foreach (Product product in products)
        //    {
        //        Console.WriteLine("----------------------------------");
        //        Console.WriteLine($"Product Id    : {product.ProductId}");
        //        Console.WriteLine($"Product Name  : {product.ProductName}");
        //        Console.WriteLine($"Category Id   : {product.CategoryId}");
        //        Console.WriteLine($"Price         : {product.Price}");
        //        Console.WriteLine($"Quantity      : {product.Quantity}");
        //        Console.WriteLine($"Reorder Level : {product.ReorderLevel}");
        //    }

        //    if (products.Count == 0)
        //    {
        //        Console.WriteLine("No products found.");
        //    }
        //}

        //private static void SearchProduct(ProductService service)
        //{
        //    Console.Clear();
        //    Console.WriteLine("========== SEARCH PRODUCT ==========");

        //    Console.Write("Enter Product Name: ");
        //    string productName = Console.ReadLine();

        //    List<Product> products =
        //        service.SearchProduct(productName);

        //    foreach (Product product in products)
        //    {
        //        Console.WriteLine("----------------------------------");
        //        Console.WriteLine($"Product Id    : {product.ProductId}");
        //        Console.WriteLine($"Product Name  : {product.ProductName}");
        //        Console.WriteLine($"Category Id   : {product.CategoryId}");
        //        Console.WriteLine($"Price         : {product.Price}");
        //        Console.WriteLine($"Quantity      : {product.Quantity}");
        //        Console.WriteLine($"Reorder Level : {product.ReorderLevel}");
        //    }

        //    if (products.Count == 0)
        //    {
        //        Console.WriteLine("No matching products found.");
        //    }
        //}

        //private static void UpdateProduct(ProductService service)
        //{
        //    Console.Clear();
        //    Console.WriteLine("========== UPDATE PRODUCT ==========");

        //    Product product = new Product();

        //    Console.Write("Product Id: ");
        //    product.ProductId =
        //        Convert.ToInt32(Console.ReadLine());

        //    Console.Write("Product Name: ");
        //    product.ProductName = Console.ReadLine();

        //    Console.Write("Category Id: ");
        //    product.CategoryId =
        //        Convert.ToInt32(Console.ReadLine());

        //    Console.Write("Price: ");
        //    product.Price =
        //        Convert.ToDecimal(Console.ReadLine());

        //    Console.Write("Quantity: ");
        //    product.Quantity =
        //        Convert.ToInt32(Console.ReadLine());

        //    Console.Write("Reorder Level: ");
        //    product.ReorderLevel =
        //        Convert.ToInt32(Console.ReadLine());

        //    service.UpdateProduct(product);

        //    Console.WriteLine("Product updated successfully.");
        //}

        //private static void DeleteProduct(ProductService service)
        //{
        //    Console.Clear();
        //    Console.WriteLine("========== DELETE PRODUCT ==========");

        //    Console.Write("Enter Product Id: ");
        //    int productId = Convert.ToInt32(Console.ReadLine());

        //    service.DeleteProduct(productId);

        //    Console.WriteLine("Product deleted successfully.");
        //}

        //private static void UpdateStockQuantity(ProductService service)
        //{
        //    Console.Clear();
        //    Console.WriteLine("========== UPDATE STOCK ==========");

        //    Console.Write("Enter Product Id: ");
        //    int productId = Convert.ToInt32(Console.ReadLine());

        //    Console.Write("Enter New Stock Quantity: ");
        //    int quantity = Convert.ToInt32(Console.ReadLine());

        //    if (quantity < 0)
        //    {
        //        Console.WriteLine("Quantity cannot be negative.");
        //        return;
        //    }

        //    service.UpdateStockQuantity(productId, quantity);

        //    Console.WriteLine("Stock quantity updated successfully.");
        //}

        //private static void ViewLowStockProducts(ProductService service)
        //{
        //    Console.Clear();
        //    Console.WriteLine("========== LOW-STOCK PRODUCTS ==========");

        //    List<Product> products =
        //        service.DisplayLowStockProducts();

        //    foreach (Product product in products)
        //    {
        //        Console.WriteLine("----------------------------------");
        //        Console.WriteLine($"Product Id    : {product.ProductId}");
        //        Console.WriteLine($"Product Name  : {product.ProductName}");
        //        Console.WriteLine($"Quantity      : {product.Quantity}");
        //        Console.WriteLine($"Reorder Level : {product.ReorderLevel}");
        //        Console.WriteLine("Stock Status  : LOW STOCK");
        //    }

        //    if (products.Count == 0)
        //    {
        //        Console.WriteLine("No low-stock products found.");
        //    }
        //}

        //private static void UpdateReorderLevel(ProductService service)
        //{
        //    Console.Clear();
        //    Console.WriteLine("========== UPDATE REORDER LEVEL ==========");

        //    Console.Write("Enter Product Id: ");
        //    int productId = Convert.ToInt32(Console.ReadLine());

        //    Console.Write("Enter New Reorder Level: ");
        //    int reorderLevel = Convert.ToInt32(Console.ReadLine());

        //    if (reorderLevel < 0)
        //    {
        //        Console.WriteLine("Reorder level cannot be negative.");
        //        return;
        //    }

        //    service.UpdateReorderLevel(productId, reorderLevel);

        //    Console.WriteLine("Reorder level updated successfully.");
        //}

        //private static void ViewCategories(CategoryService service)
        //{
        //    Console.Clear();
        //    Console.WriteLine("========== PRODUCT CATEGORIES ==========");

        //    List<Category> categories = service.DisplayCategories();

        //    foreach (Category category in categories)
        //    {
        //        Console.WriteLine("----------------------------------");
        //        Console.WriteLine($"Category Id   : {category.CategoryId}");
        //        Console.WriteLine($"Category Name : {category.CategoryName}");
        //        Console.WriteLine($"Description   : {category.Description}");
        //    }

        //    if (categories.Count == 0)
        //    {
        //        Console.WriteLine("No categories found.");
        //    }
        //}
    }
}