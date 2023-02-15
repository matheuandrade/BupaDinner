using BupaDinner.Application.Common.Interfaces.Authentication;
using BupaDinner.Application.Common.Interfaces.Persistance;
using BupaDinner.Domain.Entities;

namespace BupaDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGerator;

    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGerator, IUserRepository userRepository)
    {
        _jwtTokenGerator = jwtTokenGerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Login(string email, string password)
    {
        if(_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("User with given email already exists");
        }

        if(user.Password != password)
        {
            throw new Exception("Invalid password");
        }

        var token = _jwtTokenGerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {

        if(_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("User with given email already exists");
        }

        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.AddUser(user);

        var userId = Guid.NewGuid();

        var token = _jwtTokenGerator.GenerateToken(user);

       return new AuthenticationResult(
           user,
           token);
    }
}