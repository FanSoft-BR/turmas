using MediatR;

namespace FanSoft.CadTurmas.Domain.Mediator.Sign.In
{
    public class Request : IRequest<Response>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }
        
         // password | refresh_token
        public string GrantType { get; set; } = "password";
        
    }
}