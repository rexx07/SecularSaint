using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using SS.Domain.Blog;
using SS.Domain.Common;

namespace SS.Domain.Users;

public class ApplicationUser : IdentityUser
{
    private int _TotArticles;
    private int _TotComments;
    private int _TotReactions;

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? MiddleName { get; set; }
    public List<string> MediaUrls { get; set; }
    public string Bio { get; set; }
    public string? ImageUrl { get; set; }
    public string? CoverUrl { get; set; }
    public bool IsActive { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
    public bool isAdmin { get; set; }
    public bool EmailSubscriber { get; set; }
    public string Area { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string? ZipPostalCode { get; set; }
    public string Ip { get; set; }
    public string Region { get; set; }
    public string? FacebookName { get; set; }
    public string? TwitterUsername { get; set; }
    public string? InstagramUsername { get; set; }
    public string? WebsiteUrl { get; set; }
    public ICollection<Article>? Articles { get; set; }
    public ICollection<Comment>? Comments { get; set; }
    public ICollection<Reaction>? Reactions { get; set; }

    [NotMapped]
    public int TotArticles
    {
        get => Articles?.Count ?? _TotArticles;
        set => _TotArticles = value;
    }

    [NotMapped]
    public int TotComments
    {
        get => Comments?.Count ?? _TotComments;
        set => _TotComments = value;
    }

    [NotMapped]
    public int TotReactions
    {
        get => Reactions?.Count ?? _TotReactions;
        set => _TotReactions = value;
    }
}