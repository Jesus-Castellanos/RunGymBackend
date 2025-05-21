using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using RunGym.Repositorios.Interfaces;

namespace RunGym.Models
{
    public class PasosEjercicio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int EjercicioId { get; set; }
        public int NumeroPaso { get; set; }
        public string DescripcionPaso { get; set; }
        [JsonIgnore]
        public virtual Ejercicios Ejercicio { get; set; }
    }
}