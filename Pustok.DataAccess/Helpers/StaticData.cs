using Pustok.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.DataAccess.Helpers
{
    public static class StaticData
    {
        public static Gender MaleGender = new()
        {
            Id = Guid.Parse("9ead0c3c-e6e3-472e-b687-41672cfc06df"),
            Name = "Male"
        };
        public static Gender FemaleGender = new()
        {
            Id = Guid.Parse("185276c2-7a25-4627-b820-feed745e9f20"),
            Name = "Female"
        };
    }
}
