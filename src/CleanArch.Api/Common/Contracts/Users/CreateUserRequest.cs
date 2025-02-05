namespace CleanArch.Api.Common.Contracts.Users;

public record CreateUserRequest(
    string Name,
    string Email);