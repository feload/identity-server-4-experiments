using DRHIdentityServer.Models;
using IdentityModel;
using IdentityServer4.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRHIdentityServer.Validator
{
    public class CustomResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IUserRepository _userRepository;

        public CustomResourceOwnerPasswordValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            if (_userRepository.ValidateCredentials(context.UserName, context.Password))
            {
                var user = _userRepository.FindByCorreo(context.UserName);
                context.Result = new GrantValidationResult(user.id.ToString(), OidcConstants.AuthenticationMethods.Password);
            }

            return Task.FromResult(0);
        }
    }
}
