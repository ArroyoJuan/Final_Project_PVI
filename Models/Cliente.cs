using System.ComponentModel.DataAnnotations;

namespace Final_Project_PVI.Models
{
    public class Cliente
    {
        [Key]
        [Required(ErrorMessage = "La identificacion es obligatorio")]
        public int IdCliente { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de correo no válido")]
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string Pais { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public DateTime FechaAdicion { get; set; }
        public string AdicionadoPor { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string ModificacionPor { get; set; }
    }
    public class ClienteViewModel
    {
        public Cliente NuevoMensaje { get; set; }
        public List<Cliente> Mensajes { get; set; } = new List<Cliente>();
    }
}
