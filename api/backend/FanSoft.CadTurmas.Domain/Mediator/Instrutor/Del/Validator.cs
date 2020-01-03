using FluentValidation;

namespace FanSoft.CadTurmas.Domain.Mediator.Instrutor.Del
{
    public class Validator : AbstractValidator<Request>
    {

        public Validator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id é obrigatório");

        }
    }
}