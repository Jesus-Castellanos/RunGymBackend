using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RunGym.Models
{
    public class Metas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string MetaPrincipal { get; set; }
        public string CuerpoActual { get; set; }
        public string CuerpoDeseado { get; set; }
        public string Descripción { get; set; }
        public DateTime FechaObjetivo { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

    }
}