using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pustok.Business.Dtos.PositionDtos;
using Pustok.Business.Services.Abstractions;

namespace Pustok.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController(IPositionService _service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
          var positions = await _service.GetAllAsync();
            return Ok(positions);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var position  =await _service.GetByIdAsync(id);
            return Ok(position);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] PositionCreateDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok(dto);

        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PositionUpdateDto dto)
        {
            await _service.UpdateAsync(dto);
            return Ok("Updated!!");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            await _service.DeleteAsync(id);
            return Ok("Deleted");
        }
    }
}
