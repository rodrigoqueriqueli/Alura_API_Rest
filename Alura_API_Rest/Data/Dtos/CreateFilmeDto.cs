using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos
{
    /// <summary>
    /// Dto voltado pra criar um recurso (filme) no sistema
    /// </summary>
    public class CreateFilmeDto
    {
        public string Titulo { get; set; }
        [Required(ErrorMessage = "The Director field is required.")]
        public string Diretor { get; set; }
        [StringLength(30, ErrorMessage = "Genre must be shorter.")]
        public string Genero { get; set; }
        [Range(1, 600, ErrorMessage = "The duration must be between 1 and 600 min")]
        public int Duracao { get; set; }
    }
}
