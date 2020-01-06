using FluentValidation;

namespace FanSoft.CadTurmas.Domain.Mediator.Sign.In
{
    public class Validator : AbstractValidator<Request>
    {

        public Validator()
        {

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Email inválido")
                .NotEmpty().When(m => m.GrantType=="password").WithMessage("Email é obrigatório");

            RuleFor(m => m.Password)
                .NotEmpty().When(m => m.GrantType=="password")
                    .WithMessage("Password é obrigatório");

            // https://fluentvalidation.net/built-in-validators#predicate-validator
            RuleFor(m => m.GrantType).Must(x => x == "password" || x == "refresh_token")
                .WithMessage("Valor inválido, informe password ou refresh_token");

            RuleFor(x => x.RefreshToken)
                .NotEmpty().When(m => m.GrantType=="refresh_token").WithMessage("RefreshToken é obrigatório");

        }
    }
}
