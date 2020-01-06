using System.Threading;
using System.Threading.Tasks;
using FanSoft.CadTurmas.Domain.Contracts.Infra.Data;
using FanSoft.CadTurmas.Domain.Contracts.Repositories;
using FanSoft.CadTurmas.Domain.Infra.Helpers;
using MediatR;

namespace FanSoft.CadTurmas.Domain.Mediator.Usuario.ChangePassword
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IMediator _mediator;
        private readonly IUsuarioWriteRepository _usuarioWriteRepository;
        private readonly IUsuarioReadRepository _usuarioReadRepository;
        private readonly IUnitOfWork _uow;
        
        public Handler(
            IMediator mediator,
            IUsuarioWriteRepository usuarioWriteRepository,
            IUsuarioReadRepository usuarioReadRepository,
            IUnitOfWork uow)
        {
            _mediator = mediator;
            _usuarioWriteRepository = usuarioWriteRepository;
            _usuarioReadRepository = usuarioReadRepository;
            _uow = uow;
        }

        public IMediator Mediator => _mediator;

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioReadRepository.GetAsync(request.Id);

            if (usuario == null)
                return new Response().AddError($"Usuário de id {request.Id} não encontrado");

            if (usuario.Senha != request.SenhaAntiga.Encrypt())
                return new Response().AddError($"Senha antiga não confere");

            usuario.UpdatePassword(request.NovaSenha.Encrypt());
            _usuarioWriteRepository.Update(usuario);
            await _uow.CommitAsync();

            return new Response(usuario);
        }
    }
}