using System.Collections.Generic;
using MediatR;

namespace FanSoft.CadTurmas.Domain.Mediator.Usuario.Add
{
    public class Request : IRequest<Response>
    {
        
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public IEnumerable<int> Roles { get; set; }
        
    }
}