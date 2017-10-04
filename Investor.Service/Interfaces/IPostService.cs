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
        Task<int> GetTotalNumberOfPostsByCategoryUrlAsync(string categoryUrl);
        Task<int> GetTotalNumberOfPostByTagAsync(string tag);
        Task<Post> GetPostByIdAsync(int id);
        Task<IEnumerable<T>> GetAllPostsAsync<T>();
        Task<IEnumerable<PostPreview>> GetLatestPostsAsync(int limit);
        Task<IEnumerable<PostPreview>> GetImportantPostsAsync(int limit);
        Task<IEnumerable<PostPreview>> GetPopularPostByCategoryUrlAsync(string categoryUrl, int limit);
        Task<IEnumerable<PostPreview>> GetLatestPostsByCategoryUrlAsync(string categoryUrl, bool onMainPage = false, int limit = 10);
        Task<IEnumerable<PostPreview>> GetPagedLatestPostsByCategoryUrlAsync(string categoryUrl, int limit, int page);
        Task<IEnumerable<PostPreview>> GetAllPostsByTagNameAsync(string tagName);
        //Task<IEnumerable<Post>> GetQueryPagesAsync(string query, int count, int page = 1);
        //Task<IEnumerable<Post>> GetPostsBasedOnIdCollectionAsync(List<int> postIds);
        Task<Post> AddPostAsync(Post map);
        Task UpdatePostAsync(Post post);
        Task RemovePostAsync(int id);
    }
}
