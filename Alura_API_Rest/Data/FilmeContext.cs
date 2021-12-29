using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Data
{
    /// <summary>
    /// Classe responsavel pela parte de contexto entre aplicacao (API) e o BD
    /// </summary>
    public class FilmeContext : DbContext
    {
        //Set de dados do BD
        //Filme objeto q quero mapear e acessar no BD
        public DbSet<Filme> Filmes { get; set; } 

        //recebendo opcoes desse contexto
        public FilmeContext(DbContextOptions<FilmeContext> dbContextOptions)  : base (dbContextOptions) //passando opcoes para o construtor do DbContext
        {}


    }
}
