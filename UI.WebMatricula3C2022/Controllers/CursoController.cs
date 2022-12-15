using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UI.WebMatricula3C2022.Logica;

namespace UI.WebMatricula3C2022.Controllers
{
    public class CursoController : Controller
    {
        LnCurso lnCurso = new LnCurso();

        [Authorize]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Index()
        {
            Models.Curso.Entrada.VerTodosCursos parametro = new Models.Curso.Entrada.VerTodosCursos();

            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");

            var listaCurso = await lnCurso.VerTodosCursos(parametro, usuarioActual.Token);



            ///////// GRAFICOS CHART.JS ///////////////////////////////////////////
            ///

            var random = new Random();

            var etiquetas = new List<int>();
            var colores = new List<string>();
            var valores = new List<string>();

            foreach (var credito in listaCurso.ListaCursos.GroupBy(e => e.Creditos)
                .Select(group => new
                {
                    Credito = group.Key,
                    Cantidad = group.Count()
                }).OrderBy(x => x.Credito))
            {
                string color = String.Format("#{0:X6}", random.Next(0x1000000));

                etiquetas.Add(credito.Credito);
                valores.Add(credito.Cantidad.ToString());
                colores.Add(color);
            }


            ViewBag.Etiquetas = JsonConvert.SerializeObject(etiquetas);
            ViewBag.Valores = JsonConvert.SerializeObject(valores);
            ViewBag.Colores = JsonConvert.SerializeObject(colores);



            /// 
            ///////// GRAFICOS CHART.JS ///////////////////////////////////////////



            return View(listaCurso.ListaCursos);
        }

        [HttpPost]

        [Authorize]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<JsonResult> AgregarCurso(Models.Curso.Entrada.AgregarCurso agregarCurso)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnCurso.AgregarCurso(agregarCurso, usuarioActual.Token);

            if (codigo != null)
            {
                return Json(String.Format("El Curso: {0} ha sido ingresado con éxito", agregarCurso.Nombre));
            }
            else
            {
                return Json(String.Format("El Curso: {0} no fue ingresado", agregarCurso.Nombre));
            }
        }


        [HttpPost]
        [Authorize]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<JsonResult> EditarCurso(Models.Curso.Entrada.EditarCurso editarCurso)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnCurso.EditarCurso(editarCurso, usuarioActual.Token);

            if (codigo != null)
            {
                return Json(String.Format("El Curso: {0} ha sido modificado con éxito", editarCurso.Nombre));
            }
            else
            {
                return Json(String.Format("El Curso: {0} no fue modificado", editarCurso.Nombre));
            }
        }


        [HttpPost]
        [Authorize]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<JsonResult> EliminarCurso(Models.Curso.Entrada.EliminarCurso eliminarCurso)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnCurso.EliminarCurso(eliminarCurso, usuarioActual.Token);

            if (codigo != null)
            {
                return Json(String.Format("El Curso: {0} ha sido eliminado con éxito", eliminarCurso.Codigo));
            }
            else
            {
                return Json(String.Format("El Curso: {0} no fue eliminado", eliminarCurso.Codigo));
            }
        }


        [HttpPost]
        [Authorize]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<JsonResult> VerDetalleCurso(Models.Curso.Entrada.VerDetalleCurso veDetalleCurso)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var respuesta = await lnCurso.VerDetalleCurso(veDetalleCurso, usuarioActual.Token);

            return Json(respuesta);
        }




    }
}

