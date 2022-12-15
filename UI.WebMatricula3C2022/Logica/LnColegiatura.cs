using Newtonsoft.Json;

namespace UI.WebMatricula3C2022.Logica
{
    public class LnColegiatura
    {

        LnConsumoAPI lnConsumoAPI;

        public LnColegiatura()
        {
            lnConsumoAPI = new LnConsumoAPI();
        }

        public async Task<Models.Colegiatura.Salida.VerTodosColegiaturas> VerTodosColegiaturas(
            Models.Colegiatura.Entrada.VerTodosColegiaturas pDatos, string token)
        {
            string encabezado = "Colegiatura/VerTodosColegiaturas";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Colegiatura.Salida.VerTodosColegiaturas>(respuesta);
        }

        public async Task<Models.Colegiatura.Salida.VerDetalleColegiatura> VerDetalleColegiatura(
            Models.Colegiatura.Entrada.VerDetalleColegiatura pDatos, string token)
        {
            string encabezado = "Colegiatura/VerDetalleColegiatura";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Colegiatura.Salida.VerDetalleColegiatura>(respuesta);
        }

        public async Task<Models.Colegiatura.Salida.AgregarColegiatura> AgregarColegiatura(
         Models.Colegiatura.Entrada.AgregarColegiatura pDatos, string token)
        {
            string encabezado = "Colegiatura/AgregarColegiatura";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Colegiatura.Salida.AgregarColegiatura>(respuesta);
        }

        public async Task<Models.Colegiatura.Salida.EditarColegiatura> EditarColegiatura(
       Models.Colegiatura.Entrada.EditarColegiatura pDatos, string token)
        {
            string encabezado = "Colegiatura/EditarColegiatura";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Colegiatura.Salida.EditarColegiatura>(respuesta);
        }

        public async Task<Models.Colegiatura.Salida.EliminarColegiatura> EliminarColegiatura(
      Models.Colegiatura.Entrada.EliminarColegiatura pDatos, string token)
        {
            string encabezado = "Colegiatura/EliminarColegiatura";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Colegiatura.Salida.EliminarColegiatura>(respuesta);
        }



    }
}
