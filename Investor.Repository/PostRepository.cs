using Investor.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Investor.Entity;
using Investor.Model;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Investor.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly NewsContext _newsContext;
        private readonly int categoryBlogId;
        public PostRepository(NewsContext context)
        {
            _newsContext = context;
            categoryBlogId = _newsContext
                .Categories
                .FirstOrDefault(c => c.Url == "blog")
                .CategoryId;
        }
        public async Task<PostEntity> AddPostAsync(PostEntity post)
        {
            await _newsContext.Posts.AddAsync(post);
            await _newsContext.SaveChangesAsync();
            return post;
        }

        public async Task<IEnumerable<PostEntity>> GetAllPostsAsync()
        {
            return await _newsContext.Posts
                .Include(p => p.Category)
                .Include(p => p.Author)
                .Where(p=>p.CategoryId != categoryBlogId)
                .ToListAsync();
        }

        public IEnumerable<PostEntity> GetAllPosts()
        {
            return _newsContext.Posts
                .Include(p => p.Category)
                .Include(p => p.Author)
                .Include(p => p.PostTags)
                .Where(p => p.CategoryId != categoryBlogId)
                .ToList();


        }

        public async Task<IEnumerable<PostEntity>> GetLatestPostsByCategoryUrlAsync(string categoryUrl, bool onMainPage, int limit)
        {
            IQueryable<PostEntity> posts = null;

            switch (onMainPage)
            {
                case true:
                    posts = _newsContext
                        .Posts
                        .OrderByDescending(p => p.PublishedOn)
                        .Include(p => p.Category)
                        .Where(p => (p.IsOnMainPage ?? false) && p.Category.Url == categoryUrl.ToLower());
                    break;
                case false:
                    posts = _newsContext
                        .Posts
                        .OrderByDescending(p => p.PublishedOn)
                        .Include(p => p.Category)
                        .Where(p => p.Category.Url == categoryUrl.ToLower());
                    break;
                default:
                    break;
            }



            return await posts.Take(limit).ToListAsync();
        }

        public async Task<IEnumerable<PostEntity>> GetPagedLatestPostsByCategoryUrlAsync(string categoryUrl, int limit, int page)
        {
            return await _newsContext.Posts
                .Where(p => p.Category.Url == categoryUrl.ToLower())
                .Include(p => p.Category)
                .OrderByDescending(p => p.PublishedOn)
                .Skip(limit * (page - 1))
                .Take(limit)
                .ToListAsync();
        }

        public async Task<IEnumerable<PostEntity>> GetAllPostsByTagNameAsync(string tagName)
        {
            return await _newsContext.Posts
                .Include(p => p.PostTags)
                .Where(p => p.PostTags.Select(posttag=>posttag.Tag.Name).Contains(tagName))
                .ToListAsync();
        }

        public Task<IEnumerable<PostEntity>> GetAllPostsPagesAsync(int count, int page = 1)
        {
            throw new NotImplementedException();
        }

        public async Task<PostEntity> GetPostByIdAsync(int id)
        {
            return await _newsContext.Posts
                .AsNoTracking()
                .Include(p => p.Category)
                .Include(p => p.Author)
                .Include(p => p.PostTags)
                .FirstOrDefaultAsync(p => p.PostId == id);
        }

        public async Task<IEnumerable<PostEntity>> GetPostsBasedOnIdCollectionAsync(IEnumerable<int> postIds)
        {
            return await _newsContext.Posts
                .Where(p => postIds.Contains(p.PostId))
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

        public async Task<int> GetTotalNumberOfPostsByCategoryUrlAsync(string categoryUrl)
        {
            return await _newsContext
                .Posts
                .Include(p => p.Category)
                .Where(p => p.Category.Url == categoryUrl)
                .CountAsync();
        }

        public async Task RemovePostAsync(int id)
        {
            var postToRemove = await _newsContext
                    .Posts
                    .FirstOrDefaultAsync(c => c.PostId == id);

            _newsContext
                .Posts
                .Remove(postToRemove);

            await _newsContext.SaveChangesAsync();
        }

        public async Task RemovePostAsync(IEnumerable<int> id)
        {
            var postsToRemove = _newsContext
                .Posts
                .Where(p => id.Contains(p.PostId));

            _newsContext.Posts.RemoveRange(postsToRemove);
            await _newsContext.SaveChangesAsync();
        }

        public async Task<PostEntity> UpdatePostAsync(PostEntity post)
        {
            PostEntity oldPost = _newsContext.Posts.FindAsync(post.PostId).Result;
            oldPost = Mapper.Map<PostEntity, PostEntity>(post, oldPost);
            oldPost.Category = _newsContext.Categories.Find(oldPost.Category.CategoryId);
            _newsContext.Posts.Update(oldPost);            
            await _newsContext.SaveChangesAsync();
            return post;
        }

        public async Task UpdatePostAsync(IEnumerable<PostEntity> posts)
        {
            List<PostEntity> newPosts = posts as List<PostEntity> ?? posts.ToList();
            var postsId = newPosts.Select(x => x.PostId);
            var oldPosts = await GetPostsBasedOnIdCollectionAsync(postsId);

            foreach (PostEntity postEntity in oldPosts)
            {
                postEntity.IsImportant = newPosts.Find(x => x.PostId == postEntity.PostId).IsImportant;
                postEntity.IsPublished = newPosts.Find(x => x.PostId == postEntity.PostId).IsPublished;
                postEntity.IsOnMainPage = newPosts.Find(x => x.PostId == postEntity.PostId).IsOnMainPage;
                postEntity.ModifiedOn = DateTime.Now;
            }

            await _newsContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<PostEntity>> GetLatestPostsAsync(int limit)
        {
            return await _newsContext.Posts
                .Include(p => p.Category)
                .OrderByDescending(p => p.PublishedOn)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<IEnumerable<PostEntity>> GetPopularPostByCategoryUrlAsync(string categoryUrl, int limit)
        {
            return await _newsContext.Posts
                .Where(p => p.Category.Url == categoryUrl)
                .OrderByDescending(p => p.PublishedOn)
                .Take(limit)
                .Include(p => p.Category)
                .ToListAsync();
        }

        public async Task<IEnumerable<PostEntity>> GetImportantPostAsync(int limit)
        {
            return await _newsContext.Posts
                .Where(p => p.IsImportant ?? false)
                .OrderByDescending(p => p.PublishedOn)
                .Take(limit)
                .Include(p => p.Category)
                .ToListAsync();
        }

        public async Task<TagEntity> AddTagToPostAsync(int postId, TagEntity tag)
        {
            var post = _newsContext
                 .Posts
                 .Include(t => t.PostTags)
                 .FirstOrDefault(p => p.PostId == postId);

            var newTag = new PostTagEntity() { Post = post, Tag = tag };
            post.PostTags.Add(newTag);
            await _newsContext.SaveChangesAsync();
            return newTag.Tag;
        }

        public async Task<List<TagEntity>> GetAllTagsByPostIdAsync(int id)
        {
            var post = await _newsContext.Posts.Include(p => p.PostTags).ThenInclude(p => p.Tag).FirstOrDefaultAsync(p => p.PostId == id);
            return post.PostTags.Select(p => p.Tag).ToList();
        }

        public async Task<IEnumerable<PostEntity>> GetQueriedPost(PostSearchQuery query)
        {

            DateTime? dtStart = null;
            DateTime? dtEnd = null;

            if (query.Date.HasValue)
            {
                dtStart = new DateTime(query.Date.Value.Year, query.Date.Value.Month, query.Date.Value.Day);
                dtEnd = new DateTime(query.Date.Value.Year, query.Date.Value.Month, query.Date.Value.Day + 1);
            }

            IQueryable<PostEntity> posts = _newsContext.Posts
                .Include(post => post.Category)
                .Where(post => (string.IsNullOrEmpty(query.CategoryUrl) || post.Category.Url == query.CategoryUrl) &&
                               (string.IsNullOrEmpty(query.Query) || post.Description.ToLower().Contains(query.Query.ToLower()) ||
                                post.Title.ToLower().Contains(query.Query.ToLower())) &&
                               (!query.Date.HasValue || post.PublishedOn.HasValue && (post.PublishedOn.Value > dtStart && post.PublishedOn.Value < dtEnd)) &&
                               (post.IsPublished ?? true))//TODO change true to false
                .OrderByDescending(x => x.PublishedOn)
                .Skip((query.Page - 1) * query.Count)
                .Take(query.Count);
            return await posts.ToListAsync();
        }

        public async Task<IEnumerable<PostEntity>> GetQueriedPostByTag(PostSearchQuery query)
        {
            DateTime? dtStart = null;
            DateTime? dtEnd = null;

            if (query.Date.HasValue)
            {
                dtStart = new DateTime(query.Date.Value.Year, query.Date.Value.Month, query.Date.Value.Day);
                dtEnd = new DateTime(query.Date.Value.Year, query.Date.Value.Month, query.Date.Value.Day + 1);
            }
            IQueryable<PostEntity> posts = _newsContext
                .Posts
                .Include(post=>post.PostTags)
                .Include(post=>post.Category)
                .Where(post => (string.IsNullOrEmpty(query.CategoryUrl) || post.Category.Url == query.CategoryUrl) &&
                               (string.IsNullOrEmpty(query.Query) || post.PostTags.FirstOrDefault(posttag => posttag.Tag.Name.ToLower().Contains(query.Query.ToLower())) != null) &&
                               (!query.Date.HasValue || post.PublishedOn.HasValue && (post.PublishedOn.Value > dtStart && post.PublishedOn.Value < dtEnd)) &&
                               (post.IsPublished ?? true))//TODO change true to false
                .OrderByDescending(x => x.PublishedOn)
                .Skip((query.Page - 1) * query.Count)
                .Take(query.Count);
            return await posts.ToListAsync();
        }
    }
}
