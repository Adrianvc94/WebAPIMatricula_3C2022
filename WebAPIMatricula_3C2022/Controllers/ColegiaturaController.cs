using API.Bll.Colegiatura.Interfaces;
using API.Bll.Colegiatura;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIMatricula_3C2022.Controllers
{
    [Route("api/v1/" + "[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class ColegiaturaController : Controller
    {
        private LnColegiatura oLnColegiatura;
        public ColegiaturaController(IAdColegiatura accesoAdColegiatura)
        {
            oLnColegiatura = new LnColegiatura(accesoAdColegiatura);
        }

        [HttpPost]
        [Route("AgregarColegiatura")]
        public IActionResult AgregarColegiatura([FromBody] API.Dto.Colegiatura.Entrada.AgregarColegiatura pDatos)
        {
            API.Dto.Colegiatura.Salida.AgregarColegiatura respuesta = new API.Dto.Colegiatura.Salida.AgregarColegiatura();

            try
            {
                respuesta = oLnColegiatura.AgregarColegiatura(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                return Ok(ex.Message);
            }
        }

        [HttpPost]
        [Route("VerTodosColegiaturas")]
        public IActionResult VerTodosColegiaturas(API.Dto.Colegiatura.Entrada.VerTodosColegiaturas pDatos)
        {
            API.Dto.Colegiatura.Salida.VerTodosColegiaturas respuesta = new API.Dto.Colegiatura.Salida.VerTodosColegiaturas();



            try
            {
                respuesta = oLnColegiatura.VerTodosColegiaturas(pDatos);
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
        [Route("EliminarColegiatura")]
        public IActionResult EliminarColegiatura([FromBody] API.Dto.Colegiatura.Entrada.EliminarColegiatura pDatos)
        {
            API.Dto.Colegiatura.Salida.EliminarColegiatura respuesta = new API.Dto.Colegiatura.Salida.EliminarColegiatura();



            try
            {
                respuesta = oLnColegiatura.EliminarColegiatura(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                return Ok(respuesta);
            }
        }




        [HttpPost]
        [Route("VerDetalleColegiatura")]
        public IActionResult VerDetalleColegiatura([FromBody] API.Dto.Colegiatura.Entrada.VerDetalleColegiatura pDatos)
        {
            API.Dto.Colegiatura.Salida.VerDetalleColegiatura respuesta = new API.Dto.Colegiatura.Salida.VerDetalleColegiatura();

            try
            {
                respuesta = oLnColegiatura.VerDetalleColegiatura(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                return Ok(respuesta);
            }
        }



        [HttpPost]
        [Route("EditarColegiatura")]
        public IActionResult EditarColegiatura([FromBody] API.Dto.Colegiatura.Entrada.EditarColegiatura pDatos)
        {
            API.Dto.Colegiatura.Salida.EditarColegiatura respuesta = new API.Dto.Colegiatura.Salida.EditarColegiatura();

            try
            {
                respuesta = oLnColegiatura.EditarColegiatura(pDatos);
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
