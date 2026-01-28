using Microsoft.AspNetCore.Http;

namespace Pustok.Business.Dtos.EmployeeDtos
{
    public class EmployeeUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public IFormFile? Image { get; set; }
        public decimal Salary { get; set; }
        public Guid PositionId { get; set; }
    }
}
