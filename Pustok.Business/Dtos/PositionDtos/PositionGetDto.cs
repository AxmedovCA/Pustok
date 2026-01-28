using Pustok.Business.Dtos.EmployeeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.Business.Dtos.PositionDtos
{
    public class PositionGetDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } =string.Empty;
        public List<EmployeeGetDto> Employees { get; set; } = [];
    }
}
