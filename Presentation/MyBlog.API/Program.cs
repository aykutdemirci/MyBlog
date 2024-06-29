using FluentValidation.AspNetCore;
using MyBlog.API.Extensions;
using MyBlog.Application.Validators.Posts;
using MyBlog.Infrastructure;
using MyBlog.Infrastructure.Enums;
using MyBlog.Infrastructure.Services.Storage.Local;
using MyBlog.Persistance;
using Serilog;
using Serilog.Sinks.MSSqlServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCache(CachingType.Distributed);
builder.Services.AddPersistanceSerivces();
builder.Services.AddInfrastructureServices();
builder.Services.AddStorage<LocalStorage>();
builder.Services.AddControllers().AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreatePostValidator>());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var logger = new LoggerConfiguration()
    .WriteTo.File("logs/log.txt")
    .WriteTo.Console()
    .WriteTo.MSSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection"), sinkOptions: new MSSqlServerSinkOptions
    {
        AutoCreateSqlTable = true,
        TableName = "logs"
    }).CreateLogger();

builder.Host.UseSerilog(logger);

var app = builder.Build();

app.AddExceptionHandler(app.Services.GetRequiredService<ILogger<Program>>());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
