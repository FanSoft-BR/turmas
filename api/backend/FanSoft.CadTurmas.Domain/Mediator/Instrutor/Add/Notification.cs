using System;
using MediatR;

namespace FanSoft.CadTurmas.Domain.Mediator.Instrutor.Add
{
    public class Notification : INotification
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataHora { get; set; } = DateTime.Now;

        public override string ToString()
            => $"Instrutor {Nome} inserido com sucesso em {DataHora}";
    }
}