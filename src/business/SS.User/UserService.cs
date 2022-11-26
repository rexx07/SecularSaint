using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using SS.Application.Caching;
using SS.Application.Dtos.Users;
using SS.Application.Exceptions;
using SS.Application.FileStorage;
using SS.Application.Interfaces.Common;
using SS.Application.Interfaces.Events;
using SS.Application.Interfaces.Service.User;
using SS.Application.Mailing;
using SS.Domain.Auth;
using SS.Domain.Users;
using SS.Infrastructure.Persistence.Context;
using SS.Infrastructure.SecurityHeaders;
using SS.Shared.Authorization;
using SS.User.Events;

namespace SS.User;

internal partial class UserService : IUserService
{
    private readonly ICacheService _cache;
    private readonly ICacheKeyService _cacheKeys;
    private readonly ICurrentUser _currentUser;
    private readonly ApplicationDbContext _db;
    private readonly IEventPublisher _events;
    private readonly IFileStorageService _fileStorage;
    private readonly IMailService _mailService;
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly SecuritySettings _securitySettings;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IStringLocalizer _t;
    private readonly IEmailTemplateService _templateService;
    private readonly UserManager<ApplicationUser> _userManager;

    public UserService(
        SignInManager<ApplicationUser> signInManager,
        UserManager<ApplicationUser> userManager,
        RoleManager<ApplicationRole> roleManager,
        ApplicationDbContext db,
        IStringLocalizer<UserService> localizer,
        IMailService mailService,
        IEmailTemplateService templateService,
        IFileStorageService fileStorage,
        IEventPublisher events,
        ICacheService cache,
        //ICacheKeyService cacheKeys,
        ICurrentUser currentUser,
        IOptions<SecuritySettings> securitySettings)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _roleManager = roleManager;
        _db = db;
        _t = localizer;
        _mailService = mailService;
        _templateService = templateService;
        _fileStorage = fileStorage;
        _events = events;
        _cache = cache;
        //_cacheKeys = cacheKeys;
        _currentUser = currentUser;
        _securitySettings = securitySettings.Value;
    }

    /*public async Task<PaginationResponse<UserWithDetailsDto>> SearchAsync(UserListFilter filter, CancellationToken cancellationToken)
    {
        var spec = new EntitiesByPaginationFilterSpec<ApplicationUser>(filter);

        var users = await _userManager.Users
            .WithSpecification(spec)
            .ProjectToType<UserDetailsDto>()
            .ToListAsync(cancellationToken);
        int count = await _userManager.Users
            .CountAsync(cancellationToken);

        return new PaginationResponse<UserDetailsDto>(users, count, filter.PageNumber, filter.PageSize);
    }*/

    public async Task<bool> UserExistsWithNameAsync(string name)
    {
        return await _userManager.FindByNameAsync(name) is not null;
    }

    public async Task<bool> UserExistsWithEmailAsync(string email, string? exceptId = null)
    {
        return await _userManager.FindByEmailAsync(email.Normalize()) is ApplicationUser user && user.Id != exceptId;
    }

    public async Task<bool> UserExistsWithPhoneNumberAsync(string phoneNumber, string? exceptId = null)
    {
        return await _userManager.Users.FirstOrDefaultAsync(x =>
            x.PhoneNumber == phoneNumber) is ApplicationUser user && user.Id != exceptId;
    }

    public async Task<List<UserDto>> GetAllUsersAsync(CancellationToken cancellationToken)
    {
        return await _userManager.Users
            .Select(u => new UserDto
            {
                Id = u.Id,
                UserName = u.UserName,
                Bio = u.Bio,
                ImageUrl = u.ImageUrl,
                IsActive = u.IsActive,
                EmailConfirmed = u.EmailConfirmed,
            })
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public Task<int> GetUsersCountAsync(CancellationToken cancellationToken)
    {
        return _userManager.Users.AsNoTracking().CountAsync(cancellationToken);
    }

    public async Task<UserWithDetailsDto> GetUserAsync(string userId, CancellationToken cancellationToken)
    {
        var user = await _userManager.Users
            .AsNoTracking()
            .Where(u => u.Id == userId)
            .Select(u => new UserWithDetailsDto
            {
                Id = u.Id,
                UserName = u.UserName,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                IsActive = u.IsActive,
                EmailConfirmed = u.EmailConfirmed,
                PhoneNumber = u.PhoneNumber,
                ImageUrl = u.ImageUrl
            })
            .FirstOrDefaultAsync(cancellationToken);

        _ = user ?? throw new NotFoundException(_t["User Not Found."]);

        return user;
    }

    public async Task ToggleUserStatusAsync(ToggleUserStatusRequestDto request, CancellationToken cancellationToken)
    {
        var user = await _userManager.Users.Where(u => u.Id == request.UserId).FirstOrDefaultAsync(cancellationToken);

        _ = user ?? throw new NotFoundException(_t["User Not Found."]);

        var isAdmin = await _userManager.IsInRoleAsync(user, SSRoles.Admin);
        if (isAdmin) throw new ConflictException(_t["Root User Profile's Status cannot be toggled"]);

        user.IsActive = request.ActivateUser;

        await _userManager.UpdateAsync(user);

        await _events.PublishAsync(new ApplicationUserUpdatedEvent(user.Id));
    }
}