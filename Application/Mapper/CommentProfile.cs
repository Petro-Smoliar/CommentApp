using Application.Dto;
using AutoMapper;
using CommentApp.Domain.Entities;

namespace Application.Mapper;

public class CommentProfile : Profile
{
    public CommentProfile()
    {
        CreateMap<CreateCommentDto, Comment>();
    }
}