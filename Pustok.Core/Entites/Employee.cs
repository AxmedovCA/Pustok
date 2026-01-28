using Pustok.Core.Entites.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.Core.Entites
{
    public class Employee:BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public decimal Salary { get; set; } 
        public Guid PositionId { get; set; }
        public Position Position { get; set; } = null!;
    }
}
