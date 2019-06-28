﻿using ExamenNet.Models;
using ExamenNet.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenNet.Validators
{
    public interface IUserRoleValidator
    {
        ErrorsCollection Validate(UserUserRolePostModel userUserRolePostModel, MoviesDbContext context);
    }


    public class UserRoleValidator : IUserRoleValidator
    {
        public ErrorsCollection Validate(UserUserRolePostModel userUserRolePostModel, MoviesDbContext context)
        {
            ErrorsCollection errorsCollection = new ErrorsCollection { Entity = nameof(UserUserRolePostModel) };

            List<string> userRoles = context.UserRoles
                .Select(userRole => userRole.Name)
                .ToList();

            if (!userRoles.Contains(userUserRolePostModel.UserRoleName))
            {
                errorsCollection.ErrorMessages.Add($"The userRole {userUserRolePostModel.UserRoleName} does not exists in Db!");
            }

            if (errorsCollection.ErrorMessages.Count > 0)
            {
                return errorsCollection;
            }
            return null;
        }
    }
}

