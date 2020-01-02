using System.Threading;
using System.Threading.Tasks;
using FanSoft.CadTurmas.Domain.Contracts.Infra.Data;
using FanSoft.CadTurmas.Domain.Contracts.Repositories;
using MediatR;

namespace FanSoft.CadTurmas.Domain.Mediator.Turma.Edit
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IMediator _mediator;
        private readonly ITurmaReadRepository _turmaReadRepository;
        private readonly ITurmaWriteRepository _turmaWriteRepository;
        private readonly IUnitOfWork _uow;
        
        public Handler(
            IMediator mediator, 
            ITurmaWriteRepository turmaWriteRepository, 
            ITurmaReadRepository turmaReadRepository,
            IUnitOfWork uow)
        {
            _mediator = mediator;
            _turmaWriteRepository = turmaWriteRepository;
            _turmaReadRepository = turmaReadRepository;
            _uow = uow;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var turma = await _turmaReadRepository.GetAsync(request.Id);

            if (turma == null)
            {
                var response = new Response();
                response.AddError($"Turma de id {request.Id} não encontrado");
                return response;
            }

            turma.Update(request.Nome, request.Descricao);
            _turmaWriteRepository.Update(turma);
            await _uow.CommitAsync();

            return new Response(turma);
        }
    }
}