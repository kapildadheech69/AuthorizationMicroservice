using Authorization.Model;

namespace Authorization.Infrastructure
{
    public interface IUserModel
    {
        UserModel AuthenticateUser(UserModel login);
        string GenerateJSONWebToken(UserModel userInfo);
    }
}
