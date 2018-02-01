using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Investor.Entity;
using Investor.Model;
using Investor.Repository.Interfaces;
using Investor.Service.Interfaces;

namespace Investor.Service
{
    public class SearchService : ISearchService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public SearchService(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PostPreview>> SearchPosts(PostSearchQuery query)
        {
            var posts = await _postRepository.GetQueriedNews(query);

            return posts.Select(_mapper.Map<PostEntity, PostPreview>);
        }
    }
}
