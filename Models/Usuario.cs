using System.ComponentModel.DataAnnotations;

namespace Final_Project_PVI.Models
{
    public class Usuario
    {
        [Key]
        [Required(ErrorMessage = "La identificacion es obligatorio")]
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }

        public string Rol { get; set; }
        public DateTime FechaAdicion { get; set; }
        public string AdicionadoPor { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string ModificacionPor { get; set; }
    }
}
