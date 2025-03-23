using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Project_PVI.Models
{
    public class Proveedor
    {
        [Key]
        [Required(ErrorMessage = "La identificacion es obligatorio")]
        public int IdProveedor { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de correo no válido")]
        public string Correo { get; set; }
        public string Direccion { get; set; }
    }
    public class ProveedorViewModel
    {
        public Proveedor NuevoMensaje { get; set; }
        public List<Proveedor> Mensajes { get; set; } = new List<Proveedor>();
    }
}
