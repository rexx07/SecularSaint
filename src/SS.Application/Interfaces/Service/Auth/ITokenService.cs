using SS.Application.Dtos.Auth.Token;
using SS.Application.Interfaces.Common;

namespace SS.Application.Interfaces.Service.Auth;

public interface ITokenService : ITransientService
{
    Task<TokenDto> GetTokenAsync(TokenRequestDto request, string? ipAddress, CancellationToken cancellationToken);

    Task<TokenDto> RefreshTokenAsync(RefreshTokenRequestDto request, string? ipAddress);
}