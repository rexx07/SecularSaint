namespace SS.Application.Dtos.Common;

public class CreateUpdateAddressRequestDto
{
    public Guid AddressId { get; init; }
    public string Country { get; init; }
    public string Area { get; init; }
    public string State { get; init; }
    public string Region { get; init; }
    public string Ip { get; init; }
    public string? ZipPostalCode { get; init; }
}