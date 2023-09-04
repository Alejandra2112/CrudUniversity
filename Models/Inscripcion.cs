using System.ComponentModel.DataAnnotations;

namespace CrudUniversity.Models
{
    public enum grado
    {
        A, B, C, D, E, F
    }
    public class Inscripcion
    {
        [Key]
        public int IdInscripcion { get; set; }

        public int IdCurso { get; set; }

        public int IdEstudiante { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public grado? grado { get; set; }

        public Cursos? cursos { get; set; }
        public Estudiante? estudiante { get; set; }
    }
}
