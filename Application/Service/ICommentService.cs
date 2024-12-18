using Application.Dto;
using CommentApp.Domain.Entities;

namespace Application.Service;

public interface ICommentService
{
    Comment CreateComment(CreateCommentDto createCommentDto);
    
    IEnumerable<Comment> GetAllComments(SortParams sortParams, PageParams pageParams);
}