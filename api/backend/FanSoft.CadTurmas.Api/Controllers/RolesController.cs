using System.Linq;
using System.Threading.Tasks;
using FanSoft.CadTurmas.Domain.Contracts.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FanSoft.CadTurmas.Api.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class RolesController : ControllerBase
    {


        private readonly IRoleReadRepository _roleReadRepository;
        private readonly IMediator _mediator;

        public RolesController(IRoleReadRepository roleReadRepository, IMediator mediator)
        {
            _roleReadRepository = roleReadRepository;
            _mediator = mediator;
        }

        /// <summary>
        /// Lista todos as role.
        /// </summary>
        /// <returns>Uma lista de roles</returns>
        /// <response code="200">Roles retornardas com sucesso</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _roleReadRepository.GetAsync();
            return Ok(data);
        }

        /// <summary>
        /// Busca uma role pelo ID.
        /// </summary>
        /// <param name="id">Id da Role</param> 
        /// <returns>Uma Role</returns>
        /// <response code="200">Role retornarda com sucesso</response>
        /// <response code="404">Caso a role não exista ou o id não seja um inteiro</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id:int}", Name = "GetRoleById")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _roleReadRepository.GetAsync(id);

            if (data == null)
                return NotFound();

            return Ok(data);
        }

        /// <summary>
        /// Adiciona uma nova role.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     POST /Roles
        ///     {
        ///        "nome": "Role XPTO",
        ///        "descricao": "Descrição da role XPTO"
        ///     }
        /// </remarks>
        /// <param name="request"></param>
        /// <returns>Uma nova role</returns>
        /// <response code="201">Retorna a nova role</response>
        /// <response code="400">Caso o nome seja nulo</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles="Usuario")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Domain.Mediator.Role.Add.Request request)
        {
            var response = await _mediator.Send(request).ConfigureAwait(false);

            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return CreatedAtRoute("GetRoleById", new { id = response.Result.Id }, response.Result);
        }


        /// <summary>
        /// Edita uma role.
        /// </summary>
        /// <param name="id">Id da Role</param> 
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     PUT /Roles/{id}
        ///     {
        ///        "nome": "Role XPTO",
        ///        "descricao": "Descrição da role XPTO"
        ///     }
        ///
        /// </remarks>
        /// <param name="request"></param>
        /// <response code="204">Se tudo OK</response>
        /// <response code="400">Caso o nome seja nulo</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody]Domain.Mediator.Role.Edit.Request request)
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
        /// Exclui uma role pelo ID.
        /// </summary>
        /// <param name="id">Id da role</param> 
        /// <response code="204">Role excluída c/ sucesso</response>
        /// <response code="400">Caso a role não exista ou o id não seja um inteiro</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var request = new Domain.Mediator.Role.Del.Request();
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