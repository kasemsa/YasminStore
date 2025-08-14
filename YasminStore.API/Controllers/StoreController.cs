using MediatR;
using Microsoft.AspNetCore.Mvc;
using YasminStore.Application.Features.Stores.Command.CreateStore;
using YasminStore.Application.Features.Stores.Queries.GetAllStores;
using YasminStore.Application.Features.Stores.Queries.GetStoreById;
using YasminStore.ApplicationContract.DTOs.Stores;

namespace YasminStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StoreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateStoreDto createStoreDto)
        {
            var command = new CreateStoreCommand
            {
                Name = createStoreDto.Name,
                Description = createStoreDto.Description,
                Location = createStoreDto.Location,
                CommercialRegistrationNumber = createStoreDto.CommercialRegistrationNumber,
                OpenAt = createStoreDto.OpenAt,
                ClosedAt = createStoreDto.ClosedAt,
                City = createStoreDto.City,
                SaleType = createStoreDto.SaleType,
                PhoneNumber = createStoreDto.PhoneNumber,
                Logo = createStoreDto.Logo,
                FacebookPage = createStoreDto.FacebookPage,
                InstaAccount = createStoreDto.InstaAccount,
                Whatsapp = createStoreDto.Whatsapp,
                Telegram = createStoreDto.Telegram,
                CategoryIds = createStoreDto.CategoryIds
            };

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        // You might want to add these endpoints as well:
        [HttpGet("{id}")]
        public async Task<ActionResult<StoreDto>> Get(int id)
        {
            var query = new GetStoreById { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<StoreDto>>> GetAll()
        {
            var query = new GetAllStores();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}