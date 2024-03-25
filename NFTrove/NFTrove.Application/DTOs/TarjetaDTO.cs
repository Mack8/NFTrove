using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFTrove.Application.DTOs
{
    public record TarjetaDTO
    {
        [Display(Name = "ID")]
        public int ID { get; init; }

        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "{0} es requerido")]
        [StringLength(30, ErrorMessage = "{0} debe tener como máximo {1} caracteres.")]
        public string Tipo { get; init; }
    }
}