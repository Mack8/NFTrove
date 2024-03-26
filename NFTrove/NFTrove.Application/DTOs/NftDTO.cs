using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFTrove.Application.DTOs;

public record NftDTO
{
    [Display(Name = "ID")]
    public Guid ID { get; init; }

    [Display(Name = "Nombre")]
    [Required(ErrorMessage = "{0} es requerido")]
    [StringLength(50, ErrorMessage = "{0} debe tener como máximo {1} caracteres.")]
    public string Nombre { get; init; }

    [Display(Name = "Autor")]
    [Required(ErrorMessage = "{0} es requerido")]
    [StringLength(50, ErrorMessage = "{0} debe tener como máximo {1} caracteres.")]
    public string Autor { get; init; }

    [Display(Name = "Valor")]
    [Range(0, 999999999, ErrorMessage = "El valor mínimo es {0}")]
    [Required(ErrorMessage = "{0} es requerido")]
    public decimal? Valor { get; set; }

    [Display(Name = "Cantidad")]
    [Range(0, 999999999, ErrorMessage = "El valor mínimo es {0}")]
    [Required(ErrorMessage = "{0} es requerido")]
    public int Cantidad { get; set; }

    [Display(Name = "Imagen")]
    [Required(ErrorMessage = "{0} es requerido")]
    public byte[] Imagen { get; set; } = null!;
}
