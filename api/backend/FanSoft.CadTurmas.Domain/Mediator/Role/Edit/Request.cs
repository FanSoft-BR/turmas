using MediatR;

namespace FanSoft.CadTurmas.Domain.Mediator.Role.Edit
{
    public class Request : IRequest<Response>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

    }
}