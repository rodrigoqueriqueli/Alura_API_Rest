using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    /// <summary>
    /// Class responsavel por add perfis utilizados pelo automapper
    /// </summary>
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            //metodos de mapping (de, para)
            CreateMap<CreateFilmeDto, Filme>();
            CreateMap<Filme, ReadFilmeDto>();
            CreateMap<UpdateFilmeDto, Filme>();
        }
    }
}
