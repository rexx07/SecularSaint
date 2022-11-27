namespace SS.Application.Dtos.Auth.Token;

public record RefreshTokenRequestDto(string Token, string RefreshToken);