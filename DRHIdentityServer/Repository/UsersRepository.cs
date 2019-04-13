using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using DRHIdentityServer.Context;
using DRHIdentityServer.Models;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Test;


namespace DRHIdentityServer
{
    public class UserRepository : IUserRepository
    {
        private BDTContext context;
        public UserRepository(BDTContext ctxt){
            context = ctxt;
        }

        public bool ValidateCredentials(string correo, string password)
        {
            var user = FindByCorreo(correo);
            if (user != null)
            {
                return user.contrasenia.Equals(password);
            }

            return false;
        }

        public Usuario FindByCorreo(string correo)
        {
            return context.Usuarios.FirstOrDefault(x => x.correo.Equals(correo, StringComparison.OrdinalIgnoreCase));
        }

        public Usuario FindBySubjectId(string subjectId)
        {
            return context.Usuarios.FirstOrDefault(u => u.id.ToString().Equals(subjectId));
        }
    }
}