namespace SS.Application.Dtos.Auth.Token;

public record TokenDto(string Token, string RefreshToken, DateTime RefreshTokenExpiryTime);