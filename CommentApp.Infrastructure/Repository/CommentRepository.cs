using CommentApp.Domain.Entities;
using CommentApp.Domain.Repository;
using CommentApp.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace CommentApp.Infrastructure.Repository;

public class CommentRepository(AppDbContext context, DbSet<Comment> dbSet) : ICommentRepository
{
    private readonly AppDbContext _context = context;
    private readonly DbSet<Comment> _dbSet = dbSet;

    public Comment Add(Comment comment)
    {
        var entityEntry = _dbSet.Add(comment);
        _context.SaveChanges();
        return entityEntry.Entity;
    }

    public IQueryable<Comment> GetAll()
    {
        return _dbSet.AsNoTracking();
    }
}