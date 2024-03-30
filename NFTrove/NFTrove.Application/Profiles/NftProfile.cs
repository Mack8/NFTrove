using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFTrove.Application.DTOs;
using NFTrove.Infraestructure.Models;

namespace NFTrove.Application.Profiles
{
    public class NftProfile : Profile
    {
        public NftProfile()
        {

            CreateMap<NftDTO, Nft>();


            CreateMap<Nft, NftDTO>()
            .ForMember(dest => dest.Nombre, orig => orig.MapFrom(o => o.Nombre))
            .ForMember(dest => dest.Autor, orig => orig.MapFrom(o => o.Autor))
            .ForMember(dest => dest.Valor, orig => orig.MapFrom(o => o.Valor))
            .ForMember(dest => dest.CantidadInventario, orig => orig.MapFrom(o => o.CantidadInventario))
            .ForMember(dest => dest.Imagen, orig => orig.MapFrom(o => o.Imagen));
        }

    }
}
