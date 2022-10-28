using API.Bll.Horario.Interfaces;
using API.Bll.Horario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIMatricula_3C2022.Controllers
{
    [Route("api/v1/" + "[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class HorarioController : Controller
    {
        private LnHorario oLnHorario;
        public HorarioController(IAdHorario accesoAdHorario)
        {
            oLnHorario = new LnHorario(accesoAdHorario);
        }

        [HttpPost]
        [Route("AgregarHorario")]
        public IActionResult AgregarHorario([FromBody] API.Dto.Horario.Entrada.AgregarHorario pDatos)
        {
            API.Dto.Horario.Salida.AgregarHorario respuesta = new API.Dto.Horario.Salida.AgregarHorario();

            try
            {
                respuesta = oLnHorario.AgregarHorario(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                return Ok(ex.Message);
            }
        }

        [HttpPost]
        [Route("VerTodosHorarios")]
        public IActionResult VerTodosHorarios(API.Dto.Horario.Entrada.VerTodosHorarios pDatos)
        {
            API.Dto.Horario.Salida.VerTodosHorarios respuesta = new API.Dto.Horario.Salida.VerTodosHorarios();



            try
            {
                respuesta = oLnHorario.VerTodosHorarios(pDatos);
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
        [Route("EliminarHorario")]
        public IActionResult EliminarHorario([FromBody] API.Dto.Horario.Entrada.EliminarHorario pDatos)
        {
            API.Dto.Horario.Salida.EliminarHorario respuesta = new API.Dto.Horario.Salida.EliminarHorario();



            try
            {
                respuesta = oLnHorario.EliminarHorario(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                return Ok(respuesta);
            }
        }




        [HttpPost]
        [Route("VerDetalleHorario")]
        public IActionResult VerDetalleHorario([FromBody] API.Dto.Horario.Entrada.VerDetalleHorario pDatos)
        {
            API.Dto.Horario.Salida.VerDetalleHorario respuesta = new API.Dto.Horario.Salida.VerDetalleHorario();

            try
            {
                respuesta = oLnHorario.VerDetalleHorario(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                return Ok(respuesta);
            }
        }



        [HttpPost]
        [Route("EditarHorario")]
        public IActionResult EditarHorario([FromBody] API.Dto.Horario.Entrada.EditarHorario pDatos)
        {
            API.Dto.Horario.Salida.EditarHorario respuesta = new API.Dto.Horario.Salida.EditarHorario();

            try
            {
                respuesta = oLnHorario.EditarHorario(pDatos);
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
