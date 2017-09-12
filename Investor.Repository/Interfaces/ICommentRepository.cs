using Investor.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Repository.Interfaces
{
    public interface ICommentRepository
    {
        Task<IEnumerable<CommentEntity>> GetAllCommentsAsync();
        Task<IEnumerable<CommentEntity>> GetUnpublishedCommentsAsync();
        Task<IEnumerable<CommentEntity>> GetPostCommentsAsync(int postId);

        Task<CommentEntity> AddCommentAsync(CommentEntity comment);
        Task <CommentEntity> UpdateCommentAsync(CommentEntity comment);
        Task RemoveCommentAsync(int id);
    }
}
