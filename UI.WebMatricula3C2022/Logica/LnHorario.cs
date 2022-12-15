using Newtonsoft.Json;

namespace UI.WebMatricula3C2022.Logica
{
    public class LnHorario
    {
        LnConsumoAPI lnConsumoAPI;

        public LnHorario()
        {
            lnConsumoAPI = new LnConsumoAPI();
        }

        public async Task<Models.Horario.Salida.VerTodosHorarios> VerTodosHorarios(
            Models.Horario.Entrada.VerTodosHorarios pDatos, string token)
        {
            string encabezado = "Horario/VerTodosHorarios";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Horario.Salida.VerTodosHorarios>(respuesta);
        }

        public async Task<Models.Horario.Salida.VerDetalleHorario> VerDetalleHorario(
            Models.Horario.Entrada.VerDetalleHorario pDatos, string token)
        {
            string encabezado = "Horario/VerDetalleHorario";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Horario.Salida.VerDetalleHorario>(respuesta);
        }

        public async Task<Models.Horario.Salida.AgregarHorario> AgregarHorario(
         Models.Horario.Entrada.AgregarHorario pDatos, string token)
        {
            string encabezado = "Horario/AgregarHorario";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Horario.Salida.AgregarHorario>(respuesta);
        }

        public async Task<Models.Horario.Salida.EditarHorario> EditarHorario(
       Models.Horario.Entrada.EditarHorario pDatos, string token)
        {
            string encabezado = "Horario/EditarHorario";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Horario.Salida.EditarHorario>(respuesta);
        }

        public async Task<Models.Horario.Salida.EliminarHorario> EliminarHorario(
      Models.Horario.Entrada.EliminarHorario pDatos, string token)
        {
            string encabezado = "Horario/EliminarHorario";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Horario.Salida.EliminarHorario>(respuesta);
        }
    }
}