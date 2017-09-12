using Investor.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Repository.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryEntity>> GetAllCategoriesAsync();
        Task<CategoryEntity> GetCategoryByIdAsync(int id);

        Task<CategoryEntity> AddCategoryAsync(CategoryEntity categoryEntity);
        Task UpdateCategoryAsync(CategoryEntity categoryEntity);
        Task RemoveCategoryAsync(int id);
    }
}
