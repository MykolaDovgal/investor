using Investor.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Investor.Entity;
using Investor.Model;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Investor.Repository
{
    public class PostRepository : IPostRepository
    {
        readonly private NewsContext _newsContext;
        public PostRepository(NewsContext context)
        {
            _newsContext = context;
        }
        public async Task<PostEntity> AddAsync(PostEntity post)
        {
            await _newsContext.Posts.AddAsync(post);
            await _newsContext.SaveChangesAsync();
            return post;
        }

        public async Task<IEnumerable<PostEntity>> GetAllAsync()
        {
            return await _newsContext.Posts
                .Include(p => p.Category)
                .Include(p => p.Comments)
                .Include(p => p.Article)
                .Include(p => p.Author)
                .Include(p => p.PostTags)
                .ToListAsync();           
        }

        public IEnumerable<PostEntity> GetAll()
        {
            return  _newsContext.Posts
                .Include(p => p.Category)
                .Include(p => p.Comments)
                .Include(p => p.Article)
                .Include(p => p.Author)
                .Include(p => p.PostTags)
                .ToList();


        }

        public async Task<IEnumerable<PostEntity>> GetAllByCategoryNameAsync(string categoryName, bool onMainPage = false)
        {
            IQueryable<PostEntity> posts = null;
        
            switch (onMainPage)
            {
                case true:
                    posts = _newsContext.Posts.Include(p => p.Category).Where(p => p.IsOnMainPage && p.Category.Name == categoryName);
                    break;
                case false:
                    posts = _newsContext.Posts.Include(p => p.Category).Where(p => p.Category.Name == categoryName);
                    break;
                default:
                    break;
            }

            return await posts.ToListAsync();
        }

        public async Task<IEnumerable<PostEntity>> GetAllByTagNameAsync(string tagName)
        {
            return await _newsContext.Posts
                .Include(p => p.PostTags)
                .Where(p => p.PostTags.Find(pt => pt.Tag.Name == tagName) != null)
                .ToListAsync();
        }

        public Task<IEnumerable<PostEntity>> GetAllPagesAsync(int count, int page = 1)
        {
            throw new NotImplementedException();
        }

        public async Task<PostEntity> GetByIdAsync(int id)
        {
            return await _newsContext.Posts
                .Include(p => p.Category)
                .Include(p => p.Comments)
                .Include(p => p.Article)
                .Include(p => p.Author)
                .Include(p => p.PostTags)
                .FirstOrDefaultAsync(p => p.PostId == id);
        }

        public async Task<IEnumerable<PostEntity>> GetPostsBasedOnIdCollectionAsync(List<int> postIds)
        {
            return await _newsContext.Posts
                .Where(p => postIds.Contains(p.PostId))
                .Include(p => p.Category)
                .Include(p => p.Comments)
                .Include(p => p.Article)
                .Include(p => p.Author)
                .Include(p => p.PostTags)
                .ToListAsync();
        }

        public Task<IEnumerable<PostEntity>> GetQueryPagesAsync(string query, int count, int page = 1)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalNumberOfPostByTagAsync(string tag)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetTotalNumberOfPostsAsync()
        {
            return await _newsContext
                    .Posts
                    .CountAsync();
        }

        public Task<int> GetTotalNumberOfPostsByCategoryAsync(string category)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(int id)
        {
            var postToRemove = await _newsContext
                    .Posts
                    .FirstOrDefaultAsync(c => c.PostId == id);

            _newsContext
                .Posts
                .Remove(postToRemove);

            await _newsContext.SaveChangesAsync();
        }

        public async Task<PostEntity> UpdateAsync(PostEntity post)
        {
            _newsContext.Entry(post).State = EntityState.Modified;
            await _newsContext.SaveChangesAsync();
            return post;
        }

        public async Task<IEnumerable<PostEntity>> GetLatestPostsAsync(int limit)
        {
            return await _newsContext.Posts
                .Include(p => p.Category)
                .Include(p => p.Comments)
                .Include(p => p.Article)
                .Include(p => p.Author)
                .Include(p => p.PostTags)
                .OrderByDescending(p => p.PublishedOn)
                .Take(limit)
                .ToListAsync();
        }
    }
}
