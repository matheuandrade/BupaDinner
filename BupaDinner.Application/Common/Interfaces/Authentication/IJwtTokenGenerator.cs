using BupaDinner.Domain.Entities;

namespace BupaDinner.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator 
{
    string GenerateToken(User user);
}