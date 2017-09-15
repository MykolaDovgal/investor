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

        public async Task<Post> AddAsync(Post map)
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

            var response = await _postRepository.AddAsync(Mapper.Map<Post, PostEntity>(map));
            map.PostId = response.PostId;

            return map;
        }

        public async Task<IEnumerable<Post>> GetAllPostsAsync()
        {
            var posts = await _postRepository.GetAllAsync();
            return posts.Select(Mapper.Map<PostEntity, Post>);
        }

        public async Task<IEnumerable<Post>> GetAllByCategoryNameAsync(string category, bool onMainPage)
        {
            var posts = await _postRepository.GetAllByCategoryNameAsync(category, onMainPage);
            return posts.Select(Mapper.Map<PostEntity, Post>);
        }

        public async Task<IEnumerable<Post>> GetAllByTagNameAsync(string tagName)
        {
            var posts = await _postRepository.GetAllByTagNameAsync(tagName);
            return posts.Select(Mapper.Map<PostEntity, Post>);
        }

        public async Task<Post> GetByIdAsync(int id)
        {
            return Mapper.Map<PostEntity, Post>(await _postRepository.GetByIdAsync(id));
        }

        public async Task<IEnumerable<Post>> GetAllPagesAsync(int count, int page)
        {
            var posts = await _postRepository.GetAllPagesAsync(count, page);
            return posts.Select(Mapper.Map<PostEntity, Post>);
        }

        public async Task<int> GetTotalNumberOfPostByTagAsync(string tag)
        {
            return await _postRepository.GetTotalNumberOfPostByTagAsync(tag);
        }

        public async Task<int> GetTotalNumberOfPostsByCategoryAsync(string category)
        {
            return await _postRepository.GetTotalNumberOfPostsByCategoryAsync(category);
        }

        public async Task<int> GetTotalNumberOfPostsAsync()
        {
            return await _postRepository.GetTotalNumberOfPostsAsync();
        }

        public async Task<IEnumerable<Post>> GetLatestPostsAsync(int limit)
        {
            var posts = await _postRepository.GetLatestPostsAsync(limit);
            return posts.Select(Mapper.Map<PostEntity, Post>);
        }

        public async Task UpdateAsync(Post post)
        {
            await _postRepository.UpdateAsync(Mapper.Map<Post, PostEntity>(post));
        }

        public async Task RemoveAsync(int id)
        {
            await _postRepository.RemoveAsync(id);
        }

        //public async Task<Post> AddAsync(Post map)
        //{


        //    post.Category = null;
        //    post.PostedOn = DateTime.Now;
        //    post.ModifiedOn = post.PostedOn;
        //    post.CreatedOn = post.PostedOn;
        //    post.Published = false;

        //    var response = _postRepository.Add(Mapper.Map<Post, PostEntity>(post));
        //    post.PostId = response.PostId;
        //    return post;
        //}

    }
}
