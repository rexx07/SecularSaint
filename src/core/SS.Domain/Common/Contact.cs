using SS.Domain.Contracts;

namespace SS.Domain.Common;

public class Contact : AuditableEntity
{
    public Contact(
        string? facebookName,
        string? twitterUsername,
        string? instagramUsername,
        string? websiteUrl)
    {
        FacebookName = facebookName;
        TwitterUsername = twitterUsername;
        InstagramUsername = instagramUsername;
        WebsiteUrl = websiteUrl;
    }

    public string Name { get; set; }
    public string? FacebookName { get; set; }
    public string? TwitterUsername { get; set; }
    public string? InstagramUsername { get; set; }
    public string? WebsiteUrl { get; set; }
    public List<string> PhoneNumbers { get; set; }
    public List<string> Emails { get; set; }
}