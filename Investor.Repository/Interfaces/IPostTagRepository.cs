using Investor.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Repository.Interfaces
{
    public interface IPostTagRepository
    {
        Task<PostTagEntity> AddPostTagAsync(PostTagEntity postTag);
        Task RemovePostTagAsync(PostTagEntity postTag);
    }
}
