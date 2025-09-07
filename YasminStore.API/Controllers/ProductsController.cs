using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YasminStore.Application.Features.Product.Command.CreateProduct;
using YasminStore.Application.Features.Product.Command.DeleteProduct;
using YasminStore.Application.Features.Product.Command.UpdateProduct;
using YasminStore.Application.Features.Product.Query.GetAllProducts;
using YasminStore.Application.Features.Product.Query.GetProductById;
using YasminStore.ApplicationContract.DTOs.Product;
using YasminStore.Domain.Entities;
using YasminStore.Persistence;

namespace YasminStore.API.Controllers
{
   
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // ✅ Get All Products
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllProductQuery());
            return Ok(result);
        }

        // ✅ Get Product by Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetProductByIdQuery(id));
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // ✅ Create Product (مثال مع Role: Admin فقط)
        //[Authorize(Roles = "Admin")]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateProductDto dto)
        {
            var result = await _mediator.Send(new CreateProductCommand(dto));
            return Ok(result);
        }

        // ✅ Update Product (Admin فقط)
        //[Authorize(Roles = "Admin")]
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProductDto dto)
        {
            if (id != dto.Id)
                return BadRequest("الـ Id في الرابط لا يطابق Id في البيانات");

            var result = await _mediator.Send(new UpdateProductCommand(dto));
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // ✅ Delete Product (Admin فقط)
        //[Authorize(Roles = "Admin")]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteProductCommand(id));
            if (!result)
                return NotFound();
            return NoContent();
        }
    }
}
