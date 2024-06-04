using MyBlog.Application.Abstractions.UnitOfWork;
using MyBlog.Application.Repositories;
using MyBlog.Persistance.Contexts;

namespace MyBlog.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyBlogDbContext _dbContext;

        public IPostRepository PostRepository { get; }

        public IBlogRepository BlogRepository { get; }

        public IAuthorRepository AuthorRepository { get; }

        public UnitOfWork(MyBlogDbContext dbContext,
                          IPostRepository postRepository,
                          IBlogRepository blogRepository,
                          IAuthorRepository authorRepository)
        {
            _dbContext = dbContext;
            PostRepository = postRepository;
            BlogRepository = blogRepository;
            AuthorRepository = authorRepository;
        }

        public async Task<bool> SaveAsync()
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                var affectedRows = await _dbContext.SaveChangesAsync();

                transaction.Commit();

                return affectedRows > 0;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}
