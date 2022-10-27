using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dto.Horario.Entrada
{
    public class AgregarHorario : General.EntradaAPI
    {
        public string Dia { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public string Sede { get; set; }
        public string Aula { get; set; }
    }
}
