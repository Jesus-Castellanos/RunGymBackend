using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RunGym.Models
{
    public class Ejercicios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public string? ImagenURL { get; set; }
        [JsonIgnore]
        public virtual ICollection<DetallesEjercicio> Detalles { get; set; }
        [JsonIgnore]
        public virtual ICollection<PasosEjercicio> Pasos { get; set; }
    }
}