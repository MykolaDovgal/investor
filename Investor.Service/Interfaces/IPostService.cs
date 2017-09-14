using Investor.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Service.Interfaces
{
    public interface IPostService
    {
        Task<int> GetTotalNumberOfPostsAsync();
        Task<int> GetTotalNumberOfPostsByCategoryAsync(string category);
        Task<int> GetTotalNumberOfPostByTagAsync(string tag);
        Task<Post> GetByIdAsync(int id);
        Task<IEnumerable<Post>> GetAllPostsAsync();
        Task<IEnumerable<Post>> GetLatestPostsAsync(int limit);
        Task<IEnumerable<Post>> GetAllByCategoryNameAsync(string categoryName, bool onMainPage);
        Task<IEnumerable<Post>> GetAllByTagNameAsync(string tagName);
        Task<IEnumerable<Post>> GetAllPagesAsync(int count, int page);
        //Task<IEnumerable<Post>> GetQueryPagesAsync(string query, int count, int page = 1);
        //Task<IEnumerable<Post>> GetPostsBasedOnIdCollectionAsync(List<int> postIds);
        Task<Post> AddAsync(Post map);
        //Task<Post> UpdateAsync(Post post);
        //Task RemoveAsync(int id);
    }
}
