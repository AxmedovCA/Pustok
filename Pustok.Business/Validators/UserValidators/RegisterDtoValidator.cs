using FluentValidation;
using Pustok.Business.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.Business.Validators.UserValidators
{
    public class RegisterDtoValidator:AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotNull().NotEmpty()
                .EmailAddress().WithMessage("Email duzgun formatda olmalidir")
                .MaximumLength(256);

            RuleFor(x => x.Fullname)
                .NotNull().NotEmpty()
                .MinimumLength(3).WithMessage("Ad ve soyad en az 3 simvoldan ibaret olmalidir")
                .MaximumLength(256);

            RuleFor(x => x.UserName)
                .NotNull().NotEmpty()
                .MinimumLength(3).WithMessage("Istifadeci adi en az 3 simvoldan ibaret olmalidir")
                .MaximumLength(256);

            RuleFor(x => x.Password)
                .NotNull().NotEmpty()
                .MinimumLength(6).WithMessage("Parol en az 6 simvol olmalidir")
                .MaximumLength(100);
           

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password).WithMessage("Parollar uyqunlasmadi");
        }
    }
}
