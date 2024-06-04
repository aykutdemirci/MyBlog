using MyBlog.Application.Abstractions.Services;
using MyBlog.Application.Abstractions.UnitOfWork;
using MyBlog.Application.Exceptions;
using MyBlog.Application.ViewModels.Authors;

namespace MyBlog.Infrastructure.Services.Author
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateAsync(VmCreateAuthor model)
        {
            var isAdded = await _unitOfWork.AuthorRepository.AddAsync(new Domain.Entities.Author
            {
                Name = model.Name,
            });

            if (isAdded) return await _unitOfWork.SaveAsync();

            throw new AuthorCreateFailedException();
        }
    }
}
