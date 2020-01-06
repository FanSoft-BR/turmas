using System.Threading;
using System.Threading.Tasks;
using FanSoft.CadTurmas.Domain.Contracts.Infra.Data;
using FanSoft.CadTurmas.Domain.Contracts.Repositories;
using FanSoft.CadTurmas.Domain.Infra.Helpers;
using FanSoft.CadTurmas.Domain.Infra.Models;
using MediatR;

namespace FanSoft.CadTurmas.Domain.Mediator.Sign.In
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IMediator _mediator;
        private readonly IUsuarioWriteRepository _usuarioWriteRepository;
        private readonly IUsuarioReadRepository _usuarioReadRepository;
        private readonly IUnitOfWork _uow;
        private readonly SecuritySettings _securitySettings;

        public Handler(
            IMediator mediator,
            IUsuarioWriteRepository usuarioWriteRepository,
            IUsuarioReadRepository usuarioReadRepository,
            IUnitOfWork uow,
            SecuritySettings securitySettings)
        {
            _mediator = mediator;
            _usuarioWriteRepository = usuarioWriteRepository;
            _usuarioReadRepository = usuarioReadRepository;
            _uow = uow;
            _securitySettings = securitySettings;
        }

        public IMediator Mediator => _mediator;

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            bool credenciaisValidas = false;

            Entities.Usuario userData = null;
            switch (request.GrantType)
            {
                case "password":
                    userData = await _usuarioReadRepository.GetByEmailAsync(request.Email);
                    credenciaisValidas = (userData != null && request.Password.Encrypt() == userData.Senha);
                    break;
                case "refresh_token":
                    userData = await _usuarioReadRepository.GetByRefreshTokenAsync(request.RefreshToken);
                    credenciaisValidas = (userData?.RefreshToken != null && userData.RefreshTokenIsValid && request.RefreshToken == userData.RefreshToken);
                    break;
                default:
                    credenciaisValidas = false;
                    break;
            }

            if (!credenciaisValidas) return new Response().AddError("Dados Inválidos");

            // Gerar RefreshToken
            userData.RefreshTokenGenerate(_securitySettings.RefreshTokenExpires);
            _usuarioWriteRepository.Update(userData);
            await _uow.CommitAsync();


            return new Response(userData);
        }
    }
}