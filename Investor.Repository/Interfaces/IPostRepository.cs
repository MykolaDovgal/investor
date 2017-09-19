using Investor.Entity;
using Investor.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Repository.Interfaces
{
    public interface IPostRepository
    {
        Task<int> GetTotalNumberOfPostsAsync();
        Task<int> GetTotalNumberOfPostsByCategoryAsync(string category);
        Task<int> GetTotalNumberOfPostByTagAsync(string tag);
        Task<PostEntity> GetByIdAsync(int id);
        Task<IEnumerable<PostEntity>> GetAllAsync();
        Task<IEnumerable<PostEntity>> GetLatestPostsAsync(int limit);
        Task<IEnumerable<PostEntity>> GetPopularPostByCategoryNameAsync(string categoryName, int limit);
        IEnumerable<PostEntity> GetAll();
        Task<IEnumerable<PostEntity>> GetAllByCategoryNameAsync(string categoryName, bool onMainPage  );
        Task<IEnumerable<PostEntity>> GetAllByTagNameAsync(string tagName);
        Task<IEnumerable<PostEntity>> GetAllPagesAsync(int count, int page = 1);
        Task<IEnumerable<PostEntity>> GetQueryPagesAsync(string query, int count, int page = 1);
        Task<IEnumerable<PostEntity>> GetPostsBasedOnIdCollectionAsync(List<int> postIds);
        Task<PostEntity> AddAsync(PostEntity map);
        Task<PostEntity> UpdateAsync(PostEntity post);
        Task RemoveAsync(int id);
    }


}
