using MediatR;
using Microsoft.AspNetCore.Mvc;
using YasminStore.Application.Features.Role.Command.CreateRoleCommand;
using YasminStore.Application.Features.Role.Command.DeleteRoleCommand;
using YasminStore.Application.Features.Role.Command.UpdateRoleCommand;
using YasminStore.Application.Features.Role.Queries.GetAllRoleQuery;
using YasminStore.Application.Features.Role.Queries.GetRoleByIdQuery;
using YasminStore.ApplicationContract.DTOs.Role;

namespace YasminStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Create Role
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateRoleDto dto)
        {
            var result = await _mediator.Send(new CreateRoleCommand(dto));
            return Ok(result);
        }

        // Get All Roles
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllRoleQuery());
            return Ok(result);
        }

        // Get Role by Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetRoleByIdQuery(id));
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // Update Role
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateRoleDto dto)
        {
            var result = await _mediator.Send(new UpdateRoleCommand(id, dto));
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // Delete Role
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteRoleCommand(id));
            if (!result)
                return NotFound();
            return NoContent();
        }
    }
}
