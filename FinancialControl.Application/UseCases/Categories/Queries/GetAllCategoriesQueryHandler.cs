using FinancialControl.Application.Interfaces;
using FinancialControl.Application.ViewModels.Categories;
using FinancialControl.Domain.Entities;
using FinancialControl.Domain.Repositories;
using MediatR;

namespace FinancialControl.Application.UseCases.Categories.Queries
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryViewModel>>
    {
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly ILoggedUserService _loggedUserService;

        public GetAllCategoriesQueryHandler(IGenericRepository<Category> categoryRepository, ILoggedUserService loggedUserService)
        {
            _categoryRepository = categoryRepository;
            _loggedUserService = loggedUserService;
        }

        public async Task<IEnumerable<CategoryViewModel>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var userId = _loggedUserService.GetUserId();

            var allCategories = await _categoryRepository.GetAllAsync();

            var userCategories = allCategories
                .Where(c => c.UserId == userId)
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                });

            return userCategories;
        }
    }
}
