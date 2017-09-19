﻿using Investor.Service.Interfaces;
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

        public async Task<IEnumerable<PostPreview>> GetAllPostsAsync()
        {
            var posts = await _postRepository.GetAllAsync();
            return posts.Select(Mapper.Map<PostEntity, PostPreview>);
        }

        public async Task<IEnumerable<PostPreview>> GetAllByCategoryNameAsync(string category, bool onMainPage, int? count)
        {
            var posts = (await _postRepository
                .GetAllByCategoryNameAsync(category, onMainPage))
                .Select(Mapper.Map<PostEntity, PostPreview>);

            if (onMainPage && count.HasValue)
            {
                if (posts.Count() > count.Value)
                    return posts.Take(count.Value);

                if(posts.Count() < count.Value)
                {
                    var mainPagePosts = (await _postRepository
                    .GetLatestPostsAsync(count.Value - posts.Count()))
                    .Select(Mapper.Map<PostEntity, PostPreview>);

                    posts.ToList().AddRange(mainPagePosts);
                }
            }
            return posts;
        }

        public async Task<IEnumerable<PostPreview>> GetAllByTagNameAsync(string tagName)
        {
            var posts = await _postRepository.GetAllByTagNameAsync(tagName);
            return posts.Select(Mapper.Map<PostEntity, PostPreview>);
        }

        public async Task<Post> GetByIdAsync(int id)
        {
            return Mapper.Map<PostEntity, Post>(await _postRepository.GetByIdAsync(id));
        }

        public async Task<IEnumerable<PostPreview>> GetAllPagesAsync(int count, int page)
        {
            var posts = await _postRepository.GetAllPagesAsync(count, page);
            return posts.Select(Mapper.Map<PostEntity, PostPreview>);
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

        public async Task<IEnumerable<PostPreview>> GetLatestPostsAsync(int limit)
        {
            var posts = await _postRepository.GetLatestPostsAsync(limit);
            return posts.Select(Mapper.Map<PostEntity, PostPreview>);
        }

        public async Task UpdateAsync(Post post)
        {
            await _postRepository.UpdateAsync(Mapper.Map<Post, PostEntity>(post));
        }

        public async Task RemoveAsync(int id)
        {
            await _postRepository.RemoveAsync(id);
        }

        public async Task<IEnumerable<PostPreview>> GetPopularPostByCategoryNameAsync(string categoryName, int limit)
        {
            var posts = await _postRepository.GetPopularPostByCategoryNameAsync(categoryName, limit);
            return posts.Select(Mapper.Map<PostEntity, PostPreview>);
        }

    }
}