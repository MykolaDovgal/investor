using System.Collections.Generic;
using System.Threading.Tasks;
using Investor.Model;

namespace Investor.Service.Interfaces
{
    public interface IBlogService
    {
        Task<IEnumerable<T>> GetLatestBlogsAsync<T>(int limit = 10);
        Task<IEnumerable<T>> GetAllBlogsAsync<T>();
        Task<IEnumerable<BlogPreview>> GetPopularBlogsAsync(int limit = 3);
        Task<IEnumerable<BlogPreview>> GetBlogsByUserIdAsync(string userId, bool? isPublished = null);
        Task<IEnumerable<BlogPreview>> GetPublishedBlogsByUserIdAsync(string userId);
        Task<IEnumerable<BlogPreview>> GetPagedLatestBlogsAsync(int page, int limit);
        Task AddTagsToBlogAsync(int blogId, IEnumerable<string> tags);
        Task<T> GetBlogByIdAsync<T>(int id);
        Task<IEnumerable<T>> GetAllBlogsByTagNameAsync<T>(string tagName);
        Task<IEnumerable<Blog>> GetBlogsBasedOnIdCollectionAsync(IEnumerable<int> postIds);
        Task<Blog> AddBlogAsync(Blog map);
        Task<Blog> UpdateBlogAsync(Blog post);
        Task UpdateBlogAsync<T>(IEnumerable<T> post);
        Task RemoveBlogAsync(int id);
        Task RemoveBlogAsync(IEnumerable<int> id);
        Task<Tag> AddTagToBlogAsync(int postId, Tag tag);
        Task<List<Tag>> GetAllTagsByBlogIdAsync(int id);
        Task<IEnumerable<PopularUser>> GetPopularUsers(int limit);
        //Task<int> GetNumberOfBlogsByUserId(string userId);
    }
}
