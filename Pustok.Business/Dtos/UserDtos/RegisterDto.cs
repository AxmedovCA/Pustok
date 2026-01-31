using Pustok.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.Business.Dtos.UserDtos
{
    public class RegisterDto
    {
        public string Email { get; set; } = string.Empty;
        public string Fullname { get; set; } =string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;

        

    }
}
