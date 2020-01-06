using FluentValidation;

namespace FanSoft.CadTurmas.Domain.Mediator.Role.Add
{
    public class Validator : AbstractValidator<Request>
    {

        public Validator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório")
                .Length(1, 80).WithMessage("Nome não pode ser maior que 80 caracteres");

            RuleFor(x => x.Descricao)
                .Length(1, 80).WithMessage("Descrição não pode ser maior que 80 caracteres");
            

        }
    }
}