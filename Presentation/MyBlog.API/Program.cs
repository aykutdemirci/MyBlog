using FluentValidation;
using MyBlog.Application.Validators.Posts;
using MyBlog.Infrastructure;
using MyBlog.Infrastructure.Services.Storage.Local;
using MyBlog.Persistance;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistanceSerivces();
builder.Services.AddInfrastructureServices();
builder.Services.AddStorage<LocalStorage>();

builder.Services.AddControllers();
builder.Services.AddValidatorsFromAssemblyContaining<CreatePostValidator>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
