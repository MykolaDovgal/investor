using Investor.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Investor.Service.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByUrlAsync(string url);
    }
}
