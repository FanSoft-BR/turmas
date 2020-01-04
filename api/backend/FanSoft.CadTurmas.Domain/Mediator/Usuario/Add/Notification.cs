using System;
using MediatR;

namespace FanSoft.CadTurmas.Domain.Mediator.Usuario.Add
{
    public class Notification : INotification
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataHora { get; set; } = DateTime.Now;

        public override string ToString()
            => $"Usuario {Nome} inserido com sucesso em {DataHora}";
    }
}