using AutoMapper;
using Pustok.Business.Dtos.PositionDtos;
using Pustok.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.Business.Profiles
{
    internal class PositionProfile:Profile
    {
        public PositionProfile()
        {
            CreateMap<Position, PositionGetDto>().ReverseMap();
            CreateMap<Position, PositionUpdateDto>().ReverseMap();
            CreateMap<Position,PositionCreateDto>().ReverseMap();  
        }
    }
}
