using Investor.Entity;
using Investor.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Repository.Interfaces
{
    public interface INewsRepository
    {
        Task<int> GetTotalNumberOfNewsAsync();
        Task<int> GetTotalNumberOfNewsByCategoryUrlAsync(string url);
        Task<int> GetTotalNumberOfNewsByTagAsync(string tag);
        Task<IEnumerable<NewsEntity>> GetLatestNewsAsync(int limit);
        Task<IEnumerable<NewsEntity>> GetImportantNewsAsync(int limit);
        Task<IEnumerable<NewsEntity>> GetAllNewsByCategoryUrlOnMainPageAsync(string url, int limit);
        Task<IEnumerable<NewsEntity>> GetSideNewsAsync(int limit);
        Task<IEnumerable<NewsEntity>> GetSliderNewsAsync(int limit);
    }


}
