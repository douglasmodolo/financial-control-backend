using FinancialControl.Application.DTOs.Categories;
using FinancialControl.Application.UseCases.Categories.Commands;
using FinancialControl.Application.UseCases.Categories.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinancialControl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDTO dto)
        {
            var command = new CreateCategoryCommand
            {
                Name = dto.Name,
                UserId = dto.UserId
            };

            var categoryId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetCategoryById), new { id = categoryId }, new { id = categoryId });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var query = new GetAllCategoriesQuery();

            var categories = await _mediator.Send(query);

            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(Guid id)
        {
            return Ok();
        }
    }
}
