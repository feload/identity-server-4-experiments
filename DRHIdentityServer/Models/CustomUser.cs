using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRHIdentityServer.Models
{
    public class CustomUser
    {
        public string SubjectId { get; set; }        
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
