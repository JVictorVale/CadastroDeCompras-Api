using FluentValidation;

namespace CadastroDeCompras.Application.DTOs.Validations
{
    public class UserDTOValidator : AbstractValidator<UserDTO>
    {
        public UserDTOValidator()
        {
            RuleFor(u => u.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("Email deve ser informado!");

            RuleFor(u => u.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage("Password deve ser informado!");
        }
    }
}