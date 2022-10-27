using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dto.Colegiatura.Salida
{
    public class VerTodasColegiaturas : General.RespuestaAPI
    {
        public List<DatosColegiaturas> ListaColegiaturas { get; set; }

        public VerTodasColegiaturas()
        {
            ListaColegiaturas = new List<DatosColegiaturas>();
        }
    }

    public class DatosColegiaturas
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Facultad { get; set; }
        public string GradoAcademico { get; set; }
        public string Acreditada { get; set; }
    }
}
