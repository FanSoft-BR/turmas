using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FanSoft.CadTurmas.Domain.Entities;
using FanSoft.CadTurmas.Domain.Infra.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FanSoft.CadTurmas.Api.Controllers
{

    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class SignController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly SecuritySettings _securitySettings;

        public SignController(IMediator mediator, SecuritySettings securitySettings)
        {
            _mediator = mediator;
            _securitySettings = securitySettings;
        }



        /// <summary>
        /// Adiciona um novo usuario.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     POST /Usuarios
        ///     {
        ///       "email": "nalin@fansoft.com.br",
        ///       "password": "123456",
        ///       "grantType": "password"
        ///     }
        ///
        ///     ou
        ///
        ///     {
        ///       "grantType": "refresh_token",
        ///       "refreshToken": "1820B90754F64952B42E2A731531B6A30"
        ///     }
        ///
        /// </remarks>
        /// <param name="request"></param>
        /// <returns>Um novo usuário</returns>
        /// <response code="201">Returno o novo usuário</response>
        /// <response code="400">Caso o nome, email e senha sejam nulo</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Domain.Mediator.Sign.In.Request request)
        {
            var response = await _mediator.Send(request).ConfigureAwait(false);

            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return generateToken(response.Result as Usuario);
        }

        private IActionResult generateToken(Usuario usuario)
        {

            var claims = new List<Claim>() {
                new Claim("id", usuario.Id.ToString()),
                new Claim("nome", usuario.Nome),
                new Claim("email", usuario.Email),
                //new Claim("perfis", string.Join(',', perfis.Select(p =>new {p.PerfilId, p.Perfil.Nome })))
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_securitySettings.SigningKey));
            var siginCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                    issuer: "fansoft.com.br",
                    audience: "fansoft.com.br",
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(5),
                    notBefore: DateTime.UtcNow,
                    signingCredentials: siginCredentials
                );

            return Ok(
                        new
                        {
                            access_token = new JwtSecurityTokenHandler().WriteToken(token),
                            refresh_token = usuario.RefreshToken
                        }
                    );

        }
    }
}
