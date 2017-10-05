using Investor.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Investor.Model;
using System.Threading.Tasks;
using Investor.Repository.Interfaces;
using AutoMapper;
using Investor.Entity;
using System.Linq;

namespace Investor.Service
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<Tag> AddTagAsync(Tag tag)
        {
            var result = await _tagRepository.AddTagAsync(Mapper.Map<Tag, TagEntity>(tag));
            tag.TagId = result.TagId;
            return tag;
        }

        public async Task<IEnumerable<Tag>> GetAllTagsAsync()
        {
            var tags = await _tagRepository.GetAllTagsAsync();
            return tags.Select(Mapper.Map<TagEntity, Tag>);
        }

        public async Task<Tag> GetTagByIdAsync(int id)
        {
            return Mapper.Map<TagEntity, Tag>(await _tagRepository.GetTagByIdAsync(id));
        }

        public async Task RemoveTagAsync(int id)
        {
            await _tagRepository.RemoveTagAsync(id);
        }

        public async Task UpdateTagAsync(Tag tag)
        {
            await _tagRepository.UpdateTagAsync(Mapper.Map<Tag, TagEntity>(tag));
        }

        public async Task<IEnumerable<Tag>> GetAllTagsByPostId(int id)
        {
            List<TagEntity> tags = await _tagRepository.GetAllTagsByPostIdAsync(id);
            return tags.Select(Mapper.Map<TagEntity, Tag>);
        }
    }
}
