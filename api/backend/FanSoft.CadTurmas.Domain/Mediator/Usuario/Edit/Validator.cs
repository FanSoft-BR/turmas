using FluentValidation;

namespace FanSoft.CadTurmas.Domain.Mediator.Usuario.Edit
{
    public class Validator : AbstractValidator<Request>
    {

        public Validator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id é obrigatório");

            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório")
                .Length(1, 80).WithMessage("Nome não pode ser maior que 80 caracteres");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Email inválido")
                .NotEmpty().WithMessage("Email é obrigatório")
                .Length(1, 80).WithMessage("Email não pode ser maior que 80 caracteres");

        }
    }
}
