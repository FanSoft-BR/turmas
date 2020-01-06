using System;
using System.Collections.Generic;
using System.Linq;

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


        public Usuario(string nome, string email, string senha, IEnumerable<int> rolesId = null)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            if (rolesId != null && rolesId.Count() > 0) addRoles(rolesId);
        }

        private void addRoles(IEnumerable<int> rolesId)
        {
            var roles = new List<UsuarioRole>();
            rolesId.ToList().ForEach(r => roles.Add(new UsuarioRole(Id, r)));
            UsuarioRoles = roles;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }

        public string RefreshToken { get; private set; }
        public DateTime? RefreshTokenValidate { get; private set; }
        public bool RefreshTokenIsValid => RefreshTokenValidate != null && DateTime.UtcNow < RefreshTokenValidate;

        public IEnumerable<UsuarioRole> UsuarioRoles { get; set; }

        public void Update(string nome, string email, IEnumerable<int> rolesId)
        {
            Nome = nome;
            Email = email;
            AlteradoEm = DateTime.UtcNow;

            if (rolesId != null && rolesId.Count() > 0)
                addRoles(rolesId);
            else
                UsuarioRoles = null;
        }

        public void UpdatePassword(string novaSenha)
        {
            Senha = novaSenha;
            AlteradoEm = DateTime.UtcNow;
        }

        public void RefreshTokenGenerate(int refreshTokenExpires)
        {
            RefreshToken = Guid.NewGuid().ToString("N").ToUpper();
            RefreshTokenValidate = DateTime.UtcNow.AddHours(refreshTokenExpires);
            AlteradoEm = DateTime.UtcNow;
        }
    }
}
