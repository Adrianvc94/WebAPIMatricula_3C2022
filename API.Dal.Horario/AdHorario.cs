using API.Bll.Horario.Interfaces;
using API.Dal.General;
using API.Dto.Horario.Salida;
using API.Dto.General;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace API.Dal.Horario
{
    public class AdHorario : IAdHorario
    {
        private ConexionManager manager;



        public AdHorario(IOptions<AppSettings> oConfiguraciones)
        {
            manager = new ConexionManager(oConfiguraciones);
        }



        public Dto.Horario.Salida.VerTodosHorarios VerTodosHorarios()
        {
            IDbConnection oConexion = null;
            API.Dto.Horario.Salida.VerTodosHorarios resultado = new API.Dto.Horario.Salida.VerTodosHorarios();



            oConexion = manager.GetConexion();
            oConexion.Open();
            IDbCommand oComando = manager.GetComando();



            try
            {
                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Ver_Todos_Horarios");



                DatosHorario dato;



                while (objDr.Read())
                {
                    dato = new DatosHorario();
                    dato.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    dato.Dia = objDr["Dia"].ToString();
                    dato.HoraInicio = objDr["HoraInicio"].ToString();
                    dato.HoraFin = objDr["HoraFin"].ToString();
                    dato.Sede = objDr["Sede"].ToString();
                    dato.Aula = objDr["Aula"].ToString();

                    resultado.ListaHorarios.Add(dato);
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



        public Dto.Horario.Salida.VerDetalleHorario VerDetalleHorario(Dto.Horario.Entrada.VerDetalleHorario pInformacion)
        {
            IDbConnection oConexion = null;
            API.Dto.Horario.Salida.VerDetalleHorario resultado = new API.Dto.Horario.Salida.VerDetalleHorario();



            oConexion = manager.GetConexion();
            oConexion.Open();
            IDbCommand oComando = manager.GetComando();



            try
            {
                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));
                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Ver_Detalle_Horario");



                if (objDr.Read())
                {
                    resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    resultado.Dia = objDr["Dia"].ToString();
                    resultado.HoraInicio = objDr["HoraInicio"].ToString();
                    resultado.HoraFin = objDr["HoraFin"].ToString();
                    resultado.Sede = objDr["Sede"].ToString();
                    resultado.Aula = objDr["Aula"].ToString();
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

        public Dto.Horario.Salida.AgregarHorario AgregarHorario(Dto.Horario.Entrada.AgregarHorario pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Horario.Salida.AgregarHorario resultado = new Dto.Horario.Salida.AgregarHorario();



            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();



                oComando.Parameters.Add(manager.GetParametro("@Dia", pInformacion.Dia));
                oComando.Parameters.Add(manager.GetParametro("@HoraInicio", pInformacion.HoraInicio));
                oComando.Parameters.Add(manager.GetParametro("@HoraFin", pInformacion.HoraFin));
                oComando.Parameters.Add(manager.GetParametro("@Sede", pInformacion.Sede));
                oComando.Parameters.Add(manager.GetParametro("@Aula", pInformacion.Aula));



                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Agregar_Horario");



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



        public Dto.Horario.Salida.EliminarHorario EliminarHorario(Dto.Horario.Entrada.EliminarHorario pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Horario.Salida.EliminarHorario resultado = new Dto.Horario.Salida.EliminarHorario();



            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();



                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));



                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Eliminar_Horario");
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

        public Dto.Horario.Salida.EditarHorario EditarHorario(Dto.Horario.Entrada.EditarHorario pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Horario.Salida.EditarHorario resultado = new Dto.Horario.Salida.EditarHorario();



            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();



                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));
                oComando.Parameters.Add(manager.GetParametro("@Dia", pInformacion.Dia));
                oComando.Parameters.Add(manager.GetParametro("@HoraInicio", pInformacion.HoraInicio));
                oComando.Parameters.Add(manager.GetParametro("@HoraFin", pInformacion.HoraFin));
                oComando.Parameters.Add(manager.GetParametro("@Sede", pInformacion.Sede));
                oComando.Parameters.Add(manager.GetParametro("@Aula", pInformacion.Aula));



                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Editar_Horario");



                if (objDr.Read())
                {
                    resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    resultado.Dia = objDr["Dia"].ToString();
                    resultado.HoraInicio = objDr["HoraInicio"].ToString();
                    resultado.HoraFin = objDr["HoraFin"].ToString();
                    resultado.Sede = objDr["Sede"].ToString();
                    resultado.Aula = objDr["Aula"].ToString();
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