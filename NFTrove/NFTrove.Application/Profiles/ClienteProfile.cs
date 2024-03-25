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
    public class ClienteProfile : Profile
    {

        public ClienteProfile()
        {
            // Means: Source   , Destination and Reverse :)  
            CreateMap<ClienteDTO, Cliente>().ReverseMap();
        }

    }
}
