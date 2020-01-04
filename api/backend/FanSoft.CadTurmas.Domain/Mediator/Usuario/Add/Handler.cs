using System.Threading;
using System.Threading.Tasks;
using FanSoft.CadTurmas.Domain.Contracts.Infra.Data;
using FanSoft.CadTurmas.Domain.Contracts.Repositories;
using FanSoft.CadTurmas.Domain.Helpers;
using MediatR;

namespace FanSoft.CadTurmas.Domain.Mediator.Usuario.Add
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IMediator _mediator;
        private readonly IUsuarioWriteRepository _usuarioWriteRepository;
        private readonly IUnitOfWork _uow;
        
        public Handler(IMediator mediator, IUsuarioWriteRepository usuarioWriteRepository, IUnitOfWork uow)
        {
            _mediator = mediator;
            _usuarioWriteRepository = usuarioWriteRepository;
            _uow = uow;
        }

        public IMediator Mediator => _mediator;

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var novoUsuario = new Entities.Usuario(request.Nome, request.Email, request.Senha.Encrypt());
            _usuarioWriteRepository.Add(novoUsuario);
            await _uow.CommitAsync();

            await Mediator.Publish(new Notification {
                Id = novoUsuario.Id, Nome = novoUsuario.Nome, Email = novoUsuario.Email
            });

            return new Response(novoUsuario);
        }
    }
}