using CapstoneData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneData.Provider
{
    public class CategoryProvider : ICategoryProvider
    {
        private readonly ICapstoneDBContext _context;
        public CategoryProvider(ICapstoneDBContext context)
        {
            _context = context;
        }
        public CategoryDbo CreateCategory(CategoryDbo category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }

        public bool DeleteCategoryById(int id)
        {
            CategoryDbo? categoryToRemove = _context.Categories.FirstOrDefault(auth => auth.Id == id);
            if (categoryToRemove is not null)
            {
                _context.Categories.Remove(categoryToRemove);
            }
            return _context.SaveChanges() is not 0;
        }

        public IEnumerable<CategoryDbo> GetCategories()
        {
            return _context.Categories;
        }

        public CategoryDbo? GetCategoryById(int id)
        {
            return _context.Categories.FirstOrDefault(cat => cat.Id == id);
        }

        public CategoryDbo UpdateCategoryById(int id, CategoryDbo category)
        {
            CategoryDbo? categoryToModify = _context.Categories.FirstOrDefault(auth => auth.Id == id);
            if (categoryToModify is not null)
            {
                categoryToModify.Name = category.Name;
                _context.SaveChanges();
            }
            return categoryToModify;
        }
    }
}
