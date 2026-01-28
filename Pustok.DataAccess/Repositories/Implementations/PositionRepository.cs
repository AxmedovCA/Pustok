using Pustok.Core.Entites;
using Pustok.DataAccess.Context;
using Pustok.DataAccess.Repositories.Abstractions;
using Pustok.DataAccess.Repositories.Implementations.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.DataAccess.Repositories.Implementations
{
    internal class PositionRepository(AppDbContext _context): Repository<Position>(_context),IPositionRepository
    {
    }
}
