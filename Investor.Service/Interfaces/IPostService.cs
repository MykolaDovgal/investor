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
        Task AddTagToPostAsync(int postId, string tagName);
        Task AddTagsToPostAsync(int postId, IEnumerable<string> tags);
        Task<IEnumerable<Tag>> GetAllTagsByPostId(int id);
        Task<Post> AddPostAsync(Post map);
        Task<Post> UpdatePostAsync(Post post);
        Task UpdatePostAsync(IEnumerable<Post> post);
        Task RemovePostAsync(int id);
    }
}
