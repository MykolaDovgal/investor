using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Investor.Entity;
using Investor.Model;

namespace Investor.Service.Interfaces
{
    public interface IBlogService
    {
        Task<IEnumerable<BlogPreview>> GetLatestBlogsAsync(int limit = 10);
        Task<IEnumerable<BlogPreview>> GetPopularBlogsAsync(int limit = 3);
        Task<IEnumerable<BlogPreview>> GetBlogsByUserIdAsync(string userId);

        Task<T> GetBlogByIdAsync<T>(int id);
        Task<IEnumerable<T>> GetAllBlogsByTagNameAsync<T>(string tagName);
        Task<IEnumerable<Blog>> GetBlogsBasedOnIdCollectionAsync(IEnumerable<int> postIds);
        Task<Blog> AddBlogAsync(Blog map);
        Task<T> UpdateBlogAsync<T>(T post);
        Task UpdateBlogAsync<T>(IEnumerable<T> post);
        Task RemoveBlogAsync(int id);
        Task RemoveBlogAsync(IEnumerable<int> id);
        Task<Tag> AddTagToBlogAsync(int postId, Tag tag);
        Task<List<Tag>> GetAllTagsByBlogIdAsync(int id);
    }
}
