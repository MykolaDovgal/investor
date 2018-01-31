using Investor.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Investor.Service.Interfaces
{
    public interface ITagService
    {
        Task<IEnumerable<Tag>> GetAllTagsAsync();
        Task<Tag> GetTagByIdAsync(int id);
        Task<Tag> AddTagAsync(Tag tag);
        Task<Tag> UpdateTagAsync(Tag tag);
        Task RemoveTagAsync(int id);
        Task RemoveTagAsync(IEnumerable<int> id);
        Task<Tag> GetTagByNameAsync(string name);
        Task<IEnumerable<AdminTag>> GetAllTagsWithPostCountAsync();
        Task<IEnumerable<Tag>> GetPopularTagsAsync(int number);
    }
}
