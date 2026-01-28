using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.Business.Dtos.EmployeeDtos
{
    public class EmployeeGetDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public string PositionName { get; set; } = string.Empty;
    }
}
