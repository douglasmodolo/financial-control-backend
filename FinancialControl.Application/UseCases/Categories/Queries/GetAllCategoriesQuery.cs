using FinancialControl.Application.ViewModels.Categories;
using MediatR;

namespace FinancialControl.Application.UseCases.Categories.Queries
{
    public class GetAllCategoriesQuery : IRequest<IEnumerable<CategoryViewModel>>
    {
    }
}
