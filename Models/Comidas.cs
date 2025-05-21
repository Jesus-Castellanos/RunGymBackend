using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RunGym.Models
{
    public class Comidas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdDieta { get; set; }
        public string TipoComida { get; set; }
        public DateTime HoraComida { get; set; }
        public string Descripcion { get; set; }

    }
}
