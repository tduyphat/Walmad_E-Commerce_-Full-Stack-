using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Walmad.Business.src.Shared;
using Walmad.Core.src.Abstraction;
using Walmad.Core.src.Entity;
using Walmad.Core.src.Parameter;
using Walmad.WebAPI.src.Database;

namespace Walmad.WebAPI.src.Repository;

public class UserRepo : IUserRepo
{
    private DbSet<User> _users;
    private DatabaseContext _database;
    private IConfiguration _config;

    public UserRepo(DatabaseContext database, IConfiguration config)
    {
        _users = database.Users;
        _database = database;
        _config = config;
    }

    public User CreateOne(User user)
    {
        _users.Add(user);
        _database.SaveChanges();
        return user;
    }

    public bool DeleteOne(Guid id)
    {
        var foundUser = _users.FirstOrDefault(user => user.Id == id);

        if (foundUser != null)
        {
            _users.Remove(foundUser);
            _database.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
    }

    public User FindUserByCredentials(User user)
    {
        var foundUser = _users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
        if (foundUser is not null)
        {
            return foundUser;
        }
        else
        {
            throw CustomExeption.NotFoundException();
        }
    }

    public string GenerateToken(User user)
    {
        var issuer = _config.GetSection("Jwt:Issuer").Value;
        var claims = new List<Claim>{
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Role, user.Role.ToString()),
        };
        var audience = _config.GetSection("Jwt:Audience").Value;
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Jwt:Key").Value!));
        var signingKey = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var descriptor = new SecurityTokenDescriptor
        {
            Issuer = issuer,
            Audience = audience,
            Expires = DateTime.Now.AddDays(2),
            Subject = new ClaimsIdentity(claims),
            SigningCredentials = signingKey
        };
        var token = tokenHandler.CreateToken(descriptor);
        return token.ToString()!;
    }

    public IEnumerable<User> GetAll(GetAllParams options)
    {
        return _users.Skip(options.Offset).Take(options.Limit);
    }

    public User GetOneById(Guid id)
    {
        var foundUser = _users.FirstOrDefault(user => user.Id == id);
        if (foundUser != null)
        {

            return foundUser;
        }
        else
        {
            throw CustomExeption.NotFoundException();
        }
    }

    public User UpdateOne(Guid id, User user)
    {
        var foundUser = _users.FirstOrDefault(user => user.Id == id);
        if (foundUser != null)
        {

            foundUser.Name = user.Name;
            foundUser.Email = user.Email;
            foundUser.Avatar = user.Avatar;
            _database.SaveChanges();
            return foundUser;
        }
        else
        {
            throw CustomExeption.NotFoundException();
        }
    }
}
