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
        public void AdicionaFilme([FromBody] Filme filme)  //Filme que recebo vem do body da request
        {
            filme.Id = id++;
            filmes.Add(filme);
        }

        [HttpGet] //recuperar recurso do sistema
        public IEnumerable<Filme> RecuperarFilmes()
        {
            return filmes;
        } 
    }
}
