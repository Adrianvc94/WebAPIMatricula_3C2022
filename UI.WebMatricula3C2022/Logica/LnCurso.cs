using Newtonsoft.Json;

namespace UI.WebMatricula3C2022.Logica
{
    public class LnCurso
    {


        LnConsumoAPI lnConsumoAPI;

        public LnCurso()
        {
            lnConsumoAPI = new LnConsumoAPI();
        }

        public async Task<Models.Curso.Salida.VerTodosCursos> VerTodosCursos(
            Models.Curso.Entrada.VerTodosCursos pDatos, string token)
        {
            string encabezado = "Curso/VerTodosCursos";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Curso.Salida.VerTodosCursos>(respuesta);
        }


    }
}
