using System.Linq;
using System.Threading.Tasks;
using FanSoft.CadTurmas.Api.Models;
using FanSoft.CadTurmas.Domain.Contracts.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FanSoft.CadTurmas.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class UsuariosController:ControllerBase
    {
        
         private readonly IUsuarioReadRepository _usuarioReadRepository;
        private readonly IMediator _mediator;

        public UsuariosController(IUsuarioReadRepository usuarioReadRepository, IMediator mediator)
        {
            _usuarioReadRepository = usuarioReadRepository;
            _mediator = mediator;
        }

        /// <summary>
        /// Lista todos os usuários.
        /// </summary>
        /// <returns>Uma lista de usuarios</returns>
        /// <response code="200">Usuários retornardos com sucesso</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _usuarioReadRepository.GetAsync();
            return Ok(data.Select(d=>d.ToVM()));
        }

        /// <summary>
        /// Busca um usuário pelo ID.
        /// </summary>
        /// <param name="id">Id do Usuário</param> 
        /// <returns>Um usuário</returns>
        /// <response code="200">Usuário retornardo com sucesso</response>
        /// <response code="404">Caso o Usuário não exista ou o id não seja um ID</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id:int}", Name = "GetUsuarioById")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _usuarioReadRepository.GetAsync(id);

            if (data == null)
                return NotFound();

            return Ok(data.ToVM());
        }

        /// <summary>
        /// Adiciona um novo usuario.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     POST /Usuarios
        ///     {
        ///         "nome": "Novo Usuario",
        ///         "email": "usuario@usuario.com.br",
        ///         "senha": "senha"
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
        public async Task<IActionResult> Post([FromBody]Domain.Mediator.Usuario.Add.Request request)
        {
            var response = await _mediator.Send(request).ConfigureAwait(false);

            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return CreatedAtRoute("GetUsuarioById", new { id = response.Result.Id }, (response.Result as Domain.Entities.Usuario).ToVM());
        }

        /// <summary>
        /// Edita um usuario.
        /// </summary>
        /// <param name="id">Id do Usuário</param> 
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     PUT /Usuarios/{id}
        ///     {
        ///        "nome": "Usuário XPTO",
        ///        "email": "usuario@user.com.br"
        ///     }
        ///
        /// </remarks>
        /// <param name="request"></param>
        /// <response code="204">Se tudo OK</response>
        /// <response code="400">Caso o nome e/ou email seja nulo</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody]Domain.Mediator.Usuario.Edit.Request request)
        {
            request.Id = id;

            var response = await _mediator.Send(request).ConfigureAwait(false);

            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return NoContent();
        }

         /// <summary>
        /// Altera a senha de um usuário
        /// </summary>
        /// <param name="id">Id do Usuário</param> 
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     PUT /Usuarios/{id}/ChangePassword
        ///     {
        ///        "senhaAntiga": "senhaantiga",
        ///        "novaSenha": "nova senha"
        ///     }
        ///
        /// </remarks>
        /// <param name="request"></param>
        /// <response code="204">Se tudo OK</response>
        /// <response code="400">Caso o usuário não seja encontrado ou os dados da senha estjão incorretos</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id:int}/changepassword")]
        public async Task<IActionResult> PutChangePass(int id, [FromBody]Domain.Mediator.Usuario.ChangePassword.Request request)
        {
            request.Id = id;

            var response = await _mediator.Send(request).ConfigureAwait(false);

            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return NoContent();
        }

        /// <summary>
        /// Exclui um usuário pelo ID.
        /// </summary>
        /// <param name="id">Id do usuário</param> 
        /// <response code="204">Usuario excluído c/ sucesso</response>
        /// <response code="400">Caso o usuário não exista ou o id não seja um inteiro</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var request = new Domain.Mediator.Usuario.Del.Request();
            request.Id = id;

            var response = await _mediator.Send(request).ConfigureAwait(false);

            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return NoContent();
        }

    }
}
