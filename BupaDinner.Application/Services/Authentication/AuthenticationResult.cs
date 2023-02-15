using BupaDinner.Domain.Entities;

namespace BupaDinner.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token
);