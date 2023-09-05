using System.ComponentModel.DataAnnotations;

namespace CrudUniversity.Models
{
    public class Cursos
    {
        [Key]

        public int IdCurso { get; set; }

        [RegularExpression(@"^[A-Za-z\s]*$", ErrorMessage = "El título solo debe contener letras")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [Range(1, 12, ErrorMessage = "Los créditos deben estar en el rango de 1 a 12.")]
        public int Creditos { get; set; }


        public ICollection<Inscripcion> Inscripciones { get; set; }
    }
}
