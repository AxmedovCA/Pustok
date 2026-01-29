using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pustok.Business.Dtos.PositionDtos;
using Pustok.Business.Dtos.ResultDtos;
using Pustok.Business.Exceptions;
using Pustok.Business.Services.Abstractions;
using Pustok.Core.Entites;
using Pustok.DataAccess.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.Business.Services.Implementations
{
    internal class PositionService(IPositionRepository _repository, IMapper _mapper) : IPositionService
    {
        public async Task<ResultDto> CreateAsync(PositionCreateDto dto)
        {
            var isExistPosition = await _repository.AnyAsync(x => x.Name == dto.Name);
            if (isExistPosition)
            {
                throw new AlreadyExistException();
            }
            var position = _mapper.Map<Position>(dto);
            await _repository.AddAsync(position);
            await _repository.SaveChangesAsync();
            return new("Created!!");
        }

        public async Task<ResultDto> DeleteAsync(Guid id)
        {
            var position = await _repository.GetAsync(x => x.Id == id);
            if (position is null)
            {
                throw new NotFoundException();
            }
            _repository.Delete(position);
            await _repository.SaveChangesAsync();
            return new("Deleted");

        }

        public async Task<ResultDto<List<PositionGetDto>>> GetAllAsync()
        {
            var positions = await _repository.GetAll().Include(x=>x.Employees).ToListAsync();
            var dtos = _mapper.Map<List<PositionGetDto>>(positions);
            return new(dtos);
        }

        public async Task<ResultDto<PositionGetDto>> GetByIdAsync(Guid id)
        {
            var position = await _repository.GetAsync(x => x.Id == id);
            if (position is null)
            {
                throw new NotFoundException();
            }
            var dto = _mapper.Map<PositionGetDto>(position);
            return new(dto);
        }

        public async Task<ResultDto> UpdateAsync(PositionUpdateDto dto)
        {
            var position = await _repository.GetByIdAsync(dto.Id);
            if (position is null)
            {
                throw new NotFoundException();
            }
            var isExistPosition = await _repository.AnyAsync(x => x.Name.ToLower() == dto.Name.ToLower() && x.Id!=dto.Id);
            if (isExistPosition)
            {
                throw new AlreadyExistException();
            }
            position =  _mapper.Map(dto, position);
            _repository.Update(position);
            await _repository.SaveChangesAsync();

            return new("Updated");
        }
    }
}
