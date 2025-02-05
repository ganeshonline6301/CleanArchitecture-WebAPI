namespace CleanArch.Api.Common.Contracts.Users;

public record UserResponse(
    string Name,
    string Email,
    Guid Id);