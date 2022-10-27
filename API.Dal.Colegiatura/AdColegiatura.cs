using API.Bll.Colegiatura.Interfaces;
using API.Dal.General;
using API.Dto.Colegiatura.Salida;
using API.Dto.General;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dal.Colegiatura
{
    public class AdColegiatura : IAdColegiatura
    {
        private ConexionManager manager;

        public AdColegiatura(IOptions<AppSettings> oConfiguraciones)
        {
            manager = new ConexionManager(oConfiguraciones);
        }



        public Dto.Colegiatura.Salida.VerTodosColegiaturas VerTodosColegiaturas()
        {
            IDbConnection oConexion = null;
            API.Dto.Colegiatura.Salida.VerTodosColegiaturas resultado = new API.Dto.Colegiatura.Salida.VerTodosColegiaturas();



            oConexion = manager.GetConexion();
            oConexion.Open();
            IDbCommand oComando = manager.GetComando();



            try
            {
                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Ver_Todas_Colegiaturas");



                DatosColegiaturas dato;

                while (objDr.Read())
                {
                    dato = new DatosColegiaturas();
                    dato.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    dato.Nombre = objDr["Nombre"].ToString();
                    dato.Facultad = objDr["Facultad"].ToString();
                    dato.GradoAcademico = objDr["GradoAcademico"].ToString();
                    dato.Acreditada = objDr["Acreditada"].ToString();

                    resultado.ListaColegiaturas.Add(dato);
                }
            }
            catch (Exception)
            {
                manager.CerrarConexion(oConexion);
            }
            finally
            {
                manager.CerrarConexion(oConexion);
            }



            return resultado;
        }



        public Dto.Colegiatura.Salida.VerDetalleColegiatura VerDetalleColegiatura(Dto.Colegiatura.Entrada.VerDetalleColegiatura pInformacion)
        {
            IDbConnection oConexion = null;
            API.Dto.Colegiatura.Salida.VerDetalleColegiatura resultado = new API.Dto.Colegiatura.Salida.VerDetalleColegiatura();



            oConexion = manager.GetConexion();
            oConexion.Open();
            IDbCommand oComando = manager.GetComando();



            try
            {
                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));
                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Ver_Detalle_Colegiatura");



                if (objDr.Read())
                {
                    resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    resultado.Nombre = objDr["Nombre"].ToString();
                    resultado.Facultad = objDr["Facultad"].ToString();
                    resultado.GradoAcademico = objDr["GradoAcademico"].ToString();
                    resultado.Acreditada = objDr["Acreditada"].ToString();

                }
            }
            catch (Exception)
            {
                manager.CerrarConexion(oConexion);
            }
            finally
            {
                manager.CerrarConexion(oConexion);
            }



            return resultado;
        }

        public Dto.Colegiatura.Salida.AgregarColegiatura AgregarColegiatura(Dto.Colegiatura.Entrada.AgregarColegiatura pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Colegiatura.Salida.AgregarColegiatura resultado = new Dto.Colegiatura.Salida.AgregarColegiatura();



            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();



                oComando.Parameters.Add(manager.GetParametro("@Nombre", pInformacion.Nombre));
                oComando.Parameters.Add(manager.GetParametro("@Facultad", pInformacion.Facultad));
                oComando.Parameters.Add(manager.GetParametro("@GradoAcademico", pInformacion.GradoAcademico));
                oComando.Parameters.Add(manager.GetParametro("@Acreditada", pInformacion.Acreditada));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Agregar_Colegiatura");


                if (objDr.Read())
                    resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());



            }
            catch (Exception ex)
            {
                resultado.DetalleRespuesta = ex.Message;
                manager.CerrarConexion(oConexion);
            }
            finally
            {
                manager.CerrarConexion(oConexion);
            }



            return resultado;
        }



        public Dto.Colegiatura.Salida.EliminarColegiatura EliminarColegiatura(Dto.Colegiatura.Entrada.EliminarColegiatura pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Colegiatura.Salida.EliminarColegiatura resultado = new Dto.Colegiatura.Salida.EliminarColegiatura();



            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();



                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));



                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Eliminar_Colegiatura");
            }
            catch (Exception ex)
            {
                resultado.DetalleRespuesta = ex.Message;
                manager.CerrarConexion(oConexion);
            }
            finally
            {
                manager.CerrarConexion(oConexion);
            }



            return resultado;
        }

        public Dto.Colegiatura.Salida.EditarColegiatura EditarColegiatura(Dto.Colegiatura.Entrada.EditarColegiatura pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Colegiatura.Salida.EditarColegiatura resultado = new Dto.Colegiatura.Salida.EditarColegiatura();

            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));
                oComando.Parameters.Add(manager.GetParametro("@Nombre", pInformacion.Nombre));
                oComando.Parameters.Add(manager.GetParametro("@Facultad", pInformacion.Facultad));
                oComando.Parameters.Add(manager.GetParametro("@GradoAcademico", pInformacion.GradoAcademico));
                oComando.Parameters.Add(manager.GetParametro("@Acreditada", pInformacion.Acreditada));


                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Editar_Colegiatura");



                if (objDr.Read())
                {
                    resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    resultado.Nombre = objDr["Nombre"].ToString();
                    resultado.Facultad = objDr["Facultad"].ToString();
                    resultado.GradoAcademico = objDr["GradoAcademico"].ToString();
                    resultado.Acreditada = objDr["Acreditada"].ToString();

                }



            }
            catch (Exception ex)
            {
                resultado.DetalleRespuesta = ex.Message;
                manager.CerrarConexion(oConexion);
            }
            finally
            {
                manager.CerrarConexion(oConexion);
            }



            return resultado;
        }
    }
}
