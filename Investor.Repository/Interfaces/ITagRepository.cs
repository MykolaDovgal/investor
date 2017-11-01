using Investor.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Repository.Interfaces
{
    public interface ITagRepository
    {
        Task<IEnumerable<TagEntity>> GetAllTagsAsync();
        Task<TagEntity> GetTagByIdAsync(int id);
        Task<TagEntity> AddTagAsync(TagEntity tagEntity);
        Task<TagEntity> UpdateTagAsync(TagEntity tag);
        Task RemoveTagAsync(int id);
        Task RemoveTagAsync(IEnumerable<int> id);
        Task<TagEntity> GetTagByNameAsync(string name);
    }
}
