using System;

namespace FanSoft.CadTurmas.Api.Models
{


    public class TurmaList 
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Instrutor { get; set; }
        public string DataInicio { get; set; }
        public string DataTermino { get; set; }
        
    }

    public static class TurmasCtrlModelExtensions
    {
        public static TurmaList ToVM(this Domain.Entities.Turma entity)
        {
            return new TurmaList {
                Id = entity.Id,
                Nome = entity.Nome,
                Instrutor = entity.Instrutor != null ? entity.Instrutor.Nome : $"InstrutorId: {entity.InstrutorId}",
                DataInicio = entity.DataInicio.ToString("dd/MM/yyyy"),
                DataTermino = entity.DataTermino.ToString("dd/MM/yyyy")
            };
        }
    }
}