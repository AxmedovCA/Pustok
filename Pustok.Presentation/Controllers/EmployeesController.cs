using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pustok.Business.Dtos.EmployeeDtos;
using Pustok.Business.Services.Abstractions;
using Pustok.DataAccess.Repositories.Abstractions;

namespace Pustok.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmployeesController(IEmployeeService _service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _service.GetAllAsync();
            return Ok(employees);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] EmployeeCreateDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok("Created");
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm]EmployeeUpdateDto dto)
        {
            await _service.UpdateAsync(dto);
            return Ok("Updated");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return Ok("Deleted");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {
            var employee = await _service.GetByIdAsync(id);
            return Ok(employee);
        }
    }
}
