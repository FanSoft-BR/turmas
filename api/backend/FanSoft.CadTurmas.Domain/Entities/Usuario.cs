using System;

namespace FanSoft.CadTurmas.Domain.Entities
{
    public class Usuario : Entity
    {
        protected Usuario() { }

        public Usuario(int id, string nome, string email, string senha)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
        }

        public Usuario(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }

        public void Update(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

        public void UpdatePassword(string novaSenha)
        {
            Senha = novaSenha;
        }
    }
}
