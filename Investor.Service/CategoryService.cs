using Investor.Service.Interfaces;
using System;
using System.Collections.Generic;
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
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            return categories.Select(_mapper.Map<CategoryEntity, Category>);
        }

        public async Task<Category> GetCategoryByUrlAsync(string url)
        {
            if (String.IsNullOrWhiteSpace(url))
            {
                return null;
            }
            var category = await _categoryRepository.GetCategoryByUrlAsync(url);
            return _mapper.Map<CategoryEntity, Category>(category);
        }
    }
}
