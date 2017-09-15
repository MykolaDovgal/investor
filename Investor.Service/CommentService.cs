using Investor.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Investor.Model;
using System.Threading.Tasks;
using Investor.Repository.Interfaces;
using AutoMapper;
using Investor.Entity;
using System.Linq;

namespace Investor.Service
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<Comment> AddCommentAsync(Comment comment)
        {
            var result = await _commentRepository.AddCommentAsync(Mapper.Map<Comment, CommentEntity>(comment));
            comment.CommentId = result.CommentId;
            return comment;
        }

        public async Task<IEnumerable<Comment>> GetAllCommentsAsync()
        {
            var comments = await _commentRepository.GetAllCommentsAsync();
            return comments.Select(Mapper.Map<CommentEntity, Comment>);
        }

        public async Task<IEnumerable<Comment>> GetPostCommentsAsync(int postId)
        {
            var comments = await _commentRepository.GetPostCommentsAsync(postId);
            return comments.Select(Mapper.Map<CommentEntity, Comment>);
        }

        public async Task<IEnumerable<Comment>> GetUnpublishedCommentsAsync()
        {
            var comments = await _commentRepository.GetUnpublishedCommentsAsync();
            return comments.Select(Mapper.Map<CommentEntity, Comment>);
        }

        public async Task RemoveCommentAsync(int id)
        {
            await _commentRepository.RemoveCommentAsync(id);
        }

        public async Task UpdateCommentAsync(Comment comment)
        {
            await _commentRepository.UpdateCommentAsync(Mapper.Map < Comment, CommentEntity > (comment));
        }
    }
}
