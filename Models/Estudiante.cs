using System.ComponentModel.DataAnnotations;

namespace CrudUniversity.Models
{
    public class Estudiante
    {
        [Key]
        public int IdEstudiante { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [RegularExpression(@"^[A-Za-z\s]*$", ErrorMessage = "El nombre solo debe contener letras.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [RegularExpression(@"^[A-Za-z\s]*$", ErrorMessage = "El apellido solo debe contener letras")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public DateTime FechaInscripcion { get; set; }

        public ICollection<Inscripcion> Inscripciones { get; set; }
    }
}
