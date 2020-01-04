namespace FanSoft.CadTurmas.Api.Models
{
    public class UsuarioList
    {
        public int Id { get; set; }
        public string Nome { get;  set; }
        public string Email { get; set; }
    }

    public static class UsuariosCtrlModelExtensions
    {
        public static UsuarioList ToVM(this Domain.Entities.Usuario entity)
        {
            return new UsuarioList {
                Id = entity.Id,
                Nome = entity.Nome,
                Email = entity.Email
            };
        }
    }
}