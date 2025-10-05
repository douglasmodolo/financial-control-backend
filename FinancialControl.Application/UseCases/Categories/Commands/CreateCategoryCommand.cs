using MediatR;

namespace FinancialControl.Application.UseCases.Categories.Commands
{
    public class CreateCategoryCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }
    }
}
