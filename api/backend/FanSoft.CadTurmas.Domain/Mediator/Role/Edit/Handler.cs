using System.Threading;
using System.Threading.Tasks;
using FanSoft.CadTurmas.Domain.Contracts.Infra.Data;
using FanSoft.CadTurmas.Domain.Contracts.Repositories;
using MediatR;

namespace FanSoft.CadTurmas.Domain.Mediator.Role.Edit
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IMediator _mediator;
        private readonly IRoleReadRepository _roleReadRepository;
        private readonly IRoleWriteRepository _roleWriteRepository;
        private readonly IUnitOfWork _uow;

        public Handler(
                IMediator mediator,
                IRoleWriteRepository roleWriteRepository,
                IRoleReadRepository roleReadRepository,
                IUnitOfWork uow
            )
        {
            _mediator = mediator;
            _roleWriteRepository = roleWriteRepository;
            _roleReadRepository = roleReadRepository;
            _uow = uow;
        }

        public IMediator Mediator => _mediator;

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var role = await _roleReadRepository.GetAsync(request.Id);

            if (role == null)
            {
                var response = new Response();
                response.AddError($"Role de id {request.Id} não encontrado");
                return response;
            }

            role.Update(request.Nome, request.Descricao);
            _roleWriteRepository.Update(role);
            await _uow.CommitAsync();

            return new Response(role);
        }
    }
}