using Investor.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Service.Interfaces
{
    public interface IPostTagService
    {
        Task<PostTag> AddPostTagAsync(PostTag postTag);
        Task RemovePostTagAsync(PostTag postTag);
    }
}
