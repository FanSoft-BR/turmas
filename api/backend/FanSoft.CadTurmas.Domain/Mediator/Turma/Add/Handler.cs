using System.Threading;
using System.Threading.Tasks;
using FanSoft.CadTurmas.Domain.Contracts.Infra.Data;
using FanSoft.CadTurmas.Domain.Contracts.Repositories;
using MediatR;

namespace FanSoft.CadTurmas.Domain.Mediator.Turma.Add
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IMediator _mediator;
        private readonly ITurmaWriteRepository _turmaWriteRepository;
        private readonly IUnitOfWork _uow;

        public Handler(IMediator mediator, ITurmaWriteRepository turmaWriteRepository, IUnitOfWork uow)
        {
            _mediator = mediator;
            _turmaWriteRepository = turmaWriteRepository;
            _uow = uow;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var novaTurma = new Entities.Turma(request.Nome, request.DataInicio, request.DataTermino, request.InstrutorId, request.Descricao);
            _turmaWriteRepository.Add(novaTurma);
            await _uow.CommitAsync();

            await _mediator.Publish(new Notification
            {
                Id = novaTurma.Id,
                Nome = novaTurma.Nome
            });

            return new Response(novaTurma);
        }
    }
}