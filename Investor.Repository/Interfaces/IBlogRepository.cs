using System.Collections.Generic;
using System.Threading.Tasks;
using Investor.Entity;

namespace Investor.Repository.Interfaces
{
    public interface IBlogRepository
    {
        Task<IEnumerable<BlogEntity>> GetAllBlogsAsync();
        Task<IEnumerable<BlogEntity>> GetLatestBlogsAsync(int limit);
        Task<IEnumerable<BlogEntity>> GetPopularBlogsAsync(int limit);
        Task<IEnumerable<BlogEntity>> GetBlogsByUserIdAsync(string userId, bool? isPublished = null);
        Task<int> GetNumberOfBlogsByUserId(string userId);
        Task<IEnumerable<string>> GetPopularUserIds(int limit);
        Task<IEnumerable<BlogEntity>> GetPagedLatestBlogsAsync(int page, int limit);
        Task<IEnumerable<UserEntity>> GetBlogersBasedOnIdCollectionAsync(ICollection<string> ids);
    }
}
