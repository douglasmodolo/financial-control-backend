using FinancialControl.Application.ViewModels.Categories;
using FinancialControl.Domain.Entities;
using FinancialControl.Domain.Repositories;
using MediatR;

namespace FinancialControl.Application.UseCases.Categories.Queries
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryViewModel>>
    {
        private readonly IGenericRepository<Category> _categoryRepository;

        public GetAllCategoriesQueryHandler(IGenericRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryViewModel>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllAsync();

            var viewModels = categories.Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name
            });

            return viewModels;
        }
    }
}
