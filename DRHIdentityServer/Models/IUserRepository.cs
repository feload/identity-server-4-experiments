using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRHIdentityServer.Models
{
    public interface IUserRepository
    {
        bool ValidateCredentials(string username, string password);
        CustomUser FindBySubjectId(string subjectId);
        CustomUser FindByUsername(string username);
    }
}
