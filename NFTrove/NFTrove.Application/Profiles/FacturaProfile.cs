using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NFTrove.Application.DTOs;
using NFTrove.Infraestructure.Models;

namespace NFTrove.Application.Profiles;

public class FacturaProfile : Profile
{
    public FacturaProfile()
    {
        CreateMap<EncabezadoFacturaDTO, EncabezadoFactura>().ReverseMap();
        CreateMap<DetalleFacturaDTO, DetalleFactura>().ReverseMap();

        CreateMap<EncabezadoFacturaDTO,EncabezadoFactura >()
             .ForMember(dest => dest.FacturaId, orig => orig.MapFrom(x => x.FacturaId))
             .ForMember(dest => dest.ClienteId, orig => orig.MapFrom(x => x.ClienteId))
             .ForMember(dest => dest.TarjetaId, orig => orig.MapFrom(x => x.TarjetaId))
             .ForMember(dest => dest.EstadoFactura, orig => orig.MapFrom(x => x.EstadoFactura))
             .ForMember(dest => dest.DetalleFactura, orig => orig.MapFrom(x => x.ListDetalleFactura));
    }
}
