using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Bll.Nota.Interfaces
{
    public interface IAdNota
    {
        API.Dto.Nota.Salida.VerTodosNotas VerTodosNotas();
        API.Dto.Nota.Salida.VerDetalleNota VerDetalleNota(API.Dto.Nota.Entrada.VerDetalleNota pInformacion);
        API.Dto.Nota.Salida.AgregarNota AgregarNota(API.Dto.Nota.Entrada.AgregarNota pInformacion);
        API.Dto.Nota.Salida.EditarNota EditarNota(API.Dto.Nota.Entrada.EditarNota pInformacion);
        API.Dto.Nota.Salida.EliminarNota EliminarNota(API.Dto.Nota.Entrada.EliminarNota pInformacion);
    }
}
