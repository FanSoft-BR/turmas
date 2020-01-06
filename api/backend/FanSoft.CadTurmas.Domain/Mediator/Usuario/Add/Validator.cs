using FluentValidation;

namespace FanSoft.CadTurmas.Domain.Mediator.Usuario.Add
{
    public class Validator : AbstractValidator<Request>
    {

        public Validator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório")
                .Length(1, 80).WithMessage("Nome não pode ser maior que 80 caracteres");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Email inválido")
                .NotEmpty().WithMessage("Email é obrigatório")
                .Length(1, 80).WithMessage("Email não pode ser maior que 80 caracteres");

            RuleFor(x => x.Senha)
                .NotEmpty().WithMessage("Senha é obrigatório")
                .Length(1, 10).WithMessage("Senha não pode ser maior que 10 caracteres");

        }
    }
}