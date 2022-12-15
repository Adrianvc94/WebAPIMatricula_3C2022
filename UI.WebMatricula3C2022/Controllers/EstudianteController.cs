using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UI.WebMatricula3C2022.Logica;

namespace UI.WebMatricula3C2022.Controllers
{
    public class EstudianteController : Controller
    {
        LnEstudiante lnEstudiante = new LnEstudiante();

        [Authorize]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Index()
        {
            Models.Estudiante.Entrada.VerTodosEstudiantes parametro = new Models.Estudiante.Entrada.VerTodosEstudiantes();

            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");

            var listaEstudiante = await lnEstudiante.VerTodosEstudiantes(parametro, usuarioActual.Token);



            ///////// GRAFICOS CHART.JS ///////////////////////////////////////////
            ///
            
            var random = new Random();

            var etiquetas = new List<string>();
            var colores = new List<string>();   
            var valores = new List<string>();

            foreach (var estado in listaEstudiante.ListaEstudiantes.GroupBy(e => e.Estado)
                .Select(group => new
                {
                    Estado = group.Key,
                    Cantidad = group.Count()
                }).OrderBy(x => x.Estado))
            {
                string color = String.Format("#{0:X6}", random.Next(0x1000000));

                etiquetas.Add(estado.Estado);
                valores.Add(estado.Cantidad.ToString());
                colores.Add(color);
            }


            ViewBag.Etiquetas = JsonConvert.SerializeObject(etiquetas);
            ViewBag.Valores = JsonConvert.SerializeObject(valores);
            ViewBag.Colores = JsonConvert.SerializeObject(colores);



            /// 
            ///////// GRAFICOS CHART.JS ///////////////////////////////////////////



            return View(listaEstudiante.ListaEstudiantes);
        }

        [Authorize]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [HttpPost]
        public async Task<JsonResult> AgregarEstudiante(Models.Estudiante.Entrada.AgregarEstudiante agregarEstudiante)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnEstudiante.AgregarEstudiante(agregarEstudiante, usuarioActual.Token);

            if (codigo != null)
            {
                return Json(String.Format("El estudiante: {0} ha sido ingresado con éxito", agregarEstudiante.NombreCompleto));
            }
            else
            {
                return Json(String.Format("El estudiante: {0} no fue ingresado", agregarEstudiante.NombreCompleto));
            }
        }

        [Authorize]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [HttpPost]
        public async Task<JsonResult> EditarEstudiante(Models.Estudiante.Entrada.EditarEstudiante editarEstudiante)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnEstudiante.EditarEstudiante(editarEstudiante, usuarioActual.Token);

            if (codigo != null)
            {
                return Json(String.Format("El estudiante: {0} ha sido modificado con éxito", editarEstudiante.NombreCompleto));
            }
            else
            {
                return Json(String.Format("El estudiante: {0} no fue modificado", editarEstudiante.NombreCompleto));
            }
        }

        [Authorize]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [HttpPost]
        public async Task<JsonResult> EliminarEstudiante(Models.Estudiante.Entrada.EliminarEstudiante eliminarEstudiante)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnEstudiante.EliminarEstudiante(eliminarEstudiante, usuarioActual.Token);

            if (codigo != null)
            {
                return Json(String.Format("El estudiante: {0} ha sido eliminado con éxito", eliminarEstudiante.Codigo));
            }
            else
            {
                return Json(String.Format("El estudiante: {0} no fue eliminado", eliminarEstudiante.Codigo));
            }
        }

        [Authorize]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [HttpPost]
        public async Task<JsonResult> VerDetalleEstudiante(Models.Estudiante.Entrada.VerDetalleEstudiante veDetalleEstudiante)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var respuesta = await lnEstudiante.VerDetalleEstudiante(veDetalleEstudiante, usuarioActual.Token);

            return Json(respuesta);
        }




    }
}
