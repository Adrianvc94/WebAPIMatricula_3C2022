using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UI.WebMatricula3C2022.Logica;

namespace UI.WebMatricula3C2022.Controllers
{
    public class ColegiaturaController : Controller
    {


        LnColegiatura lnColegiatura = new LnColegiatura();

        [Authorize]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Index()
        {
            Models.Colegiatura.Entrada.VerTodosColegiaturas parametro = new Models.Colegiatura.Entrada.VerTodosColegiaturas();

            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");

            var listaColegiatura = await lnColegiatura.VerTodosColegiaturas(parametro, usuarioActual.Token);



            ///////// GRAFICOS CHART.JS ///////////////////////////////////////////
            ///

            var random = new Random();

            var etiquetas = new List<string>();
            var colores = new List<string>();
            var valores = new List<string>();

            foreach (var acreditada in listaColegiatura.ListaColegiaturas.GroupBy(e => e.Acreditada)
                .Select(group => new
                {
                    Acreditada = group.Key,
                    Cantidad = group.Count()
                }).OrderBy(x => x.Acreditada))
            {
                string color = String.Format("#{0:X6}", random.Next(0x1000000));

                etiquetas.Add(acreditada.Acreditada);
                valores.Add(acreditada.Cantidad.ToString());
                colores.Add(color);
            }


            ViewBag.Etiquetas = JsonConvert.SerializeObject(etiquetas);
            ViewBag.Valores = JsonConvert.SerializeObject(valores);
            ViewBag.Colores = JsonConvert.SerializeObject(colores);



            /// 
            ///////// GRAFICOS CHART.JS ///////////////////////////////////////////



            return View(listaColegiatura.ListaColegiaturas);
        }

        [Authorize]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [HttpPost]
        public async Task<JsonResult> AgregarColegiatura(Models.Colegiatura.Entrada.AgregarColegiatura agregarColegiatura)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnColegiatura.AgregarColegiatura(agregarColegiatura, usuarioActual.Token);

            if (codigo != null)
            {
                return Json(String.Format("La colegiatura: {0} ha sido ingresada con éxito", agregarColegiatura.Nombre));
            }
            else
            {
                return Json(String.Format("La colegiatura: {0} no fue ingresada", agregarColegiatura.Nombre));
            }
        }

        [Authorize]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [HttpPost]
        public async Task<JsonResult> EditarColegiatura(Models.Colegiatura.Entrada.EditarColegiatura editarColegiatura)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnColegiatura.EditarColegiatura(editarColegiatura, usuarioActual.Token);

            if (codigo != null)
            {
                return Json(String.Format("La colegiatura: {0} ha sido modificada con éxito", editarColegiatura.Nombre));
            }
            else
            {
                return Json(String.Format("La colegiatura: {0} no fue modificada", editarColegiatura.Nombre));
            }
        }

        [Authorize]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [HttpPost]
        public async Task<JsonResult> EliminarColegiatura(Models.Colegiatura.Entrada.EliminarColegiatura eliminarColegiatura)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnColegiatura.EliminarColegiatura(eliminarColegiatura, usuarioActual.Token);

            if (codigo != null)
            {
                return Json(String.Format("La colegiatura: {0} ha sido eliminada con éxito", eliminarColegiatura.Codigo));
            }
            else
            {
                return Json(String.Format("La colegiatura: {0} no fue eliminada", eliminarColegiatura.Codigo));
            }
        }

        [Authorize]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [HttpPost]
        public async Task<JsonResult> VerDetalleColegiatura(Models.Colegiatura.Entrada.VerDetalleColegiatura veDetalleColegiatura)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var respuesta = await lnColegiatura.VerDetalleColegiatura(veDetalleColegiatura, usuarioActual.Token);

            return Json(respuesta);
        }


    }
}
