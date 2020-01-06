using System;
using MediatR;

namespace FanSoft.CadTurmas.Domain.Mediator.Sign.In
{
    public class Notification : INotification
    {
        public string Email { get; set; }
        
        public string GrantType { get; set; }

        public DateTime DataHora { get; set; } = DateTime.UtcNow;

        public override string ToString()
            => $"Signin c/ email {Email} do tipo {GrantType} realizado c/ sucesso em {DataHora}";

    }
}