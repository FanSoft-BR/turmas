using System.Threading;
using System.Threading.Tasks;
using FanSoft.CadTurmas.Domain.Contracts.Infra.Data;
using FanSoft.CadTurmas.Domain.Contracts.Repositories;
using MediatR;

namespace FanSoft.CadTurmas.Domain.Mediator.Instrutor.Del
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IMediator _mediator;
        private readonly IInstrutorWriteRepository _instrutorWriteRepository;
        private readonly IInstrutorReadRepository _instrutorReadRepository;
        private readonly IUnitOfWork _uow;
        
        public Handler(
            IMediator mediator,
            IInstrutorWriteRepository instrutorWriteRepository,
            IInstrutorReadRepository instrutorReadRepository,
            IUnitOfWork uow)
        {
            _mediator = mediator;
            _instrutorWriteRepository = instrutorWriteRepository;
            _instrutorReadRepository = instrutorReadRepository;
            _uow = uow;
        }

        public IMediator Mediator => _mediator;

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var instrutor = await _instrutorReadRepository.GetAsync(request.Id);

            if (instrutor == null)
            {
                var response = new Response();
                response.AddError($"Instrutor de id {request.Id} não encontrado");
                return response;
            }

            _instrutorWriteRepository.Delete(instrutor);
            await _uow.CommitAsync();

            return new Response(instrutor);
        }
    }
}