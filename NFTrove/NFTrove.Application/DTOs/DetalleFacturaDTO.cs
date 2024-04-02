using System;
using System.ComponentModel.DataAnnotations;

namespace NFTrove.Application.DTOs
{
    public record DetalleFacturaDTO
    {
        public int DetalleID { get; init; }

        [Display(Name = "Factura ID")]
        [Required(ErrorMessage = "{0} es requerido")]
        public int FacturaID { get; init; }

        [Display(Name = "NFT ID")]
        [Required(ErrorMessage = "{0} es requerido")]
        public Guid NFTID { get; init; }

        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "{0} es requerida")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} debe ser mayor que 0.")]
        public int Cantidad { get; init; }

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "{0} es requerido")]
        [Range(0, double.MaxValue, ErrorMessage = "{0} debe ser un número positivo.")]
        public decimal Precio { get; init; }

        [Display(Name = "Total de la línea")]
        [Required(ErrorMessage = "{0} es requerido")]
        [Range(0, double.MaxValue, ErrorMessage = "{0} debe ser un número positivo.")]
        public decimal TotalLinea { get; init; }

        [Display(Name = "Estado de la factura")]
        [Required(ErrorMessage = "{0} es requerido")]
        public int EstadoFactura { get; init; }
    }
}
