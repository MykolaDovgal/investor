using Investor.Service.Interfaces;
using System.Collections.Generic;
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
        private readonly IMapper _mapper;

        public TagService(ITagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public async Task<Tag> AddTagAsync(Tag tag)
        {
            var result = await _tagRepository.AddTagAsync(_mapper.Map<Tag, TagEntity>(tag));
            tag.TagId = result.TagId;
            return tag;
        }

        public async Task<IEnumerable<Tag>> GetAllTagsAsync()
        {
            var tags = await _tagRepository.GetAllTagsAsync();
            return tags.Select(_mapper.Map<TagEntity, Tag>);
        }

        public async Task<IEnumerable<Tag>> GetPopularTagsAsync(int number)
        {
            return (await _tagRepository
                .GetAllTagsAsync())
                .ToList()
                .OrderByDescending(t => t.PostTags.Count)
                .Take(number)
                .Select(_mapper.Map<TagEntity, Tag>);
        }

        public async Task<Tag> GetTagByIdAsync(int id)
        {
            return _mapper.Map<TagEntity, Tag>(await _tagRepository.GetTagByIdAsync(id));
        }

        public async Task RemoveTagAsync(int id)
        {
            await _tagRepository.RemoveTagAsync(id);
        }

        public async Task RemoveTagAsync(IEnumerable<int> id)
        {
            await _tagRepository.RemoveTagAsync(id);
        }

        public async Task<Tag> UpdateTagAsync(Tag tag)
        {
            var result = await _tagRepository.UpdateTagAsync(_mapper.Map<Tag, TagEntity>(tag));
            return _mapper.Map<TagEntity, Tag>(result);
        }

        public async Task<Tag> GetTagByNameAsync(string name)
        {
            return _mapper.Map<TagEntity, Tag>(await _tagRepository.GetTagByNameAsync(name));
        }

        public async Task<IEnumerable<AdminTag>> GetAllTagsWithPostCountAsync()
        {
            IEnumerable<TagEntity> tags = await _tagRepository.GetAllTagsAsync();
            List<AdminTag> list = new List<AdminTag>();
            tags.ToList().ForEach(tag => list.Add(
                new AdminTag
                {
                    Name = tag.Name,
                    PostCount = tag.PostTags.Count,
                    TagId = tag.TagId,
                    Url = tag.Url
                }));
            return list;
        }


    }
}
