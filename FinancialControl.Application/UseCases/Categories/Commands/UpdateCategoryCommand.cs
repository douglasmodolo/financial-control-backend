using MediatR;

namespace FinancialControl.Application.UseCases.Categories.Commands
{
    public class UpdateCategoryCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
