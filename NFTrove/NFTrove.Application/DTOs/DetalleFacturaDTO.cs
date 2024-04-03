using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFTrove.Application.DTOs;

public record DetalleFacturaDTO
{
    public int FacturaId { get; set; }

    [Display(Name = "No")]
    public int DetalleId { get; set; }

    [Display(Name = "NFT")]
    public Guid NftId { get; set; }


    [Display(Name = "Cantidad")]
    public int Cantidad { get; set; }

    [DisplayFormat(DataFormatString = "{0:n2}")]
    [Display(Name = "Precio")]
    public decimal Precio { get; set; }

    public decimal TotalLinea { get; set; }
}
