using Pustok.Core.Entites.Common;

namespace Pustok.Core.Entites
{
    public class Position : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<Employee> Employees { get; set; } = [];
    }
}
