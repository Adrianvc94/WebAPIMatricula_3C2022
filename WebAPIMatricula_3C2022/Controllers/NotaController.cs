using API.Bll.Nota;
using API.Bll.Nota.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIMatricula_3C2022.Controllers
{
    [Route("api/v1/" + "[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class NotaController : Controller
    {
        private LnNota oLnNota;
        public NotaController(IAdNota accesoAdNota)
        {
            oLnNota = new LnNota(accesoAdNota);
        }

        [HttpPost]
        [Route("AgregarNota")]
        public IActionResult AgregarNota([FromBody] API.Dto.Nota.Entrada.AgregarNota pDatos)
        {
            API.Dto.Nota.Salida.AgregarNota respuesta = new API.Dto.Nota.Salida.AgregarNota();

            try
            {
                respuesta = oLnNota.AgregarNota(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                return Ok(ex.Message);
            }
        }

        [HttpPost]
        [Route("VerTodasNotas")]
        public IActionResult VerTodosNotas(API.Dto.Nota.Entrada.VerTodasNotas pDatos)
        {
            API.Dto.Nota.Salida.VerTodasNotas respuesta = new API.Dto.Nota.Salida.VerTodasNotas();



            try
            {
                respuesta = oLnNota.VerTodasNotas(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                //return StatusCode(StatusCodes.Status500InternalServerError, ex);
                return Ok(respuesta);
            }
        }

        [HttpPost]
        [Route("EliminarNota")]
        public IActionResult EliminarNota([FromBody] API.Dto.Nota.Entrada.EliminarNota pDatos)
        {
            API.Dto.Nota.Salida.EliminarNota respuesta = new API.Dto.Nota.Salida.EliminarNota();



            try
            {
                respuesta = oLnNota.EliminarNota(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                return Ok(respuesta);
            }
        }




        [HttpPost]
        [Route("VerDetalleNota")]
        public IActionResult VerDetalleNota([FromBody] API.Dto.Nota.Entrada.VerDetalleNota pDatos)
        {
            API.Dto.Nota.Salida.VerDetalleNota respuesta = new API.Dto.Nota.Salida.VerDetalleNota();

            try
            {
                respuesta = oLnNota.VerDetalleNota(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                return Ok(respuesta);
            }
        }



        [HttpPost]
        [Route("EditarNota")]
        public IActionResult EditarNota([FromBody] API.Dto.Nota.Entrada.EditarNota pDatos)
        {
            API.Dto.Nota.Salida.EditarNota respuesta = new API.Dto.Nota.Salida.EditarNota();

            try
            {
                respuesta = oLnNota.EditarNota(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                return Ok(respuesta);
            }
        }


    }
}
