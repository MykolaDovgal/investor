using Investor.Entity;
using Investor.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Repository.Interfaces
{
    public interface IPostRepository
    {
        Task<int> GetTotalNumberOfPostsAsync();
        Task<int> GetTotalNumberOfPostsByCategoryUrlAsync(string url);
        Task<int> GetTotalNumberOfPostByTagAsync(string tag);
        Task<PostEntity> GetPostByIdAsync(int id);
        Task<IEnumerable<PostEntity>> GetAllPostsAsync();
        Task<IEnumerable<PostEntity>> GetLatestPostsAsync(int limit);
        Task<IEnumerable<PostEntity>> GetImportantPostAsync(int limit);       
        Task<IEnumerable<PostEntity>> GetPopularPostByCategoryUrlAsync(string categoryUrl, int limit);
        IEnumerable<PostEntity> GetAllPosts();
        Task<IEnumerable<PostEntity>> GetLatestPostsByCategoryUrlAsync(string categoryUrl,bool onMainPage,int limit);
        Task<IEnumerable<PostEntity>> GetPagedLatestPostsByCategoryUrlAsync(string categoryUrl, int limit, int page);
        Task<IEnumerable<PostEntity>> GetAllPostsByTagNameAsync(string tagName);
        Task<IEnumerable<PostEntity>> GetPostsBasedOnIdCollectionAsync(List<int> postIds);
        Task<PostEntity> AddPostAsync(PostEntity map);
        Task<PostEntity> UpdatePostAsync(PostEntity post);
        Task RemovePostAsync(int id);
        Task<TagEntity> AddTagToPostAsync(int postId, TagEntity tag);
        Task<List<TagEntity>> GetAllTagsByPostIdAsync(int id);
        Task<IEnumerable<PostEntity>> GetQueriedPost(PostSearchQuery query);
    }


}
