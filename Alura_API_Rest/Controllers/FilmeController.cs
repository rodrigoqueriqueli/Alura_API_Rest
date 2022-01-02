using FilmesApi.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)  //Filme que recebo vem do body da request
        {
            Filme filme = new Filme()
            {
                Titulo = filmeDto.Titulo,
                Genero = filmeDto.Genero,
                Diretor = filmeDto.Diretor,
                Duracao = filmeDto.Duracao
            };

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
            {
                ReadFilmeDto filmeDto = new ReadFilmeDto()
                {
                    Diretor = filme.Diretor,
                    Titulo = filme.Titulo,
                    Duracao = filme.Duracao,
                    Genero = filme.Genero,
                    Id = filme.Id,
                    MomentoDaConsulta = DateTime.Now
                };

                return Ok(filmeDto); //retorna 200 Ok com o filme
            }
                
            else
                return NotFound();
        }

        //IActionResult pra retornar resultado da action executada 
        //indico que vou receber id por parametro (url da request)
        [HttpPut("{id}")] 
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeASerAtualizadoDto)
        {
            var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);

            if (filme == null)
                return NotFound();
            else 
            {
                filme.Titulo = filmeASerAtualizadoDto.Titulo;
                filme.Diretor = filmeASerAtualizadoDto.Diretor;
                filme.Duracao = filmeASerAtualizadoDto.Duracao;
                filme.Genero = filmeASerAtualizadoDto.Genero;
                _context.SaveChanges(); //filme que foi recuperado e alterado, com o SaveChanges cravo
                return NoContent(); //boa pratica de retorno quando feito o put
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);

            if (filme == null)
                return NotFound();
            else
            {
                _context.Remove(filme);
                _context.SaveChanges();
                return NoContent(); //boa pratica de retorno quando feito o delete
            }
        }
    }
}
