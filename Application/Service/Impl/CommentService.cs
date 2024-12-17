using System.Linq.Expressions;
using Application.Dto;
using AutoMapper;
using CommentApp.Domain.Entities;
using CommentApp.Domain.Repository;

namespace Application.Service.Impl;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;

    public CommentService(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }

    public Comment CreateComment(CreateCommentDto createCommentDto)
    {
        return _commentRepository.Add(_mapper.Map<Comment>(createCommentDto));
    }

    public IEnumerable<Comment> GetAllComments(SortParams sortParams, PageParams pageParams)
    {
        var query = _commentRepository.GetAll();
        query = AddSort(query, sortParams);
        query = ApplyPagination(query, pageParams);
        return query.ToList();
    }

    private IQueryable<Comment> AddSort(IQueryable<Comment> query, SortParams sortParams)
    {
        Expression<Func<Comment, object>>? expression;
        
        switch (sortParams.OrderBy.ToLower())
        {
            case "date":
                expression = c => c.Date;
                break;

            case "username":
                expression = c => c.Username;
                break;
            
            case "email":
                expression = c => c.Email;
                break;

            default:
                return query;
        }
        
        return sortParams.Ascending 
            ? query.OrderBy(expression) 
            : query.OrderByDescending(expression);
    }

    private IQueryable<Comment> ApplyPagination(IQueryable<Comment> query, PageParams pageParams)
    {
        return query.Skip((pageParams.Page - 1) * pageParams.PageSize)
            .Take(pageParams.PageSize);
    }
}