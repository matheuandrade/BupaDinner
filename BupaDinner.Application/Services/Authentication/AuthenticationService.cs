using BupaDinner.Application.Common.Interfaces.Authentication;

namespace BupaDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGerator)
    {
        _jwtTokenGerator = jwtTokenGerator;
    }

    public AuthenticationResult Login(string email, string password)
    {
        return new AuthenticationResult(Guid.NewGuid(),
                                        "first-name",
                                        "last-name",
                                        email,
                                        "token");
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {



        var token = _jwtTokenGerator.GenerateToken(Guid.NewGuid(), firstName, lastName);

       return new AuthenticationResult(Guid.NewGuid(),
                                        firstName,
                                        lastName,
                                        email,
                                        token);
    }
}