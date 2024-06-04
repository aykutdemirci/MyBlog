using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyBlog.Application.Abstractions.Services;
using MyBlog.Application.Abstractions.UnitOfWork;
using MyBlog.Application.Exceptions;
using MyBlog.Application.ViewModels.Authors;

namespace MyBlog.Persistance.Services.Author
{
    public class AuthorService : IAuthorService
    {
        private readonly ILogger<AuthorService> _looger;
        private readonly IUnitOfWork _unitOfWork;

        public AuthorService(ILogger<AuthorService> logger, IUnitOfWork unitOfWork)
        {
            _looger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateAsync(VmCreateAuthor model)
        {
            var isAdded = await _unitOfWork.AuthorRepository.AddAsync(new Domain.Entities.Author
            {
                Name = model.Name,
            });

            if (isAdded)
            {
                _looger.LogInformation("Author Created Succesfully");
                return await _unitOfWork.SaveAsync();
            }

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
