using Microsoft.EntityFrameworkCore;
using MyBlog.Application.Abstractions.Services;
using MyBlog.Application.Abstractions.UnitOfWork;
using MyBlog.Application.Exceptions;
using MyBlog.Application.ViewModels.Authors;

namespace MyBlog.Persistance.Services.Author
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

        public async Task<List<VmListAuthor>> GetAllAsync()
        {
            return await _unitOfWork.AuthorRepository.GetAll(tracking: false).Select(a => new VmListAuthor
            {
                Image = a.Image,
                Name = a.Name,
            }).ToListAsync();
        }
    }
}
