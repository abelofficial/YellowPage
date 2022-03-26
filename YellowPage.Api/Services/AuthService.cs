using YellowPage.Api.Data;
using YellowPage.Api.Models;

namespace YellowPage.Api.Services;

public class AuthService : IAuthService
{
    private YellowPageDb _context;

    public AuthService(YellowPageDb context)
    {
        _context = context;
    }

    public User Register(User user, string password)
    {
        // validation
        if (string.IsNullOrWhiteSpace(password))
            throw new Exception("Password is required");

        if (_context.User.Any(x => x.UserName == user.UserName))
            throw new Exception("Username \"" + user.UserName + "\" is already taken");

        byte[] passwordHash, passwordSalt;
        CreatePasswordHash(password, out passwordHash, out passwordSalt);

        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;

        _context.User.Add(user);
        _context.SaveChanges();

        return user;
    }

    // private helper methods
    private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        if (password == null) throw new ArgumentNullException("password");
        if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

        using (var hmac = new System.Security.Cryptography.HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }

    public User GetById(int id)
    {
        return _context.User.Find(id);
    }
}
