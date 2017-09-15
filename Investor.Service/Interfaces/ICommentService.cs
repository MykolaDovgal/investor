using Investor.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Service.Interfaces
{
    public interface ICommentService
    {
        Task<IEnumerable<Comment>> GetAllCommentsAsync();
        Task<IEnumerable<Comment>> GetUnpublishedCommentsAsync();
        Task<IEnumerable<Comment>> GetPostCommentsAsync(int postId);

        Task<Comment> AddCommentAsync(Comment comment);
        Task UpdateCommentAsync(Comment comment);
        Task RemoveCommentAsync(int id);
    }
}
