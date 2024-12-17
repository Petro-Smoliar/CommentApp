using CommentApp.Domain.Entities;

namespace CommentApp.Domain.Repository;

public interface ICommentRepository
{
    Comment Add(Comment comment);

    IQueryable<Comment> GetAll();
}