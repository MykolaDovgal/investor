using Investor.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Investor.Entity;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Investor.Repository
{
    class CommentRepository : ICommentRepository
    {
        private readonly NewsContext _newsContext;

        public CommentRepository(NewsContext newsContext)
        {
            _newsContext = newsContext;
        }

        public async Task<IEnumerable<CommentEntity>> GetAllCommentsAsync()
        {
            return await _newsContext
                .Comments
                .ToListAsync();
        }

        public async Task<IEnumerable<CommentEntity>> GetPostCommentsAsync(int postId)
        {
            return await _newsContext
                .Comments
                .Where(c => c.PostId == postId).ToListAsync();
        }

        public async Task<IEnumerable<CommentEntity>> GetUnpublishedCommentsAsync()
        {
            return await _newsContext
                .Comments
                .Where(c => c.Pubished == false).ToListAsync();
        }

        public async Task<CommentEntity> AddCommentAsync(CommentEntity comment)
        {
            await _newsContext
                .Comments
                .AddAsync(comment);
            await _newsContext.SaveChangesAsync();

            return comment;
        }

        public async Task RemoveCommentAsync(int id)
        {
            CommentEntity commentToRemove = await _newsContext
                .Comments
                .FirstOrDefaultAsync(c=> c.CommentId == id);

            _newsContext
                .Comments
                .Remove(commentToRemove);

            await _newsContext.SaveChangesAsync();
        }

        //Comment is published by admin
        public async Task<CommentEntity> UpdateCommentAsync(CommentEntity comment)
        {
            _newsContext.Entry(comment).State = EntityState.Modified;
            await _newsContext.SaveChangesAsync();
            return comment;
        }

        
    }
}
