using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RunGym.Models
{
    public class Login
    {
       
        public string Correo { get; set; }

        public string Contraseña { get; set; }
    }
}
