using Investor.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Investor.Model;
using System.Threading.Tasks;
using Investor.Repository.Interfaces;
using AutoMapper;
using Investor.Entity;

namespace Investor.Service
{
    public class PostTagService : IPostTagService
    {
        private readonly IPostTagRepository _postTagRepository;

        public PostTagService(IPostTagRepository postRepository)
        {
            _postTagRepository = postRepository;
        }

        public async Task<PostTag> AddPostTagAsync(PostTag postTag)
        {
            var result = await _postTagRepository.AddPostTagAsync(Mapper.Map<PostTag, PostTagEntity>(postTag));
            postTag.PostTagId = result.PostTagId;
            return postTag;
        }

        public async Task RemovePostTagAsync(PostTag postTag)
        {
            await _postTagRepository.RemovePostTagAsync(Mapper.Map<PostTag, PostTagEntity>(postTag));
        }
    }
}
