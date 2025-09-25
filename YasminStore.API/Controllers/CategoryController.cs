using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using YasminStore.Application.Features.Categorys.Command.CreateCategory;
using YasminStore.Application.Features.Categorys.Command.DeleteCategory;
using YasminStore.Application.Features.Categorys.Command.UpdateCategory;
using YasminStore.Application.Features.Categorys.Queries.GetAllCategory;
using YasminStore.Application.Features.Categorys.Queries.GetCategoryById;
using YasminStore.ApplicationContract.DTOs.Categories;

namespace YasminStore.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
       

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }




        // GET api/categories
        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> GetAll()
        {
            var query = new GetAllCategories();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET api/categories/{Id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetById(int id)
        {
            var query = new GetCategoryById { Id = id };
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST api/categories
        [HttpPost("create")]
        public async Task<ActionResult<int>> Create([FromBody] CreateCategoryCommand command)
        {

            if (command == null)
            {
                return BadRequest("Request body cannot be null");
            }
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // Put api/category/{Id}
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCategoryCommand command)
        {
            if (id != command.Id) return BadRequest();
            await _mediator.Send(command);
            return NoContent();
        }


        // Delete
        // api/category/{Id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteCategoryCommand { Id = id });
            return NoContent();
        }










    }
}
