using SS.Application.Interfaces.Service.Auth;
using SS.Application.Interfaces.Service.Blog;
using SS.Application.Interfaces.Service.Common;
using SS.Application.Interfaces.Service.User;

namespace SS.Application.Interfaces.Service;

public interface IServiceManager
{
    IRoleService RoleService { get; }

    ITokenService TokenService { get; }
    IUserService UserService { get; }
    IAddressService AddressService { get; }
    IContactService ContactService { get; }
    IArticleService ArticleService { get; }
    ICommentService CommentService { get; }
    IReactionService ReactionService { get; }
}