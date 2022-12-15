using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UI.WebMatricula3C2022.Logica;

namespace UI.WebMatricula3C2022.Controllers
{
    public class HorarioController : Controller
    {
        LnHorario lnHorario = new LnHorario();


        [Authorize]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Index()
        {
            Models.Horario.Entrada.VerTodosHorarios parametro = new Models.Horario.Entrada.VerTodosHorarios();

            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");

            var listaHorario = await lnHorario.VerTodosHorarios(parametro, usuarioActual.Token);



            ///////// GRAFICOS CHART.JS ///////////////////////////////////////////
            ///

            var random = new Random();

            var etiquetas = new List<string>();
            var colores = new List<string>();
            var valores = new List<string>();

            foreach (var dia in listaHorario.ListaHorarios.GroupBy(e => e.Dia)
                .Select(group => new
                {
                    Dia = group.Key,
                    Cantidad = group.Count()
                }).OrderBy(x => x.Dia))
            {
                string color = String.Format("#{0:X6}", random.Next(0x1000000));

                etiquetas.Add(dia.Dia);
                valores.Add(dia.Cantidad.ToString());
                colores.Add(color);
            }


            ViewBag.Etiquetas = JsonConvert.SerializeObject(etiquetas);
            ViewBag.Valores = JsonConvert.SerializeObject(valores);
            ViewBag.Colores = JsonConvert.SerializeObject(colores);



            /// 
            ///////// GRAFICOS CHART.JS ///////////////////////////////////////////



            return View(listaHorario.ListaHorarios);
        }

        [HttpPost]
        [Authorize]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<JsonResult> AgregarHorario(Models.Horario.Entrada.AgregarHorario agregarHorario)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnHorario.AgregarHorario(agregarHorario, usuarioActual.Token);

            if (codigo != null)
            {
                return Json(String.Format("El Horario: {0} ha sido ingresado con éxito", agregarHorario.Dia, agregarHorario.Aula));
            }
            else
            {
                return Json(String.Format("El Horario: {0} no fue ingresado", agregarHorario.Dia, agregarHorario.Aula));
            }
        }


        [HttpPost]
        [Authorize]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<JsonResult> EditarHorario(Models.Horario.Entrada.EditarHorario editarHorario)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnHorario.EditarHorario(editarHorario, usuarioActual.Token);

            if (codigo != null)
            {
                return Json(String.Format("El Horario: {0} ha sido modificado con éxito", editarHorario.Dia, editarHorario.Aula));
            }
            else
            {
                return Json(String.Format("El Horario: {0} no fue modificado", editarHorario.Dia, editarHorario.Aula));
            }
        }


        [HttpPost]
        [Authorize]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<JsonResult> EliminarHorario(Models.Horario.Entrada.EliminarHorario eliminarHorario)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnHorario.EliminarHorario(eliminarHorario, usuarioActual.Token);

            if (codigo != null)
            {
                return Json(String.Format("El Horario: {0} ha sido eliminado con éxito", eliminarHorario.Codigo));
            }
            else
            {
                return Json(String.Format("El Horario: {0} no fue eliminado", eliminarHorario.Codigo));
            }
        }


        [HttpPost]
        [Authorize]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<JsonResult> VerDetalleHorario(Models.Horario.Entrada.VerDetalleHorario veDetalleHorario)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var respuesta = await lnHorario.VerDetalleHorario(veDetalleHorario, usuarioActual.Token);

            return Json(respuesta);
        }




    }
}

