using Investor.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Investor.Repository.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryEntity>> GetAllCategoriesAsync();
        Task<CategoryEntity> GetCategoryByIdAsync(int id);
        Task<CategoryEntity> GetCategoryByUrlAsync(string url);

        Task<CategoryEntity> AddCategoryAsync(CategoryEntity categoryEntity);
        Task UpdateCategoryAsync(CategoryEntity categoryEntity);
        Task RemoveCategoryAsync(int id);
    }
}
