using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Franshelina_AP1_P2.Models;

public class VentasDetalle
{
    [Key]
    public int DetalleId { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio")]
    public int VentaId { get; set; }

    [ForeignKey("VentaId")]
    [InverseProperty("VentasDetalle")]
    public virtual Ventas? Ventas { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio")]
    public int ProductoId { get; set; }

    [ForeignKey("ProductoId")]
    public virtual Productos? Producto { get; set; }

    [Range(1, double.MaxValue, ErrorMessage = "El monto debe ser mayor a 0")]
    public double Precio { get; set; }

    [Range(1, double.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
    public int Cantidad { get; set; }
}
