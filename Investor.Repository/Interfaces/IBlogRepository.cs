using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Investor.Entity;

namespace Investor.Repository.Interfaces
{
    public interface IBlogRepository
    {
        Task<IEnumerable<PostEntity>> GetAllBlogsAsync();
        Task<IEnumerable<PostEntity>> GetLatestBlogsAsync(int limit);
        Task<IEnumerable<PostEntity>> GetPopularBlogsAsync(int limit);
    }
}
