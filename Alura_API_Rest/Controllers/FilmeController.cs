using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] //chamando o nome do controller (/filme, controller eh chamado)
    public class FilmeController : ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>();
        private static int id = 1;

        /// <summary>
        /// Cadastrar filme
        /// </summary>
        [HttpPost] //criando recurso novo no sistema
        public IActionResult AdicionaFilme([FromBody] Filme filme)  //Filme que recebo vem do body da request
        {
            filme.Id = id++;
            filmes.Add(filme);
            return CreatedAtAction(nameof(RecuperaFilmePorId), new { Id = filme.Id}, filme); //Retorna o status da requisicao e retorna em que lugar o recurso foi criado
        }

        [HttpGet] //recuperar recurso do sistema
        public IActionResult RecuperaFilmes()
        {
            return Ok(filmes);
        } 

        [HttpGet("{id}")] //indico que vou receber id por parametro (url da request)
        public IActionResult RecuperaFilmePorId(int id)
        {
            var filme = filmes.FirstOrDefault(f => f.Id == id);
            if (filme != null)
                return Ok(filme); //retorna 200 Ok com o filme
            else
                return NotFound();
        }
    }
}
