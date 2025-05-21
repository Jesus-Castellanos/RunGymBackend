using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RunGym.Models
{
    public class Usuarios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get;  set; }
        public string TipoDocumento { get; set; }
        public string Documento { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public string Celular {  get; set; }
        public string Genero { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Peso { get; set; }
        public Decimal Altura { get; set; }
        public byte HorasSueno { get; set; }
        public string ConsumoAgua { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        public string? CodigoVerificacion { get; set; }
        public DateTime? CodigoExpira { get; set; }
    }
}