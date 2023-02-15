using BupaDinner.Domain.Entities;

namespace BupaDinner.Application.Common.Interfaces.Persistance;


public interface IUserRepository
{
    void AddUser(User user);   

    User GetUserByEmail(string email);
}