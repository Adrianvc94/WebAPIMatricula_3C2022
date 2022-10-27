using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dto.Nota.Entrada
{
    public class AgregarNota : General.EntradaAPI
    {
        public int CodigoCurso { get; set; }
        public int CodigoEstudiante { get; set; }
        public int CodigoProfesor { get; set; }
        public decimal Nota { get; set; }
        public string Estado { get; set; }
    }
}
