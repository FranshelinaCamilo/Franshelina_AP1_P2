using System.ComponentModel.DataAnnotations;

namespace Franshelina_AP1_P2.Models;

public class Productos
{
    [Key]
    public int ProductoId { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio")]
    public string? Descripcion { get; set; }

    [Range(1, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
    public double? Precio { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "La existencia debe ser mayor a 0")]
    public int? Stock { get; set; } = 10;
}
