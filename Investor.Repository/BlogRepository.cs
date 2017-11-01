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
        private readonly int categoryBlogId;

        public BlogRepository(NewsContext context)
        {
            _newsContext = context;
            categoryBlogId = _newsContext
                .Categories
                .FirstOrDefault(c => c.Url == "blog")
                .CategoryId;
        }

        public async Task<PostEntity> AddBlogAsync(PostEntity blog)
        {
            blog.ModifiedOn = DateTime.Now;
            blog.CreatedOn = DateTime.Now;
            blog.CategoryId = 5;
            await _newsContext.Posts.AddAsync(blog);
            await _newsContext.SaveChangesAsync();
            return blog;
        }

        public async Task<IEnumerable<PostEntity>> GetLatestBlogsAsync(int limit)
        {
            return await _newsContext.Posts
                .Where(p => p.CategoryId == categoryBlogId)
                .Include(p => p.Author)
                .OrderByDescending(p => p.PublishedOn)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<IEnumerable<PostEntity>> GetPopularBlogsAsync(int limit)
        {
            return await _newsContext.Posts
                .Where(p => p.CategoryId == categoryBlogId)
                .Include(p => p.Author)
                .OrderByDescending(p => p.PublishedOn)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<IEnumerable<PostEntity>> GetAllBlogsAsync()
        {
            return await _newsContext.Posts
                .Where(p => p.CategoryId == categoryBlogId)
                .Include(p => p.Author)
                .ToListAsync();
        }

        public async Task<PostEntity> GetPostByIdAsync(int id)
        {
            return await _newsContext.Posts
                .Where(p => p.CategoryId == categoryBlogId)
                .Include(p => p.Author)
                .FirstOrDefaultAsync(p => p.PostId == id);
        }

        public async Task<IEnumerable<PostEntity>> GetBlogsByUserIdAsync(string userId)
        {
            return await _newsContext.Posts
                .Include(p => p.Author)
                .Where(p => (p.CategoryId == categoryBlogId) && (p.AuthorId == userId))
                .ToListAsync();
        }
    }
}
