using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFTrove.Application.DTOs
{
    public record EncabezadoFacturaDTO
    {
        [Display(Name = "No Factura")]
        [ValidateNever]
        public int FacturaId { get; set; }


        [Display(Name = "No Cliente")]
        public Guid ClienteId { get; set; }


        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "No Tarjeta")]
        public int TarjetaId { get; set; }

        [Display(Name = "Estado de la Factura")]
        public int EstadoFactura { get; set; }


        public List<DetalleFacturaDTO> ListDetalleFactura = null!;

    }
}
