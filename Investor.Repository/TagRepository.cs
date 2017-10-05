using Investor.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Investor.Entity;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Investor.Repository
{
    public class TagRepository : ITagRepository
    {
        private readonly NewsContext _newsContext;

        public TagRepository(NewsContext newsContext)
        {
            _newsContext = newsContext;
        }

        public async Task<TagEntity> AddTagAsync(TagEntity tagEntity)
        {
            await _newsContext
               .Tags
               .AddAsync(tagEntity);
            await _newsContext.SaveChangesAsync();

            return tagEntity;
        }

        public async Task<IEnumerable<TagEntity>> GetAllTagsAsync()
        {
            return await _newsContext
                .Tags
                .Include(s => s.PostTags)
                .ToListAsync();
        }

        public async Task<TagEntity> GetTagByIdAsync(int id)
        {
            return await _newsContext
               .Tags
               .Include(s => s.PostTags)
               .FirstOrDefaultAsync(s => s.TagId == id);
        }
        
        public async Task<List<TagEntity>> GetAllTagsByPostIdAsync(int id)
        {
            return await _newsContext.Tags
                 .Include(p => p.PostTags)
                 .Where(p => p.PostTags.Find(pt => pt.PostId == id) != null)
                 .ToListAsync();
        }

        public async Task RemoveTagAsync(int id)
        {
            TagEntity tagToRemove = await _newsContext
                .Tags
                .FirstOrDefaultAsync(p => p.TagId == id);

            _newsContext
                .Tags
                .Remove(tagToRemove);

            await _newsContext.SaveChangesAsync();
        }

        public async Task UpdateTagAsync(TagEntity tag)
        {
            _newsContext
                .Tags
                .Update(tag);

            await _newsContext.SaveChangesAsync();
        }
    }
}
