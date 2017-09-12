using Investor.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Investor.Entity;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Investor.Repository
{
    class PostTagRepository : IPostTagRepository
    {
        private readonly NewsContext _newsContext;

        public PostTagRepository(NewsContext newsContext)
        {
            _newsContext = newsContext;
        }

        public async Task<PostTagEntity> AddPostTagAsync(PostTagEntity postTag)
        {
            await _newsContext
                .PostTags
                .AddAsync(postTag);
            await _newsContext.SaveChangesAsync();
           
            return postTag;
        }

        public async Task RemovePostTagAsync(PostTagEntity postTag)
        {
            PostTagEntity postTagToRemove = await _newsContext
                .PostTags
                .FirstOrDefaultAsync(p => (p.TagId == postTag.TagId && p.PostId == postTag.PostId));

            _newsContext
                .PostTags
                .Remove(postTagToRemove);

            await _newsContext.SaveChangesAsync();
        }
    }
}
