using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SS.Application.Interfaces.Common;
using SS.Domain.Auth;
using SS.Domain.Blog;
using SS.Domain.Common;
using SS.Domain.Users;
using SS.Infrastructure.Persistence.Configuration;

namespace SS.Infrastructure.Persistence.Context;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>,
    IdentityUserRole<string>, IdentityUserLogin<string>, ApplicationRoleClaim, IdentityUserToken<string>>
{
    protected readonly ICurrentUser _currentUser;
    private readonly ISerializerService _serializer;
    protected readonly DbContextOptions<ApplicationDbContext> _options;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ICurrentUser currentUser,
        ISerializerService serializer, DbSet<Category> categories, DbSet<MailSetting> mailSettings, DbSet<Newsletter> newsletters) : base(options)
    {
        _currentUser = currentUser;
        _serializer = serializer;
        Categories = categories;
        MailSettings = mailSettings;
        Newsletters = newsletters;
        _options = options;
    }

    public DbSet<Address>? Addresses { get; set; }
    public DbSet<Article>? Articles { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment>? Comments { get; set; }
    public DbSet<Contact>? Contacts { get; set; }
    public DbSet<MailSetting> MailSettings { get; set; }
    public DbSet<Newsletter> Newsletters { get; set; }
    public DbSet<Reaction>? Reactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new IdentityUserTokenConfig());
        modelBuilder.ApplyConfiguration(new IdentityUserTokenConfig());
        modelBuilder.ApplyConfiguration(new IdentityUserClaimConfig());
        modelBuilder.ApplyConfiguration(new IdentityUserRoleConfig());
        modelBuilder.ApplyConfiguration(new ApplicationRoleClaimConfig());
        modelBuilder.ApplyConfiguration(new ApplicationRoleConfig());
        modelBuilder.ApplyConfiguration(new ApplicationUserConfig());
        modelBuilder.ApplyConfiguration(new AddressConfig());
        modelBuilder.ApplyConfiguration(new ContactConfig());
        modelBuilder.ApplyConfiguration(new CommentConfig());
        modelBuilder.ApplyConfiguration(new ArticleConfig());
        modelBuilder.ApplyConfiguration(new ReactionConfig());
    }
}