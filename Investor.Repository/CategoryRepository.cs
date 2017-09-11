using Investor.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Investor.Entity;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Investor.Repository
{
    class CategoryRepository : ICategoryRepository
    {
        private readonly NewsContext _newsContext;

        public CategoryRepository(NewsContext newsContext)
        {
            _newsContext = newsContext;
        }

        public async Task<CategoryEntity> AddCategoryAsync(CategoryEntity categoryEntity)
        {
            await _newsContext.Categories.AddAsync(categoryEntity);
            await _newsContext.SaveChangesAsync();

            return categoryEntity;
        }

        public async Task<IEnumerable<CategoryEntity>> GetAllCategoriesAsync()
        {
            return await _newsContext.Categories.ToListAsync();
        }

        public async Task<CategoryEntity> GetCategoryByIdAsync(int id)
        {
            return await _newsContext.Categories.FindAsync(id);
        }

        public async Task RemoveCategoryAsync(int id)
        {
            CategoryEntity categoryToRemove = await _newsContext.Categories.FindAsync(id);
            _newsContext.Categories.Remove(categoryToRemove);

            await _newsContext.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(CategoryEntity category)
        {
            CategoryEntity categoryToUpdate = await _newsContext.Categories.FirstOrDefaultAsync(c => c.CategoryId == category.CategoryId);
            categoryToUpdate.Name = category.Name;
            categoryToUpdate.Url = category.Url;

            await _newsContext.SaveChangesAsync();
        }
    }
}
