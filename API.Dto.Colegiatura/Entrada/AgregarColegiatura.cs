using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dto.Colegiatura.Entrada
{
    public class AgregarColegiatura : General.EntradaAPI
    {
        public string Nombre { get; set; }
        public string Facultad { get; set; }
        public string GradoAcademico { get; set; }
        public string Acreditada { get; set; }
    }
}
