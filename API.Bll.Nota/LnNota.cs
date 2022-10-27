using API.Bll.Nota.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Bll.Nota
{
    public class LnNota
    {

        private IAdNota adNota;

        public LnNota(IAdNota accesoDatosNota)
        {
            this.adNota = accesoDatosNota;
        }



        public API.Dto.Nota.Salida.VerTodasNotas VerTodasNotas(Dto.Nota.Entrada.VerTodasNotas pInformacion)
        {
            API.Dto.Nota.Salida.VerTodasNotas respuesta = new API.Dto.Nota.Salida.VerTodasNotas();

            try
            {
                respuesta = adNota.VerTodasNotas();
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }



        public Dto.Nota.Salida.VerDetalleNota VerDetalleNota(Dto.Nota.Entrada.VerDetalleNota pInformacion)
        {
            API.Dto.Nota.Salida.VerDetalleNota respuesta = new Dto.Nota.Salida.VerDetalleNota();



            try
            {
                respuesta = adNota.VerDetalleNota(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }



        public API.Dto.Nota.Salida.AgregarNota AgregarNota(Dto.Nota.Entrada.AgregarNota pInformacion)
        {
            API.Dto.Nota.Salida.AgregarNota respuesta = new API.Dto.Nota.Salida.AgregarNota();



            try
            {
                respuesta = adNota.AgregarNota(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }



        public Dto.Nota.Salida.EditarNota EditarNota(Dto.Nota.Entrada.EditarNota pInformacion)
        {
            API.Dto.Nota.Salida.EditarNota respuesta = new API.Dto.Nota.Salida.EditarNota();



            try
            {
                API.Dto.Nota.Entrada.VerDetalleNota entradaVerDetalleNota = new API.Dto.Nota.Entrada.VerDetalleNota();
                entradaVerDetalleNota.Codigo = pInformacion.Codigo;
                //API.Dto.Nota.Salida.VerDetalleNota detalleTrader = adNota.VerDetalleNota(entradaVerDetalleNota);



                respuesta = adNota.EditarNota(pInformacion);



            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }
        public Dto.Nota.Salida.EliminarNota EliminarNota(Dto.Nota.Entrada.EliminarNota pInformacion)
        {
            API.Dto.Nota.Salida.EliminarNota respuesta = new Dto.Nota.Salida.EliminarNota();



            try
            {
                respuesta = adNota.EliminarNota(pInformacion);



            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }

    }
}
