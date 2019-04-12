using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using DRHIdentityServer.Models;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Test;


namespace DRHIdentityServer
{
    public class UserRepository : IUserRepository
    {        
        private readonly List<CustomUser> _users = new List<CustomUser>
        {
            new CustomUser{
                SubjectId = "123",
                UserName = "damienbod",
                Password = "damienbod"
            },
            new CustomUser{
                SubjectId = "124",
                UserName = "raphael",
                Password = "raphael"
            }
        };

        public bool ValidateCredentials(string username, string password)
        {
            var user = FindByUsername(username);
            if (user != null)
            {
                return user.Password.Equals(password);
            }

            return false;
        }

        public CustomUser FindBySubjectId(string subjectId)
        {
            return _users.FirstOrDefault(x => x.SubjectId == subjectId);
        }

        public CustomUser FindByUsername(string username)
        {
            return _users.FirstOrDefault(x => x.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));
        }
    }
}