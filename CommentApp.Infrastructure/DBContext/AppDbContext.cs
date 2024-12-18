using CommentApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CommentApp.Infrastructure.DBContext;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Comment> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasMany(c => c.Replies)
                .WithOne(c => c.ParentComment)
                .HasForeignKey(c => c.ParentCommentId)
                .OnDelete(DeleteBehavior.Cascade);
            
            entity.Property(c => c.ParentCommentId).IsRequired(false);
            
            entity.Property(c => c.HomePage).HasMaxLength(200);
        });
    }
}