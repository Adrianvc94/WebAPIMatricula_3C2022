using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dto.Nota.Salida
{
    public class VerTodosNotas : General.RespuestaAPI
    {
        public List<DatosNotas> ListaNotas { get; set; }

        public VerTodosNotas()
        {
            ListaNotas = new List<DatosNotas>();
        }

    }

    public class DatosNotas
    {
        public int Codigo { get; set; }
        public int CodigoCurso { get; set; }
        public int CodigoEstudiante { get; set; }
        public int CodigoProfesor { get; set; }
        public decimal Nota { get; set; }
        public string Estado { get; set; }
    }

}
