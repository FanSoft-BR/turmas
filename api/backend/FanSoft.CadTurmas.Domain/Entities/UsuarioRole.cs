using System.Collections.Generic;

namespace FanSoft.CadTurmas.Domain.Entities
{
    public class UsuarioRole : Entity
    {
        protected UsuarioRole() {}
        public UsuarioRole(int usuarioId, int roleId)
        {
            UsuarioId = usuarioId;
            RoleId = roleId;
        }

        public int UsuarioId { get; private set; }
        public int RoleId { get; private set; }

        public Usuario Usuario { get; set; }
        public Role Role { get; set; }
    }
}