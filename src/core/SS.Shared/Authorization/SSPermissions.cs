using System.Collections.ObjectModel;

namespace SS.Shared.Authorization;

public static class SSAction
{
    public const string View = nameof(View);
    public const string Search = nameof(Search);
    public const string Create = nameof(Create);
    public const string Update = nameof(Update);
    public const string Delete = nameof(Delete);
    public const string Export = nameof(Export);
    public const string ExtendAccess = nameof(ExtendAccess);
}

public static class SSResource
{
    /*public const string Dashboard = nameof(Dashboard);
    public const string Hangfire = nameof(Hangfire);*/

    public const string Users = nameof(Users);
    public const string UserRoles = nameof(UserRoles);
    public const string Roles = nameof(Roles);
    public const string RoleClaims = nameof(RoleClaims);
    public const string ArticleCategories = nameof(ArticleCategories);
    public const string Categories = nameof(Categories);
    public const string Articles = nameof(Articles);
    public const string Comments = nameof(Comments);
    public const string Reactions = nameof(Reactions);
    public const string Newsletter = nameof(Newsletter);
    public const string Addresses = nameof(Addresses);
    public const string Contacts = nameof(Contacts);
}

public static class SSPermissions
{
    private static readonly SSPermission[] _all =
    {
        /*new("View Dashboard", NgclopediaAction.View, NgclopediaResource.Dashboard),
        new("View Hangfire", NgclopediaAction.View, NgclopediaResource.Hangfire),*/

        new("View Users", SSAction.View, SSResource.Users, IsRoot: false),
        new("Search Users", SSAction.Search, SSResource.Users, IsRoot: false),
        new("Create Users", SSAction.Create, SSResource.Users, IsRoot: false),
        new("Update Users", SSAction.Update, SSResource.Users, IsRoot: false),
        new("Delete Users", SSAction.Delete, SSResource.Users, IsRoot: false),
        new("Export Users", SSAction.Export, SSResource.Users, IsRoot: false),
        new("Upgrade Users", SSAction.ExtendAccess, SSResource.Users, IsRoot: true),

        new("View User Roles", SSAction.View, SSResource.UserRoles),
        new("Search User Roles", SSAction.Search, SSResource.UserRoles),
        new("Create User Roles", SSAction.Create, SSResource.UserRoles),
        new("Update User Roles", SSAction.Update, SSResource.UserRoles),
        new("Delete User Roles", SSAction.Delete, SSResource.UserRoles),

        new("View Roles", SSAction.View, SSResource.Roles),
        new("Search Roles", SSAction.Search, SSResource.Roles),
        new("Create Roles", SSAction.Create, SSResource.Roles),
        new("Update Roles", SSAction.Update, SSResource.Roles),
        new("Delete Roles", SSAction.Delete, SSResource.Roles),
        new("View Role Claims", SSAction.View, SSResource.RoleClaims),
        new("Update Role Claims", SSAction.Update, SSResource.RoleClaims),

        
        
        new("View Article Categories", SSAction.View, SSResource.ArticleCategories,
            true),
        new("Search Article Categories", SSAction.Search, SSResource.ArticleCategories,
            true),
        new("Create Article Categories", SSAction.Create, SSResource.ArticleCategories),
        new("Update Article Categories", SSAction.Update, SSResource.ArticleCategories),
        new("Delete Article Categories", SSAction.Delete, SSResource.ArticleCategories),
        new("Export Article Categories", SSAction.Export, SSResource.ArticleCategories),

        new("View Categories", SSAction.View, SSResource.Categories,
            true),
        new("Search Categories", SSAction.Search, SSResource.Categories,
            true),
        new("Create Categories", SSAction.Create, SSResource.Categories),
        new("Update Categories", SSAction.Update, SSResource.Categories),
        new("Delete Categories", SSAction.Delete, SSResource.Categories),
        new("Export Categories", SSAction.Export, SSResource.Categories),

        new("View Articles", SSAction.View, SSResource.Articles, true),
        new("Search Articles", SSAction.Search, SSResource.Articles, true),
        new("Create Articles", SSAction.Create, SSResource.Articles),
        new("Update Articles", SSAction.Update, SSResource.Articles),
        new("Delete Articles", SSAction.Delete, SSResource.Articles),
        new("Export Articles", SSAction.Export, SSResource.Articles),

        new("View Comments", SSAction.View, SSResource.Comments, true),
        new("Search Comments", SSAction.Search, SSResource.Comments, true),
        new("Create Comments", SSAction.Create, SSResource.Comments),
        new("Update Comments", SSAction.Update, SSResource.Comments),
        new("Delete Comments", SSAction.Delete, SSResource.Comments),
        new("Export Comments", SSAction.Export, SSResource.Comments),

        new("View Reactions", SSAction.View, SSResource.Reactions, true),
        new("Search Reactions", SSAction.Search, SSResource.Reactions, true),
        new("Create Reactions", SSAction.Create, SSResource.Reactions),
        new("Update Reactions", SSAction.Update, SSResource.Reactions),
        new("Delete Reactions", SSAction.Delete, SSResource.Reactions),

        new("View Addresses", SSAction.View, SSResource.Addresses, true),
        new("Search Addresses", SSAction.Search, SSResource.Addresses, true),
        new("Create Addresses", SSAction.Create, SSResource.Addresses),
        new("Update Addresses", SSAction.Update, SSResource.Addresses),
        new("Delete Addresses", SSAction.Delete, SSResource.Addresses),
        new("Export Addresses", SSAction.Export, SSResource.Addresses),

        new("View Contacts", SSAction.View, SSResource.Contacts, true),
        new("Search Contacts", SSAction.Search, SSResource.Contacts, true),
        new("Create Contacts", SSAction.Create, SSResource.Contacts),
        new("Update Contacts", SSAction.Update, SSResource.Contacts),
        new("Delete Contacts", SSAction.Delete, SSResource.Contacts),
        new("Export Contacts", SSAction.Export, SSResource.Contacts),

        new("View Newsletter", SSAction.View, SSResource.Newsletter, true),
        new("Search Newsletter", SSAction.Search, SSResource.Newsletter, true),
        new("Create Newsletter", SSAction.Create, SSResource.Newsletter),
        new("Update Newsletter", SSAction.Update, SSResource.Newsletter),
        new("Delete Newsletter", SSAction.Delete, SSResource.Newsletter),
        new("Export Newsletter", SSAction.Export, SSResource.Newsletter),
    };

    public static IReadOnlyList<SSPermission> All { get; } = new ReadOnlyCollection<SSPermission>
        (_all);

    public static IReadOnlyList<SSPermission> Root { get; } = new ReadOnlyCollection<SSPermission>
        (_all.Where(p => p.IsRoot).ToArray());

    public static IReadOnlyList<SSPermission> Superuser { get; } = new ReadOnlyCollection<SSPermission>
        (_all.Where(p => p.IsRoot).ToArray());

    public static IReadOnlyList<SSPermission> Admin { get; } = new ReadOnlyCollection<SSPermission>
        (_all.Where(p => !p.IsRoot).ToArray());

    public static IReadOnlyList<SSPermission> Basic { get; } = new ReadOnlyCollection<SSPermission>
        (_all.Where(p => p.IsBasic).ToArray());
}

public record SSPermission(string Description, string Action, string Resource, bool IsBasic = false,
    bool IsRoot = false)
{
    public string Name => NameFor(Action, Resource);

    public static string NameFor(string action, string resource) =>
        $"Permissions.{resource}.{action}";
}