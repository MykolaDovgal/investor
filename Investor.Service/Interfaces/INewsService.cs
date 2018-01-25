using Investor.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Investor.ViewModel;

namespace Investor.Service.Interfaces
{
    public interface INewsService
    {
        Task<int> GetTotalNumberOfNewsAsync();
        Task<int> GetTotalNumberOfNewsByCategoryUrlAsync(string categoryUrl);
        Task<int> GetTotalNumberOfNewsByTagAsync(string tag);
        Task<News> GetNewsByIdAsync(int id);
        Task<IEnumerable<T>> GetAllNewsAsync<T>();
        Task<IEnumerable<PostPreview>> GetLatestNewsAsync(int limit);
        Task<IEnumerable<PostPreview>> GetImportantNewsAsync(int limit);
        Task<IEnumerable<PostPreview>> GetPopularNewsByCategoryUrlAsync(string categoryUrl, int limit);
        Task<IEnumerable<PostPreview>> GetLatestNewsByCategoryUrlAsync(string categoryUrl, bool onMainPage = false, int limit = 10);
        Task<IEnumerable<PostPreview>> GetPagedLatestNewsByCategoryUrlAsync(string categoryUrl, int limit, int page);
        Task<IEnumerable<PostPreview>> GetAllNewsByTagNameAsync(string tagName);
        Task<IEnumerable<PostPreview>> GetSideNewsAsync(int limit);
        Task<IEnumerable<PostPreview>> GetSliderNewsAsync(int limit);
        Task AddTagToNewsAsync(int postId, string tagName);
        Task AddTagsToNewsAsync(int postId, IEnumerable<string> tags);
        Task<IEnumerable<Tag>> GetAllTagsByNewsIdAsync(int id);
        Task<News> AddNewsAsync(News map);
        Task<News> UpdateNewsAsync(NewsViewModel post);
        Task UpdateNewsAsync(IEnumerable<News> post);
        Task RemoveNewsAsync(int id);
        Task RemoveNewsAsync(IEnumerable<int> posts);
    }
}
