using BupaDinner.Application.Common.Interfaces.Persistance;
using BupaDinner.Domain.Entities;

namespace BupaDinner.Infrastructure.Persistance;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public User GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(x => x.Email == email);
    }
}