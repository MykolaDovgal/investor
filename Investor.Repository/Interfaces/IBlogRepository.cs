using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Investor.Entity;
using Investor.Model;

namespace Investor.Repository.Interfaces
{
    public interface IBlogRepository
    {
        Task<IEnumerable<BlogEntity>> GetAllBlogsAsync();
        Task<IEnumerable<BlogEntity>> GetLatestBlogsAsync(int limit);
        Task<IEnumerable<BlogEntity>> GetPopularBlogsAsync(int limit);
        Task<IEnumerable<BlogEntity>> GetBlogsByUserIdAsync(string userId);
        Task<int> GetNumberOfBlogsByUserId(string userId);
        Task<IEnumerable<UserEntity>> GetPopularUsers(int limit);
    }
}
