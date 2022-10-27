using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dto.Colegiatura.Salida
{
    public class EditarColegiatura : General.RespuestaAPI
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Facultad { get; set; }
        public string GradoAcademico { get; set; }
        public string Acreditada { get; set; }
    }
}
