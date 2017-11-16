using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Investor.Entity;
using Investor.Repository.Interfaces;
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
                .OrderByDescending(p => p.PublishedOn)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<IEnumerable<BlogEntity>> GetPopularBlogsAsync(int limit)
        {
            return await _newsContext.Blogs
                .Include(p => p.Author)
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

        public async Task<IEnumerable<BlogEntity>> GetBlogsByUserIdAsync(string userId)
        {
            return await _newsContext.Blogs
                .Include(p => p.Author)
                .Where(p => p.AuthorId == userId)
                .ToListAsync();
        }
    }
}
