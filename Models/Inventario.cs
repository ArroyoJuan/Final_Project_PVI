using System.ComponentModel.DataAnnotations;

namespace Final_Project_PVI.Models
{
    public class Inventario
    {
        [Key]
        public int IdInventario { get; set; }

        public int IdProducto { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int StockAnual { get; set; }
    }
}
