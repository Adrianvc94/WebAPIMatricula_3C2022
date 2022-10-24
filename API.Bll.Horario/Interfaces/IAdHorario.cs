using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Bll.Horario.Interfaces
{
    public interface IAdHorario
    {
        API.Dto.Horario.Salida.VerTodosHorarios VerTodosHorarios();
        API.Dto.Horario.Salida.VerDetalleHorario VerDetalleHorario(API.Dto.Horario.Entrada.VerDetalleHorario pInformacion);
        API.Dto.Horario.Salida.AgregarHorario AgregarHorario(API.Dto.Horario.Entrada.AgregarHorario pInformacion);
        API.Dto.Horario.Salida.EditarHorario EditarHorario(API.Dto.Horario.Entrada.EditarHorario pInformacion);
        API.Dto.Horario.Salida.EliminarHorario EliminarHorario(API.Dto.Horario.Entrada.EliminarHorario pInformacion);
    }
}
