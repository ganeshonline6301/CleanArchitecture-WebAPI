﻿using CleanArch.Application.Common.Interfaces;
using CleanArch.Domain.ToDos;
using CleanArch.Domain.ToDos.Enums;
using ErrorOr;
using MediatR;

namespace CleanArch.Application.ToDos.Commands.UpdateTask;

public class CompleteToDoCommandHandler(IToDoRepository toDoRepository) : IRequestHandler<CompleteToDoCommand, ErrorOr<Updated>>
{
    public async Task<ErrorOr<Updated>> Handle(CompleteToDoCommand command, CancellationToken cancellationToken)
    {
        var result = await toDoRepository.GetByIdAsync(command.Id);

        if (result is null)
        {
            return Error.NotFound(description: "Task not found");    
        }

        var completeToDoResult = result.CompleteTask();
        if (completeToDoResult.IsError)
        {
            return completeToDoResult.Errors;
        }

        await toDoRepository.CompleteTaskAsync(command.Id);
        
        return Result.Updated;
    }
}