using Microsoft.AspNetCore.Mvc;
using Final_Project_PVI.Models;
using System.Diagnostics;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Final_Project_PVI.Controllers
{
    public class HomeController : Controller
    {
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
                _datos.AgregarProducto(producto);
                TempData["SuccessMessage"] = "Tu producto se guardo con exito.";
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
                    TempData["Usuario"] = usuario.NombreUsuario;
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

    }
}
