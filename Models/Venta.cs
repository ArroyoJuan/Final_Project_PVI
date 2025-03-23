using System.ComponentModel.DataAnnotations;

namespace Final_Project_PVI.Models
{
    public class Venta
    {
        [Key]
        public int IdVenta { get; set; }

        public DateTime Fecha { get; set; }
        public int IdCliente { get; set; }
        public int IdEmpleado { get; set; }
        public DateTime FechaAdicion { get; set; }
        public string AdicionadoPor { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string ModificacionPor { get; set; }
        public decimal Total { get; set; }
    }
}
