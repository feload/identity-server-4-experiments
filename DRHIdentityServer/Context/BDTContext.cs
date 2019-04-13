using DRHIdentityServer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRHIdentityServer.Context
{
    public class BDTContext : DbContext
    {
        public BDTContext(DbContextOptions<BDTContext> options): base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
    }    
}
