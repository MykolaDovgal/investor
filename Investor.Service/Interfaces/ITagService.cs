using Investor.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Service.Interfaces
{
    public interface ITagService
    {
        Task<IEnumerable<Tag>> GetAllTagsAsync();
        Task<Tag> GetTagByIdAsync(int id);
        Task<Tag> AddTagAsync(Tag tag);
        Task UpdateTagAsync(Tag tag);
        Task RemoveTagAsync(int id);
        Task<IEnumerable<Tag>> GetAllTagsByPostId(int id);
    }
}
