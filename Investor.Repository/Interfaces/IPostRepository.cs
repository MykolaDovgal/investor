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
        Task<int> GetTotalNumberOfPostsByCategoryUrlAsync(string url);
        Task<int> GetTotalNumberOfPostByTagAsync(string tag);
        Task<PostEntity> GetPostByIdAsync(int id);
        Task<IEnumerable<PostEntity>> GetAllPostsAsync();
        Task<IEnumerable<PostEntity>> GetLatestPostsAsync(int limit);
        Task<IEnumerable<PostEntity>> GetImportantPostAsync(int limit);
        Task<IEnumerable<PostEntity>> GetPopularPostByCategoryUrlAsync(string categoryUrl, int limit);
        IEnumerable<PostEntity> GetAllPosts();
        Task<IEnumerable<PostEntity>> GetAllPostsByCategoryUrlAsync(string categoryUrl, bool onMainPage  );
        Task<IEnumerable<PostEntity>> GetAllPostsByTagNameAsync(string tagName);
        Task<IEnumerable<PostEntity>> GetAllPostsPagesAsync(int count, int page = 1);
        Task<IEnumerable<PostEntity>> GetQueryPagesAsync(string query, int count, int page = 1);
        Task<IEnumerable<PostEntity>> GetPostsBasedOnIdCollectionAsync(List<int> postIds);
        Task<PostEntity> AddPostAsync(PostEntity map);
        Task<PostEntity> UpdatePostAsync(PostEntity post);
        Task RemovePostAsync(int id);
    }


}
