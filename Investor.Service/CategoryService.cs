using Investor.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Investor.Model;
using System.Threading.Tasks;
using Investor.Repository.Interfaces;
using System.Linq;
using AutoMapper;
using Investor.Entity;

namespace Investor.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            return categories.Select(Mapper.Map<CategoryEntity, Category>);
        }

        public async Task<Category> GetCategoryByUrlAsync(string url)
        {
            if (String.IsNullOrWhiteSpace(url))
            {
                return null;
            }
            var category = await _categoryRepository.GetCategoryByUrlAsync(url);
            return Mapper.Map<CategoryEntity, Category>(category);
        }
    }
}
