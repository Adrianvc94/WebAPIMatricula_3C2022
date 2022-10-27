using API.Bll.Colegiatura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Bll.Colegiatura
{
    public class LnColegiatura
    {

        private IAdColegiatura adColegiatura;

        public LnColegiatura(IAdColegiatura accesoDatosColegiatura)
        {
            this.adColegiatura = accesoDatosColegiatura;
        }



        public API.Dto.Colegiatura.Salida.VerTodasColegiaturas VerTodasColegiaturas(Dto.Colegiatura.Entrada.VerTodasColegiaturas pInformacion)
        {
            API.Dto.Colegiatura.Salida.VerTodasColegiaturas respuesta = new API.Dto.Colegiatura.Salida.VerTodasColegiaturas();

            try
            {
                respuesta = adColegiatura.VerTodasColegiaturas();
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }



        public Dto.Colegiatura.Salida.VerDetalleColegiatura VerDetalleColegiatura(Dto.Colegiatura.Entrada.VerDetalleColegiatura pInformacion)
        {
            API.Dto.Colegiatura.Salida.VerDetalleColegiatura respuesta = new Dto.Colegiatura.Salida.VerDetalleColegiatura();



            try
            {
                respuesta = adColegiatura.VerDetalleColegiatura(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }



        public API.Dto.Colegiatura.Salida.AgregarColegiatura AgregarColegiatura(Dto.Colegiatura.Entrada.AgregarColegiatura pInformacion)
        {
            API.Dto.Colegiatura.Salida.AgregarColegiatura respuesta = new API.Dto.Colegiatura.Salida.AgregarColegiatura();



            try
            {
                respuesta = adColegiatura.AgregarColegiatura(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }



        public Dto.Colegiatura.Salida.EditarColegiatura EditarColegiatura(Dto.Colegiatura.Entrada.EditarColegiatura pInformacion)
        {
            API.Dto.Colegiatura.Salida.EditarColegiatura respuesta = new API.Dto.Colegiatura.Salida.EditarColegiatura();



            try
            {
                API.Dto.Colegiatura.Entrada.VerDetalleColegiatura entradaVerDetalleColegiatura = new API.Dto.Colegiatura.Entrada.VerDetalleColegiatura();
                entradaVerDetalleColegiatura.Codigo = pInformacion.Codigo;
                //API.Dto.Colegiatura.Salida.VerDetalleColegiatura detalleTrader = adColegiatura.VerDetalleColegiatura(entradaVerDetalleColegiatura);



                respuesta = adColegiatura.EditarColegiatura(pInformacion);



            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }
        public Dto.Colegiatura.Salida.EliminarColegiatura EliminarColegiatura(Dto.Colegiatura.Entrada.EliminarColegiatura pInformacion)
        {
            API.Dto.Colegiatura.Salida.EliminarColegiatura respuesta = new Dto.Colegiatura.Salida.EliminarColegiatura();



            try
            {
                respuesta = adColegiatura.EliminarColegiatura(pInformacion);



            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }


    }
}
