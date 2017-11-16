using Investor.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Investor.Entity;
using Investor.Model;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Investor.Repository
{
    public class NewsRepository : INewsRepository
    {
        private readonly NewsContext _newsContext;
        public NewsRepository(NewsContext context)
        {
            _newsContext = context;
        }

        public Task<int> GetTotalNumberOfNewsByTagAsync(string tag)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetTotalNumberOfNewsAsync()
        {
            return await _newsContext
                    .News
                    .CountAsync();
        }

        public async Task<int> GetTotalNumberOfNewsByCategoryUrlAsync(string categoryUrl)
        {
            return await _newsContext
                .News
                .Include(p => p.Category)
                .Where(p => p.Category.Url == categoryUrl)
                .CountAsync();
        }

        public async Task<IEnumerable<NewsEntity>> GetLatestNewsAsync(int limit)
        {
            return await _newsContext.News
                .Include(p => p.Category)
                .OrderByDescending(p => p.PublishedOn)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<IEnumerable<NewsEntity>> GetImportantNewsAsync(int limit)
        {
            return await _newsContext.News
                .Where(p => p.IsImportant ?? false)
                .OrderByDescending(p => p.PublishedOn)
                .Take(limit)
                .Include(p => p.Category)
                .ToListAsync();
        }

        public async Task<IEnumerable<NewsEntity>> GetSideNewsAsync(int limit)
        {
            var news = _newsContext.News;
            var filteredNews = news.Where(n => (n.IsOnSide ?? false));
            return await news
                .OrderByDescending(n => n.PublishedOn)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<IEnumerable<NewsEntity>> GetSliderNewsAsync(int limit)
        {
            return await _newsContext
                .News
                .Where(n => (n.IsOnSlider ?? false) )
                .OrderByDescending(n=>n.PublishedOn)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<IEnumerable<NewsEntity>> GetAllNewsByCategoryUrlOnMainPageAsync(string url, int limit)
        {
            return await _newsContext
                .News
                .Include(c => c.Category)
                .Where(n => n.Category.Url == url && n.IsOnMainPage == true)
                .Take(limit)
                .ToListAsync();
        }
    }
}
