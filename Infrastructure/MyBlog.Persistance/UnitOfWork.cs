using MyBlog.Application.Abstractions.UnitOfWork;
using MyBlog.Application.Repositories;
using MyBlog.Persistance.Contexts;

namespace MyBlog.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyBlogDbContext _dbContext;

        private readonly IPostRepository _postRepository;
        private readonly IBlogRepository _blogRepository;
        private readonly IAuthorRepository _authorRepository;

        public UnitOfWork(MyBlogDbContext dbContext,
                          IPostRepository postRepository,
                          IBlogRepository blogRepository,
                          IAuthorRepository authorRepository)
        {
            _dbContext = dbContext;
            _postRepository = postRepository;
            _blogRepository = blogRepository;
            _authorRepository = authorRepository;
        }

        public async Task Save()
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                await _dbContext.SaveChangesAsync();

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}
