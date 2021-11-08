using System;
using System.Collections.Generic;
using MediatR;
using ModularRestaurant.Shared.Application.CQRS;

namespace ModularRestaurant.Menus.Application.Commands.ChangeGroups
{
    public record ChangeGroupsCommand(Guid MenuId, GroupsToAdd GroupsToAdd = null, 
        GroupsToUpdate GroupsToUpdate = null, GroupsToRemove GroupsToRemove = null) : ICommand<Unit>;

    public record GroupsToAdd(List<string> Names);

    public record GroupsToUpdate(List<UpdateGroup> Groups);

    public record UpdateGroup(Guid Id, string NewName);
    
    public record GroupsToRemove(List<Guid> Ids);
}