using AutoMapper;
using NFTrove.Application.DTOs;
using NFTrove.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFTrove.Application.Profiles
{
    public class TarjetaProfile : Profile
    {

        public TarjetaProfile()
        {
            
            CreateMap<TarjetaDTO, Tarjeta>().ReverseMap();
        }

    }
}
