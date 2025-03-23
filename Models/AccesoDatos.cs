using Microsoft.Data.SqlClient;

namespace Final_Project_PVI.Models
{
    public class AccesoDatos
    {
        private readonly string _conexion;
        public AccesoDatos(IConfiguration configuration)
        {
            _conexion = configuration.GetConnectionString("DefaultConnection");
        }

        /*public void IngresarPedido(Pedidos pedido)
        {
            using (SqlConnection conn = new SqlConnection(_conexion))
            {
                try
                {
                    string query = "Exec IngresarPedido @Fecha,@Cliente,@Total,@Estado";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Fecha", pedido.Fecha);
                        cmd.Parameters.AddWithValue("@Cliente", pedido.Cliente);
                        cmd.Parameters.AddWithValue("@Total", pedido.Total);
                        cmd.Parameters.AddWithValue("@Estado", pedido.Estado);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al registrar pedido " + ex.Message);
                }
            }
        }*/
    }
}
