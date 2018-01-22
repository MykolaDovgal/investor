using Investor.Entity;
using Investor.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Investor.Model.Views;

namespace Investor.Repository.Interfaces
{
    public interface IPostRepository
    {
        IEnumerable<T> GetAllPosts<T>() where T : PostEntity;
        Task<T> GetPostByIdAsync<T>(int id) where T : PostEntity;
        Task<IEnumerable<T>> GetPopularPostsByCategoryUrlAsync<T>(string categoryUrl, int limit) where T : PostEntity;
        Task<IEnumerable<T>> GetLatestPostsByCategoryUrlAsync<T>(string categoryUrl, int limit) where T : PostEntity;
        Task<IEnumerable<T>> GetPagedLatestPostsByCategoryUrlAsync<T>(string categoryUrl, int limit, int page) where T : PostEntity;
        Task<IEnumerable<T>> GetAllPostsByTagNameAsync<T>(string tagName) where T : PostEntity;
        Task<IEnumerable<T>> GetPostsBasedOnIdCollectionAsync<T>(IEnumerable<int> postIds) where T : PostEntity;
        Task<IEnumerable<PostEntity>> GetQueriedNews(PostSearchQueryViewModel query);
        Task<T> AddPostAsync<T>(T map) where T : PostEntity;
        Task<T> UpdatePostAsync<T>(T post) where T : PostEntity;
        Task UpdatePostAsync<T>(IEnumerable<T> post) where T : PostEntity;
        Task RemovePostAsync(int id);
        Task RemovePostAsync(IEnumerable<int> id);
        Task<TagEntity> AddTagToPostAsync(int postId, TagEntity tag);
        Task<List<TagEntity>> GetAllTagsByPostIdAsync(int id);
        Task RemoveTagFromPostAsync(int postId, TagEntity tag);
    }
}
