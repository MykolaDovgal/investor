using Investor.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Investor.Entity;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AutoMapper;
using Investor.Model;

namespace Investor.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly NewsContext _newsContext;
        public PostRepository(NewsContext context)
        {
            _newsContext = context;
        }

        public async Task<T> AddPostAsync<T>(T map) where T : PostEntity
        {
            map.ModifiedOn = DateTime.Now;
            map.CreatedOn = DateTime.Now;
            map.PublishedOn = DateTime.Now; // TODO!
            await _newsContext.Set<T>().AddAsync(map);
            await _newsContext.SaveChangesAsync();
            return map;
        }

        public async Task<TagEntity> AddTagToPostAsync(int postId, TagEntity tag)
        {
            var post = _newsContext
                 .Posts
                 .Include(t => t.PostTags)
                 .FirstOrDefault(p => p.PostId == postId);

            var newTag = new PostTagEntity() { Post = post, Tag = tag };
            post?.PostTags?.Add(newTag);
            await _newsContext.SaveChangesAsync();
            return newTag.Tag;
        }
        public async Task RemoveTagFromPostAsync (int postId, TagEntity tag)
        {
            var post = _newsContext
                 .Posts
                 .Include(t => t.PostTags)
                 .FirstOrDefault(p => p.PostId == postId);

            var postTag = post.PostTags.FirstOrDefault(pt => pt.PostId == postId && pt.TagId == tag.TagId);
            post.PostTags.Remove(postTag);
            _newsContext.Update(post);
            await _newsContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllPostsByTagNameAsync<T>(string tagName) where T : PostEntity
        {
            return await _newsContext.Posts
                .OfType<T>()
                .Include(p => p.PostTags)
                .Where(c => c.IsPublished ?? false)
                .Where(p => p.PostTags.Select(posttag => posttag.Tag.Name)
                .Contains(tagName))
                .ToListAsync();
        }

        public async Task<List<TagEntity>> GetAllTagsByPostIdAsync(int id)
        {
            var post = await _newsContext
                .Posts
                .Include(p => p.PostTags)
                .ThenInclude(p => p.Tag)
                .FirstOrDefaultAsync(p => p.PostId == id);
            return post?.PostTags?.Select(p => p.Tag).ToList();
        }

        public async Task<IEnumerable<T>> GetLatestPostsByCategoryUrlAsync<T>(string categoryUrl, int limit) where T : PostEntity
        {
            IQueryable<T> posts = null;

            posts = _newsContext
                .Posts
                .OfType<T>()
                .Include(p => p.Category)
                .Where(c => c.IsPublished ?? false)
                .Where(p => p.Category.Url == categoryUrl.ToLower())
                .OrderByDescending(p => p.PublishedOn);
            return await posts.Take(limit).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetPagedLatestPostsByCategoryUrlAsync<T>(string categoryUrl, int limit, int page) where T : PostEntity
        {
            return await _newsContext.Posts
                .Include(p => p.Category)
                .OfType<T>()
                .Where(c => c.IsPublished ?? false)
                .Where(p => p.Category.Url.Contains(categoryUrl.ToLower()))
                .OrderByDescending(p => p.PublishedOn)
                .Skip(limit * (page - 1))
                .Take(limit)
                .ToListAsync();
        }

        public async Task<IEnumerable<T>> GetPopularPostsByCategoryUrlAsync<T>(string categoryUrl, int limit) where T : PostEntity
        {
            return await _newsContext.Posts
                .OfType<T>()
                .Where(c => c.IsPublished ?? false)
                .Where(p => p.Category.Url == categoryUrl)
                .OrderByDescending(p => p.PublishedOn)
                .Take(limit)
                .Include(p => p.Category)
                .ToListAsync();
        }

        public async Task<T> GetPostByIdAsync<T>(int id) where T : PostEntity
        {  
            var blog = await _newsContext.Posts
                .OfType<T>()
                .Include(p => p.Category)
                .Include(p => p.PostTags)
                .ThenInclude(p=>p.Tag)
                .FirstOrDefaultAsync(p => p.PostId == id);
            if (blog is BlogEntity)
                _newsContext.Entry(blog as BlogEntity).Reference(c => c.Author).Load();
            return blog;

        }

        public async Task<IEnumerable<T>> GetPostsBasedOnIdCollectionAsync<T>(IEnumerable<int> postIds) where T : PostEntity
        {
            return await _newsContext.Posts
                .OfType<T>()
                .Include(c=>c.Category)
                .AsNoTracking()
                .Where(p => postIds.Contains(p.PostId))
                .ToListAsync();
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

        public async Task<T> UpdatePostAsync<T>(T post) where T : PostEntity
        {
            T oldPost = _newsContext
                .Posts
                .OfType<T>()
                .Include(c=>c.Category)
                .FirstOrDefaultAsync(p => p.PostId == post.PostId)
                .Result;

            oldPost.PublishedOn = (post.IsPublished ?? false) && !(oldPost.IsPublished ?? false) ? DateTime.Now : oldPost.PublishedOn;
            oldPost = Mapper.Map(post, oldPost);
            oldPost.Category = _newsContext.Categories.Find(post.CategoryId ?? oldPost.Category.CategoryId);
            var newPost = _newsContext.Set<T>().Update(oldPost);
            await _newsContext.SaveChangesAsync();
            return oldPost;
        }

        public async Task UpdatePostAsync<T>(IEnumerable<T> posts) where T : PostEntity
        {
            List<T> newPosts = posts as List<T> ?? posts.ToList();
            IEnumerable<int> postsId = newPosts.Select(x => x.PostId);
            List<T> oldPosts = (await GetPostsBasedOnIdCollectionAsync<T>(postsId)).ToList();

            for (var i=0; i < oldPosts.Count(); i++)
            {
                T newPost = newPosts.Find(x => x.PostId == oldPosts[i].PostId);
                oldPosts[i].PublishedOn = (newPost.IsPublished ?? false) && !(oldPosts[i].IsPublished ?? false) ? DateTime.Now : oldPosts[i].PublishedOn;
                oldPosts[i] = Mapper.Map<T, T>(newPost, oldPosts[i]);  //TODO ??
                oldPosts[i].ModifiedOn = DateTime.Now;
            }
            _newsContext.Set<T>().UpdateRange(oldPosts);
            await _newsContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<PostEntity>> GetQueriedNews(PostSearchQuery query)
        {
            DateTime? dtStart = null;
            DateTime? dtEnd = null;

            query.Tag = query.Tag ?? string.Empty;

            if (query.Date.HasValue)
            {
                dtStart = new DateTime(query.Date.Value.Year, query.Date.Value.Month, query.Date.Value.Day);
                dtEnd = new DateTime(query.Date.Value.Year, query.Date.Value.Month, query.Date.Value.Day + 1);
            }
            IQueryable<PostEntity> posts = _newsContext.Posts
                .Include(post => post.Category)
                .Include(post => post.PostTags)
                .ThenInclude(post => post.Tag)
                .Where(post => (string.IsNullOrEmpty(query.CategoryUrl) || post.Category.Url == query.CategoryUrl) &&
                               (string.IsNullOrEmpty(query.Tag) && (string.IsNullOrEmpty(query.Query) || post.Description.ToLower().Contains(query.Query.ToLower()) ||
                                post.Title.ToLower().Contains(query.Query.ToLower()) || (post.PostTags != null && post.PostTags.Select(posttag => posttag.Tag).Any(c => c.Name.ToLower().Contains(query.Query.ToLower()))))
                                || (!string.IsNullOrEmpty(query.Tag) && post.PostTags != null && post.PostTags.Select(posttag => posttag.Tag.Name.ToLower()).Contains(query.Tag.ToLower()))) &&
                               (!query.Date.HasValue || post.PublishedOn.HasValue && (post.PublishedOn.Value > dtStart && post.PublishedOn.Value < dtEnd)) &&
                               (post.IsPublished ?? false))//TODO change true to false
                .OrderByDescending(x => x.PublishedOn)
                .Skip((query.Page - 1) * query.Count)
                .Take(query.Count);
            return await posts.ToListAsync();
        }

        public IEnumerable<T> GetAllPosts<T>() where T : PostEntity
        {
            if (typeof(T) == typeof(BlogEntity))
                _newsContext.Users.Where(b => b.Blogs.Count > 0).Load();
            return _newsContext
                .Set<T>()
                .Include(c=>c.Category);
        }
    }
}
