using Pustok.Business.Dtos.PositionDtos;
using Pustok.Business.Dtos.ResultDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.Business.Services.Abstractions
{
    public interface IPositionService
    {
        Task<ResultDto> CreateAsync(PositionCreateDto dto);
        Task<ResultDto> UpdateAsync(PositionUpdateDto dto);
        Task<ResultDto> DeleteAsync(Guid id);
        Task<ResultDto<List<PositionGetDto>>> GetAllAsync();

        Task <ResultDto<PositionGetDto>> GetByIdAsync(Guid id);
        //Task <List<PositionGetDto>> GetEmployeeByPositionId(Guid positionId);


    }

}
