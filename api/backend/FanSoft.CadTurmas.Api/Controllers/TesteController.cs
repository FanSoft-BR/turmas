
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FanSoft.CadTurmas.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class TesteController
    {
        /// <summary>
        /// Testa a conectividade
        /// </summary>
        /// <returns>Uma string</returns>
        /// <response code="200">Houve conectividade</response>
        [HttpGet("ping")]
        public string Ping() => "Pong";

        /// <summary>
        /// Testa se o atributo Autorize está ok
        /// </summary>
        /// <returns>Uma string</returns>
        /// <response code="200">Houve conectividade</response>
        [Authorize]
        [HttpGet("autenticado")]
        public string Autenticado() => "User Autenticado";

        /// <summary>
        /// Testa o atributo Autorize com a Role Admin
        /// </summary>
        /// <returns>Uma string</returns>
        /// <response code="200">Houve conectividade</response>
        [Authorize(Roles = "Admin")]
        [HttpGet("roleadmin")]
        public string RoleAdmin() => "User Autenticado e com a role Admin";


        /// <summary>
        /// Testa o atributo Autorize com a Role PowerUser
        /// </summary>
        /// <returns>Uma string</returns>
        /// <response code="200">Houve conectividade</response>
        [Authorize(Roles = "PowerUser")]
        [HttpGet("rolepoweruser")]
        public string RolePowerUser() => "User Autenticado e com a role PowerUser";

        /// <summary>
        /// Testa o atributo Autorize com a Role User
        /// </summary>
        /// <returns>Uma string</returns>
        /// <response code="200">Houve conectividade</response>
        [Authorize(Roles = "User")]
        [HttpGet("roleuser")]
        public string RoleUser() => "User Autenticado e com a role User";

    }
}