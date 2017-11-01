using Investor.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Investor.Entity;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using UnidecodeSharpFork;

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
            tagEntity.Url = tagEntity.Name.Unidecode();
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

        public async Task<TagEntity> GetTagByNameAsync(string name)
        {
            return await _newsContext
                .Tags
                .Include(s => s.PostTags)
                .FirstOrDefaultAsync(s => s.Name == name);
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

        public async Task RemoveTagAsync(IEnumerable<int> id)
        {
            IQueryable<TagEntity> tagsToRemove = _newsContext
                .Tags
                .Where(t => id.Contains(t.TagId));

            _newsContext
                .Tags
                .RemoveRange(tagsToRemove);

            await _newsContext.SaveChangesAsync();
        }

        public async Task<TagEntity> UpdateTagAsync(TagEntity tag)
        {
            tag.Url = tag.Name.Unidecode();
            _newsContext
                .Tags
                .Update(tag);

            await _newsContext.SaveChangesAsync();
            return tag;
        }
    }
}
