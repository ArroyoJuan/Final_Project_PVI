using Microsoft.AspNetCore.Mvc;
using Final_Project_PVI.Models;
using System.Diagnostics;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Final_Project_PVI.Controllers
{
    public class HomeController : Controller
    {
        AccesoDatos accesoDatos = new AccesoDatos();
        private string memoryUser = "";
        private readonly AccesoDatos _datos;
        public HomeController(AccesoDatos datos)
        {
            _datos = datos;
        }
        public IActionResult Start()
        {
            ViewData["HideMenu"] = true;
            return View();
        }
        [HttpPost]
        public IActionResult GoToMain()
        {
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Main()
        {
            return View();
        }
        public IActionResult Productos()
        {
            return View();
        }
        public IActionResult _1C_Productos()
        {
            List<Producto> productos = _datos.ObtenerProductos(); 
            ViewBag.Productos = productos;
            return View(new Producto());
        }
        public IActionResult Cre_Pro(Producto producto)
        {
            try
            {
                var nombreUsuario = HttpContext.Session.GetString("NombreUsuario");
                if (string.IsNullOrEmpty(nombreUsuario))
                {
                    TempData["ErrorMessage"] = "Sesión expirada o no iniciada.";
                    return RedirectToAction("Start");
                }

                producto.AdicionadoPor = nombreUsuario;
                _datos.AgregarProducto(producto);
                TempData["SuccessMessage"] = "Tu producto se guardó con éxito.";
                return RedirectToAction("_1C_Productos");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Tu producto no se guardó. Error: " + ex.Message;
                return RedirectToAction("_1C_Productos");
            }
        }
        public IActionResult Log_In(Usuario usuario)
        {
            try
            {
                if (_datos.ConsultarUsuario(usuario.NombreUsuario, usuario.Contraseña))
                {
                    HttpContext.Session.SetString("NombreUsuario", usuario.NombreUsuario);
                    return RedirectToAction("_1C_Productos");
                }
                else
                {
                    TempData["ErrorMessage"] = "Usuario o contraseña incorrectos.";
                    return RedirectToAction("Start");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error al iniciar sesión. Error: " + ex.Message;
                return RedirectToAction("Start");
            }
        }
        public IActionResult Eli_Pro(int id)
        {
            try
            {
                _datos.EliminarProducto(id);
                TempData["SuccessMessage"] = "El producto se ha eliminado con éxito.";
                return Ok();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "No se pudo eliminar el producto. Error: " + ex.Message;
                return StatusCode(500, "Error interno del servidor");
            }
        }
        public IActionResult Edi_Pro([FromBody] Producto producto)
        {
            try
            {
                var nombreUsuario = HttpContext.Session.GetString("NombreUsuario");
                if (string.IsNullOrEmpty(nombreUsuario))
                {
                    TempData["ErrorMessage"] = "Sesión expirada o no iniciada.";
                    return RedirectToAction("Start");
                }

                _datos.ActualizarProducto(
                    producto.IdProducto,
                    producto.Nombre,
                    producto.Descripcion,
                    Convert.ToDouble(producto.Precio),
                    producto.Stock,
                    producto.IdProveedor,
                    nombreUsuario
                );

                TempData["SuccessMessage"] = "El producto se ha actualizado con éxito.";
                return Ok();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "No se pudo actualizar el producto. Error: " + ex.Message;
                return StatusCode(500, "Error interno del servidor");
            }
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(5);
            });
            services.AddControllersWithViews();
        }
    }
}
