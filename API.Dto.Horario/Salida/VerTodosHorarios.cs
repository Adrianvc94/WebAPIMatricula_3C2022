using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace API.Dto.Horario.Salida
{
    public class VerTodosHorarios : Dto.General.RespuestaAPI
    {
        public List<DatosHorario> ListaHorarios { get; set; }



        public VerTodosHorarios()
        {
            ListaHorarios = new List<DatosHorario>();
        }
    }



    public class DatosHorario
    {
        public int Codigo { get; set; }
        public string Dia { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public string Sede { get; set; }
        public string Aula { get; set; }
    }
}