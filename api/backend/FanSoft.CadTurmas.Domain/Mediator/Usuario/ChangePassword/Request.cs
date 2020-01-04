using MediatR;

namespace FanSoft.CadTurmas.Domain.Mediator.Usuario.ChangePassword
{
    public class Request : IRequest<Response>
    {
        public int Id { get; set; }
        public string SenhaAntiga { get; set; }
        public string NovaSenha { get; set; }
        
    }
}