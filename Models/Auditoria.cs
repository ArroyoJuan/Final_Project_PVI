using System.ComponentModel.DataAnnotations;

namespace Final_Project_PVI.Models
{
    public class Auditoria
    {
        [Key]
        public int IdAuditoria { get; set; }
        public int IdRegistroAfectado { get; set; }
        public string Accion { get; set; }
        public string Usuario { get; set; }
        public DateTime Fecha { get; set; }
    }
}
