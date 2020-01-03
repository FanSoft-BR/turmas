using System.Threading;
using System.Threading.Tasks;
using FanSoft.CadTurmas.Domain.Contracts.Infra.Data;
using FanSoft.CadTurmas.Domain.Contracts.Repositories;
using MediatR;

namespace FanSoft.CadTurmas.Domain.Mediator.Instrutor.Add
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IMediator _mediator;
        private readonly IInstrutorWriteRepository _instrutorWriteRepository;
        private readonly IUnitOfWork _uow;
        
        public Handler(IMediator mediator, IInstrutorWriteRepository instrutorWriteRepository, IUnitOfWork uow)
        {
            _mediator = mediator;
            _instrutorWriteRepository = instrutorWriteRepository;
            _uow = uow;
        }

        public IMediator Mediator => _mediator;

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var novoInstrutor = new Entities.Instrutor(request.Nome, request.Descricao);
            _instrutorWriteRepository.Add(novoInstrutor);
            await _uow.CommitAsync();

            await Mediator.Publish(new Notification {
                Id = novoInstrutor.Id, Nome = novoInstrutor.Nome
            });

            return new Response(novoInstrutor);
        }
    }
}