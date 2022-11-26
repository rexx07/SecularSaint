namespace SS.Application.Dtos.Common;

public class CreateUpdateContactRequestDto
{
    public string Name { get; init; }
    public string? FacebookName { get; init; }
    public string? TwitterUsername { get; init; }
    public string? InstagramUsername { get; init; }
    public string? WebsiteUrl { get; init; }
    public string PhoneNumber { get; init; }
    public string Email { get; init; }
}