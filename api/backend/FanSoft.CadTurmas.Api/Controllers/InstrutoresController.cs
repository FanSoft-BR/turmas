using System.Linq;
using System.Threading.Tasks;
using FanSoft.CadTurmas.Domain.Contracts.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FanSoft.CadTurmas.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class InstrutoresController : ControllerBase
    {
        private readonly IInstrutorReadRepository _instrutorReadRepository;
        private readonly IMediator _mediator;

        public InstrutoresController(IInstrutorReadRepository instrutorReadRepository, IMediator mediator)
        {
            _instrutorReadRepository = instrutorReadRepository;
            _mediator = mediator;
        }

        /// <summary>
        /// Lista todos os instrutores.
        /// </summary>
        /// <returns>Uma lista de instrutores</returns>
        /// <response code="200">Instrutores retornardos com sucesso</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _instrutorReadRepository.GetAsync();
            return Ok(data);
        }

        /// <summary>
        /// Busca um instrutor pelo ID.
        /// </summary>
        /// <param name="id">Id do Instrutor</param> 
        /// <returns>Um instrutor</returns>
        /// <response code="200">Instrutor retornardo com sucesso</response>
        /// <response code="404">Caso o instrutor não exista ou o id não seja um GUID</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id:int}", Name = "GetInstrutorById")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _instrutorReadRepository.GetAsync(id);

            if (data == null)
                return NotFound();

            return Ok(data);
        }

        /// <summary>
        /// Adiciona um novo instrutor.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     POST /Instrutores
        ///     {
        ///        "nome": "Instrutor XPTO",
        ///        "descricao": "Descrição do instrutor XPTO"
        ///     }
        ///
        /// </remarks>
        /// <param name="request"></param>
        /// <returns>Um novo instrutor</returns>
        /// <response code="201">Returna o novo instrutor</response>
        /// <response code="400">Caso o nome seja nulo</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Domain.Mediator.Instrutor.Add.Request request)
        {
            var response = await _mediator.Send(request).ConfigureAwait(false);

            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return CreatedAtRoute("GetInstrutorById", new { id = response.Result.Id }, response.Result);
        }

        /// <summary>
        /// Edita um instrutor.
        /// </summary>
        /// <param name="id">Id do Instrutor</param> 
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     PUT /Instrutores/{id}
        ///     {
        ///        "nome": "Instrutor XPTO",
        ///        "descricao": "Descrição do instrutor XPTO"
        ///     }
        ///
        /// </remarks>
        /// <param name="request"></param>
        /// <response code="204">Se tudo OK</response>
        /// <response code="400">Caso o nome seja nulo</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody]Domain.Mediator.Instrutor.Edit.Request request)
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
        /// Exclui um instrutor pelo ID.
        /// </summary>
        /// <param name="id">Id do instrutor</param> 
        /// <response code="204">Instrutor excluído c/ sucesso</response>
        /// <response code="400">Caso o instrutor não exista ou o id não seja um inteiro</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var request = new Domain.Mediator.Instrutor.Del.Request();
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