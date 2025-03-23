using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Final_Project_PVI.Models
{
    public class AccesoDatos
    {
        private readonly string _conexion;
        public AccesoDatos(IConfiguration configuration)
        {
            _conexion = configuration.GetConnectionString("DefaultConnection");
        }
        //AgregarProducto
        public void AgregarProducto(Producto productos)
        {
            using (SqlConnection conn = new SqlConnection(_conexion))
            {
                try
                {
                    string query = "Exec sp_InsertarProducto @Nombre,@Descripcion,@Precio,@Stock,@IdProveedor,@AdicionadoPor";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", productos.Nombre);
                        cmd.Parameters.AddWithValue("@Descripcion", productos.Descripcion);
                        cmd.Parameters.AddWithValue("@Precio", productos.Precio);
                        cmd.Parameters.AddWithValue("@Stock", productos.Stock);
                        cmd.Parameters.AddWithValue("@IdProveedor", productos.IdProveedor);
                        cmd.Parameters.AddWithValue("@AdicionadoPor", productos.AdicionadoPor);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al registrar pedido " + ex.Message);
                }
            }
        }
        public List<Producto> ObtenerProductos()
        {
            List<Producto> productos = new List<Producto>();
            using(SqlConnection con=new SqlConnection(_conexion))
            {
                con.Open();
                using(SqlCommand cmd=new SqlCommand("sp_ConsultarProducto", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using(SqlDataReader reader=cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productos.Add(new Producto()
                            {
                                IdProducto = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Descripcion = reader.IsDBNull(2) ? "" : reader.GetString(2),
                                Precio = reader.GetDecimal(3),
                                Stock = reader.GetInt32(4),
                                IdProveedor = reader.IsDBNull(5) ? 0 : reader.GetInt32(5),
                                FechaAdicion = reader.GetDateTime(6),
                                AdicionadoPor = reader.IsDBNull(7) ? "" : reader.GetString(7),
                                FechaModificacion = reader.IsDBNull(8) ? DateTime.MinValue : reader.GetDateTime(8),
                                ModificacionPor = reader.IsDBNull(9) ? "" : reader.GetString(9)
                            });
                        }
                    }
                }
            }
            return productos;
        }
        public bool ConsultarUsuario(string getUsuarioToConsult, string getContraToConsult)
        {
            bool condicion = false;
            List<Usuario> usuario = new List<Usuario>();

            byte[] contrasenaBinary = ConvertirStringAVarBinary(getContraToConsult);

            using (SqlConnection con = new SqlConnection(_conexion))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("sp_ConsultarUsuario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@NombreUsuario", getUsuarioToConsult);
                    cmd.Parameters.AddWithValue("@Contraseña", contrasenaBinary);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            condicion = true;
                        }
                    }
                }
            }
            return condicion;
        }
        private byte[] ConvertirStringAVarBinary(string str)
        {
            return System.Text.Encoding.UTF8.GetBytes(str);
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
