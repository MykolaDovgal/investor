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
    class PostRepository : IPostRepository
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

        public Task<IEnumerable<PostEntity>> GetAllAsync()
        {
            //return _newsContext.Posts
            //    .Include(p => p.Category)
            //    .Include(p => p.Comments)
            //    .Include(p => p.Article)
            //    .Include(p => p.Author)
            //    .Include(p => p.PostTags).ToListAsync();


        }

        public Task<IEnumerable<PostEntity>> GetAllByCategoryNameAsync(string categoryName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PostEntity>> GetAllByTagNameAsync(string tagName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PostEntity>> GetAllPagesAsync(int count, int page = 1)
        {
            throw new NotImplementedException();
        }

        public Task<PostEntity> GetByIdAsync(int id, bool includeExceprt)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PostEntity>> GetPostsBasedOnIdCollectionAsync(List<int> postIds)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PostEntity>> GetQueryPagesAsync(string query, int count, int page = 1)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalNumberOfPostByTagAsync(string tag)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalNumberOfPostsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalNumberOfPostsByCategoryAsync(string category)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Post post)
        {
            throw new NotImplementedException();
        }
    }
}
