using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.Core.Entites
{
    public class AppUser:IdentityUser
    {
        public string Fullname { get; set; } = string.Empty;
        public DateTime BirthDay { get; set; } 
    }
}
