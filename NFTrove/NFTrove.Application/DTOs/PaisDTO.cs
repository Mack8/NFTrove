using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NFTrove.Application.DTOs
{
    public record PaisDTO
    {
        public int ID { get; init; }

        [Display(Name = "ISO")]
        [Required(ErrorMessage = "{0} es requerido")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "{0} debe tener {1} caracteres.")]
        public string ISO { get; init; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "{0} es requerido")]
        [StringLength(100, ErrorMessage = "{0} debe tener como máximo {1} caracteres.")]
        public string Descripcion { get; init; }
    }
}
