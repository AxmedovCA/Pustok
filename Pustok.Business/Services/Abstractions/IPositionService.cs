using Pustok.Business.Dtos.PositionDtos;
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
        Task CreateAsync(PositionCreateDto dto);
        Task UpdateAsync(PositionUpdateDto dto);
        Task DeleteAsync(Guid id);
        Task<List<PositionGetDto>> GetAllAsync();

        Task <PositionGetDto> GetByIdAsync(Guid id);
        //Task <List<PositionGetDto>> GetEmployeeByPositionId(Guid positionId);


    }

}
