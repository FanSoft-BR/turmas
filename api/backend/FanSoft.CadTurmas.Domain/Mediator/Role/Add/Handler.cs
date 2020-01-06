using System.Threading;
using System.Threading.Tasks;
using FanSoft.CadTurmas.Domain.Contracts.Infra.Data;
using FanSoft.CadTurmas.Domain.Contracts.Repositories;
using MediatR;

namespace FanSoft.CadTurmas.Domain.Mediator.Role.Add
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IMediator _mediator;
        private readonly IRoleWriteRepository _roleWriteRepository;
        private readonly IUnitOfWork _uow;
        
        public Handler(IMediator mediator, IRoleWriteRepository roleWriteRepository, IUnitOfWork uow)
        {
            _mediator = mediator;
            _roleWriteRepository = roleWriteRepository;
            _uow = uow;
        }

        public IMediator Mediator => _mediator;

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var novaRole = new Entities.Role(request.Nome, request.Descricao);
            _roleWriteRepository.Add(novaRole);
            await _uow.CommitAsync();

            return new Response(novaRole);
        }
    }
}