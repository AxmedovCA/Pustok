using FluentValidation;
using Pustok.Business.Dtos.EmployeeDtos;
using Pustok.Business.Helpers;

namespace Pustok.Business.Validators.EmployeeValidators
{
    public class EmployeeUpdateDtoValidator:AbstractValidator<EmployeeUpdateDto>
    {
        public EmployeeUpdateDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().MaximumLength(256).MinimumLength(3).Must(x => x.Contains("a")).WithMessage("name de a herfi olmalidir");
            RuleFor(x => x.Salary).NotNull().GreaterThan(0).LessThan(999999999);
            RuleFor(x => x.Image).Must(x => x?.CheckSize(2)??true).WithMessage("Max 2 mb olmalidir")
                .Must(x => x?.CheckType("image")??true).WithMessage("Ancaq sekil formatinda data olmalidir");
        }
    }
}
