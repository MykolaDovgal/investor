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

namespace Investor.Service
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IPostRepository _postRepository;
        private readonly IUserService _userService;

        public BlogService(IBlogRepository blogRepository, IUserService userService, IPostRepository postRepository)
        {
            _blogRepository = blogRepository;
            _userService = userService;
            _postRepository = postRepository;
        }

        public async Task<Blog> AddBlogAsync(Blog map)
        {
            map.Author = _userService.GetCurrentUserAsync().Result;
            var response = await _postRepository.AddPostAsync<BlogEntity>(Mapper.Map<Blog, BlogEntity>(map));
            map.PostId = response.PostId;
            return map;
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
            var tags = await _postRepository.GetAllTagsByPostIdAsync(id);
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

        public async Task<IEnumerable<BlogPreview>> GetLatestBlogsAsync(int limit = 10)
        {
            var blogs = await _blogRepository.GetLatestBlogsAsync(limit);
            return blogs.Select(Mapper.Map<BlogEntity, BlogPreview>);
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

        public async Task<T> UpdateBlogAsync<T>(T post)
        {
            var blog = await _postRepository.UpdatePostAsync<BlogEntity>(Mapper.Map<T, BlogEntity>(post));
            return Mapper.Map<BlogEntity, T>(blog);
        }

        public async Task UpdateBlogAsync<T>(IEnumerable<T> post)
        {
            await _postRepository.UpdatePostAsync<BlogEntity>(post.Select(Mapper.Map<T, BlogEntity>));
        }
    }
}
