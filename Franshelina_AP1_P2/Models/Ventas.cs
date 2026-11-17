using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Franshelina_AP1_P2.Models;

public class Ventas
{
    [Key]
    public int VentasId { get; set; }

    [Required(ErrorMessage ="Este campo es obligatorio")]
    public DateOnly? Fecha { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio")]
    public string? Observacion { get; set; }

    [Range(1, double.MaxValue, ErrorMessage = "El monto debe ser mayor a 0")]
    public double? Monto { get; set; }

    [InverseProperty("Ventas")]
    public ICollection<VentasDetalle>? VentasDetalle { get; set; } = new List<VentasDetalle>();
}
