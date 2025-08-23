using MediatR;
using Microsoft.AspNetCore.Mvc;
using YasminStore.Application.Features.Stores.Command.CreateStore;
using YasminStore.Application.Features.Stores.Command.DeleteStore;
using YasminStore.Application.Features.Stores.Command.UpdateStore;
using YasminStore.Application.Features.Stores.Commands.CreateStore;

using YasminStore.Application.Features.Stores.Queries.GetAllStores;
using YasminStore.Application.Features.Stores.Queries.GetStoreById;

using YasminStore.ApplicationContract.DTOs.Stores;

namespace YasminStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StoreController : ControllerBase
{
    private readonly IMediator _mediator;

    public StoreController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/Store
    [HttpGet]
    public async Task<ActionResult<List<StoreResponseDto>>> GetAll()
    {
        var query = new GetStoresQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    // GET: api/Store/{id}
    [HttpGet("{id:int}")]
    public async Task<ActionResult<StoreResponseDto>> GetById(int id)
    {
        var query = new GetStoreByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    // POST: api/Store
    [HttpPost("create")]
    public async Task<ActionResult<StoreResponseDto>> Create([FromBody] CreateStoreDto dto)
    {
        var command = new CreateStoreCommand(dto);
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    // PUT: api/Store/{id}
    [HttpPut("update/{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateStoreDto dto)
    {
        if (id != dto.Id) return BadRequest("Id mismatch");
        var command = new UpdateStoreCommand(dto);
        await _mediator.Send(command);
        return NoContent();
    }

    // DELETE: api/Store/{id}
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteStoreCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }
}
