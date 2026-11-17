using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Franshelina_AP1_P2.Models;

public class Ventas
{
    [Key]
    public int VentaId { get; set; }

    [Required(ErrorMessage ="Este campo es obligatorio")]
    public DateTime? Fecha { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio")]
    public string Observacion { get; set; }

    public double Total { get; set; } = 0;

    [InverseProperty("Ventas")]
    public ICollection<VentasDetalle> VentasDetalle { get; set; } = new List<VentasDetalle>();
}
