using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UI.WebMatricula3C2022.Logica;

namespace UI.WebMatricula3C2022.Controllers
{
    public class NotaController : Controller
    {


        LnNota lnNota = new LnNota();
        LnEstudiante lnEstudiante = new LnEstudiante();
        LnCurso lnCurso = new LnCurso();
        //LnProfesor lnProfesor = new LnProfesor();



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Index()
        {
            Models.Nota.Entrada.VerTodosNotas parametro = new Models.Nota.Entrada.VerTodosNotas();
            Models.Estudiante.Entrada.VerTodosEstudiantes paramEstudiante = new Models.Estudiante.Entrada.VerTodosEstudiantes();
            Models.Curso.Entrada.VerTodosCursos paramCurso = new Models.Curso.Entrada.VerTodosCursos();
            //Models.Profesor.Entrada.VerTodosProfesores paramProfesor = new Models.Profesor.Entrada.VerTodosProfesores();



            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");

            var listaNota = await lnNota.VerTodosNotas(parametro, usuarioActual.Token);

            var listaEstudiante = await lnEstudiante.VerTodosEstudiantes(paramEstudiante, usuarioActual.Token);
            var listaCurso = await lnCurso.VerTodosCursos(paramCurso, usuarioActual.Token);
            //var LnProfesor = await lnProfesor.VerTodosProfesores(paramProfesor, usuarioActual.Token);

            //int CodigoCurso = 2;

            //var prueba5 = ((IEnumerable<UI.WebMatricula3C2022.Models.Curso.Salida.DatosCursos>)listaCurso.ListaCursos).Where(x => x.Codigo == CodigoCurso).First();

            //@((IEnumerable<UI.WebMatricula3C2022.Models.Curso.Salida.DatosCursos>)listaCursos).Where(x => x.Codigo == item.Codigo).First()

            //var prueba = listaCurso.ListaCursos.Where(x => x.Codigo == CodigoCurso).First();

            //var pasd = listaCurso.ListaCursos[0];

            ViewBag.Estudiantes = listaEstudiante.ListaEstudiantes;
            ViewBag.Cursos = listaCurso.ListaCursos;
            //ViewBag.Profesores = LnProfesor.ListaProfesores;


            ///////// GRAFICOS CHART.JS ///////////////////////////////////////////
            ///

            var random = new Random();

            var etiquetas = new List<string>();
            var colores = new List<string>();
            var valores = new List<string>();

            foreach (var estado in listaNota.ListaNotas.GroupBy(e => e.Estado)
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





            return View(listaNota.ListaNotas);
        }

        [HttpPost]
        public async Task<JsonResult> AgregarNota(Models.Nota.Entrada.AgregarNota agregarNota)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnNota.AgregarNota(agregarNota, usuarioActual.Token);

            if (codigo != null)
            {
                return Json(String.Format("La Nota ha sido ingresado con éxito"));
            }
            else if(codigo.Codigo == 0)
            {
                return Json(String.Format("No se pudo ingresar la nota"));
            }
            else
            {
                return Json(String.Format("El Nota no fue ingresado"));
            }
        }


        [HttpPost]
        public async Task<JsonResult> EditarNota(Models.Nota.Entrada.EditarNota editarNota)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnNota.EditarNota(editarNota, usuarioActual.Token);

            if (codigo != null)
            {
                return Json(String.Format("La nota ha sido modificado con éxito"));
            }
            else if (codigo.Codigo == 0)
            {
                return Json(String.Format("No se pudo modificar la nota"));
            }
            else
            {
                return Json(String.Format("La nota no fue modificado"));
            }
        }


        [HttpPost]
        public async Task<JsonResult> EliminarNota(Models.Nota.Entrada.EliminarNota eliminarNota)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnNota.EliminarNota(eliminarNota, usuarioActual.Token);

            if (codigo != null)
            {
                return Json(String.Format("La nota: {0} ha sido eliminado con éxito", eliminarNota.Codigo));
            }
            else
            {
                return Json(String.Format("La nota: {0} no fue eliminado", eliminarNota.Codigo));
            }
        }


        [HttpPost]
        public async Task<JsonResult> VerDetalleNota(Models.Nota.Entrada.VerDetalleNota veDetalleNota)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var respuesta = await lnNota.VerDetalleNota(veDetalleNota, usuarioActual.Token);

            return Json(respuesta);
        }



    }
}
