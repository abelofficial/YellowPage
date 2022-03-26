using YellowPage.Api.Models;

namespace YellowPage.Api.Services;

public interface IAuthService
{
    User Register(User user, string password);

    User GetById(int id);

}
