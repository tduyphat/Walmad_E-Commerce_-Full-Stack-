using Walmad.Core.src.Abstraction;
using Walmad.Core.src.Entity;
using Walmad.Core.src.Parameter;
using Walmad.WebAPI.src.Database;

namespace Walmad.WebAPI.src.Repository;

public class UserRepo : IUserRepo
{
    private List<User> _users;

    public UserRepo()
    {
        _users = new DatabaseContext().Users;
    }

    public User CreateOne(User user)
    {
        _users.Add(user);
        return user;
    }

    public bool DeleteOne(Guid id)
    {
        int foundIndex = _users.FindIndex(user => user.Id == id);
        if (foundIndex != -1)
        {
            _users.Remove(_users[foundIndex]);
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

        int foundIndex = _users.FindIndex(user => user.Id == id);
        if (foundIndex != -1)
        {

            return _users[foundIndex];
        }
        else
        {
            throw new NotImplementedException();
        }
    }

    public User UpdateOne(Guid id, User user)
    {
        int foundIndex = _users.FindIndex(user => user.Id == id);
        if (foundIndex != -1)
        {

            _users[foundIndex].Name = user.Name;
            _users[foundIndex].Email = user.Email;
            _users[foundIndex].Avatar = user.Avatar;
            return _users[foundIndex];
        }
        else
        {
            throw new NotImplementedException();
        }
    }
}
