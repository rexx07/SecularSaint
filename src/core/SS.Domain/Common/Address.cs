using SS.Domain.Contracts;

namespace SS.Domain.Common;

public class Address : AuditableEntity
{
    public Address(
        string name,
        string area,
        string state,
        string? country,
        string? zipPostalCode)
    {
        Name = name;
        Area = area;
        State = state;
        Country = country;
        ZipPostalCode = zipPostalCode;
    }
    public string Name { get; set; }
    public string Area { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string? ZipPostalCode { get; set; }
    public string Ip { get; set; }
    public string Region { get; set; }
}