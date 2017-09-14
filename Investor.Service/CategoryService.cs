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

        public CategoryService(ICategoryRepository postRepository)
        {
            _categoryRepository = postRepository;
        }
        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            return categories.Select(Mapper.Map<CategoryEntity, Category>);
        }
    }
}
