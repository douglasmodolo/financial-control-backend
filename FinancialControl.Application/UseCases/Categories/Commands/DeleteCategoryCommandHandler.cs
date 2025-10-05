using FinancialControl.Application.Exceptions;
using FinancialControl.Application.Interfaces;
using FinancialControl.Domain.Entities;
using FinancialControl.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FinancialControl.Application.UseCases.Categories.Commands
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly IApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggedUserService _loggedUserService;

        public DeleteCategoryCommandHandler(
            IGenericRepository<Category> categoryRepository,
            IApplicationDbContext context,
            IUnitOfWork unitOfWork,
            ILoggedUserService loggedUserService)
        {
            _categoryRepository = categoryRepository;
            _context = context;
            _unitOfWork = unitOfWork;
            _loggedUserService = loggedUserService;
        }

        public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
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

            var isCategoryInUse = await _context.Transactions
                                          .AnyAsync(t => t.CategoryId == request.Id, cancellationToken);

            if (isCategoryInUse)
            {
                throw new Exception("Não é possível excluir uma categoria que já possui transações associadas.");
            }

            _categoryRepository.Delete(category);
            await _unitOfWork.CommitAsync();
        }
    }
}
