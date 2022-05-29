﻿using ComicBookStoreAPI.Domain.Authorization.Requirements;
using ComicBookStoreAPI.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ComicBookStoreAPI.Domain.Authorization.RequirementHandler
{
    public class ResourceOperationRequirementHandler : AuthorizationHandler<ResourceOperationRequirement, Rating>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ResourceOperationRequirement requirement, Rating resource)
        {
            if (requirement.ResourceOperation == ResourceOperation.Read)
            {
                context.Succeed(requirement);
            }


            string userId = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;

            if (userId == null)
            {
                throw new Exception("Unable to get User Id during auth authorization");
            }

            if (requirement.ResourceOperation == ResourceOperation.Update && resource.User.Id == userId)
            {
                context.Succeed(requirement);
            }


            return Task.CompletedTask;
        }
    }
}