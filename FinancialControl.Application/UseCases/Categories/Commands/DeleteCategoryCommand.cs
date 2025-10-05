using MediatR;

namespace FinancialControl.Application.UseCases.Categories.Commands
{
    public class DeleteCategoryCommand : IRequest
    {
        public Guid Id { get; }

        public DeleteCategoryCommand(Guid id)
        {
            Id = id;
        }
    }
}
