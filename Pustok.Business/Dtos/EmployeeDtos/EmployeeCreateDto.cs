using Microsoft.AspNetCore.Http;

namespace Pustok.Business.Dtos.EmployeeDtos
{
    public class EmployeeCreateDto
    {
      
        public string Name { get; set; } = string.Empty;
        public IFormFile Image { get; set; } = null!;
        public decimal Salary { get; set; }
        public Guid PositionId { get; set; } 
    }
}
