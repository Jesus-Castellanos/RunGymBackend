using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using RunGym.Repositorios.Interfaces;

namespace RunGym.Models
{
    public class DetallesEjercicio
    {
        public int Id { get; set; }
        public int EjercicioId { get; set; }
        public string Descripcion { get; set; }
        public string Repeticiones { get; set; }
        public string Descanso { get; set; }
        public string Cuidados { get; set; }
        public string URLVideo { get; set; }

        // Relación con Ejercicio
        public virtual Ejercicios Ejercicio { get; set; }
    }

}