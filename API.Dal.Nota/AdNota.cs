using API.Bll.Nota.Interfaces;
using API.Dal.General;
using API.Dto.General;
using API.Dto.Nota.Salida;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dal.Nota
{
    public class AdNota : IAdNota
    {

        private ConexionManager manager;

        public AdNota(IOptions<AppSettings> oConfiguraciones)
        {
            manager = new ConexionManager(oConfiguraciones);
        }



        public Dto.Nota.Salida.VerTodosNotas VerTodosNotas()
        {
            IDbConnection oConexion = null;
            API.Dto.Nota.Salida.VerTodosNotas resultado = new API.Dto.Nota.Salida.VerTodosNotas();



            oConexion = manager.GetConexion();
            oConexion.Open();
            IDbCommand oComando = manager.GetComando();



            try
            {
                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Ver_Todas_Notas");



                DatosNotas dato;



                while (objDr.Read())
                {
                    dato = new DatosNotas();
                    dato.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    dato.CodigoCurso = Convert.ToInt32(objDr["CodigoCurso"].ToString());
                    dato.CodigoEstudiante = Convert.ToInt32(objDr["CodigoEstudiante"].ToString());
                    dato.CodigoProfesor = Convert.ToInt32(objDr["CodigoProfesor"].ToString());
                    dato.Nota = Convert.ToDecimal(objDr["Nota"].ToString());
                    dato.Estado = objDr["Estado"].ToString();


                    resultado.ListaNotas.Add(dato);
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



        public Dto.Nota.Salida.VerDetalleNota VerDetalleNota(Dto.Nota.Entrada.VerDetalleNota pInformacion)
        {
            IDbConnection oConexion = null;
            API.Dto.Nota.Salida.VerDetalleNota resultado = new API.Dto.Nota.Salida.VerDetalleNota();



            oConexion = manager.GetConexion();
            oConexion.Open();
            IDbCommand oComando = manager.GetComando();



            try
            {
                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));
                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Ver_Detalle_Nota");



                if (objDr.Read())
                {
                    resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    resultado.CodigoCurso = Convert.ToInt32(objDr["CodigoCurso"].ToString());
                    resultado.CodigoEstudiante = Convert.ToInt32(objDr["CodigoEstudiante"].ToString());
                    resultado.CodigoProfesor = Convert.ToInt32(objDr["CodigoProfesor"].ToString());
                    resultado.Nota = Convert.ToDecimal(objDr["Nota"].ToString());
                    resultado.Estado = objDr["Estado"].ToString();


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

        public Dto.Nota.Salida.AgregarNota AgregarNota(Dto.Nota.Entrada.AgregarNota pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Nota.Salida.AgregarNota resultado = new Dto.Nota.Salida.AgregarNota();



            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();



                oComando.Parameters.Add(manager.GetParametro("@CodigoCurso", pInformacion.CodigoCurso));
                oComando.Parameters.Add(manager.GetParametro("@CodigoEstudiante", pInformacion.CodigoEstudiante));
                oComando.Parameters.Add(manager.GetParametro("@CodigoProfesor", pInformacion.CodigoProfesor));
                oComando.Parameters.Add(manager.GetParametro("@Nota", pInformacion.Nota));
                oComando.Parameters.Add(manager.GetParametro("@Estado", pInformacion.Estado));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Agregar_Nota");




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



        public Dto.Nota.Salida.EliminarNota EliminarNota(Dto.Nota.Entrada.EliminarNota pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Nota.Salida.EliminarNota resultado = new Dto.Nota.Salida.EliminarNota();



            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();



                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));



                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Eliminar_Nota");
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

        public Dto.Nota.Salida.EditarNota EditarNota(Dto.Nota.Entrada.EditarNota pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Nota.Salida.EditarNota resultado = new Dto.Nota.Salida.EditarNota();



            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));
                oComando.Parameters.Add(manager.GetParametro("@CodigoCurso", pInformacion.CodigoCurso));
                oComando.Parameters.Add(manager.GetParametro("@CodigoEstudiante", pInformacion.CodigoEstudiante));
                oComando.Parameters.Add(manager.GetParametro("@CodigoProfesor", pInformacion.CodigoProfesor));
                oComando.Parameters.Add(manager.GetParametro("@Nota", pInformacion.Nota));
                oComando.Parameters.Add(manager.GetParametro("@Estado", pInformacion.Estado));



                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Editar_Nota");



                if (objDr.Read())
                {
                    resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    resultado.CodigoCurso = Convert.ToInt32(objDr["CodigoCurso"].ToString());
                    resultado.CodigoEstudiante = Convert.ToInt32(objDr["CodigoEstudiante"].ToString());
                    resultado.CodigoProfesor = Convert.ToInt32(objDr["CodigoProfesor"].ToString());
                    resultado.Nota = Convert.ToDecimal(objDr["Nota"].ToString());
                    resultado.Estado = objDr["Estado"].ToString();
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
