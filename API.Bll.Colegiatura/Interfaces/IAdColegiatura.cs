using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Bll.Colegiatura.Interfaces
{
    public interface IAdColegiatura
    {
        API.Dto.Colegiatura.Salida.VerTodosColegiaturas VerTodosColegiaturas();
        API.Dto.Colegiatura.Salida.VerDetalleColegiatura VerDetalleColegiatura(API.Dto.Colegiatura.Entrada.VerDetalleColegiatura pInformacion);
        API.Dto.Colegiatura.Salida.AgregarColegiatura AgregarColegiatura(API.Dto.Colegiatura.Entrada.AgregarColegiatura pInformacion);
        API.Dto.Colegiatura.Salida.EditarColegiatura EditarColegiatura(API.Dto.Colegiatura.Entrada.EditarColegiatura pInformacion);
        API.Dto.Colegiatura.Salida.EliminarColegiatura EliminarColegiatura(API.Dto.Colegiatura.Entrada.EliminarColegiatura pInformacion);
    }
}
