using System.ComponentModel.DataAnnotations;

namespace CrudUniversity.Models
{
    public class Cursos
    {
        [Key]

        public int IdCurso { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public int Creditos { get; set; }

        public ICollection<Inscripcion> Inscripciones { get; set; }
    }
}
