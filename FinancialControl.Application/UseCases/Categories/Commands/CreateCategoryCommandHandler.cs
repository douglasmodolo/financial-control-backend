using FinancialControl.Application.Interfaces;
using FinancialControl.Domain.Entities;
using FinancialControl.Domain.Repositories;
using MediatR;

namespace FinancialControl.Application.UseCases.Categories.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
    {
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggedUserService _loggedUserService;

        public CreateCategoryCommandHandler(IGenericRepository<Category> categoryRepository, IUnitOfWork unitOfWork, ILoggedUserService loggedUserService)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _loggedUserService = loggedUserService;
        }

        public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var userId = _loggedUserService.GetUserId();
            var category = new Category(request.Name, userId);

            await _categoryRepository.AddAsync(category);

            await _unitOfWork.CommitAsync();

            return category.Id;
        }
    }
}
