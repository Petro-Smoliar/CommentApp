using Application.Mapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(CommentProfile));

var app = builder.Build();

app.Run();