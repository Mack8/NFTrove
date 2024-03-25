using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFTrove.Application.DTOs
{
    public record ClienteDTO
    {
        [Display(Name = "ID")]
        public Guid ID { get; init; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "{0} es requerido")]
        [StringLength(50, ErrorMessage = "{0} debe tener como máximo {1} caracteres.")]
        public string Nombre { get; init; }

        [Display(Name = "Apellidos")]
        [StringLength(50, ErrorMessage = "{0} debe tener como máximo {1} caracteres.")]
        public string Apellidos { get; init; }

        [Display(Name = "Identificación")]
        [StringLength(50, ErrorMessage = "{0} debe tener como máximo {1} caracteres.")]
        public string Identificacion { get; init; }

        [Display(Name = "Correo Electrónico")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
        [StringLength(100, ErrorMessage = "{0} debe tener como máximo {1} caracteres.")]
        public string CorreoElectronico { get; init; }

        public int PaisID { get; init; }
    }
}
