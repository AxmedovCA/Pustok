using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.DataAccess.Abstractions
{
    public interface IContextInitalizer
    {
        Task InitDatabaseAsync();
    }
}
