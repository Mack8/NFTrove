using System;
using System.ComponentModel.DataAnnotations;

namespace NFTrove.Application.DTOs
{
    public record FacturaDTO
    {
        public int FacturaID { get; init; }

        [Display(Name = "Cliente ID")]
        [Required(ErrorMessage = "{0} es requerido")]
        public Guid ClienteID { get; init; }

        [Display(Name = "Fecha de Factura")]
        [Required(ErrorMessage = "{0} es requerida")]
        [DataType(DataType.Date)]
        public DateTime FechaFactura { get; init; }

        [Display(Name = "Total")]
        [Required(ErrorMessage = "{0} es requerido")]
        [Range(0, double.MaxValue, ErrorMessage = "{0} debe ser un número positivo.")]
        public decimal Total { get; init; }

        [Display(Name = "Tarjeta ID")]
        [Required(ErrorMessage = "{0} es requerido")]
        public int TarjetaID { get; init; }

        [Display(Name = "Estado de Factura")]
        [Required(ErrorMessage = "{0} es requerido")]
        public int EstadoFactura { get; init; }
    }
}
