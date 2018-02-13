using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Investor.Entity;
using Investor.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Investor.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly NewsContext _newsContext;

        public BlogRepository(NewsContext context)
        {
            _newsContext = context;
        }
        public async Task<IEnumerable<BlogEntity>> GetLatestBlogsAsync(int limit)
        {
            return await _newsContext.Blogs
                .Include(p => p.Author)
                .Where(c => c.IsPublished ?? false)
                .OrderByDescending(p => p.PublishedOn)
                .ToListAsync();
            
        }

        public async Task<IEnumerable<BlogEntity>> GetPopularBlogsAsync(int limit)
        {
            return await _newsContext.Blogs
                .Include(p => p.Author)
                .Where(c => c.IsPublished ?? false)
                .OrderByDescending(p => p.PublishedOn)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<IEnumerable<BlogEntity>> GetAllBlogsAsync()
        {
            return await _newsContext.Blogs
                .Include(p => p.Author)
                .ToListAsync();
        }

        public async Task<IEnumerable<BlogEntity>> GetBlogsByUserIdAsync(string userId, bool? isPublished = null)
        {
            return await _newsContext.Blogs
                .Include(p => p.Author)
                .Where(c => isPublished == null || (c.IsPublished == isPublished && isPublished != null))
                .Where(p => p.AuthorId == userId)
                .ToListAsync();
        }

        public async Task<int> GetNumberOfBlogsByUserId(string userId)
        {
            return await _newsContext.Blogs
                .Include(p => p.Author)
                .Where(p => p.AuthorId == userId)
                .CountAsync();
        }

        public async Task<IEnumerable<string>> GetPopularUserIds(int limit)
        {
            IdentityRole role = _newsContext.Roles.FirstOrDefault(r => r.Name == "bloger");

            List<UserEntity> users = await _newsContext
                .Users
                .Where(u => _newsContext.UserRoles.Where(ur => ur.RoleId == role.Id).Select(ur => ur.UserId).Contains(u.Id)) // select users in role "bloger"
                .Include(c => c.Blogs)
                .ToListAsync();
        
            List<string> popularUserIds = users
                .OrderByDescending(u => u.Blogs.Count(b => b.IsPublished ?? false))
                .Take(limit)
                .Select(u => u.Id)
                .ToList();

            return popularUserIds;
        }

        public async Task<IEnumerable<UserEntity>> GetBlogersBasedOnIdCollectionAsync(ICollection<string> ids)
        {
            return await _newsContext
                .Users
                .Where(u => ids.Contains(u.Id)) 
                .Include(c => c.Blogs)
                .ToListAsync();
        }

        public async Task<IEnumerable<BlogEntity>> GetPagedLatestBlogsAsync(int page, int limit)
        {
            var r = await _newsContext.Blogs
                .Include(p => p.Author)
                .Where(c => c.IsPublished ?? false)
                .OrderByDescending(p => p.PublishedOn)
                .Skip(limit * (page - 1))
                .Take(limit)
                .ToListAsync();
            return r;
        }
    }
}
