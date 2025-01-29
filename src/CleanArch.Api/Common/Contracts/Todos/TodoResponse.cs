namespace CleanArch.Api.Common.Contracts.Todos;

public record TodoResponse(Guid Id, string Title, string Description, Guid UserId);