using Newtonsoft.Json;

namespace UI.WebMatricula3C2022.Logica
{
    public class LnNota
    {

        LnConsumoAPI lnConsumoAPI;

        public LnNota()
        {
            lnConsumoAPI = new LnConsumoAPI();
        }

        public async Task<Models.Nota.Salida.VerTodosNotas> VerTodosNotas(
            Models.Nota.Entrada.VerTodosNotas pDatos, string token)
        {
            string encabezado = "Nota/VerTodosNotas";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Nota.Salida.VerTodosNotas>(respuesta);
        }

        public async Task<Models.Nota.Salida.VerDetalleNota> VerDetalleNota(
            Models.Nota.Entrada.VerDetalleNota pDatos, string token)
        {
            string encabezado = "Nota/VerDetalleNota";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Nota.Salida.VerDetalleNota>(respuesta);
        }

        public async Task<Models.Nota.Salida.AgregarNota> AgregarNota(
         Models.Nota.Entrada.AgregarNota pDatos, string token)
        {
            string encabezado = "Nota/AgregarNota";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Nota.Salida.AgregarNota>(respuesta);
        }

        public async Task<Models.Nota.Salida.EditarNota> EditarNota(
       Models.Nota.Entrada.EditarNota pDatos, string token)
        {
            string encabezado = "Nota/EditarNota";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Nota.Salida.EditarNota>(respuesta);
        }

        public async Task<Models.Nota.Salida.EliminarNota> EliminarNota(
      Models.Nota.Entrada.EliminarNota pDatos, string token)
        {
            string encabezado = "Nota/EliminarNota";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Nota.Salida.EliminarNota>(respuesta);
        }

    }
}
