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

        public async Task<Blog> AddBlogAsync(Blog map)
        {
            map.ModifiedOn = DateTime.Now;
            map.CreatedOn = DateTime.Now;
            var response = await _blogRepository.AddBlogAsync(Mapper.Map<Blog, PostEntity>(map));
            map.PostId = response.PostId;
            return map;
        }

        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        public async Task<IEnumerable<BlogPreview>> GetLatestBlogsAsync(int limit = 10)
        {
            var blogs =  await _blogRepository.GetLatestBlogsAsync(limit);
            return blogs.Select(Mapper.Map<PostEntity, BlogPreview>);
        }

        public async Task<IEnumerable<BlogPreview>> GetPopularBlogsAsync(int limit = 3)
        {
            var blogs = await _blogRepository.GetLatestBlogsAsync(limit);
            return blogs.Select(Mapper.Map<PostEntity, BlogPreview>);
        }

        public async Task<IEnumerable<T>> GetAllPostsAsync<T>()
        {
            var posts = await _blogRepository.GetAllBlogsAsync();
            return posts.Select(Mapper.Map<PostEntity, T>);
        }

        public async Task<Blog> GetPostByIdAsync(int id)
        {
            var post = await _blogRepository.GetPostByIdAsync(id);
            return Mapper.Map<PostEntity, Blog>(post);
        }
    }
}
