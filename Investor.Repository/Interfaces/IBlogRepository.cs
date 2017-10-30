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
        Task<PostEntity> AddBlogAsync(PostEntity blog);
        Task<PostEntity> GetPostByIdAsync(int id);
        Task<IEnumerable<PostEntity>> GetAllBlogsAsync();
        Task<IEnumerable<PostEntity>> GetLatestBlogsAsync(int limit);
        Task<IEnumerable<PostEntity>> GetPopularBlogsAsync(int limit);
        Task<IEnumerable<PostEntity>> GetBlogsByUserIdAsync(string userId);
    }
}
