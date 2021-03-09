using AutoMapper;
using Sistema.BackEnd.Models;
using Sistema.BackEnd.Models.Dtos;

namespace Sistema.BackEnd.CrossCutting.AutoMapperConfiguration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Categoria, CategoriaDto>();
            CreateMap<CategoriaDto, Categoria>();
        }
    }
}
