using FilmesApi.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] //chamando o nome do controller (/filme, controller eh chamado)
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context;

        public FilmeController(FilmeContext context)
        {
            _context = context; 
        }

        /// <summary>
        /// Cadastrar filme
        /// </summary>
        [HttpPost] //criando recurso novo no sistema
        public IActionResult AdicionaFilme([FromBody] Filme filme)  //Filme que recebo vem do body da request
        {
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaFilmePorId), new { Id = filme.Id}, filme); //Retorna o status da requisicao e retorna em que lugar o recurso foi criado
        }

        [HttpGet] //recuperar recurso do sistema
        public IEnumerable<Filme> RecuperaFilmes()
        {
            return _context.Filmes;   
        } 

        [HttpGet("{id}")] //indico que vou receber id por parametro (url da request)
        public IActionResult RecuperaFilmePorId(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
            if (filme != null)
                return Ok(filme); //retorna 200 Ok com o filme
            else
                return NotFound();
        }
    }
}
