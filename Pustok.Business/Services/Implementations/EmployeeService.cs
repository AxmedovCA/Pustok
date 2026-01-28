using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Pustok.Business.Dtos.EmployeeDtos;
using Pustok.Business.Exceptions;
using Pustok.Business.Services.Abstractions;
using Pustok.Core.Entites;
using Pustok.DataAccess.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.Business.Services.Implementations
{
    internal class EmployeeService(IEmployeeRepository _repository,IMapper _mapper,ICloudinaryService _cloudinaryService) : IEmployeeService
    {
        public async Task CreateAsync(EmployeeCreateDto dto)
        {
            var employee = _mapper.Map<Employee>(dto);

            var imagePath = await _cloudinaryService.FileCreateAsync(dto.Image);
            employee.ImagePath =  imagePath;

            await _repository.AddAsync(employee);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var employee = await _repository.GetByIdAsync(id);
            if(employee is null)
            {
                throw new NotFoundException("Employee not found"); 
            }
            _repository.Delete(employee);
            await _repository.SaveChangesAsync();

            await _cloudinaryService.FileDeleteAsync(employee.ImagePath);
        }

        public async Task<List<EmployeeGetDto>> GetAllAsync()
        {
            var employees =await _repository.GetAll().Include(x=>x.Position).ToListAsync();
            var dtos = _mapper.Map<List<EmployeeGetDto>>(employees);
            return dtos; 
        }
          
        public async Task<EmployeeGetDto> GetByIdAsync(Guid id)
        {
            var employee = await _repository.GetByIdAsync(id);
            if (employee is null)
            {
                throw new NotFoundException("Employee not found");
            }
            var dto = _mapper.Map<EmployeeGetDto>(employee);
            return dto;
        }

        public async Task UpdateAsync(EmployeeUpdateDto dto)
        {
            var employee = await _repository.GetByIdAsync(dto.Id);
            if (employee is null)
            {
                throw new NotFoundException("Employee not found");
            }

            if(dto.Image is not null)
            {
                await _cloudinaryService.FileDeleteAsync(employee.ImagePath);
                var newImagePath = await _cloudinaryService.FileCreateAsync(dto.Image);
                employee.ImagePath = newImagePath;
            }
            employee = _mapper.Map(dto, employee);  
            _repository.Update(employee);
            await _repository.SaveChangesAsync();

        }
    }
}
