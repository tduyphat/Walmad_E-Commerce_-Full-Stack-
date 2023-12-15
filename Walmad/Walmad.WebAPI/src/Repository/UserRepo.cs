using Microsoft.EntityFrameworkCore;
using Walmad.Core.src.Abstraction;
using Walmad.Core.src.Entity;
using Walmad.Core.src.Parameter;
using Walmad.WebAPI.src.Database;

namespace Walmad.WebAPI.src.Repository;

public class UserRepo : IUserRepo
{
    private DbSet<User> _users;
    private DatabaseContext _database;

    public UserRepo(DatabaseContext database)
    {
        _users = database.Users;
        _database = database;
    }

    public User CreateOne(User user)
    {
        _users.Add(user);
        _database.SaveChanges();
        return user;
    }

    public bool DeleteOne(Guid id)
    {
        var userToRemove = _users.FirstOrDefault(user => user.Id == id);

        if (userToRemove != null)
        {
            _users.Remove(userToRemove);
            _database.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
    }

    public IEnumerable<User> GetAll(GetAllParams options)
    {
        return _users.Skip(options.Offset).Take(options.Limit);
    }

    public User GetOneById(Guid id)
    {
        var userToRemove = _users.FirstOrDefault(user => user.Id == id);
        if (userToRemove != null)
        {

            return userToRemove;
        }
        else
        {
            throw new NotImplementedException();
        }
    }

    public User UpdateOne(Guid id, User user)
    {
        var userToRemove = _users.FirstOrDefault(user => user.Id == id);
        if (userToRemove != null)
        {

            userToRemove.Name = user.Name;
            userToRemove.Email = user.Email;
            userToRemove.Avatar = user.Avatar;
            _database.SaveChanges();
            return userToRemove;
        }
        else
        {
            throw new NotImplementedException();
        }
    }
}
