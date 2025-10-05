using AutoMapper;
using Domain.DTOs;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
