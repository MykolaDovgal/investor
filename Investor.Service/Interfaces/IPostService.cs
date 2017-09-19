﻿using Investor.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Service.Interfaces
{
    public interface IPostService
    {
        Task<int> GetTotalNumberOfPostsAsync();
        Task<int> GetTotalNumberOfPostsByCategoryAsync(string category);
        Task<int> GetTotalNumberOfPostByTagAsync(string tag);
        Task<Post> GetByIdAsync(int id);
        Task<IEnumerable<PostPreview>> GetAllPostsAsync();
        Task<IEnumerable<PostPreview>> GetLatestPostsAsync(int limit);
        Task<IEnumerable<PostPreview>> GetPopularPostByCategoryNameAsync(string categoryName, int limit);
        Task<IEnumerable<PostPreview>> GetAllByCategoryNameAsync(string categoryName, bool onMainPage, int? count);
        Task<IEnumerable<PostPreview>> GetAllByTagNameAsync(string tagName);
        Task<IEnumerable<PostPreview>> GetAllPagesAsync(int count, int page);
        //Task<IEnumerable<Post>> GetQueryPagesAsync(string query, int count, int page = 1);
        //Task<IEnumerable<Post>> GetPostsBasedOnIdCollectionAsync(List<int> postIds);
        Task<Post> AddAsync(Post map);
        Task UpdateAsync(Post post);
        Task RemoveAsync(int id);
    }
}