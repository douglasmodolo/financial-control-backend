using FinancialControl.Application.Exceptions;
using FinancialControl.Application.Interfaces;
using FinancialControl.Domain.Entities;
using FinancialControl.Domain.Repositories;
using MediatR;

namespace FinancialControl.Application.UseCases.Categories.Commands
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggedUserService _loggedUserService;

        public UpdateCategoryCommandHandler(
            IGenericRepository<Category> categoryRepository,
            IUnitOfWork unitOfWork,
            ILoggedUserService loggedUserService)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _loggedUserService = loggedUserService;
        }

        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var userId = _loggedUserService.GetUserId();
            var category = await _categoryRepository.GetByIdAsync(request.Id);

            if (category is null)
            {
                throw new NotFoundException(nameof(Category), request.Id);
            }

            if (category.UserId != userId)
            {
                throw new ForbiddenAccessException();
            }

            category.Update(request.Name);

            _categoryRepository.Update(category);

            await _unitOfWork.CommitAsync();
        }
    }
}
