using Newtonsoft.Json;

namespace UI.WebMatricula3C2022.Logica
{
    public class LnProfesor
    {

        LnConsumoAPI lnConsumoAPI;

        public LnProfesor()
        {
            lnConsumoAPI = new LnConsumoAPI();
        }

        public async Task<Models.Profesor.Salida.VerTodosProfesores> VerTodosProfesores(
            Models.Profesor.Entrada.VerTodosProfesores pDatos, string token)
        {
            string encabezado = "Profesor/VerTodosProfesores";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Profesor.Salida.VerTodosProfesores>(respuesta);
        }


    }
}
