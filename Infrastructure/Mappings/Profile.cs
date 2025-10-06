using AutoMapper;
using Domain.DTOs;
using Domain.Entity;

namespace Infrastructure.Mappings
    {
    public class MapProfile : Profile
        {
        public MapProfile()
            {
            CreateMap<Banco, BancoDto>().ReverseMap();
            CreateMap<Boleto, BoletoDto>().ReverseMap();
            }
        }
    }
