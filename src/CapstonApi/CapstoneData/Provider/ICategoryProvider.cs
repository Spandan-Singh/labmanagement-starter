using CapstoneData.Model;

namespace CapstoneData.Provider
{
    public interface ICategoryProvider
    {
        IEnumerable<CategoryDbo> GetCategories();
        CategoryDbo? GetCategoryById(int id);
        CategoryDbo CreateCategory(CategoryDbo category);
        CategoryDbo UpdateCategoryById(int id, CategoryDbo category);
        bool DeleteCategoryById(int id);
    }
}
