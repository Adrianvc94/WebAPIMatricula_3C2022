using API.Bll.Horario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace API.Bll.Horario
{
    public class LnHorario
    {
        private IAdHorario adHorario;



        public LnHorario(IAdHorario accesoDatosHorario)
        {
            this.adHorario = accesoDatosHorario;
        }



        public API.Dto.Horario.Salida.VerTodosHorarios VerTodosHorarios(Dto.Horario.Entrada.VerTodosHorarios pInformacion)
        {
            API.Dto.Horario.Salida.VerTodosHorarios respuesta = new API.Dto.Horario.Salida.VerTodosHorarios();

            try
            {
                respuesta = adHorario.VerTodosHorarios();
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }



        public Dto.Horario.Salida.VerDetalleHorario VerDetalleHorario(Dto.Horario.Entrada.VerDetalleHorario pInformacion)
        {
            API.Dto.Horario.Salida.VerDetalleHorario respuesta = new Dto.Horario.Salida.VerDetalleHorario();



            try
            {
                respuesta = adHorario.VerDetalleHorario(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }



        public API.Dto.Horario.Salida.AgregarHorario AgregarHorario(Dto.Horario.Entrada.AgregarHorario pInformacion)
        {
            API.Dto.Horario.Salida.AgregarHorario respuesta = new API.Dto.Horario.Salida.AgregarHorario();



            try
            {
                respuesta = adHorario.AgregarHorario(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }



        public Dto.Horario.Salida.EditarHorario EditarHorario(Dto.Horario.Entrada.EditarHorario pInformacion)
        {
            API.Dto.Horario.Salida.EditarHorario respuesta = new API.Dto.Horario.Salida.EditarHorario();



            try
            {
                API.Dto.Horario.Entrada.VerDetalleHorario entradaVerDetalleHorario = new API.Dto.Horario.Entrada.VerDetalleHorario();
                entradaVerDetalleHorario.Codigo = pInformacion.Codigo;
                //API.Dto.Horario.Salida.VerDetalleHorario detalleTrader = adHorario.VerDetalleHorario(entradaVerDetalleHorario);



                respuesta = adHorario.EditarHorario(pInformacion);



            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }
        public Dto.Horario.Salida.EliminarHorario EliminarHorario(Dto.Horario.Entrada.EliminarHorario pInformacion)
        {
            API.Dto.Horario.Salida.EliminarHorario respuesta = new Dto.Horario.Salida.EliminarHorario();



            try
            {
                respuesta = adHorario.EliminarHorario(pInformacion);



            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }
    }
}