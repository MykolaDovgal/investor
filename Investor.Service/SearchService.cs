using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Investor.Entity;
using Investor.Model;
using Investor.Repository;
using Investor.Repository.Interfaces;
using Investor.Service.Interfaces;
using Investor.ViewModel;

namespace Investor.Service
{
    public class SearchService : ISearchService
    {
        private readonly IPostRepository _postRepository;
        public SearchService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<IEnumerable<PostPreview>> SearchPosts(PostSearchQueryViewModel query)
        {
            var posts = await _postRepository.GetQueriedNews(query);

            return posts.Select(Mapper.Map<PostEntity, PostPreview>);
        }
    }
}
