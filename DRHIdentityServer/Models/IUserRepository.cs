using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRHIdentityServer.Models
{
    public interface IUserRepository
    {
        bool ValidateCredentials(string correo, string password);
        Usuario FindBySubjectId(string subjectId);
        Usuario FindByCorreo(string correo);
    }
}
