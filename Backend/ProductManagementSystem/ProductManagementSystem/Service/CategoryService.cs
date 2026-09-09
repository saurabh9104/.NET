using ProductManagementSystem.Models;
using ProductManagementSystem.Repositories;

namespace ProductManagementSystem.Services
{
    public class CategoryService
    {
        private CategoryRepository repository = new CategoryRepository();

        public void AddCategory(Category category)
        {
            repository.Add(category);
        }

        public List<Category> DisplayCategories()
        {
            return repository.GetAll();
        }

        public Category GetCategory(int categoryId)
        {
            return repository.GetById(categoryId);
        }

        public void UpdateCategory(Category category)
        {
            repository.Update(category);
        }

        public void DeleteCategory(int categoryId)
        {
            repository.Delete(categoryId);
        }

        public List<Category> SearchCategory(string categoryName)
        {
            return repository.SearchByName(categoryName);
        }
    }
}