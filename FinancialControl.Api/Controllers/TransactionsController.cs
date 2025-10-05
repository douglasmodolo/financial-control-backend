using FinancialControl.Application.DTOs.Transactions;
using FinancialControl.Application.UseCases.Transactions.Commands;
using FinancialControl.Application.UseCases.Transactions.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinancialControl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromBody] CreateTransactionDTO dto)
        {
            var command = new CreateTransactionCommand
            {
                Title = dto.Title,
                Amount = dto.Amount,
                Type = dto.Type,
                CategoryId = dto.CategoryId,
                UserId = dto.UserId
            };

            var transactionId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetTransactionById), new { id = transactionId }, new { id = transactionId });
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetAllTransactions(Guid userId)
        {
            var query = new GetAllTransactionsQuery(userId);

            var transactions = await _mediator.Send(query);

            return Ok(transactions);
        }

        [HttpGet("{id}")]
        public IActionResult GetTransactionById(Guid id)
        {
            return Ok();
        }
    }
}
