using System;
using System.Linq;
using System.Threading.Tasks;
using FanSoft.CadTurmas.Domain.Contracts.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FanSoft.CadTurmas.Api.Models;
using Microsoft.AspNetCore.Authorization;

namespace FanSoft.CadTurmas.Api.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class TurmasController : ControllerBase
    {
        private readonly ITurmaReadRepository _turmaReadRepository;
        private readonly IMediator _mediator;

        public TurmasController(ITurmaReadRepository turmaReadRepository, IMediator mediator)
        {
            _turmaReadRepository = turmaReadRepository;
            _mediator = mediator;
        }

        /// <summary>
        /// Lista todas as turmas.
        /// </summary>
        /// <returns>Uma lista de turmas</returns>
        /// <response code="200">Turmas retornardas com sucesso</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var turmas = await _turmaReadRepository.GetAllWithInstrutorAsync();
            return Ok(turmas.Select(t=>t.ToVM()).ToList());
        }

        /// <summary>
        /// Busca uma turma pelo ID.
        /// </summary>
        /// <param name="id">Id da Turma</param> 
        /// <returns>Uma turma</returns>
        /// <response code="200">Turma retornarda com sucesso</response>
        /// <response code="404">Caso a turma não exista ou o id não seja um GUID</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id:guid}", Name = "GetTurmaById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var data = await _turmaReadRepository.GetByIdWithInstrutorAsync(id);

            if (data == null)
                return NotFound();

            return Ok(data.ToVM());
        }

        /// <summary>
        /// Adiciona uma nova turma.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     POST /Turmas
        ///     {
        ///         "nome": "Nova Turma",
        ///         "dataInicio": "2020-01-03",
        ///         "dataTermino": "2020-01-15",
        ///         "instrutorId": 1,
        ///         "descricao": "Descrição da Turma nova"
        ///     }
        ///
        /// </remarks>
        /// <param name="request"></param>
        /// <returns>Uma nova turma</returns>
        /// <response code="201">Returna a nova turma</response>
        /// <response code="400">Caso o nome seja nulo</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Domain.Mediator.Turma.Add.Request request)
        {
            var response = await _mediator.Send(request).ConfigureAwait(false);

            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return CreatedAtRoute("GetTurmaById", new { id = response.Result.Id }, response.Result);
        }

        /// <summary>
        /// Edita uma turma.
        /// </summary>
        /// <param name="id">Id da Turma</param> 
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     PUT /Turmas/{id}
        ///     {
        ///        "nome": "Turma XPTO",
        ///        "descricao": "Descrição da turma XPTO"
        ///     }
        ///
        /// </remarks>
        /// <param name="request"></param>
        /// <response code="204">Se tudo OK</response>
        /// <response code="400">Caso o nome seja nulo</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]Domain.Mediator.Turma.Edit.Request request)
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
        /// Exclui uma turma pelo ID.
        /// </summary>
        /// <param name="id">Id da Turma</param> 
        /// <response code="204">Turma excluída c/ sucesso</response>
        /// <response code="400">Caso a turma não exista ou o id não seja um GUID</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var request = new Domain.Mediator.Turma.Del.Request();
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