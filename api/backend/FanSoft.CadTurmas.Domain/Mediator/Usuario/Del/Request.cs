using MediatR;

namespace FanSoft.CadTurmas.Domain.Mediator.Usuario.Del
{
    public class Request : IRequest<Response>
    {
        public int Id { get; set; }
    }
}