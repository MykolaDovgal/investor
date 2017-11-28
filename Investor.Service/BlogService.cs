using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Investor.Entity;
using Investor.Model;
using Investor.Repository.Interfaces;
using Investor.Service.Interfaces;
using Investor.Model.Views;

namespace Investor.Service
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IPostRepository _postRepository;
        private readonly IUserService _userService;
        private readonly ITagService _tagService;
        private readonly ICategoryService _categoryService;


        public BlogService(IBlogRepository blogRepository, IUserService userService, IPostRepository postRepository, ITagService tagService, ICategoryService categoryService)
        {
            _blogRepository = blogRepository;
            _userService = userService;
            _postRepository = postRepository;
            _tagService = tagService;
            _categoryService = categoryService;
        }

        public async Task<Blog> AddBlogAsync(Blog map)
        {
            map.Author = _userService.GetCurrentUserAsync().Result;
            map.Category = await _categoryService.GetCategoryByUrlAsync("blog");
            var response = await _postRepository.AddPostAsync<BlogEntity>(Mapper.Map<Blog, BlogEntity>(map));
            await AddTagsToBlogAsync(response.PostId, map.Tags.Select(c=>c.Name));
            map.PostId = response.PostId;
            return map;
        }

        private async Task AddTagsToBlogAsync(int postId, IEnumerable<string> tags) // TODO rename method
        {
            if (tags != null)
            {
                var postTags = await _postRepository.GetAllTagsByPostIdAsync(postId);
                foreach (var t in tags)
                {
                    var tag = await _tagService.GetTagByNameAsync(t) ?? await _tagService.AddTagAsync(new Tag { Name = t });
                    if (!postTags.Select(s => s.Name).Contains(t))
                    {
                        await _postRepository.AddTagToPostAsync(postId, Mapper.Map<Tag, TagEntity>(tag));
                    }
                }
                postTags.Where(pt => !tags.Contains(pt.Name)).ToList().ForEach(async pt => await _postRepository.RemoveTagFromPostAsync(postId, pt)); //!!!!!!!!!!!!!!!!!
            }
        }

        public async Task<Tag> AddTagToBlogAsync(int postId, Tag tag)
        {
            var tagEntity = await _postRepository.AddTagToPostAsync(postId, Mapper.Map<Tag, TagEntity>(tag));
            return Mapper.Map<TagEntity, Tag>(tagEntity);
        }

        public async Task<IEnumerable<T>> GetAllBlogsByTagNameAsync<T>(string tagName)
        {
            var blogs = await _postRepository.GetAllPostsByTagNameAsync<BlogEntity>(tagName);
            return blogs.Select(Mapper.Map<BlogEntity, T>);
        }

        public async Task<List<Tag>> GetAllTagsByBlogIdAsync(int id)
        {
            var tags = await _postRepository.GetAllTagsByPostIdAsync(id) ?? new List<TagEntity>();
            return tags.Select(Mapper.Map<TagEntity, Tag>).ToList();
        }

        public async Task<IEnumerable<Blog>> GetBlogsBasedOnIdCollectionAsync(IEnumerable<int> postIds)
        {
            var blogs = await _postRepository.GetPostsBasedOnIdCollectionAsync<BlogEntity>(postIds);
            return blogs.Select(Mapper.Map<BlogEntity, Blog>);
        }

        public async Task<IEnumerable<BlogPreview>> GetBlogsByUserIdAsync(string userId)
        {
            var blogs = await _blogRepository.GetBlogsByUserIdAsync(userId);
            return blogs.Select(Mapper.Map<BlogEntity, BlogPreview>);
        }

        public async Task<IEnumerable<T>> GetLatestBlogsAsync<T>(int limit = 10)
        {
            var blogs = await _blogRepository.GetLatestBlogsAsync(limit);
            return blogs.Select(Mapper.Map<BlogEntity, T>);
        }

        public async Task<IEnumerable<BlogPreview>> GetPopularBlogsAsync(int limit = 3)
        {
            var blogs = await _blogRepository.GetPopularBlogsAsync(limit);
            return blogs.Select(Mapper.Map<BlogEntity, BlogPreview>);
        }

        public async Task<T> GetBlogByIdAsync<T>(int id)
        {
            var blog = await _postRepository.GetPostByIdAsync<BlogEntity>(id);
            return Mapper.Map<BlogEntity, T>(blog);
        }

        public async Task RemoveBlogAsync(int id)
        {
            await _postRepository.RemovePostAsync(id);
        }

        public async Task RemoveBlogAsync(IEnumerable<int> id)
        {
            await _postRepository.RemovePostAsync(id);
        }

        public async Task<Blog> UpdateBlogAsync(Blog post)
        {
            post.Author = _userService.GetCurrentUserAsync().Result;
            var blog = await _postRepository.UpdatePostAsync<BlogEntity>(Mapper.Map<Blog, BlogEntity>(post));
            await AddTagsToBlogAsync(blog.PostId, post.Tags?.Select(c => c.Name));
            return Mapper.Map<BlogEntity, Blog>(blog);
        }

        public async Task UpdateBlogAsync<T>(IEnumerable<T> post)
        {
            await _postRepository.UpdatePostAsync<BlogEntity>(post.Select(Mapper.Map<T, BlogEntity>));
        }

        public async Task<IEnumerable<PopularUserViewModel>> GetPopularUsers(int limit)
        {
            List<UserEntity> users = (await _blogRepository.GetPopularUsers(limit)).ToList();

            List<PopularUserViewModel> popUsers = new List<PopularUserViewModel>();
            users.ForEach(u =>
            {
                BlogEntity blog = u.Blogs.OrderBy(b => b.PublishedOn)?.FirstOrDefault();
                popUsers.Add(new PopularUserViewModel { User = Mapper.Map<UserEntity, User>(u), NumberOfPosts = u.Blogs.Count, PostId = blog?.PostId ?? 0, Title = blog?.Title ?? String.Empty });
            });
            return popUsers;
        }

        public async Task<IEnumerable<BlogPreview>> GetPagedLatestBlogsAsync(int page, int limit)
        {
            var posts = (await _blogRepository
                .GetPagedLatestBlogsAsync(page, limit))
                .Select(Mapper.Map<BlogEntity, BlogPreview>);
            return posts;
        }
    }
}
