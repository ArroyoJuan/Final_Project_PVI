using System.ComponentModel.DataAnnotations;

namespace Final_Project_PVI.Models
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        public string Nombre { get; set; }

        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int IdProveedor { get; set; }
        public DateTime FechaAdicion { get; set; }
        public string AdicionadoPor { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string ModificacionPor { get; set; }
    }
}
