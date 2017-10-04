using Investor.Service.Interfaces;
using System;
using Investor.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Investor.Entity;
using AutoMapper;
using Investor.Repository.Interfaces;
using System.Linq;

namespace Investor.Service
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Post> AddPostAsync(Post map)
        {

            if (map.Title == null)
            {
                map.Title = Guid.NewGuid().ToString();
                //map.Url = map.Title;
            }

            map.Category = null;
            map.ModifiedOn = DateTime.Now;
            map.CreatedOn = DateTime.Now;
            map.Published = false;

            var response = await _postRepository.AddPostAsync(Mapper.Map<Post, PostEntity>(map));
            map.PostId = response.PostId;

            return map;
        }

        public async Task<IEnumerable<T>> GetAllPostsAsync<T>()
        {
            var posts = await _postRepository.GetAllPostsAsync();
            return posts.Select(Mapper.Map<PostEntity, T>);
        }

        public async Task<IEnumerable<PostPreview>> GetLatestPostsByCategoryUrlAsync(string categoryUrl, bool onMainPage = false, int limit = 10)
        {
            return (await _postRepository
                .GetLatestPostsByCategoryUrlAsync(categoryUrl,onMainPage,limit))
                .Select(Mapper.Map<PostEntity, PostPreview>);
        }

        public async Task<IEnumerable<PostPreview>> GetPagedLatestPostsByCategoryUrlAsync(string categoryUrl, int limit = 10, int page = 1)
        {
            return (await _postRepository
                .GetPagedLatestPostsByCategoryUrlAsync(categoryUrl,limit,page))
                .Select(Mapper.Map<PostEntity, PostPreview>);
        }

        public async Task<IEnumerable<PostPreview>> GetAllPostsByTagNameAsync(string tagName)
        {
            var posts = await _postRepository.GetAllPostsByTagNameAsync(tagName);
            return posts.Select(Mapper.Map<PostEntity, PostPreview>);
        }

        public async Task<Post> GetPostByIdAsync(int id)
        {
            return Mapper.Map<PostEntity, Post>(await _postRepository.GetPostByIdAsync(id));
        }

        public async Task<int> GetTotalNumberOfPostByTagAsync(string tag)
        {
            return await _postRepository.GetTotalNumberOfPostByTagAsync(tag);
        }

        public async Task<int> GetTotalNumberOfPostsByCategoryUrlAsync(string categoryUrl)
        {
            return await _postRepository.GetTotalNumberOfPostsByCategoryUrlAsync(categoryUrl);
        }

        public async Task<int> GetTotalNumberOfPostsAsync()
        {
            return await _postRepository.GetTotalNumberOfPostsAsync();
        }

        public async Task<IEnumerable<PostPreview>> GetLatestPostsAsync(int limit)
        {
            var posts = await _postRepository.GetLatestPostsAsync(limit);
            
            return posts.Select(Mapper.Map<PostEntity, PostPreview>);
        }

        public async Task UpdatePostAsync(Post post)
        {
            await _postRepository.UpdatePostAsync(Mapper.Map<Post, PostEntity>(post));
        }

        public async Task RemovePostAsync(int id)
        {
            await _postRepository.RemovePostAsync(id);
        }

        public async Task<IEnumerable<PostPreview>> GetPopularPostByCategoryUrlAsync(string categoryUrl, int limit)
        {
            var posts = await _postRepository.GetPopularPostByCategoryUrlAsync(categoryUrl, limit);
            return posts.Select(Mapper.Map<PostEntity, PostPreview>);
        }

        public async Task<IEnumerable<PostPreview>> GetImportantPostsAsync(int limit)
        {
            var posts = await _postRepository.GetImportantPostAsync(limit);
            return posts.Select(Mapper.Map<PostEntity, PostPreview>);
        }

    }
}
