using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFTrove.Application.DTOs
{
    public record FacturaDTO
    {

        [Display(Name = "No Factura")]
        [ValidateNever]
        public int FacturaId { get; set; }


        [Display(Name = "Tipo Tarjeta")]

        [Required(ErrorMessage = "{0} es requerido")]
        public int IdTarjeta { get; set; }

        public List<DetalleFacturaDTO> ListDetalleFacturaDTO = null!;

    }
}
