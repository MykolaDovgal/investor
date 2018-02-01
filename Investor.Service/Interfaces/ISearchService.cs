using System.Collections.Generic;
using System.Threading.Tasks;
using Investor.Model;

namespace Investor.Service.Interfaces
{
    public interface ISearchService
    {
        Task<IEnumerable<PostPreview>> SearchPosts(PostSearchQuery query);
    }
}
