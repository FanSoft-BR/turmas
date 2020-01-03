using System;

namespace FanSoft.CadTurmas.Domain.Entities
{
    public class Turma : Entity
    {

        public Turma(Guid id, string nome, DateTime dataInicio, DateTime dataTermino, int? instrutorId = null, string descricao = null)
        {
            Id = id;
            Nome = nome;
            DataInicio = dataInicio;
            DataTermino = dataTermino;
            InstrutorId = instrutorId;
            Descricao = descricao;
        }
        public Turma(string nome, DateTime dataInicio, DateTime dataTermino, int? instrutorId = null, string descricao = null)
        {
            Nome = nome;
            DataInicio = dataInicio;
            DataTermino = dataTermino;
            InstrutorId = instrutorId;
            Descricao = descricao;
        }

        protected Turma() { }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }

        public int? InstrutorId { get; private set; }
        public Instrutor Instrutor { get; private set; }


        public DateTime DataInicio { get; private set; }
        public DateTime DataTermino { get; private set; }


        public string Descricao { get; private set; }

        public void Update(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }
    }
}