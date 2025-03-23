using System.ComponentModel.DataAnnotations;

namespace Final_Project_PVI.Models
{
    public class Empleado
    {
        [Key]
        [Required(ErrorMessage = "La identificacion es obligatorio")]
        public int IdEmpleado { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        public string Cargo { get; set; }
        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de correo no válido")]
        public string Correo { get; set; }
        public string Telefono { get; set; }
    }
}
