using FluentValidation;
using Pustok.Business.Dtos.EmployeeDtos;
using Pustok.Business.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.Business.Validators.EmployeeValidators
{
    public class EmployeeCreateDtoValidator:AbstractValidator<EmployeeCreateDto>
    {
        public EmployeeCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().MaximumLength(256).MinimumLength(3).Must(x=>x.Contains("a")).WithMessage("name de a herfi olmalidir");
            RuleFor(x => x.Salary).NotNull().GreaterThan(0).LessThan(999999999);
            RuleFor(x => x.Image).Must(x => x.CheckSize(2)).WithMessage("Max 2 mb olmalidir")
                .Must(x=>x.CheckType("image")).WithMessage("Ancaq sekil formatinda data olmalidir");
        }
    }
}
