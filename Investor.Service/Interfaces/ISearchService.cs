using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Investor.Model;
using Investor.ViewModel;

namespace Investor.Service.Interfaces
{
    public interface ISearchService
    {
        Task<IEnumerable<PostPreview>> SearchPosts(PostSearchQueryViewModel query);
    }
}
