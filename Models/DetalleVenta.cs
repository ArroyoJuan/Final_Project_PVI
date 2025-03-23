using System.ComponentModel.DataAnnotations;

namespace Final_Project_PVI.Models
{
    public class DetalleVenta
    {
        [Key]
        [Required(ErrorMessage = "La identificacion es obligatorio")]
        public int DetalleId { get; set; }
        [Required(ErrorMessage = "La identificacion de la venta es obligatorio")]
        public int IdVenta { get; set; }
        [Required(ErrorMessage = "La identificacion del producto es obligatorio")]
        public int IdProducto { get; set; }
        [Required(ErrorMessage = "La cantidad es obligatorio es obligatorio")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
    }
}
