using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DRHIdentityServer.Models
{
    [Table("usuarios")]
    public class Usuario
    {
        [Key]
        public int id { get; set; }
        public string correo { get; set; }
        public string contrasenia { get; set; }
    }
}
