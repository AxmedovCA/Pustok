using Pustok.Business.Dtos.ResultDtos;
using Pustok.Business.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.Business.Services.Abstractions
{
    public interface IAuthService           
    {
        Task<ResultDto> RegisterAsync(RegisterDto dto);
    }
}
