using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Data
{
    /// <summary>
    /// Classe responsavel pela parte de contexto entre aplicacao (API) e o BD
    /// </summary>
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> opt) : base(opt)
        {

        }

        public FilmeContext()
        {

        }

        public DbSet<Filme> Filmes { get; set; }

    }
}