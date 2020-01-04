using FluentValidation;

namespace FanSoft.CadTurmas.Domain.Mediator.Usuario.ChangePassword
{
    public class Validator : AbstractValidator<Request>
    {

        public Validator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id é obrigatório");

            RuleFor(x => x.SenhaAntiga)
                .NotEmpty().WithMessage("Senha antiga é obrigatório")
                .Length(1, 10).WithMessage("Senha antiga não pode ser maior que 10 caracteres");

            RuleFor(x => x.NovaSenha)
                .NotEmpty().WithMessage("Nova senha é obrigatório")
                .Length(1, 10).WithMessage("Nova senha não pode ser maior que 10 caracteres");

        }
    }
}