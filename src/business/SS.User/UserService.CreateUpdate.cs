using SS.Application.Dtos.Users;
using SS.Application.Exceptions;
using SS.Application.Mailing;
using SS.Domain.Common;
using SS.Domain.Users;
using SS.Shared.Authorization;
using SS.User.Events;
using SS.User.Extensions;

namespace SS.User;

internal partial class UserService
{
    public async Task<string> CreateUserAsync(CreateUserRequestDto request, string origin)
    {
        var user = new ApplicationUser
        {
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            UserName = request.UserName,
            PhoneNumber = request.PhoneNumber,
            IsActive = true
        };

        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
            throw new InternalServerException(_t["Validation Errors Occurred."], result.GetErrors(_t));

        await _userManager.AddToRoleAsync(user, SSRoles.Basic);

        var messages = new List<string> { string.Format(_t["User {0} Registered."], user.UserName) };

        if (_securitySettings.RequireConfirmedAccount && !string.IsNullOrEmpty(user.Email))
        {
            // send verification email
            var emailVerificationUri = await GetEmailVerificationUriAsync(user, origin);
            var eMailModel = new RegisterUserEmailModel
            {
                Email = user.Email,
                UserName = user.UserName,
                Url = emailVerificationUri
            };
            var mailRequest = new MailRequest(
                new List<string> { user.Email },
                _t["Confirm Registration"],
                _templateService.GenerateEmailTemplate("email-confirmation", eMailModel));
            await _mailService.SendAsync(mailRequest, CancellationToken.None);
            messages.Add(_t[$"Please check {user.Email} to verify your account!"]);
        }

        await _events.PublishAsync(new ApplicationUserCreatedEvent(user.Id));

        return string.Join(Environment.NewLine, messages);
    }

    public async Task UpdateUserAsync(UpdateUserRequestDto request, string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);

        _ = user ?? throw new NotFoundException(_t["User Not Found."]);

        var currentImage = user.ImageUrl ?? string.Empty;
        if (request.Image != null || request.DeleteCurrentImage)
        {
            user.ImageUrl = await _fileStorage.UploadAsync<ApplicationUser>(request.Image, FileType.Image);
            if (request.DeleteCurrentImage && !string.IsNullOrEmpty(currentImage))
            {
                var root = Directory.GetCurrentDirectory();
                _fileStorage.Remove(Path.Combine(root, currentImage));
            }
        }

        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.PhoneNumber = request.PhoneNumber;
        var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
        if (request.PhoneNumber != phoneNumber) await _userManager.SetPhoneNumberAsync(user, request.PhoneNumber);

        var result = await _userManager.UpdateAsync(user);

        await _signInManager.RefreshSignInAsync(user);

        await _events.PublishAsync(new ApplicationUserUpdatedEvent(user.Id));

        if (!result.Succeeded) throw new InternalServerException(_t["Update profile failed"], result.GetErrors(_t));
    }
}