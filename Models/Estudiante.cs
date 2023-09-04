using System.ComponentModel.DataAnnotations;

namespace CrudUniversity.Models
{
    public class Estudiante
    {
        [Key]
        public int IdEstudiante { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public String Nombre { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public String Apellido { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public DateTime FechaInscripcion { get; set; }

        public ICollection<Inscripcion> Inscripciones { get; set; }
    }
}
